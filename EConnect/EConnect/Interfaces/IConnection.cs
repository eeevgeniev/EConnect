using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace EConnect.Interfaces
{
    /// <summary>
    /// Base interface for wrapper around DbConnection.
    /// </summary>
    /// <typeparam name="TConnection">TConnection must inherit DbConnection.</typeparam>
    public interface IConnection<TConnection> : IDisposable
        where TConnection : DbConnection, new()
    {
        /// <summary>
        /// Helper method to register custom parser for specific type in static (shared) cache.
        /// </summary>
        /// <typeparam name="TModel">The type for which parser is responible.</typeparam>
        /// <param name="parser">The parser responsible to parse results from DbDataReader to TModel.</param>
        void AddParserOrUpdate<TModel>(IParser<TModel> parser);

        /// <summary>
        /// Clears all parsers from the static (shared) cache.
        /// </summary>
        void ClearParsers();

        /// <summary>
        /// Commits sql transaction.
        /// </summary>
        void CommitTransaction();

        /// <summary>
        /// Executes non query sql command which returns Integer.
        /// </summary>
        /// <param name="query">The sql command.</param>
        /// <param name="parameters">Collection of SqlEParameter.</param>
        /// <param name="isStoredProcedure">Boolean to use stored procedure.</param>
        /// <param name="prepareCommand">Boolean to prepare command (Creates a prepared (or compiled) version of the command on the data source).</param>
        /// <returns>Integer</returns>
        int NonQuery(string query, 
            IEnumerable<SqlEParameter> parameters, 
            bool isStoredProcedure, 
            bool prepareCommand);

        /// <summary>
        /// Executes non query sql command which returns Task of Integer.
        /// </summary>
        /// <param name="query">The sql command.</param>
        /// <param name="parameters">Collection of SqlEParameter.</param>
        /// <param name="isStoredProcedure">Boolean to use stored procedure.</param>
        /// <param name="prepareCommand">Boolean to prepare command (Creates a prepared (or compiled) version of the command on the data source).</param>
        /// <returns>Task where the result is Integer.</returns>
        Task<int> NonQueryAsync(string query, 
            IEnumerable<SqlEParameter> parameters, 
            bool isStoredProcedure, 
            bool prepareCommand);

        /// <summary>
        /// Executes query command which returns List of TModel Objects.
        /// </summary>
        /// <typeparam name="TModel">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <param name="query">The sql command.</param>
        /// <param name="parameters">Collection of SqlEParameter.</param>
        /// <param name="isStoredProcedure">Boolean to use stored procedure.</param>
        /// <param name="prepareCommand">Boolean to prepare command (Creates a prepared (or compiled) version of the command on the data source).</param>
        /// <returns>List of Objects of type TModel.</returns>
        List<TModel> Query<TModel>(string query, 
            IEnumerable<SqlEParameter> parameters, 
            bool isStoredProcedure, 
            bool prepareCommand);

        /// <summary>
        /// Executes query command which returns Dictionary where the key is String and the value is Object.
        /// </summary>
        /// <param name="query">The sql command.</param>
        /// <param name="parameters">Collection of SqlEParameter.</param>
        /// <param name="isStoredProcedure">Boolean to use stored procedure.</param>
        /// <param name="prepareCommand">Boolean to prepare command (Creates a prepared (or compiled) version of the command on the data source).</param>
        /// <returns>List of Dictionaries where the key is String and the value is Object.</returns>
        List<Dictionary<string, object>> Query(string query, 
            IEnumerable<SqlEParameter> parameters, 
            bool isStoredProcedure, 
            bool prepareCommand);

        /// <summary>
        /// Executes query command which returns Task of List of TModel objects.
        /// </summary>
        /// <typeparam name="TModel">One of the supported types. Look in BaseTypeHelper.</typeparam>
        /// <param name="query">The sql command.</param>
        /// <param name="parameters">Collection of SqlEParameter.</param>
        /// <param name="isStoredProcedure">Boolean to use stored procedure.</param>
        /// <param name="prepareCommand">Boolean to prepare command (Creates a prepared (or compiled) version of the command on the data source).</param>
        /// <returns>Task where the result is List of Objects of type TModel.</returns>
        Task<List<TModel>> QueryAsync<TModel>(string query, 
            IEnumerable<SqlEParameter> parameters, 
            bool isStoredProcedure, 
            bool prepareCommand);

        /// <summary>
        /// Executes query command which returns Dictionary where the key is string and the value is object.
        /// </summary>
        /// <param name="query">The sql command.</param>
        /// <param name="parameters">Collection of SqlEParameter.</param>
        /// <param name="isStoredProcedure">Boolean to use stored procedure.</param>
        /// <param name="prepareCommand">Boolean to prepare command (Creates a prepared (or compiled) version of the command on the data source).</param>
        /// <returns>Task where the result is Dictionary where the key is String and the value is Object.</returns>
        Task<List<Dictionary<string, object>>> QueryAsync(string query, 
            IEnumerable<SqlEParameter> parameters, 
            bool isStoredProcedure, 
            bool prepareCommand);

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
        (bool hasResult, TModel result) Single<TModel>(string query, 
            IEnumerable<SqlEParameter> parameters, 
            bool isStoredProcedure, 
            bool prepareCommand);

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
        Task<(bool hasResult, TModel result)> SingleAsync<TModel>(string query, 
            IEnumerable<SqlEParameter> parameters, 
            bool isStoredProcedure, 
            bool prepareCommand);

        /// <summary>
        /// Returns Tuple with two values: hasResult if the query has returned result and result of type Dictionary where the key is String and the Value is object which holds the returned values, if hasResult is false the result is default.
        /// This is for queries which returns single result.
        /// </summary>
        /// <param name="query">The sql command.</param>
        /// <param name="parameters">Collection of SqlEParameter.</param>
        /// <param name="isStoredProcedure">Boolean to use stored procedure.</param>
        /// <param name="prepareCommand">Boolean to prepare command (Creates a prepared (or compiled) version of the command on the data source).</param>
        /// <returns>Tuple with two values: hasResult if there is a result of the sql query and result of type Dictionary where the key is String and the Value is object which holds the returned values. If hasResult is false result is equal to default.</returns>
        (bool hasResult, Dictionary<string, object>) Single(string query, 
            IEnumerable<SqlEParameter> parameters, 
            bool isStoredProcedure, 
            bool prepareCommand);

        /// <summary>
        /// Returns Task where the result is Tuple with two values: hasResult if the query has returned result and result of type Dictionary where the key is String and the Value is object which holds the returned values, if hasResult is false the result is default.
        /// This is for queries which returns single result.
        /// </summary>
        /// <param name="query">The sql command.</param>
        /// <param name="parameters">Collection of SqlEParameter.</param>
        /// <param name="isStoredProcedure">Boolean to use stored procedure.</param>
        /// <param name="prepareCommand">Boolean to prepare command (Creates a prepared (or compiled) version of the command on the data source).</param>
        /// <returns>Task where the result is Tuple with two values: hasResult if there is a result of the sql query and result of type Dictionary where the key is String and the Value is object which holds the returned values. If hasResult is false result is equal to default.</returns>
        Task<(bool hasResult, Dictionary<string, object>)> SingleAsync(string query, 
            IEnumerable<SqlEParameter> parameters, 
            bool isStoredProcedure, 
            bool prepareCommand);

        #region MultipleResults

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
        (List<TFirst> first, List<TSecond> second) QueryMultiple<TFirst, TSecond>(string query, 
            IEnumerable<SqlEParameter> parameters, 
            bool isStoredProcedure, 
            bool prepareCommand);

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
        Task<(List<TFirst> first, List<TSecond> second)> QueryMultipleAsync<TFirst, TSecond>(string query, 
            IEnumerable<SqlEParameter> parameters, 
            bool isStoredProcedure, 
            bool prepareCommand);

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
        (List<TFirst> first, List<TSecond> second, List<TThird> third) QueryMultiple<TFirst, TSecond, TThird>(string query, 
            IEnumerable<SqlEParameter> parameters, 
            bool isStoredProcedure, 
            bool prepareCommand);

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
        Task<(List<TFirst> first, List<TSecond> second, List<TThird> third)> QueryMultipleAsync<TFirst, TSecond, TThird>(string query, 
            IEnumerable<SqlEParameter> parameters, 
            bool isStoredProcedure, 
            bool prepareCommand);

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
        (List<TFirst> first, List<TSecond> second, List<TThird> third, List<TFourth> fourth) QueryMultiple<TFirst, TSecond, TThird, TFourth>(string query, 
            IEnumerable<SqlEParameter> parameters, 
            bool isStoredProcedure, 
            bool prepareCommand);

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
        Task<(List<TFirst> first, List<TSecond> second, List<TThird> third, List<TFourth> fourth)> QueryMultipleAsync<TFirst, TSecond, TThird, TFourth>(string query, 
            IEnumerable<SqlEParameter> parameters, 
            bool isStoredProcedure,
            bool prepareCommand);

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
        (List<TFirst> first, List<TSecond> second, List<TThird> third, List<TFourth> fourth, List<TFifth> fifth) QueryMultiple<TFirst, TSecond, TThird, TFourth, TFifth>(string query, 
            IEnumerable<SqlEParameter> parameters, 
            bool isStoredProcedure, 
            bool prepareCommand);

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
        Task<(List<TFirst> first, List<TSecond> second, List<TThird> third, List<TFourth> fourth, List<TFifth> fifth)> QueryMultipleAsync<TFirst, TSecond, TThird, TFourth, TFifth>(string query, 
            IEnumerable<SqlEParameter> parameters, 
            bool isStoredProcedure, 
            bool prepareCommand);

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
        (List<TFirst> first, List<TSecond> second, List<TThird> third, List<TFourth> fourth, List<TFifth> fifth, List<TSixth> sixth) QueryMultiple<TFirst, TSecond, TThird, TFourth, TFifth, TSixth>(string query, 
            IEnumerable<SqlEParameter> parameters, 
            bool isStoredProcedure, 
            bool prepareCommand);

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
        Task<(List<TFirst> first, List<TSecond> second, List<TThird> third, List<TFourth> fourth, List<TFifth> fifth, List<TSixth> sixth)> QueryMultipleAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth>(string query, 
            IEnumerable<SqlEParameter> parameters, 
            bool isStoredProcedure, 
            bool prepareCommand);

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
        (List<TFirst> first, List<TSecond> second, List<TThird> third, List<TFourth> fourth, List<TFifth> fifth, List<TSixth> sixth, List<TSeventh> seventh) QueryMultiple<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh>(string query, 
            IEnumerable<SqlEParameter> parameters, 
            bool isStoredProcedure, 
            bool prepareCommand);

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
        Task<(List<TFirst> first, List<TSecond> second, List<TThird> third, List<TFourth> fourth, List<TFifth> fifth, List<TSixth> sixth, List<TSeventh> seventh)> QueryMultipleAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh>(string query, 
            IEnumerable<SqlEParameter> parameters, 
            bool isStoredProcedure, 
            bool prepareCommand);

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
        (List<TFirst> first, List<TSecond> second, List<TThird> third, List<TFourth> fourth, List<TFifth> fifth, List<TSixth> sixth, List<TSeventh> seventh, List<TEighth> eighth) QueryMultiple<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEighth>(string query, 
            IEnumerable<SqlEParameter> parameters, 
            bool isStoredProcedure, 
            bool prepareCommand);

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
        Task<(List<TFirst> first, List<TSecond> second, List<TThird> third, List<TFourth> fourth, List<TFifth> fifth, List<TSixth> sixth, List<TSeventh> seventh, List<TEighth> eighth)> QueryMultipleAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEighth>(string query, 
            IEnumerable<SqlEParameter> parameters, 
            bool isStoredProcedure, 
            bool prepareCommand);

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
        (List<TFirst> first, List<TSecond> second, List<TThird> third, List<TFourth> fourth, List<TFifth> fifth, List<TSixth> sixth, List<TSeventh> seventh, List<TEighth> eighth, List<TNinth> ninth) QueryMultiple<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEighth, TNinth>(string query, 
            IEnumerable<SqlEParameter> parameters, 
            bool isStoredProcedure, 
            bool prepareCommand);

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
        Task<(List<TFirst> first, List<TSecond> second, List<TThird> third, List<TFourth> fourth, List<TFifth> fifth, List<TSixth> sixth, List<TSeventh> seventh, List<TEighth> eighth, List<TNinth> ninth)> QueryMultipleAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEighth, TNinth>(string query, 
            IEnumerable<SqlEParameter> parameters, 
            bool isStoredProcedure,
            bool prepareCommand);

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
        (List<TFirst> first, List<TSecond> second, List<TThird> third, List<TFourth> fourth, List<TFifth> fifth, List<TSixth> sixth, List<TSeventh> seventh, List<TEighth> eighth, List<TNinth> ninth, List<TTenth> tenth) QueryMultiple<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEighth, TNinth, TTenth>(string query, 
            IEnumerable<SqlEParameter> parameters, 
            bool isStoredProcedure, 
            bool prepareCommand);

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
        Task<(List<TFirst> first, List<TSecond> second, List<TThird> third, List<TFourth> fourth, List<TFifth> fifth, List<TSixth> sixth, List<TSeventh> seventh, List<TEighth> eighth, List<TNinth> ninth, List<TTenth> tenth)> QueryMultipleAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TEighth, TNinth, TTenth>(string query, 
            IEnumerable<SqlEParameter> parameters, 
            bool isStoredProcedure, 
            bool prepareCommand);

        #endregion
    }
}