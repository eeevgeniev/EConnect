using System;
using System.Data.Common;

namespace SQLEConnect.Infrastructure
{
    /// <summary>
    /// Helper class for calling GetBytes method of DbDataReader .
    /// </summary>
    internal static class BytesHelperParser
    {
        /// <summary>
        /// Reads all bytes from GetBytes method of DbDataReader .
        /// </summary>
        /// <param name="dbDataReader">The DbDataReader.</param>
        /// <param name="dbDataReaderIndex">The index of the property (The zero-based column ordinal.).</param>
        /// <returns>Array of Byte.</returns>
        internal static byte[] GetBytes(DbDataReader dbDataReader, int dbDataReaderIndex)
        {
            if (dbDataReader.IsDBNull(dbDataReaderIndex))
            {
                return default;
            }

            int bufferSize = 1024;

            byte[] bytes = new byte[0];
            byte[] buffer = new byte[bufferSize];
            long index = 0;

            long readedBytes = dbDataReader.GetBytes(dbDataReaderIndex, index, buffer, 0, bufferSize);

            while (readedBytes == bufferSize)
            {
                Array.Resize(ref bytes, bytes.Length + bufferSize);
                Array.Copy(buffer, 0, bytes, index, bufferSize);

                index += readedBytes;

                readedBytes = dbDataReader.GetBytes(dbDataReaderIndex, index, buffer, 0, bufferSize);
            }

            Array.Resize(ref bytes, bytes.Length + (int)readedBytes);
            Array.Copy(buffer, 0, bytes, index, readedBytes);

            return bytes;
        }
    }
}
