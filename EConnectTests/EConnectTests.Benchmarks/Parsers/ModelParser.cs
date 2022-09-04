using EConnect.Interfaces;
using EConnectTests.Benchmarks.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace EConnectTests.Benchmarks.Parsers
{
    public class ModelParser : IParser<Model>
    {
        public IEnumerable<Model> Parse(DbDataReader dbDataReader)
        {
            while (dbDataReader.Read())
            {
                Model model = new Model();
                string name;

                for (int i = 0; i < dbDataReader.FieldCount; i++)
                {
                    name = dbDataReader.GetName(i).ToLower();

                    if (name.Equals(nameof(Model.Id), StringComparison.OrdinalIgnoreCase))
                    {
                        model.Id = dbDataReader.GetInt32(i);
                    }
                    else if (name.Equals(nameof(Model.Strp), StringComparison.OrdinalIgnoreCase))
                    {
                        model.Strp = dbDataReader.GetString(i);
                    }
                    else if (name.Equals(nameof(Model.Chr), StringComparison.OrdinalIgnoreCase))
                    {
                        model.Chr = dbDataReader.GetString(i);
                    }
                    else if (name.Equals(nameof(Model.Char), StringComparison.OrdinalIgnoreCase))
                    {
                        model.Char = dbDataReader.GetString(i);
                    }
                    else if (name.Equals(nameof(Model.Date), StringComparison.OrdinalIgnoreCase))
                    {
                        model.Date = dbDataReader.GetDateTime(i);
                    }
                    else if (name.Equals(nameof(Model.NDate), StringComparison.OrdinalIgnoreCase))
                    {
                        model.NDate = dbDataReader.GetDateTime(i);
                    }
                    else if (name.Equals(nameof(Model.Strs), StringComparison.OrdinalIgnoreCase))
                    {
                        model.Strs = dbDataReader.GetString(i);
                    }
                    else if (name.Equals(nameof(Model.Strw), StringComparison.OrdinalIgnoreCase))
                    {
                        model.Strw = dbDataReader.GetString(i);
                    }
                    else if (name.Equals(nameof(Model.Dcml), StringComparison.OrdinalIgnoreCase))
                    {
                        model.Dcml = dbDataReader.GetDecimal(i);
                    }
                    else if (name.Equals(nameof(Model.Lng), StringComparison.OrdinalIgnoreCase))
                    {
                        model.Lng = dbDataReader.GetInt64(i);
                    }
                }

                yield return model;
            }
        }

        public (bool hasResult, Model result) ParseSingle(DbDataReader dbDataReader)
        {
            if (dbDataReader.Read() && dbDataReader.HasRows)
            {
                Model model = new Model();
                string name;

                for (int i = 0; i < dbDataReader.FieldCount; i++)
                {
                    name = dbDataReader.GetName(i).ToLower();

                    if (name.Equals(nameof(Model.Id), StringComparison.OrdinalIgnoreCase))
                    {
                        model.Id = dbDataReader.GetInt32(i);
                    }
                    else if (name.Equals(nameof(Model.Strp), StringComparison.OrdinalIgnoreCase))
                    {
                        model.Strp = dbDataReader.GetString(i);
                    }
                    else if (name.Equals(nameof(Model.Chr), StringComparison.OrdinalIgnoreCase))
                    {
                        model.Chr = dbDataReader.GetString(i);
                    }
                    else if (name.Equals(nameof(Model.Char), StringComparison.OrdinalIgnoreCase))
                    {
                        model.Char = dbDataReader.GetString(i);
                    }
                    else if (name.Equals(nameof(Model.Date), StringComparison.OrdinalIgnoreCase))
                    {
                        model.Date = dbDataReader.GetDateTime(i);
                    }
                    else if (name.Equals(nameof(Model.NDate), StringComparison.OrdinalIgnoreCase))
                    {
                        model.NDate = dbDataReader.GetDateTime(i);
                    }
                    else if (name.Equals(nameof(Model.Strs), StringComparison.OrdinalIgnoreCase))
                    {
                        model.Strs = dbDataReader.GetString(i);
                    }
                    else if (name.Equals(nameof(Model.Strw), StringComparison.OrdinalIgnoreCase))
                    {
                        model.Strw = dbDataReader.GetString(i);
                    }
                    else if (name.Equals(nameof(Model.Dcml), StringComparison.OrdinalIgnoreCase))
                    {
                        model.Dcml = dbDataReader.GetDecimal(i);
                    }
                    else if (name.Equals(nameof(Model.Lng), StringComparison.OrdinalIgnoreCase))
                    {
                        model.Lng = dbDataReader.GetInt64(i);
                    }
                }

                return (true, model);
            }

            return (false, default);
        }

        public Type Type() => typeof(Model);
    }
}
