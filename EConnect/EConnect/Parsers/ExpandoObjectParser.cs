using EConnect.Infrastructure;
using EConnect.Interfaces;
using EConnect.Parsers.Base;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Dynamic;

namespace EConnect.Parsers
{
    internal class ExpandoObjectParser : BaseKeyValueParser, IParser<object>
    {
        public IEnumerable<object> Parse(DbDataReader dbDataReader)
        {
            base.ValidateDbDataReader(dbDataReader);

            ExpandoObject expandoObject = new ExpandoObject();
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

                    func = base.GetFunc(type);

                    if (func != null)
                    {
                        if (!expandoObject.TryAdd(name, func(dbDataReader, i)))
                        {
                            throw new InvalidOperationException($"Value with key {name} is already added.");
                        }
                        
                        cashedFuncById.Add(i, func);
                    }
                }

                if (cashedFuncById.Count > 0)
                {
                    yield return expandoObject;

                    while (dbDataReader.Read())
                    {
                        expandoObject = new ExpandoObject();

                        foreach (int i in cashedFuncById.Keys)
                        {
                            expandoObject.TryAdd(dbDataReader.GetName(i), cashedFuncById[i](dbDataReader, i));
                        }

                        yield return expandoObject;
                    }
                }
            }
        }

        public (bool hasResult, object result) ParseSingle(DbDataReader dbDataReader)
        {
            base.ValidateDbDataReader(dbDataReader);

            if (dbDataReader.Read())
            {
                if (dbDataReader.FieldCount > 0)
                {
                    ExpandoObject expandoObject = new ExpandoObject();
                    string name;
                    Type type;
                    Func<DbDataReader, int, object> func;

                    for (int i = 0; i < dbDataReader.FieldCount; i++)
                    {
                        name = dbDataReader.GetName(i);
                        type = dbDataReader.GetFieldType(i);

                        func = base.GetFunc(type);

                        if (func != null)
                        {
                            if (!expandoObject.TryAdd(name, func(dbDataReader, i)))
                            {
                                throw new InvalidOperationException($"Value with key {name} is already added.");
                            }
                        }
                    }

                    return (true, expandoObject);
                }
            }

            return (false, default);
        }

        public Type Type() => BaseTypeHelper.ObjectType;
    }
}
