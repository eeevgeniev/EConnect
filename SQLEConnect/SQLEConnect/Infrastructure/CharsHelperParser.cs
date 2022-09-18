using System;
using System.Data.Common;

namespace SQLEConnect.Infrastructure
{
    /// <summary>
    /// Helper class for reading char[] from GetChars method of DbDataReader.
    /// </summary>
    internal static class CharsHelperParser
    {
        /// <summary>
        /// Reads all chars from GetChars method of DbDataReader .
        /// </summary>
        /// <param name="dbDataReader">The DbDataReader.</param>
        /// <param name="dbDataReaderIndex">The index of the property (The zero-based column ordinal.).</param>
        /// <returns>Array of Char.</returns>
        internal static char[] GetChars(DbDataReader dbDataReader, int dbDataReaderIndex)
        {
            if (dbDataReader.IsDBNull(dbDataReaderIndex))
            {
                return default;
            }

            int bufferSize = 1024;

            char[] chars = new char[0];
            char[] buffer = new char[bufferSize];
            long index = 0;

            long readedBytes = dbDataReader.GetChars(dbDataReaderIndex, index, buffer, 0, bufferSize);

            while (readedBytes == bufferSize)
            {
                Array.Resize(ref chars, chars.Length + bufferSize);
                Array.Copy(buffer, 0, chars, index, bufferSize);

                index += readedBytes;

                readedBytes = dbDataReader.GetChars(dbDataReaderIndex, index, buffer, 0, bufferSize);
            }

            Array.Resize(ref chars, chars.Length + (int)readedBytes);
            Array.Copy(buffer, 0, chars, index, readedBytes);

            return chars;
        }

        /// <summary>
        /// Reads the first char from GetString method of DbDataReader. It may return default of char if the string is null or white space.
        /// </summary>
        /// <param name="dbDataReader">The DbDataReader.</param>
        /// <param name="dbDataReaderIndex">The index of the property (The zero-based column ordinal.).</param>
        /// <returns>Array of Char.</returns>
        internal static char GetCharFromString(DbDataReader dbDataReader, int dbDataReaderIndex)
        {
            if (dbDataReader.IsDBNull(dbDataReaderIndex))
            {
                return default;
            }

            string letters = dbDataReader.GetString(dbDataReaderIndex);

            if (string.IsNullOrWhiteSpace(letters))
            {
                return default;
            }

            if (letters.Length != 1)
            {
                throw new InvalidOperationException("Char is expected but hte result returned string.");
            }

            return letters[0];
        }

        /// <summary>
        /// Reads the first char from GetString method of DbDataReader. It may return default of nullable char if the string is null or white space.
        /// </summary>
        /// <param name="dbDataReader">The DbDataReader.</param>
        /// <param name="dbDataReaderIndex">The index of the property (The zero-based column ordinal.).</param>
        /// <returns>Array of Nullable Char.</returns>
        internal static char? GetNullableCharFromString(DbDataReader dbDataReader, int dbDataReaderIndex)
        {
            if (dbDataReader.IsDBNull(dbDataReaderIndex))
            {
                return default;
            }

            string letters = dbDataReader.GetString(dbDataReaderIndex);

            if (string.IsNullOrWhiteSpace(letters))
            {
                return default;
            }

            if (letters.Length != 1)
            {
                throw new InvalidOperationException("Nullable char is expected but hte result returned string.");
            }

            return letters[0];
        }
    }
}