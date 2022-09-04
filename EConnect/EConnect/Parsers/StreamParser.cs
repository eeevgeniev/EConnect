using EConnect.Infrastructure;
using EConnect.Interfaces;
using EConnect.Parsers.Base;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;

namespace EConnect.Parsers
{
    /// <summary>
    /// Class for parsing Short from DbDataReader, the Stream the value must be contained in the first field column (index 0) in the DbDataReader.
    /// For every record only one the first field column is checked.
    /// </summary>
    internal class StreamParser : BaseParser, IParser<Stream>
    {
        /// <summary>
        /// Returns IEnumerable where the result is Stream, only the first column is checked.
        /// The GetStream value is stored in MemoryStream because it may be disposed when DbDataReader is disposed (depends on the DbDataReader implementation).
        /// </summary>
        /// <param name="dbDataReader">DbDataReader, must be not null.</param>
        /// <returns>IEnumerable where the result is Short.</returns>
        public IEnumerable<Stream> Parse(DbDataReader dbDataReader)
        {
            base.ValidateDbDataReader(dbDataReader);

            Stream defaultValue = default;

            if (dbDataReader.Read() && dbDataReader.FieldCount > 0)
            {
                if (!dbDataReader.IsDBNull(0))
                {
                    MemoryStream memoryStream = new MemoryStream();
                    dbDataReader.GetStream(0).CopyTo(memoryStream);
                    memoryStream.Position = 0;

                    yield return memoryStream;
                }
                else
                {
                    yield return defaultValue;
                }
                
                while (dbDataReader.Read())
                {
                    if (!dbDataReader.IsDBNull(0))
                    {
                        MemoryStream memoryStream = new MemoryStream();
                        dbDataReader.GetStream(0).CopyTo(memoryStream);
                        memoryStream.Position = 0;

                        yield return memoryStream;
                    }
                    else
                    {
                        yield return defaultValue;
                    }
                }
            }
        }

        /// <summary>
        /// Returns only one result from the DbDataReader, the Stream value must be contained in the first field column (index 0) in the DbDataReader.
        /// Only one the first field colum is checked.
        /// The GetStream value is stored in MemoryStream because it may be disposed when DbDataReader is disposed (depends on the DbDataReader implementation).
        /// </summary>
        /// <param name="dbDataReader">DbDataReader, must be not null.</param>
        /// <returns>Tuple with two results: hasResult - Boolean if if any result is returned, result - the actual result, default if hasResult is false.</returns>
        public (bool hasResult, Stream result) ParseSingle(DbDataReader dbDataReader)
        {
            base.ValidateDbDataReader(dbDataReader);

            Stream defaultValue = default;

            if (dbDataReader.Read() && dbDataReader.FieldCount > 0)
            {
                if (!dbDataReader.IsDBNull(0))
                {
                    MemoryStream memoryStream = new MemoryStream();
                    dbDataReader.GetStream(0).CopyTo(memoryStream);
                    memoryStream.Position = 0;

                    return (true, memoryStream);
                }
                else
                {
                    return (true, defaultValue);
                }
            }

            return (false, defaultValue);
        }

        /// <summary>
        /// Helper method to determinate for which type the parser is responisble.
        /// </summary>
        /// <returns>Type - for which type the parser is responisble.</returns>
        public Type Type() => BaseTypeHelper.StreamType;
    }
}