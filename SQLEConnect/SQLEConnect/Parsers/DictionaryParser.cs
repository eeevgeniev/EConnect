using SQLEConnect.Infrastructure;
using SQLEConnect.Interfaces;
using SQLEConnect.Parsers.Base;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace SQLEConnect.Parsers
{
    /// <summary>
    /// Class for parsing Dictionary where the key is string and the value is object from DbDataReader.
    /// </summary>
    internal sealed class DictionaryParser : BaseKeyValueParser, IParser<Dictionary<string, object>>
    {
        /// <summary>
        /// Returns IEnumerable where the result is Dictionary where the key is string and the value is object.
        /// </summary>
        /// <param name="dbDataReader">DbDataReader, must be not null.</param>
        /// <returns>IEnumerable where the result is Dictionary where the key is string and the value is object.</returns>
        public IEnumerable<Dictionary<string, object>> Parse(DbDataReader dbDataReader)
        {
            base.ValidateDbDataReader(dbDataReader);

            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            Dictionary<int, Func<DbDataReader, int, object>> cashedFuncById = new Dictionary<int, Func<DbDataReader, int, object>>();

            if (dbDataReader.Read())
            {
                string name;
                Type type;
                Func<DbDataReader, int, object> func;

                for (int i = 0; i < dbDataReader.FieldCount; i++)
                {
                    name = dbDataReader.GetName(i);
                    type = dbDataReader.GetFieldType(i);

                    if (dictionary.ContainsKey(name))
                    {
                        throw new InvalidOperationException($"Value with key {name} is already added.");
                    }

                    func = base.GetFunc(type);

                    if (func != null)
                    {
                        dictionary.Add(name, func(dbDataReader, i));
                        cashedFuncById.Add(i, func);
                    }
                }

                if (cashedFuncById.Count > 0)
                {
                    yield return dictionary;

                    while (dbDataReader.Read())
                    {
                        dictionary = new Dictionary<string, object>();

                        foreach (int i in cashedFuncById.Keys)
                        {
                            dictionary.Add(dbDataReader.GetName(i), cashedFuncById[i](dbDataReader, i));
                        }

                        yield return dictionary;
                    }
                }
            }
        }

        /// <summary>
        /// Returns only one result from the DbDataReader.
        /// </summary>
        /// <param name="dbDataReader">DbDataReader, must be not null.</param>
        /// <returns>Tuple with two results: hasResult - Boolean if if any result is returned, result - the actual result, default if hasResult is false.</returns>
        public (bool hasResult, Dictionary<string, object> result) ParseSingle(DbDataReader dbDataReader)
        {
            base.ValidateDbDataReader(dbDataReader);

            if (dbDataReader.Read())
            {
                if (dbDataReader.FieldCount > 0)
                {
                    Dictionary<string, object> dictionary = new Dictionary<string, object>();
                    string name;
                    Type type;
                    Func<DbDataReader, int, object> func;

                    for (int i = 0; i < dbDataReader.FieldCount; i++)
                    {
                        name = dbDataReader.GetName(i);
                        type = dbDataReader.GetFieldType(i);

                        if (dictionary.ContainsKey(name))
                        {
                            throw new InvalidOperationException($"Value with key {name} is already added.");
                        }

                        func = base.GetFunc(type);

                        if (func != null)
                        {
                            dictionary.Add(name, func(dbDataReader, i));
                        }
                    }

                    return (true, dictionary);
                }
            }

            return (false, default);
        }

        /// <summary>
        /// Helper method to determinate for which type the parser is responisble.
        /// </summary>
        /// <returns>Type - for which type the parser is responisble.</returns>
        public Type Type() => BaseTypeHelper.DictionaryType;
    }
}
