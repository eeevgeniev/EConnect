using SQLEConnect.Infrastructure;
using SQLEConnect.Interfaces;
using SQLEConnect.Parsers.Base;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace SQLEConnect.Parsers
{
    /// <summary>
    /// Class for parsing IEnumerable where the value is byte from DbDataReader, the IEnumerable of Byte the value must be contained in the first field column (index 0) in the DbDataReader.
    /// For every record only one the first field column is checked.
    /// </summary>
    internal sealed class BytesParser : BaseParser, IParser<byte[]>
    {
        /// <summary>
        /// Returns IEnumerable where the result is IEnumerable of Byte, only the first column is checked.
        /// </summary>
        /// <param name="dbDataReader">DbDataReader, must be not null.</param>
        /// <returns>IEnumerable where the result is IEnumerable of Byte.</returns>
        public IEnumerable<byte[]> Parse(DbDataReader dbDataReader)
        {
            base.ValidateDbDataReader(dbDataReader);

            byte[] defaultValue = default;

            if (dbDataReader.Read() && dbDataReader.FieldCount > 0)
            {
                yield return (!dbDataReader.IsDBNull(0) ? BytesHelperParser.GetBytes(dbDataReader, 0) : defaultValue);

                while (dbDataReader.Read())
                {
                    yield return (!dbDataReader.IsDBNull(0) ? BytesHelperParser.GetBytes(dbDataReader, 0) : defaultValue);
                }
            }
        }

        /// <summary>
        /// Returns only one result from the DbDataReader, the IEnumerable of Byte value must be contained in the first field column (index 0) in the DbDataReader.
        /// Only one the first field colum is checked.
        /// </summary>
        /// <param name="dbDataReader">DbDataReader, must be not null.</param>
        /// <returns>Tuple with two results: hasResult - Boolean if if any result is returned, result - the actual result, default if hasResult is false.</returns>
        public (bool hasResult, byte[] result) ParseSingle(DbDataReader dbDataReader)
        {
            base.ValidateDbDataReader(dbDataReader);

            byte[] defaultValue = default;

            return (dbDataReader.Read() && dbDataReader.FieldCount > 0) ?
                (true, (!dbDataReader.IsDBNull(0) ? BytesHelperParser.GetBytes(dbDataReader, 0) : defaultValue)) :
                (false, default);
        }

        /// <summary>
        /// Helper method to determinate for which type the parser is responisble.
        /// </summary>
        /// <returns>Type - for which type the parser is responisble.</returns>
        public Type Type() => BaseTypeHelper.ByteArrayType;
    }
}