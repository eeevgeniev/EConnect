using SQLEConnect.Interfaces;
using SQLEConnect.Parsers.Base;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace SQLEConnect.Parsers
{
    /// <summary>
    /// Class for parsing Object from DbDataReader.
    /// Only the public Properties or Fields are parsed.
    /// It uses the constructor with least parameters.
    /// The constructor must accept default values and must not throw exception.
    /// </summary>
    internal sealed class ObjectParser<TModel> : BaseObjectParser<TModel>, IParser<TModel>
    {
        private Func<TModel> _newFunc;
        private Dictionary<string, Func<TModel, DbDataReader, int, TModel>> _funcByNames = new Dictionary<string, Func<TModel, DbDataReader, int, TModel>>();

        /// <summary>
        /// Constructor creates delegate with Returns new Value of type TModel.
        /// Creates Dictionary where the key is a string - a name of public property/field in lower case and the value - delegate which accept three parameters: DbDataReader, the next index of the FieldPosition and the TModel, and returns the TModel.
        /// The Func<TModel, DbDataReader, int, TModel> receives the TModel and sets a public property/field from the DbDataReader.
        /// </summary>
        public ObjectParser()
        {
            this._newFunc = base.BuildNewFunc();
            this._funcByNames = base.BuildObjectPropertiesExpressions();

            if (this._funcByNames.Count == 0)
            {
                this._funcByNames = base.BuildObjectFieldsExpressions();
            }
        }

        /// <summary>
        /// Returns IEnumerable where the result is TModel.
        /// </summary>
        /// <param name="dbDataReader">DbDataReader, must be not null.</param>
        /// <returns>IEnumerable where the result is TModel.</returns>
        public IEnumerable<TModel> Parse(DbDataReader dbDataReader)
        {
            base.ValidateDbDataReader(dbDataReader);

            Dictionary<int, Func<TModel, DbDataReader, int, TModel>> cachedFuncByPosition = new Dictionary<int, Func<TModel, DbDataReader, int, TModel>>();
            TModel model = this._newFunc();

            if (dbDataReader.Read())
            {
                string name;

                for (int i = 0; i < dbDataReader.FieldCount; i++)
                {
                    name = dbDataReader.GetName(i)?.ToLower();

                    if (!string.IsNullOrWhiteSpace(name) && this._funcByNames.TryGetValue(name, out Func<TModel, DbDataReader, int, TModel> propertySetterFunc))
                    {
                        model = propertySetterFunc(model, dbDataReader, i);
                        cachedFuncByPosition.Add(i, propertySetterFunc);
                    }
                }

                if (cachedFuncByPosition.Count > 0)
                {
                    yield return model;

                    while (dbDataReader.Read())
                    {
                        model = this._newFunc();

                        foreach (int index in cachedFuncByPosition.Keys)
                        {
                            model = cachedFuncByPosition[index](model, dbDataReader, index);
                        }

                        yield return model;
                    }
                }
            }
        }

        /// <summary>
        /// Returns only one result from the DbDataReader.
        /// </summary>
        /// <param name="dbDataReader">DbDataReader, must be not null.</param>
        /// <returns>Tuple with two results: hasResult - Boolean if if any result is returned, result - the actual result, default if hasResult is false.</returns>
        public (bool hasResult, TModel result) ParseSingle(DbDataReader dbDataReader)
        {
            base.ValidateDbDataReader(dbDataReader);

            if (dbDataReader.Read())
            {
                string name;
                TModel model = default;

                if (dbDataReader.FieldCount > 0)
                {
                    model = this._newFunc();

                    for (int i = 0; i < dbDataReader.FieldCount; i++)
                    {
                        name = dbDataReader.GetName(i)?.ToLower();

                        if (!string.IsNullOrWhiteSpace(name) && this._funcByNames.TryGetValue(name, out Func<TModel, DbDataReader, int, TModel> propertySetterFunc))
                        {
                            model = propertySetterFunc(model, dbDataReader, i);
                        }
                    }

                    return (true, model);
                }
            }

            return (false, default);
        }

        /// <summary>
        /// Helper method to determinate for which type the parser is responisble.
        /// </summary>
        /// <returns>Type - for which type the parser is responisble.</returns>
        public Type Type() => typeof(TModel);
    }
}
