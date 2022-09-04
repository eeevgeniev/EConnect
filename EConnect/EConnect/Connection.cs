using EConnect.Interfaces;
using EConnect.ParserFactories;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace EConnect
{
    /// <summary>
    /// Base class for executing SQL queries.
    /// Implements IConnection where Conn Is DbConnection and has empty constructor.
    /// </summary>
    /// <typeparam name="Conn">DbConnection</typeparam>
    public class Connection<Conn> : IConnection<Conn>
        where Conn : DbConnection, new()
    {
        private const string AGGREGATE_EXCEPTION_MESSAGE = "Rollback exception happened. Check the inner exceptions for more information. The first is the original exception, the second is the rollback exception.";
        private const string GENERAL_EXCEPTION_MESSAGE = "General error. Check the inner exceptions for more information";

        private static ConcurrentDictionary<Type, IBaseParser> _parsersByType = new ConcurrentDictionary<Type, IBaseParser>();

        private bool _isDisposed = false;

        private bool _useTransaction = false;
        private IsolationLevel? _isolationLevel = null;
        private int? _timeout = null;

        private DbConnection _dbConnection;
        private DbCommand _dbCommand;
        private int _defaultTimeout;

        private bool _isTransactionCommited = false;

        private IParserFactory _parserFactory;

        /// <summary>
        /// Constructor creates new instance of Connection.
        /// </summary>
        /// <param name="connectionString">String - SQL connection string.</param>
        /// <param name="useTransaction">Boolean - default false, to use transaction. Commited either by calling CommitTransaction method or Dispose method.</param>
        /// <param name="isolationLevel">Optional - the isolation level of the transaction.</param>
        /// <param name="timeout">Default null, Optional. If not set it will use the default value for the specific DbConnection implementation.</param>
        public Connection(string connectionString, bool useTransaction = false, IsolationLevel? isolationLevel = null, int? timeout = null)
            : this(new BaseParserFactory(), connectionString, useTransaction, isolationLevel, timeout) { }

        /// <summary>
        /// Constructor creates new instance of Connection.
        /// </summary>
        /// <param name="parserFactory">Gives option to use custom parserFactory. Cannot be null.</param>
        /// <param name="connectionString">String - SQL connection string. Cannot be null or white space.</param>
        /// <param name="useTransaction">Boolean - default false, to use transaction. Commited either by calling CommitTransaction method or Dispose method.</param>
        /// <param name="isolationLevel">Optional - the isolation level of the transaction.</param>
        /// <param name="timeout">Default null, Optional. If not set it will use the default value for the specific DbConnection implementation.</param>
        /// <exception cref="ArgumentException">If connection string is null or white space.</exception>
        /// <exception cref="ArgumentNullException">If parserFactory is null.</exception>
        public Connection(IParserFactory parserFactory, string connectionString, bool useTransaction = false, IsolationLevel? isolationLevel = null, int? timeout = null)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentException($"Parameter {nameof(connectionString)} cannot be null or white space.");
            }

            if (parserFactory == null)
            {
                throw new ArgumentNullException($"Parameter {nameof(parserFactory)} cannot be null.");
            }

            this._dbConnection = new Conn();
            this._dbConnection.ConnectionString = connectionString;
            this._useTransaction = useTransaction;
            this._isolationLevel = isolationLevel;
            this._timeout = timeout;

            this._parserFactory = parserFactory;
        }

        /// <summary>
        /// Adds custom parser for specific type to the cache.
        /// </summary>
        /// <typeparam name="TModel">The type for which the parser is used.</typeparam>
        /// <param name="parser">Custom parser for specific type. Cannot be default.</param>
        /// <exception cref="ArgumentNullException">Throws ArgumentNullException if the argument parser is default.</exception>
        public static void AddOrUpdateParser<TModel>(IParser<TModel> parser)
        {
            if (parser == default)
            {
                throw new ArgumentNullException($"Parameter {nameof(parser)} is null.");
            }

            _parsersByType.AddOrUpdate(typeof(TModel), parser, (key, value) => parser);
        }

        /// <summary>
        /// Clears all parsers from the cache.
        /// </summary>
        public static void ClearAllParsers() => _parsersByType.Clear();

        /// <summary>
        /// Adds custom parser for specific type to the cache.
        /// Calls AddOrUpdateParser/
        /// </summary>
        /// <typeparam name="TModel">The type for which the parser is used.</typeparam>
        /// <param name="parser">Custom parser for specific type. Cannot be default.</param>
        /// <exception cref="ArgumentNullException">Throws ArgumentNullException if the argument parser is default.</exception>
        public void AddParserOrUpdate<TModel>(IParser<TModel> parser) => AddOrUpdateParser<TModel>(parser);

        /// <summary>
        /// Clears all parsers from the cache.
        /// Calls ClearAllParsers.
        /// </summary>
        public void ClearParsers() => ClearAllParsers();

        /// <summary>
        /// Commits sql transaction if any.
        /// </summary>
        /// <exception cref="AggregateException">Throws only if the rollback is unsaccessfull. It will contain two exceptions: the original exception and the rollback exception.</exception>
        /// <exception cref="Exception">Throwed if exception occured. The inner exception is the original exception. The rollback is successfull.</exception>
        public void CommitTransaction()
        {
            try
            {
                if (this._dbCommand != null && this._dbCommand.Transaction != null && this._isTransactionCommited == false)
                {
                    this._dbCommand.Transaction.Commit();
                    this._isTransactionCommited = true;
                }
            }
            catch (Exception ex)
            {
                if (this._dbCommand != null && this._dbCommand.Transaction != null && this._isTransactionCommited == false)
                {
                    try
                    {
                        this._dbCommand.Transaction.Rollback();
                    }
                    catch (Exception rollbackEx)
                    {
                        throw new AggregateException(AGGREGATE_EXCEPTION_MESSAGE, ex, rollbackEx);
                    }
                }

                throw new Exception(GENERAL_EXCEPTION_MESSAGE, ex);
            }
        }

        /// <summary>
        /// Disposes resouces, also commits sql transaction (CommitTransaction method.) if any.
        /// </summary>
        public void Dispose()
        {
            if (!this._isDisposed)
            {
                this._isDisposed = !this._isDisposed;

                if (this._dbCommand != null)
                {
                    this.CommitTransaction();
                }

                if (this._dbCommand != null)
                {
                    this._dbCommand.Dispose();
                    this._dbCommand = null;
                }

                if (this._dbConnection != null)
                {
                    this._dbConnection.Dispose();
                    this._dbConnection = null;
                }

                this._parserFactory = null;
            }
        }

        /// <summary>
        /// Executes non query sql command which returns Integer.
        /// </summary>
        /// <param name="query">The sql command.</param>
        /// <param name="parameters">Collection of SqlEParameter.</param>
        /// <param name="isStoredProcedure">Boolean to use stored procedure.</param>
        /// <param name="prepareCommand">Boolean to prepare command (Creates a prepared (or compiled) version of the command on the data source).</param>
        /// <returns>Integer</returns>
        public int NonQuery(string query,
            IEnumerable<SqlEParameter> parameters,
            bool isStoredProcedure = false,
            bool prepareCommand = false) =>
            this.ExecuteNonQuery(query, parameters, isStoredProcedure, prepareCommand);

        /// <summary>
        /// Executes non query sql command which returns Task of Integer.
        /// </summary>
        /// <param name="query">The sql command.</param>
        /// <param name="parameters">Collection of SqlEParameter.</param>
        /// <param name="isStoredProcedure">Boolean to use stored procedure.</param>
        /// <param name="prepareCommand">Boolean to prepare command (Creates a prepared (or compiled) version of the command on the data source).</param>
        /// <returns>Task where the result is Integer.</returns>
        public async Task<int> NonQueryAsync(string query,
            IEnumerable<SqlEParameter> parameters,
            bool isStoredProcedure = false,
            bool prepareCommand = false) =>
            await this.ExecuteNonQueryAsync(query, parameters, isStoredProcedure, prepareCommand);

        /// <summary>
        /// Executes query command which returns List of TModel Objects.
        /// </summary>
        /// <typeparam name="TModel">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <param name="query">The sql command.</param>
        /// <param name="parameters">Collection of SqlEParameter.</param>
        /// <param name="isStoredProcedure">Boolean to use stored procedure.</param>
        /// <param name="prepareCommand">Boolean to prepare command (Creates a prepared (or compiled) version of the command on the data source).</param>
        /// <returns>List of Objects of type TModel.</returns>
        public List<TModel> Query<TModel>(string query,
            IEnumerable<SqlEParameter> parameters,
            bool isStoredProcedure = false,
            bool prepareCommand = false) =>
            this.ExecuteQuery<TModel>(query, parameters, isStoredProcedure, prepareCommand);

        /// <summary>
        /// Executes query command which returns Dictionary where the key is String and the value is Object.
        /// </summary>
        /// <param name="query">The sql command.</param>
        /// <param name="parameters">Collection of SqlEParameter.</param>
        /// <param name="isStoredProcedure">Boolean to use stored procedure.</param>
        /// <param name="prepareCommand">Boolean to prepare command (Creates a prepared (or compiled) version of the command on the data source).</param>
        /// <returns>List of Dictionaries where the key is String and the value is Object.</returns>
        public List<Dictionary<string, object>> Query(string query,
            IEnumerable<SqlEParameter> parameters,
            bool isStoredProcedure = false,
            bool prepareCommand = false) =>
            this.ExecuteQuery<Dictionary<string, object>>(query, parameters, isStoredProcedure, prepareCommand);

        /// <summary>
        /// Executes query command which returns Task of List of TModel objects.
        /// </summary>
        /// <typeparam name="TModel">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <param name="query">The sql command.</param>
        /// <param name="parameters">Collection of SqlEParameter.</param>
        /// <param name="isStoredProcedure">Boolean to use stored procedure.</param>
        /// <param name="prepareCommand">Boolean to prepare command (Creates a prepared (or compiled) version of the command on the data source).</param>
        /// <returns>Task where the result is List of Objects of type TModel.</returns>
        public async Task<List<TModel>> QueryAsync<TModel>(string query,
            IEnumerable<SqlEParameter> parameters,
            bool isStoredProcedure = false,
            bool prepareCommand = false) =>
            await this.ExecuteQueryAsync<TModel>(query, parameters, isStoredProcedure, prepareCommand);

        /// <summary>
        /// Executes query command which returns Dictionary where the key is string and the value is object.
        /// </summary>
        /// <param name="query">The sql command.</param>
        /// <param name="parameters">Collection of SqlEParameter.</param>
        /// <param name="isStoredProcedure">Boolean to use stored procedure.</param>
        /// <param name="prepareCommand">Boolean to prepare command (Creates a prepared (or compiled) version of the command on the data source).</param>
        /// <returns>Task where the result is Dictionary where the key is String and the value is Object.</returns>
        public async Task<List<Dictionary<string, object>>> QueryAsync(string query,
            IEnumerable<SqlEParameter> parameters,
            bool isStoredProcedure = false,
            bool prepareCommand = false) =>
            await this.ExecuteQueryAsync<Dictionary<string, object>>(query, parameters, isStoredProcedure, prepareCommand);

        /// <summary>
        /// Returns Tuple with two values: hasResult if the query has returned result and result the returned value, if hasResult is false the result is default.
        /// This is for queries which returns single result.
        /// </summary>
        /// <typeparam name="TModel">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <param name="query">The sql command.</param>
        /// <param name="parameters">Collection of SqlEParameter.</param>
        /// <param name="isStoredProcedure">Boolean to use stored procedure.</param>
        /// <param name="prepareCommand">Boolean to prepare command (Creates a prepared (or compiled) version of the command on the data source).</param>
        /// <returns>Tuple with two values: hasResult if there is a result of the sql query and result, which is the result of the sql query. If hasResult is false result is equal to default.</returns>
        public (bool hasResult, TModel result) Single<TModel>(string query,
            IEnumerable<SqlEParameter> parameters,
            bool isStoredProcedure = false,
            bool prepareCommand = false) =>
            this.ExecuteSingle<TModel>(query, parameters, isStoredProcedure, prepareCommand);

        /// <summary>
        /// Returns Task where the result is Tuple with two values: hasResult if the query has returned result and result the returned value, if hasResult is false the result is default.
        /// This is for queries which returns single result.
        /// </summary>
        /// <typeparam name="TModel">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <param name="query">The sql command.</param>
        /// <param name="parameters">Collection of SqlEParameter.</param>
        /// <param name="isStoredProcedure">Boolean to use stored procedure.</param>
        /// <param name="prepareCommand">Boolean to prepare command (Creates a prepared (or compiled) version of the command on the data source).</param>
        /// <returns>Task where the result is Tuple with two values: hasResult if there is a result of the sql query and result, which is the result of the sql query. If hasResult is false result is equal to default.</returns>
        public async Task<(bool hasResult, TModel result)> SingleAsync<TModel>(string query,
            IEnumerable<SqlEParameter> parameters,
            bool isStoredProcedure = false,
            bool prepareCommand = false) =>
            await this.ExecuteSingleAsync<TModel>(query, parameters, isStoredProcedure, prepareCommand);

        /// <summary>
        /// Returns Tuple with two values: hasResult if the query has returned result and result of type Dictionary where the key is String and the Value is object which holds the returned values, if hasResult is false the result is default.
        /// This is for queries which returns single result.
        /// </summary>
        /// <param name="query">The sql command.</param>
        /// <param name="parameters">Collection of SqlEParameter.</param>
        /// <param name="isStoredProcedure">Boolean to use stored procedure.</param>
        /// <param name="prepareCommand">Boolean to prepare command (Creates a prepared (or compiled) version of the command on the data source).</param>
        /// <returns>Tuple with two values: hasResult if there is a result of the sql query and result of type Dictionary where the key is String and the Value is object which holds the returned values. If hasResult is false result is equal to default.</returns>
        public (bool hasResult, Dictionary<string, object>) Single(string query,
            IEnumerable<SqlEParameter> parameters,
            bool isStoredProcedure = false,
            bool prepareCommand = false) =>
            this.ExecuteSingle<Dictionary<string, object>>(query, parameters, isStoredProcedure, prepareCommand);

        /// <summary>
        /// Returns Task where the result is Tuple with two values: hasResult if the query has returned result and result of type Dictionary where the key is String and the Value is object which holds the returned values, if hasResult is false the result is default.
        /// This is for queries which returns single result.
        /// </summary>
        /// <param name="query">The sql command.</param>
        /// <param name="parameters">Collection of SqlEParameter.</param>
        /// <param name="isStoredProcedure">Boolean to use stored procedure.</param>
        /// <param name="prepareCommand">Boolean to prepare command (Creates a prepared (or compiled) version of the command on the data source).</param>
        /// <returns>Task where the result is Tuple with two values: hasResult if there is a result of the sql query and result of type Dictionary where the key is String and the Value is object which holds the returned values. If hasResult is false result is equal to default.</returns>
        public async Task<(bool hasResult, Dictionary<string, object>)> SingleAsync(string query,
            IEnumerable<SqlEParameter> parameters,
            bool isStoredProcedure = false,
            bool prepareCommand = false) =>
            await this.ExecuteSingleAsync<Dictionary<string, object>>(query, parameters, isStoredProcedure, prepareCommand);

        /// <summary>
        /// Returns two results from single query. The result is Tuple with two Lists - first where the results are of type TFirst and second where the results are of type TSecond.
        /// </summary>
        /// <typeparam name="TFirst">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TSecond">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <param name="query">The sql command.</param>
        /// <param name="parameters">Collection of SqlEParameter.</param>
        /// <param name="isStoredProcedure">Boolean to use stored procedure.</param>
        /// <param name="prepareCommand">Boolean to prepare command (Creates a prepared (or compiled) version of the command on the data source).</param>
        /// <returns>Tuple with two Lists - first where the results are of type TFirst and second where the results are of type TSecond.</returns>
        public (List<TFirst> first, List<TSecond> second) QueryMultiple<TFirst, TSecond>(string query,
            IEnumerable<SqlEParameter> parameters,
            bool isStoredProcedure = false,
            bool prepareCommand = false)
        {
            try
            {
                CheckIfObjectIsDisposed();

                this.PrepareConnectionAndCommand(query, parameters, isStoredProcedure, prepareCommand);

                (List<TFirst> first, List<TSecond> second) result = default;

                using (DbDataReader dbReader = this._dbCommand.ExecuteReader())
                {
                    result = this.ParseMultiple<TFirst, TSecond>(dbReader);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(GENERAL_EXCEPTION_MESSAGE, ex);
            }
        }

        /// <summary>
        /// Returns four results from single query. The result is Task where the result is Tuple with two Lists - first where the results are of type TFirst and second where the results are of type TSecond.
        /// </summary>
        /// <typeparam name="TFirst">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TSecond">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <param name="query">The sql command.</param>
        /// <param name="parameters">Collection of SqlEParameter.</param>
        /// <param name="isStoredProcedure">Boolean to use stored procedure.</param>
        /// <param name="prepareCommand">Boolean to prepare command (Creates a prepared (or compiled) version of the command on the data source).</param>
        /// <returns>Task where the result is Tuple with two Lists - first where the results are of type TFirst and second where the results are of type TSecond.</returns>
        public async Task<(List<TFirst> first, List<TSecond> second)> QueryMultipleAsync<TFirst, TSecond>(string query,
            IEnumerable<SqlEParameter> parameters,
            bool isStoredProcedure = false,
            bool prepareCommand = false)
        {
            try
            {
                CheckIfObjectIsDisposed();

                this.PrepareConnectionAndCommand(query, parameters, isStoredProcedure, prepareCommand);

                (List<TFirst> first, List<TSecond> second) result = default;

                using (DbDataReader dbReader = await this._dbCommand.ExecuteReaderAsync())
                {
                    result = this.ParseMultiple<TFirst, TSecond>(dbReader);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(GENERAL_EXCEPTION_MESSAGE, ex);
            }
        }

        /// <summary>
        /// Returns three results from single query. The result is Tuple with three Lists - first where the results are of type TFirst, second where the results are of type TSecond and third where the results are of type TThird.
        /// </summary>
        /// <typeparam name="TFirst">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TSecond">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TThird">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <param name="query">The sql command.</param>
        /// <param name="parameters">Collection of SqlEParameter.</param>
        /// <param name="isStoredProcedure">Boolean to use stored procedure.</param>
        /// <param name="prepareCommand">Boolean to prepare command (Creates a prepared (or compiled) version of the command on the data source).</param>
        /// <returns>Tuple with three Lists - first where the results are of type TFirst, second where the results are of type TSecond and third where the results are of type TThird.</returns>
        public (List<TFirst> first, List<TSecond> second, List<TThird> third) QueryMultiple<TFirst, TSecond, TThird>(string query,
            IEnumerable<SqlEParameter> parameters,
            bool isStoredProcedure = false,
            bool prepareCommand = false)
        {
            try
            {
                CheckIfObjectIsDisposed();

                this.PrepareConnectionAndCommand(query, parameters, isStoredProcedure, prepareCommand);

                (List<TFirst> first, List<TSecond> second, List<TThird> third) result = default;

                using (DbDataReader dbReader = this._dbCommand.ExecuteReader())
                {
                    result = this.ParseMultiple<TFirst, TSecond, TThird>(dbReader);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(GENERAL_EXCEPTION_MESSAGE, ex);
            }
        }

        /// <summary>
        /// Returns four results from single query. The result is Task where the result is Tuple with three Lists - first where the results are of type TFirst, second where the results are of type TSecond and third where the results are of type TThird.
        /// </summary>
        /// <typeparam name="TFirst">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TSecond">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TThird">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <param name="query">The sql command.</param>
        /// <param name="parameters">Collection of SqlEParameter.</param>
        /// <param name="isStoredProcedure">Boolean to use stored procedure.</param>
        /// <param name="prepareCommand">Boolean to prepare command (Creates a prepared (or compiled) version of the command on the data source).</param>
        /// <returns>Task where the result is Tuple with three Lists - first where the results are of type TFirst, second where the results are of type TSecond and third where the results are of type TThird.</returns>
        public async Task<(List<TFirst> first, List<TSecond> second, List<TThird> third)> QueryMultipleAsync<TFirst, TSecond, TThird>(string query,
            IEnumerable<SqlEParameter> parameters,
            bool isStoredProcedure = false,
            bool prepareCommand = false)
        {
            try
            {
                CheckIfObjectIsDisposed();

                this.PrepareConnectionAndCommand(query, parameters, isStoredProcedure, prepareCommand);

                (List<TFirst> first, List<TSecond> second, List<TThird> third) result = default;

                using (DbDataReader dbReader = await this._dbCommand.ExecuteReaderAsync())
                {
                    result = this.ParseMultiple<TFirst, TSecond, TThird>(dbReader);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(GENERAL_EXCEPTION_MESSAGE, ex);
            }
        }

        /// <summary>
        /// Returns four results from single query. The result is Tuple with four Lists - first where the results are of type TFirst, second where the results are of type TSecond, third where the results are of type TThird and fourth where the results are of type TFourth.
        /// </summary>
        /// <typeparam name="TFirst">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TSecond">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TThird">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TFourth">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <param name="query">The sql command.</param>
        /// <param name="parameters">Collection of SqlEParameter.</param>
        /// <param name="isStoredProcedure">Boolean to use stored procedure.</param>
        /// <param name="prepareCommand">Boolean to prepare command (Creates a prepared (or compiled) version of the command on the data source).</param>
        /// <returns>Tuple with four Lists - first where the results are of type TFirst, second where the results are of type TSecond, third where the results are of type TThird and fourth where the results are of type TFourth.</returns>
        public (List<TFirst> first, List<TSecond> second, List<TThird> third, List<TFourth> fourth) QueryMultiple<TFirst, TSecond, TThird, TFourth>(string query,
            IEnumerable<SqlEParameter> parameters,
            bool isStoredProcedure = false,
            bool prepareCommand = false)
        {
            try
            {
                CheckIfObjectIsDisposed();

                this.PrepareConnectionAndCommand(query, parameters, isStoredProcedure, prepareCommand);

                (List<TFirst> first, List<TSecond> second, List<TThird> third, List<TFourth> fourth) result = default;

                using (DbDataReader dbReader = this._dbCommand.ExecuteReader())
                {
                    result = this.ParseMultiple<TFirst, TSecond, TThird, TFourth>(dbReader);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(GENERAL_EXCEPTION_MESSAGE, ex);
            }
        }

        /// <summary>
        /// Returns four results from single query. The result is Task where the result is Tuple with four Lists - first where the results are of type TFirst, second where the results are of type TSecond, third where the results are of type TThird and fourth where the results are of type TFourth.
        /// </summary>
        /// <typeparam name="TFirst">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TSecond">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TThird">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TFourth">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <param name="query">The sql command.</param>
        /// <param name="parameters">Collection of SqlEParameter.</param>
        /// <param name="isStoredProcedure">Boolean to use stored procedure.</param>
        /// <param name="prepareCommand">Boolean to prepare command (Creates a prepared (or compiled) version of the command on the data source).</param>
        /// <returns>Task where the result is Tuple with four Lists - first where the results are of type TFirst, second where the results are of type TSecond, third where the results are of type TThird and fourth where the results are of type TFourth.</returns>
        public async Task<(List<TFirst> first, List<TSecond> second, List<TThird> third, List<TFourth> fourth)> QueryMultipleAsync<TFirst, TSecond, TThird, TFourth>(string query,
            IEnumerable<SqlEParameter> parameters,
            bool isStoredProcedure = false,
            bool prepareCommand = false)
        {
            try
            {
                CheckIfObjectIsDisposed();

                this.PrepareConnectionAndCommand(query, parameters, isStoredProcedure, prepareCommand);

                (List<TFirst> first, List<TSecond> second, List<TThird> third, List<TFourth> fourth) result = default;

                using (DbDataReader dbReader = await this._dbCommand.ExecuteReaderAsync())
                {
                    result = this.ParseMultiple<TFirst, TSecond, TThird, TFourth>(dbReader);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(GENERAL_EXCEPTION_MESSAGE, ex);
            }
        }

        /// <summary>
        /// Returns five results from single query. The result is Tuple with five Lists - first where the results are of type TFirst, second where the results are of type TSecond, third where the results are of type TThird, fourth where the results are of type TFourth and fifth where the results are of type TFifth.
        /// </summary>
        /// <typeparam name="TFirst">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TSecond">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TThird">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TFourth">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TFifth">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <param name="query">The sql command.</param>
        /// <param name="parameters">Collection of SqlEParameter.</param>
        /// <param name="isStoredProcedure">Boolean to use stored procedure.</param>
        /// <param name="prepareCommand">Boolean to prepare command (Creates a prepared (or compiled) version of the command on the data source).</param>
        /// <returns>Tuple with five Lists - first where the results are of type TFirst, second where the results are of type TSecond, third where the results are of type TThird, fourth where the results are of type TFourth and fifth where the results are of type TFifth.</returns>
        public (List<TFirst> first, List<TSecond> second, List<TThird> third, List<TFourth> fourth, List<TFifth> fifth) QueryMultiple<TFirst, TSecond, TThird, TFourth, TFifth>(string query,
            IEnumerable<SqlEParameter> parameters,
            bool isStoredProcedure = false,
            bool prepareCommand = false)
        {
            try
            {
                CheckIfObjectIsDisposed();

                this.PrepareConnectionAndCommand(query, parameters, isStoredProcedure, prepareCommand);

                (List<TFirst> first, List<TSecond> second, List<TThird> third, List<TFourth> fourth, List<TFifth> fifth) result = default;

                using (DbDataReader dbReader = this._dbCommand.ExecuteReader())
                {
                    result = this.ParseMultiple<TFirst, TSecond, TThird, TFourth, TFifth>(dbReader);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(GENERAL_EXCEPTION_MESSAGE, ex);
            }
        }

        /// <summary>
        /// Returns five results from single query. The result is Task where the result is Tuple with five Lists - first where the results are of type TFirst, second where the results are of type TSecond, third where the results are of type TThird, fourth where the results are of type TFourth and fifth where the results are of type TFifth.
        /// </summary>
        /// <typeparam name="TFirst">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TSecond">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TThird">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TFourth">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TFifth">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <param name="query">The sql command.</param>
        /// <param name="parameters">Collection of SqlEParameter.</param>
        /// <param name="isStoredProcedure">Boolean to use stored procedure.</param>
        /// <param name="prepareCommand">Boolean to prepare command (Creates a prepared (or compiled) version of the command on the data source).</param>
        /// <returns>Task where the result is Tuple with five Lists - first where the results are of type TFirst, second where the results are of type TSecond, third where the results are of type TThird, fourth where the results are of type TFourth and fifth where the results are of type TFifth.</returns>
        public async Task<(List<TFirst> first, List<TSecond> second, List<TThird> third, List<TFourth> fourth, List<TFifth> fifth)> QueryMultipleAsync<TFirst, TSecond, TThird, TFourth, TFifth>(string query,
            IEnumerable<SqlEParameter> parameters,
            bool isStoredProcedure = false,
            bool prepareCommand = false)
        {
            try
            {
                CheckIfObjectIsDisposed();

                this.PrepareConnectionAndCommand(query, parameters, isStoredProcedure, prepareCommand);

                (List<TFirst> first, List<TSecond> second, List<TThird> third, List<TFourth> fourth, List<TFifth> fifth) result = default;

                using (DbDataReader dbReader = await this._dbCommand.ExecuteReaderAsync())
                {
                    result = this.ParseMultiple<TFirst, TSecond, TThird, TFourth, TFifth>(dbReader);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(GENERAL_EXCEPTION_MESSAGE, ex);
            }
        }

        /// <summary>
        /// Returns six results from single query. The result is Tuple with six Lists - first where the results are of type TFirst, second where the results are of type TSecond, third where the results are of type TThird, fourth where the results are of type TFourth, fifth where the results are of type TFifth and sixth where the results are of type TSixth.
        /// </summary>
        /// <typeparam name="TFirst">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TSecond">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TThird">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TFourth">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TFifth">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TSixth">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <param name="query">The sql command.</param>
        /// <param name="parameters">Collection of SqlEParameter.</param>
        /// <param name="isStoredProcedure">Boolean to use stored procedure.</param>
        /// <param name="prepareCommand">Boolean to prepare command (Creates a prepared (or compiled) version of the command on the data source).</param>
        /// <returns>Tuple with six Lists - first where the results are of type TFirst, second where the results are of type TSecond, third where the results are of type TThird, fourth where the results are of type TFourth, fifth where the results are of type TFifth and sixth where the results are of type TSixth.</returns>
        public (List<TFirst> first, List<TSecond> second, List<TThird> third, List<TFourth> fourth, List<TFifth> fifth, List<TSixth> sixth) QueryMultiple<TFirst, TSecond, TThird, TFourth, TFifth, TSixth>(string query,
            IEnumerable<SqlEParameter> parameters,
            bool isStoredProcedure = false,
            bool prepareCommand = false)
        {
            try
            {
                CheckIfObjectIsDisposed();

                this.PrepareConnectionAndCommand(query, parameters, isStoredProcedure, prepareCommand);

                (List<TFirst> first, List<TSecond> second, List<TThird> third, List<TFourth> fourth, List<TFifth> fifth, List<TSixth> sixth) result = default;

                using (DbDataReader dbReader = this._dbCommand.ExecuteReader())
                {
                    result = this.ParseMultiple<TFirst, TSecond, TThird, TFourth, TFifth, TSixth>(dbReader);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(GENERAL_EXCEPTION_MESSAGE, ex);
            }
        }

        /// <summary>
        /// Returns six results from single query. The result is Task where the result is Tuple with six Lists - first where the results are of type TFirst, second where the results are of type TSecond, third where the results are of type TThird, fourth where the results are of type TFourth, fifth where the results are of type TFifth and sixth where the results are of type TSixth.
        /// </summary>
        /// <typeparam name="TFirst">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TSecond">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TThird">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TFourth">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TFifth">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TSixth">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <param name="query">The sql command.</param>
        /// <param name="parameters">Collection of SqlEParameter.</param>
        /// <param name="isStoredProcedure">Boolean to use stored procedure.</param>
        /// <param name="prepareCommand">Boolean to prepare command (Creates a prepared (or compiled) version of the command on the data source).</param>
        /// <returns>Task where the result is Tuple with six Lists - first where the results are of type TFirst, second where the results are of type TSecond, third where the results are of type TThird, fourth where the results are of type TFourth, fifth where the results are of type TFifth and sixth where the results are of type TSixth.</returns>
        public async Task<(List<TFirst> first, List<TSecond> second, List<TThird> third, List<TFourth> fourth, List<TFifth> fifth, List<TSixth> sixth)> QueryMultipleAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth>(string query,
            IEnumerable<SqlEParameter> parameters,
            bool isStoredProcedure = false,
            bool prepareCommand = false)
        {
            try
            {
                CheckIfObjectIsDisposed();

                this.PrepareConnectionAndCommand(query, parameters, isStoredProcedure, prepareCommand);

                (List<TFirst> first, List<TSecond> second, List<TThird> third, List<TFourth> fourth, List<TFifth> fifth, List<TSixth> sixth) result = default;

                using (DbDataReader dbReader = await this._dbCommand.ExecuteReaderAsync())
                {
                    result = this.ParseMultiple<TFirst, TSecond, TThird, TFourth, TFifth, TSixth>(dbReader);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(GENERAL_EXCEPTION_MESSAGE, ex);
            }
        }

        /// <summary>
        /// Returns seven results from single query. The result is Task where the result is Tuple with seven Lists - first where the results are of type TFirst, second where the results are of type TSecond, third where the results are of type TThird, fourth where the results are of type TFourth, fifth where the results are of type TFifth, sixth where the results are of type TSixth and the seventh where the results are of type TSeventh.
        /// </summary>
        /// <typeparam name="TFirst">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TSecond">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TThird">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TFourth">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TFifth">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TSixth">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TSeventh">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <param name="query">The sql command.</param>
        /// <param name="parameters">Collection of SqlEParameter.</param>
        /// <param name="isStoredProcedure">Boolean to use stored procedure.</param>
        /// <param name="prepareCommand">Boolean to prepare command (Creates a prepared (or compiled) version of the command on the data source).</param>
        /// <returns>Tuple with seven Lists - first where the results are of type TFirst, second where the results are of type TSecond, third where the results are of type TThird, fourth where the results are of type TFourth, fifth where the results are of type TFifth, sixth where the results are of type TSixth and the seventh where the results are of type TSeventh.</returns>
        public (List<TFirst> first, List<TSecond> second, List<TThird> third, List<TFourth> fourth, List<TFifth> fifth, List<TSixth> sixth, List<TSeventh> seventh) QueryMultiple<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh>(string query,
            IEnumerable<SqlEParameter> parameters,
            bool isStoredProcedure = false,
            bool prepareCommand = false)
        {
            try
            {
                CheckIfObjectIsDisposed();

                this.PrepareConnectionAndCommand(query, parameters, isStoredProcedure, prepareCommand);

                (List<TFirst> first, List<TSecond> second, List<TThird> third, List<TFourth> fourth, List<TFifth> fifth, List<TSixth> sixth, List<TSeventh> seventh) result = default;

                using (DbDataReader dbReader = this._dbCommand.ExecuteReader())
                {
                    result = this.ParseMultiple<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh>(dbReader);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(GENERAL_EXCEPTION_MESSAGE, ex);
            }
        }

        /// <summary>
        /// Returns seven results from single query. The result is Tuple with seven Lists - first where the results are of type TFirst, second where the results are of type TSecond, third where the results are of type TThird, fourth where the results are of type TFourth, fifth where the results are of type TFifth, sixth where the results are of type TSixth and the seventh where the results are of type TSeventh.
        /// </summary>
        /// <typeparam name="TFirst">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TSecond">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TThird">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TFourth">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TFifth">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TSixth">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TSeventh">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <param name="query">The sql command.</param>
        /// <param name="parameters">Collection of SqlEParameter.</param>
        /// <param name="isStoredProcedure">Boolean to use stored procedure.</param>
        /// <param name="prepareCommand">Boolean to prepare command (Creates a prepared (or compiled) version of the command on the data source).</param>
        /// <returns>Task where the result is Tuple with seven Lists - first where the results are of type TFirst, second where the results are of type TSecond, third where the results are of type TThird, fourth where the results are of type TFourth, fifth where the results are of type TFifth, sixth where the results are of type TSixth and the seventh where the results are of type TSeventh.</returns>
        public async Task<(List<TFirst> first, List<TSecond> second, List<TThird> third, List<TFourth> fourth, List<TFifth> fifth, List<TSixth> sixth, List<TSeventh> seventh)> QueryMultipleAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh>(string query,
            IEnumerable<SqlEParameter> parameters,
            bool isStoredProcedure = false,
            bool prepareCommand = false)
        {
            try
            {
                CheckIfObjectIsDisposed();

                this.PrepareConnectionAndCommand(query, parameters, isStoredProcedure, prepareCommand);

                (List<TFirst> first, List<TSecond> second, List<TThird> third, List<TFourth> fourth, List<TFifth> fifth, List<TSixth> sixth, List<TSeventh> seventh) result = default;

                using (DbDataReader dbReader = await this._dbCommand.ExecuteReaderAsync())
                {
                    result = this.ParseMultiple<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh>(dbReader);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(GENERAL_EXCEPTION_MESSAGE, ex);
            }
        }

        /// <summary>
        /// Returns eight results from single query. The result is Tuple with eight Lists - first where the results are of type TFirst, second where the results are of type TSecond, third where the results are of type TThird, fourth where the results are of type TFourth, fifth where the results are of type TFifth, sixth where the results are of type TSixth, the seventh where the results are of type TSeventh and eight where the results are of type TEighth.
        /// </summary>
        /// <typeparam name="TFirst">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TSecond">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TThird">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TFourth">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TFifth">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TSixth">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TSeventh">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TEighth">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <param name="query">The sql command.</param>
        /// <param name="parameters">Collection of SqlEParameter.</param>
        /// <param name="isStoredProcedure">Boolean to use stored procedure.</param>
        /// <param name="prepareCommand">Boolean to prepare command (Creates a prepared (or compiled) version of the command on the data source).</param>
        /// <returns>Tuple with eight Lists - first where the results are of type TFirst, second where the results are of type TSecond, third where the results are of type TThird, fourth where the results are of type TFourth, fifth where the results are of type TFifth, sixth where the results are of type TSixth, the seventh where the results are of type TSeventh and eight where the results are of type TEighth.</returns>
        public (List<TFirst> first, List<TSecond> second, List<TThird> third, List<TFourth> fourth, List<TFifth> fifth, List<TSixth> sixth, List<TSeventh> seventh, List<TEighth> eighth) QueryMultiple<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEighth>(string query,
            IEnumerable<SqlEParameter> parameters,
            bool isStoredProcedure = false,
            bool prepareCommand = false)
        {
            try
            {
                CheckIfObjectIsDisposed();

                this.PrepareConnectionAndCommand(query, parameters, isStoredProcedure, prepareCommand);

                (List<TFirst> first, List<TSecond> second, List<TThird> third, List<TFourth> fourth, List<TFifth> fifth, List<TSixth> sixth, List<TSeventh> seventh, List<TEighth> eighth) result = default;

                using (DbDataReader dbReader = this._dbCommand.ExecuteReader())
                {
                    result = this.ParseMultiple<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEighth>(dbReader);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(GENERAL_EXCEPTION_MESSAGE, ex);
            }
        }

        /// <summary>
        /// Returns eight results from single query. The result is Task where the result is Tuple with eight Lists - first where the results are of type TFirst, second where the results are of type TSecond, third where the results are of type TThird, fourth where the results are of type TFourth, fifth where the results are of type TFifth, sixth where the results are of type TSixth, the seventh where the results are of type TSeventh and eight where the results are of type TEighth.
        /// </summary>
        /// <typeparam name="TFirst">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TSecond">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TThird">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TFourth">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TFifth">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TSixth">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TSeventh">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TEighth">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <param name="query">The sql command.</param>
        /// <param name="parameters">Collection of SqlEParameter.</param>
        /// <param name="isStoredProcedure">Boolean to use stored procedure.</param>
        /// <param name="prepareCommand">Boolean to prepare command (Creates a prepared (or compiled) version of the command on the data source).</param>
        /// <returns>Task where the result is Tuple with eight Lists - first where the results are of type TFirst, second where the results are of type TSecond, third where the results are of type TThird, fourth where the results are of type TFourth, fifth where the results are of type TFifth, sixth where the results are of type TSixth, the seventh where the results are of type TSeventh and eight where the results are of type TEighth.</returns>
        public async Task<(List<TFirst> first, List<TSecond> second, List<TThird> third, List<TFourth> fourth, List<TFifth> fifth, List<TSixth> sixth, List<TSeventh> seventh, List<TEighth> eighth)> QueryMultipleAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEighth>(string query,
            IEnumerable<SqlEParameter> parameters,
            bool isStoredProcedure = false,
            bool prepareCommand = false)
        {
            try
            {
                CheckIfObjectIsDisposed();

                this.PrepareConnectionAndCommand(query, parameters, isStoredProcedure, prepareCommand);

                (List<TFirst> first, List<TSecond> second, List<TThird> third, List<TFourth> fourth, List<TFifth> fifth, List<TSixth> sixth, List<TSeventh> seventh, List<TEighth> eighth) result = default;

                using (DbDataReader dbReader = await this._dbCommand.ExecuteReaderAsync())
                {
                    result = this.ParseMultiple<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEighth>(dbReader);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(GENERAL_EXCEPTION_MESSAGE, ex);
            }
        }

        /// <summary>
        /// Returns eight results from single query. The result is Tuple with nine Lists - first where the results are of type TFirst, second where the results are of type TSecond, third where the results are of type TThird, fourth where the results are of type TFourth, fifth where the results are of type TFifth, sixth where the results are of type TSixth, the seventh where the results are of type TSeventh, eight where the results are of type TEighth and ninth where the results are of type TNinth.
        /// </summary>
        /// <typeparam name="TFirst">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TSecond">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TThird">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TFourth">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TFifth">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TSixth">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TSeventh">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TEighth">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TNinth">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <param name="query">The sql command.</param>
        /// <param name="parameters">Collection of SqlEParameter.</param>
        /// <param name="isStoredProcedure">Boolean to use stored procedure.</param>
        /// <param name="prepareCommand">Boolean to prepare command (Creates a prepared (or compiled) version of the command on the data source).</param>
        /// <returns>Tuple with nine Lists - first where the results are of type TFirst, second where the results are of type TSecond, third where the results are of type TThird, fourth where the results are of type TFourth, fifth where the results are of type TFifth, sixth where the results are of type TSixth, the seventh where the results are of type TSeventh, eight where the results are of type TEighth and ninth where the results are of type TNinth.</returns>
        public (List<TFirst> first, List<TSecond> second, List<TThird> third, List<TFourth> fourth, List<TFifth> fifth, List<TSixth> sixth, List<TSeventh> seventh, List<TEighth> eighth, List<TNinth> ninth) QueryMultiple<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEighth, TNinth>(string query,
            IEnumerable<SqlEParameter> parameters,
            bool isStoredProcedure = false,
            bool prepareCommand = false)
        {
            try
            {
                CheckIfObjectIsDisposed();

                this.PrepareConnectionAndCommand(query, parameters, isStoredProcedure, prepareCommand);

                (List<TFirst> first, List<TSecond> second, List<TThird> third, List<TFourth> fourth, List<TFifth> fifth, List<TSixth> sixth, List<TSeventh> seventh, List<TEighth> eighth, List<TNinth> ninth) result = default;

                using (DbDataReader dbReader = this._dbCommand.ExecuteReader())
                {
                    result = this.ParseMultiple<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEighth, TNinth>(dbReader);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(GENERAL_EXCEPTION_MESSAGE, ex);
            }
        }

        /// <summary>
        /// Returns eight results from single query. The result is Task where the result is Tuple with nine Lists - first where the results are of type TFirst, second where the results are of type TSecond, third where the results are of type TThird, fourth where the results are of type TFourth, fifth where the results are of type TFifth, sixth where the results are of type TSixth, the seventh where the results are of type TSeventh, eight where the results are of type TEighth and ninth where the results are of type TNinth.
        /// </summary>
        /// <typeparam name="TFirst">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TSecond">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TThird">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TFourth">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TFifth">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TSixth">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TSeventh">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TEighth">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TNinth">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <param name="query">The sql command.</param>
        /// <param name="parameters">Collection of SqlEParameter.</param>
        /// <param name="isStoredProcedure">Boolean to use stored procedure.</param>
        /// <param name="prepareCommand">Boolean to prepare command (Creates a prepared (or compiled) version of the command on the data source).</param>
        /// <returns>Task where the result is Tuple with nine Lists - first where the results are of type TFirst, second where the results are of type TSecond, third where the results are of type TThird, fourth where the results are of type TFourth, fifth where the results are of type TFifth, sixth where the results are of type TSixth, the seventh where the results are of type TSeventh, eight where the results are of type TEighth and ninth where the results are of type TNinth.</returns>
        public async Task<(List<TFirst> first, List<TSecond> second, List<TThird> third, List<TFourth> fourth, List<TFifth> fifth, List<TSixth> sixth, List<TSeventh> seventh, List<TEighth> eighth, List<TNinth> ninth)> QueryMultipleAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEighth, TNinth>(string query,
            IEnumerable<SqlEParameter> parameters,
            bool isStoredProcedure = false,
            bool prepareCommand = false)
        {
            try
            {
                CheckIfObjectIsDisposed();

                this.PrepareConnectionAndCommand(query, parameters, isStoredProcedure, prepareCommand);

                (List<TFirst> first, List<TSecond> second, List<TThird> third, List<TFourth> fourth, List<TFifth> fifth, List<TSixth> sixth, List<TSeventh> seventh, List<TEighth> eighth, List<TNinth> ninth) result = default;

                using (DbDataReader dbReader = await this._dbCommand.ExecuteReaderAsync())
                {
                    result = this.ParseMultiple<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEighth, TNinth>(dbReader);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(GENERAL_EXCEPTION_MESSAGE, ex);
            }
        }

        /// <summary>
        /// Returns eight results from single query. The result is Tuple with ten Lists - first where the results are of type TFirst, second where the results are of type TSecond, third where the results are of type TThird, fourth where the results are of type TFourth, fifth where the results are of type TFifth, sixth where the results are of type TSixth, the seventh where the results are of type TSeventh, eight where the results are of type TEighth, ninth where the results are of type TNinth and tehth where the results are of type TTenth.
        /// </summary>
        /// <typeparam name="TFirst">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TSecond">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TThird">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TFourth">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TFifth">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TSixth">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TSeventh">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TEighth">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TNinth">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TTenth">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <param name="query">The sql command.</param>
        /// <param name="parameters">Collection of SqlEParameter.</param>
        /// <param name="isStoredProcedure">Boolean to use stored procedure.</param>
        /// <param name="prepareCommand">Boolean to prepare command (Creates a prepared (or compiled) version of the command on the data source).</param>
        /// <returns>Tuple with ten Lists - first where the results are of type TFirst, second where the results are of type TSecond, third where the results are of type TThird, fourth where the results are of type TFourth, fifth where the results are of type TFifth, sixth where the results are of type TSixth, the seventh where the results are of type TSeventh, eight where the results are of type TEighth, ninth where the results are of type TNinth and tehth where the results are of type TTenth.</returns>
        public (List<TFirst> first, List<TSecond> second, List<TThird> third, List<TFourth> fourth, List<TFifth> fifth, List<TSixth> sixth, List<TSeventh> seventh, List<TEighth> eighth, List<TNinth> ninth, List<TTenth> tenth) QueryMultiple<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEighth, TNinth, TTenth>(string query,
            IEnumerable<SqlEParameter> parameters,
            bool isStoredProcedure = false,
            bool prepareCommand = false)
        {
            try
            {
                CheckIfObjectIsDisposed();

                this.PrepareConnectionAndCommand(query, parameters, isStoredProcedure, prepareCommand);

                (List<TFirst> first, List<TSecond> second, List<TThird> third, List<TFourth> fourth, List<TFifth> fifth, List<TSixth> sixth, List<TSeventh> seventh, List<TEighth> eighth, List<TNinth> ninth, List<TTenth> tenth) result = default;

                using (DbDataReader dbReader = this._dbCommand.ExecuteReader())
                {
                    result = this.ParseMultiple<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEighth, TNinth, TTenth>(dbReader);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(GENERAL_EXCEPTION_MESSAGE, ex);
            }
        }

        /// <summary>
        /// Returns eight results from single query. The result is Task where the result is Tuple with ten Lists - first where the results are of type TFirst, second where the results are of type TSecond, third where the results are of type TThird, fourth where the results are of type TFourth, fifth where the results are of type TFifth, sixth where the results are of type TSixth, the seventh where the results are of type TSeventh, eight where the results are of type TEighth, ninth where the results are of type TNinth and tehth where the results are of type TTenth.
        /// </summary>
        /// <typeparam name="TFirst">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TSecond">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TThird">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TFourth">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TFifth">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TSixth">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TSeventh">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TEighth">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TNinth">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <typeparam name="TTenth">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <param name="query">The sql command.</param>
        /// <param name="parameters">Collection of SqlEParameter.</param>
        /// <param name="isStoredProcedure">Boolean to use stored procedure.</param>
        /// <param name="prepareCommand">Boolean to prepare command (Creates a prepared (or compiled) version of the command on the data source).</param>
        /// <returns>Task where the result is Tuple with ten Lists - first where the results are of type TFirst, second where the results are of type TSecond, third where the results are of type TThird, fourth where the results are of type TFourth, fifth where the results are of type TFifth, sixth where the results are of type TSixth, the seventh where the results are of type TSeventh, eight where the results are of type TEighth, ninth where the results are of type TNinth and tehth where the results are of type TTenth.</returns>
        public async Task<(List<TFirst> first, List<TSecond> second, List<TThird> third, List<TFourth> fourth, List<TFifth> fifth, List<TSixth> sixth, List<TSeventh> seventh, List<TEighth> eighth, List<TNinth> ninth, List<TTenth> tenth)> QueryMultipleAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEighth, TNinth, TTenth>(string query,
            IEnumerable<SqlEParameter> parameters,
            bool isStoredProcedure = false,
            bool prepareCommand = false)
        {
            try
            {
                CheckIfObjectIsDisposed();

                this.PrepareConnectionAndCommand(query, parameters, isStoredProcedure, prepareCommand);

                (List<TFirst> first, List<TSecond> second, List<TThird> third, List<TFourth> fourth, List<TFifth> fifth, List<TSixth> sixth, List<TSeventh> seventh, List<TEighth> eighth, List<TNinth> ninth, List<TTenth> tenth) result = default;

                using (DbDataReader dbReader = await this._dbCommand.ExecuteReaderAsync())
                {
                    result = this.ParseMultiple<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEighth, TNinth, TTenth>(dbReader);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(GENERAL_EXCEPTION_MESSAGE, ex);
            }
        }

        private int ExecuteNonQuery(string query,
            IEnumerable<SqlEParameter> parameters,
            bool isStoredProcedure,
            bool prepareCommand)
        {
            try
            {
                CheckIfObjectIsDisposed();

                this.PrepareConnectionAndCommand(query, parameters, isStoredProcedure, prepareCommand);

                int result = this._dbCommand.ExecuteNonQuery();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(GENERAL_EXCEPTION_MESSAGE, ex);
            }
        }

        private async Task<int> ExecuteNonQueryAsync(string query,
            IEnumerable<SqlEParameter> parameters,
            bool isStoredProcedure,
            bool prepareCommand)
        {
            try
            {
                CheckIfObjectIsDisposed();

                this.PrepareConnectionAndCommand(query, parameters, isStoredProcedure, prepareCommand);

                int result = await this._dbCommand.ExecuteNonQueryAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(GENERAL_EXCEPTION_MESSAGE, ex);
            }
        }

        private List<TModel> ExecuteQuery<TModel>(string query, IEnumerable<SqlEParameter> parameters,
            bool isStoredProcedure,
            bool prepareCommand)
        {
            try
            {
                CheckIfObjectIsDisposed();

                IParser<TModel> parser = this.GetParser<TModel>();

                this.PrepareConnectionAndCommand(query, parameters, isStoredProcedure, prepareCommand);

                List<TModel> results = null;

                using (DbDataReader dbDataReader = this._dbCommand.ExecuteReader())
                {
                    results = new List<TModel>(parser.Parse(dbDataReader));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw new Exception(GENERAL_EXCEPTION_MESSAGE, ex);
            }
        }

        private async Task<List<TModel>> ExecuteQueryAsync<TModel>(string query,
            IEnumerable<SqlEParameter> parameters,
            bool isStoredProcedure,
            bool prepareCommand)
        {
            try
            {
                CheckIfObjectIsDisposed();

                IParser<TModel> parser = this.GetParser<TModel>();

                this.PrepareConnectionAndCommand(query, parameters, isStoredProcedure, prepareCommand);

                List<TModel> results = null;

                using (DbDataReader dbDataReader = await this._dbCommand.ExecuteReaderAsync())
                {
                    results = new List<TModel>(parser.Parse(dbDataReader));
                }

                return results;
            }
            catch (Exception ex)
            {
                throw new Exception(GENERAL_EXCEPTION_MESSAGE, ex);
            }
        }

        private (bool hasResult, TModel result) ExecuteSingle<TModel>(string query,
            IEnumerable<SqlEParameter> parameters,
            bool isStoredProcedure,
            bool prepareCommand)
        {
            try
            {
                CheckIfObjectIsDisposed();

                IParser<TModel> parser = this.GetParser<TModel>();

                this.PrepareConnectionAndCommand(query, parameters, isStoredProcedure, prepareCommand);

                (bool hasResult, TModel result) result;

                using (DbDataReader dbDataReader = this._dbCommand.ExecuteReader())
                {
                    result = parser.ParseSingle(dbDataReader);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(GENERAL_EXCEPTION_MESSAGE, ex);
            }
        }

        private async Task<(bool hasResult, TModel result)> ExecuteSingleAsync<TModel>(string query,
            IEnumerable<SqlEParameter> parameters,
            bool isStoredProcedure,
            bool prepareCommand)
        {
            try
            {
                CheckIfObjectIsDisposed();

                IParser<TModel> parser = this.GetParser<TModel>();

                this.PrepareConnectionAndCommand(query, parameters, isStoredProcedure, prepareCommand);

                (bool hasResult, TModel result) result;

                using (DbDataReader dbDataReader = await this._dbCommand.ExecuteReaderAsync())
                {
                    result = parser.ParseSingle(dbDataReader);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(GENERAL_EXCEPTION_MESSAGE, ex);
            }
        }

        private (List<TFirst> first, List<TSecond> second) ParseMultiple<TFirst, TSecond>(DbDataReader dbReader) =>
            (new List<TFirst>(this.GetParser<TFirst>().Parse(dbReader)),
                dbReader.NextResult() ? new List<TSecond>(this.GetParser<TSecond>().Parse(dbReader)) : new List<TSecond>());

        private (List<TFirst> first, List<TSecond> second, List<TThird> third) ParseMultiple<TFirst, TSecond, TThird>(DbDataReader dbReader) =>
            (new List<TFirst>(this.GetParser<TFirst>().Parse(dbReader)),
                dbReader.NextResult() ? new List<TSecond>(this.GetParser<TSecond>().Parse(dbReader)) : new List<TSecond>(),
                dbReader.NextResult() ? new List<TThird>(this.GetParser<TThird>().Parse(dbReader)) : new List<TThird>());

        private (List<TFirst> first, List<TSecond> second, List<TThird> third, List<TFourth> fourth) ParseMultiple<TFirst, TSecond, TThird, TFourth>(DbDataReader dbReader) =>
            (new List<TFirst>(this.GetParser<TFirst>().Parse(dbReader)),
                dbReader.NextResult() ? new List<TSecond>(this.GetParser<TSecond>().Parse(dbReader)) : new List<TSecond>(),
                dbReader.NextResult() ? new List<TThird>(this.GetParser<TThird>().Parse(dbReader)) : new List<TThird>(),
                dbReader.NextResult() ? new List<TFourth>(this.GetParser<TFourth>().Parse(dbReader)) : new List<TFourth>());

        private (List<TFirst> first, List<TSecond> second, List<TThird> third, List<TFourth> fourth, List<TFifth> fifth) ParseMultiple<TFirst, TSecond, TThird, TFourth, TFifth>(DbDataReader dbReader) =>
            (new List<TFirst>(this.GetParser<TFirst>().Parse(dbReader)),
                dbReader.NextResult() ? new List<TSecond>(this.GetParser<TSecond>().Parse(dbReader)) : new List<TSecond>(),
                dbReader.NextResult() ? new List<TThird>(this.GetParser<TThird>().Parse(dbReader)) : new List<TThird>(),
                dbReader.NextResult() ? new List<TFourth>(this.GetParser<TFourth>().Parse(dbReader)) : new List<TFourth>(),
                dbReader.NextResult() ? new List<TFifth>(this.GetParser<TFifth>().Parse(dbReader)) : new List<TFifth>());

        private (List<TFirst> first, List<TSecond> second, List<TThird> third, List<TFourth> fourth, List<TFifth> fifth, List<TSixth> sixth) ParseMultiple<TFirst, TSecond, TThird, TFourth, TFifth, TSixth>(DbDataReader dbReader) =>
            (new List<TFirst>(this.GetParser<TFirst>().Parse(dbReader)),
                dbReader.NextResult() ? new List<TSecond>(this.GetParser<TSecond>().Parse(dbReader)) : new List<TSecond>(),
                dbReader.NextResult() ? new List<TThird>(this.GetParser<TThird>().Parse(dbReader)) : new List<TThird>(),
                dbReader.NextResult() ? new List<TFourth>(this.GetParser<TFourth>().Parse(dbReader)) : new List<TFourth>(),
                dbReader.NextResult() ? new List<TFifth>(this.GetParser<TFifth>().Parse(dbReader)) : new List<TFifth>(),
                dbReader.NextResult() ? new List<TSixth>(this.GetParser<TSixth>().Parse(dbReader)) : new List<TSixth>());

        private (List<TFirst> first, List<TSecond> second, List<TThird> third, List<TFourth> fourth, List<TFifth> fifth, List<TSixth> sixth, List<TSeventh> seventh) ParseMultiple<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh>(DbDataReader dbReader) =>
            (new List<TFirst>(this.GetParser<TFirst>().Parse(dbReader)),
                dbReader.NextResult() ? new List<TSecond>(this.GetParser<TSecond>().Parse(dbReader)) : new List<TSecond>(),
                dbReader.NextResult() ? new List<TThird>(this.GetParser<TThird>().Parse(dbReader)) : new List<TThird>(),
                dbReader.NextResult() ? new List<TFourth>(this.GetParser<TFourth>().Parse(dbReader)) : new List<TFourth>(),
                dbReader.NextResult() ? new List<TFifth>(this.GetParser<TFifth>().Parse(dbReader)) : new List<TFifth>(),
                dbReader.NextResult() ? new List<TSixth>(this.GetParser<TSixth>().Parse(dbReader)) : new List<TSixth>(),
                dbReader.NextResult() ? new List<TSeventh>(this.GetParser<TSeventh>().Parse(dbReader)) : new List<TSeventh>());

        private (List<TFirst> first, List<TSecond> second, List<TThird> third, List<TFourth> fourth, List<TFifth> fifth, List<TSixth> sixth, List<TSeventh> seventh, List<TEighth> eighth) ParseMultiple<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEighth>(DbDataReader dbReader) =>
            (new List<TFirst>(this.GetParser<TFirst>().Parse(dbReader)),
                dbReader.NextResult() ? new List<TSecond>(this.GetParser<TSecond>().Parse(dbReader)) : new List<TSecond>(),
                dbReader.NextResult() ? new List<TThird>(this.GetParser<TThird>().Parse(dbReader)) : new List<TThird>(),
                dbReader.NextResult() ? new List<TFourth>(this.GetParser<TFourth>().Parse(dbReader)) : new List<TFourth>(),
                dbReader.NextResult() ? new List<TFifth>(this.GetParser<TFifth>().Parse(dbReader)) : new List<TFifth>(),
                dbReader.NextResult() ? new List<TSixth>(this.GetParser<TSixth>().Parse(dbReader)) : new List<TSixth>(),
                dbReader.NextResult() ? new List<TSeventh>(this.GetParser<TSeventh>().Parse(dbReader)) : new List<TSeventh>(),
                dbReader.NextResult() ? new List<TEighth>(this.GetParser<TEighth>().Parse(dbReader)) : new List<TEighth>());

        private (List<TFirst> first, List<TSecond> second, List<TThird> third, List<TFourth> fourth, List<TFifth> fifth, List<TSixth> sixth, List<TSeventh> seventh, List<TEighth> eighth, List<TNinth> ninth) ParseMultiple<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEighth, TNinth>(DbDataReader dbReader) =>
            (new List<TFirst>(this.GetParser<TFirst>().Parse(dbReader)),
                dbReader.NextResult() ? new List<TSecond>(this.GetParser<TSecond>().Parse(dbReader)) : new List<TSecond>(),
                dbReader.NextResult() ? new List<TThird>(this.GetParser<TThird>().Parse(dbReader)) : new List<TThird>(),
                dbReader.NextResult() ? new List<TFourth>(this.GetParser<TFourth>().Parse(dbReader)) : new List<TFourth>(),
                dbReader.NextResult() ? new List<TFifth>(this.GetParser<TFifth>().Parse(dbReader)) : new List<TFifth>(),
                dbReader.NextResult() ? new List<TSixth>(this.GetParser<TSixth>().Parse(dbReader)) : new List<TSixth>(),
                dbReader.NextResult() ? new List<TSeventh>(this.GetParser<TSeventh>().Parse(dbReader)) : new List<TSeventh>(),
                dbReader.NextResult() ? new List<TEighth>(this.GetParser<TEighth>().Parse(dbReader)) : new List<TEighth>(),
                dbReader.NextResult() ? new List<TNinth>(this.GetParser<TNinth>().Parse(dbReader)) : new List<TNinth>());

        private (List<TFirst> first, List<TSecond> second, List<TThird> third, List<TFourth> fourth, List<TFifth> fifth, List<TSixth> sixth, List<TSeventh> seventh, List<TEighth> eighth, List<TNinth> ninth, List<TTenth> tenth) ParseMultiple<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEighth, TNinth, TTenth>(DbDataReader dbReader) =>
            (new List<TFirst>(this.GetParser<TFirst>().Parse(dbReader)),
                dbReader.NextResult() ? new List<TSecond>(this.GetParser<TSecond>().Parse(dbReader)) : new List<TSecond>(),
                dbReader.NextResult() ? new List<TThird>(this.GetParser<TThird>().Parse(dbReader)) : new List<TThird>(),
                dbReader.NextResult() ? new List<TFourth>(this.GetParser<TFourth>().Parse(dbReader)) : new List<TFourth>(),
                dbReader.NextResult() ? new List<TFifth>(this.GetParser<TFifth>().Parse(dbReader)) : new List<TFifth>(),
                dbReader.NextResult() ? new List<TSixth>(this.GetParser<TSixth>().Parse(dbReader)) : new List<TSixth>(),
                dbReader.NextResult() ? new List<TSeventh>(this.GetParser<TSeventh>().Parse(dbReader)) : new List<TSeventh>(),
                dbReader.NextResult() ? new List<TEighth>(this.GetParser<TEighth>().Parse(dbReader)) : new List<TEighth>(),
                dbReader.NextResult() ? new List<TNinth>(this.GetParser<TNinth>().Parse(dbReader)) : new List<TNinth>(),
                dbReader.NextResult() ? new List<TTenth>(this.GetParser<TTenth>().Parse(dbReader)) : new List<TTenth>());

        private void PrepareConnectionAndCommand(string query,
            IEnumerable<SqlEParameter> parameters,
            bool isStoredProcedure,
            bool prepareCommand)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                throw new ArgumentException($"Parameter {nameof(query)} cannot be bull or white space.");
            }

            if (this._dbConnection.State == ConnectionState.Closed)
            {
                this._dbConnection.Open();
            }

            if (this._dbCommand == null)
            {
                this._dbCommand = this._dbConnection.CreateCommand();
                this._defaultTimeout = this._dbCommand.CommandTimeout;

                this._dbCommand.CommandTimeout = !this._timeout.HasValue ? this._defaultTimeout : this._timeout.Value;
            }

            this._dbCommand.CommandText = query;
            this._dbCommand.Parameters.Clear();

            if (parameters != null)
            {
                foreach (SqlEParameter parameter in parameters)
                {
                    this._dbCommand.Parameters.Add(parameter.ConvertToDbParameter(this._dbCommand));
                }
            }

            if (isStoredProcedure)
            {
                this._dbCommand.CommandType = CommandType.StoredProcedure;
            }

            if (prepareCommand == true)
            {
                this._dbCommand.Prepare();
            }

            if (this._useTransaction && this._dbCommand.Transaction == null)
            {
                this._dbCommand.Transaction = !this._isolationLevel.HasValue ? this._dbConnection.BeginTransaction() : this._dbConnection.BeginTransaction(this._isolationLevel.Value);
            }
        }

        private IParser<TModel> GetParser<TModel>()
        {
            if (!_parsersByType.TryGetValue(typeof(TModel), out IBaseParser baseParser))
            {
                baseParser = this._parserFactory.CreateParser<TModel>();

                if (!_parsersByType.TryAdd(typeof(TModel), baseParser))
                {
                    if (!_parsersByType.TryGetValue(typeof(TModel), out baseParser))
                    {
                        throw new Exception($"Error while getting parser of type {nameof(TModel)}.");
                    }
                }
            }

            IParser<TModel> parser = baseParser as IParser<TModel>;

            if (parser == null)
            {
                throw new InvalidCastException($"Error creating parser for type {nameof(TModel)}.");
            }

            return parser;
        }

        private void CheckIfObjectIsDisposed()
        {
            if (this._isDisposed)
            {
                throw new ObjectDisposedException($"{nameof(Connection<Conn>)} is disposed.");
            }
        }
    }
}