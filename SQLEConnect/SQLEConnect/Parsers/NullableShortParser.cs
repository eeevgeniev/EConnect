using SQLEConnect.Infrastructure;
using SQLEConnect.Interfaces;
using SQLEConnect.Parsers.Base;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace SQLEConnect.Parsers
{
    /// <summary>
    /// Class for parsing Nullable Short from DbDataReader, the Nullable Short the value must be contained in the first field column (index 0) in the DbDataReader.
    /// For every record only one the first field column is checked.
    /// </summary>
    internal sealed class NullableShortParser : BaseParser, IParser<short?>
    {
        /// <summary>
        /// Returns IEnumerable where the result is Nullable Short, only the first column is checked.
        /// </summary>
        /// <param name="dbDataReader">DbDataReader, must be not null.</param>
        /// <returns>IEnumerable where the result is Nullable Short.</returns>
        public IEnumerable<short?> Parse(DbDataReader dbDataReader)
        {
            base.ValidateDbDataReader(dbDataReader);

            short? defaultValue = default;

            if (dbDataReader.Read() && dbDataReader.FieldCount > 0)
            {
                yield return (!dbDataReader.IsDBNull(0) ? dbDataReader.GetInt16(0) : defaultValue);

                while (dbDataReader.Read())
                {
                    yield return (!dbDataReader.IsDBNull(0) ? dbDataReader.GetInt16(0) : defaultValue);
                }
            }
        }

        /// <summary>
        /// Returns only one result from the DbDataReader, the Nullable Short value must be contained in the first field column (index 0) in the DbDataReader.
        /// Only one the first field colum is checked.
        /// </summary>
        /// <param name="dbDataReader">DbDataReader, must be not null.</param>
        /// <returns>Tuple with two results: hasResult - Boolean if if any result is returned, result - the actual result, default if hasResult is false.</returns>
        public (bool hasResult, short? result) ParseSingle(DbDataReader dbDataReader)
        {
            base.ValidateDbDataReader(dbDataReader);

            short? defaultValue = default;

            return (dbDataReader.Read() && dbDataReader.FieldCount > 0) ?
                (true, (!dbDataReader.IsDBNull(0) ? dbDataReader.GetInt16(0) : defaultValue)) :
                (false, defaultValue);
        }

        /// <summary>
        /// Helper method to determinate for which type the parser is responisble.
        /// </summary>
        /// <returns>Type - for which type the parser is responisble.</returns>
        public Type Type() => BaseTypeHelper.NullableShortType;
    }
}