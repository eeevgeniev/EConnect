using SQLEConnect.Infrastructure;
using SQLEConnect.Interfaces;
using SQLEConnect.Parsers.Base;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace SQLEConnect.Parsers
{
    /// <summary>
    /// Class for parsing Integer from DbDataReader, the Integer the value must be contained in the first field column (index 0) in the DbDataReader.
    /// For every record only one the first field column is checked.
    /// </summary>
    internal sealed class IntParser : BaseParser, IParser<int>
    {
        /// <summary>
        /// Returns IEnumerable where the result is Integer, only the first column is checked.
        /// </summary>
        /// <param name="dbDataReader">DbDataReader, must be not null.</param>
        /// <returns>IEnumerable where the result is Integer.</returns>
        public IEnumerable<int> Parse(DbDataReader dbDataReader)
        {
            base.ValidateDbDataReader(dbDataReader);

            int defaultValue = default;

            if (dbDataReader.Read() && dbDataReader.FieldCount > 0)
            {
                yield return (!dbDataReader.IsDBNull(0) ? dbDataReader.GetInt32(0) : defaultValue);

                while (dbDataReader.Read())
                {
                    yield return (!dbDataReader.IsDBNull(0) ? dbDataReader.GetInt32(0) : defaultValue);
                }
            }
        }

        /// <summary>
        /// Returns only one result from the DbDataReader, the Integer value must be contained in the first field column (index 0) in the DbDataReader.
        /// Only one the first field colum is checked.
        /// </summary>
        /// <param name="dbDataReader">DbDataReader, must be not null.</param>
        /// <returns>Tuple with two results: hasResult - Boolean if if any result is returned, result - the actual result, default if hasResult is false.</returns>
        public (bool hasResult, int result) ParseSingle(DbDataReader dbDataReader)
        {
            base.ValidateDbDataReader(dbDataReader);

            int defaultValue = default;

            return (dbDataReader.Read() && dbDataReader.FieldCount > 0) ?
                (true, (!dbDataReader.IsDBNull(0) ? dbDataReader.GetInt32(0) : defaultValue)) :
                (false, defaultValue);
        }

        /// <summary>
        /// Helper method to determinate for which type the parser is responisble.
        /// </summary>
        /// <returns>Type - for which type the parser is responisble.</returns>
        public Type Type() => BaseTypeHelper.IntegerType;
    }
}