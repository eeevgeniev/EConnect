using System.Data.Common;
using System.IO;

namespace EConnect.Infrastructure
{
    /// <summary>
    /// Helper class for reading Streams from GetStream method of DbDataReader.
    /// </summary>
    internal static class StreamHelperParser
    {
        /// <summary>
        /// Reads Stream from GetStream method of DbDataReader. The stream is loaded in MemoryStream.
        /// </summary>
        /// <param name="dbDataReader">DbDataReader.</param>
        /// <param name="dbDataReaderIndex">The index of the property (The zero-based column ordinal.).</param>
        /// <returns>(Stream) MemoryStream.</returns>
        internal static Stream GetStream(DbDataReader dbDataReader, int dbDataReaderIndex)
        {
            if (dbDataReader.IsDBNull(dbDataReaderIndex))
            {
                return default;
            }

            MemoryStream memoryStream = new MemoryStream();
            dbDataReader.GetStream(dbDataReaderIndex).CopyTo(memoryStream);
            memoryStream.Position = 0;

            return memoryStream;
        }
    }
}