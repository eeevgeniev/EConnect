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
    /// Class for parsing Dictionary where the key is string and the value is object from DbDataReader.
    /// </summary>
    internal class DictionaryParser : BaseParser, IParser<Dictionary<string, object>>
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

                    func = this.GetFunc(type);

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

                        func = this.GetFunc(type);

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

        private Func<DbDataReader, int, object> GetFunc(Type type)
        {
            if (type == BaseTypeHelper.StringType) 
            { 
                return this.GetString; 
            }
            else if (type == BaseTypeHelper.ByteType) 
            { 
                return this.GetByte; 
            }
            else if (type == BaseTypeHelper.NullableByteType) 
            { 
                return this.GetNullableByte; 
            }
            else if (type == BaseTypeHelper.ShortType) 
            { 
                return this.GetShort; 
            }
            else if (type == BaseTypeHelper.NullableShortType) 
            { 
                return this.GetNullableShort; 
            }
            else if (type == BaseTypeHelper.IntegerType) 
            { 
                return this.GetInt; 
            }
            else if (type == BaseTypeHelper.NullableIntegerType) 
            { 
                return this.GetNullableInt; 
            }
            else if (type == BaseTypeHelper.LongType) 
            { 
                return this.GetLong; 
            }
            else if (type == BaseTypeHelper.NullableLongType) 
            { 
                return this.GetNullableLong; 
            }
            else if (type == BaseTypeHelper.FloatType) 
            { 
                return this.GetFloat; 
            }
            else if (type == BaseTypeHelper.NullableFloatType) 
            { 
                return this.GetNullableFloat; 
            }
            else if (type == BaseTypeHelper.DoubleType) 
            { 
                return this.GetDouble; 
            }
            else if (type == BaseTypeHelper.NullableDoubleType) 
            { 
                return this.GetNullableDouble; 
            }
            else if (type == BaseTypeHelper.DecimalType) 
            { 
                return this.GetDecimal; 
            }
            else if (type == BaseTypeHelper.NullableDecimalType) 
            { 
                return this.GetNullableDecimal; 
            }
            else if (type == BaseTypeHelper.DateTimeType) 
            { 
                return this.GetDateTime; 
            }
            else if (type == BaseTypeHelper.NullableDateTimeType) 
            { 
                return this.GetNullableDateTime; 
            }
            else if (type == BaseTypeHelper.BooleanType) 
            { 
                return GetBoolean; 
            }
            else if (type == BaseTypeHelper.CharType) 
            { 
                return this.GetChar; 
            }
            else if (type == BaseTypeHelper.NullableCharType) 
            { 
                return this.GetNullableChar; 
            }
            else if (type == BaseTypeHelper.NullableBooleanType) 
            { 
                return this.GetNullableBoolean; 
            }
            else if (type == BaseTypeHelper.GuidType) 
            { 
                return this.GetGuid;
            }
            else if (type == BaseTypeHelper.NullableGuidType) 
            { 
                return this.GetNullableGuid; 
            }
            else if (type == BaseTypeHelper.ByteArrayType) 
            { 
                return this.GetBytes; 
            }
            else if (type == BaseTypeHelper.CharArrayType) 
            { 
                return this.GetChars; 
            }
            else if (type == BaseTypeHelper.StreamType) 
            { 
                return this.GetStream; 
            }
            else if (type == BaseTypeHelper.SByteType) 
            { 
                return this.GetSByte; 
            }
            else if (type == BaseTypeHelper.NullableSByteType) 
            { 
                return this.GetNullableSByte; 
            }
            else if (type == BaseTypeHelper.UShortType) 
            { 
                return this.GetUShort; 
            }
            else if (type == BaseTypeHelper.NullableUShortType) 
            { 
                return this.GetNullableUShort; 
            }
            else if (type == BaseTypeHelper.UIntegerType) 
            { 
                return this.GetUInt; 
            }
            else if (type == BaseTypeHelper.NullableUIntegerType) 
            { 
                return this.GetNullableUInt; 
            }
            else if (type == BaseTypeHelper.ULongType) 
            { 
                return this.GetULong; 
            }
            else if (type == BaseTypeHelper.NullableULongType) 
            { 
                return this.GetNullableULong; 
            }

            return null;
        }

        private object GetString(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return dbDataReader.GetString(index);
            }

            return null;
        }

        private object GetByte(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return dbDataReader.GetByte(index);
            }

            return null;
        }

        private object GetNullableByte(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return dbDataReader.GetByte(index);
            }

            return null;
        }

        private object GetShort(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return dbDataReader.GetInt16(index);
            }

            return null;
        }

        private object GetNullableShort(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return dbDataReader.GetInt16(index);
            }

            return null;
        }

        private object GetInt(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return dbDataReader.GetInt32(index);
            }

            return null;
        }

        private object GetNullableInt(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return dbDataReader.GetInt32(index);
            }

            return null;
        }

        private object GetLong(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return dbDataReader.GetInt64(index);
            }

            return null;
        }

        private object GetNullableLong(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return dbDataReader.GetInt64(index);
            }

            return null;
        }

        private object GetFloat(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return dbDataReader.GetFloat(index);
            }

            return null;
        }

        private object GetNullableFloat(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return dbDataReader.GetFloat(index);
            }

            return null;
        }

        private object GetDouble(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return dbDataReader.GetDouble(index);
            }

            return null;
        }

        private object GetNullableDouble(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return dbDataReader.GetDouble(index);
            }

            return null;
        }

        private object GetDecimal(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return dbDataReader.GetDecimal(index);
            }

            return null;
        }

        private object GetNullableDecimal(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return dbDataReader.GetDecimal(index);
            }

            return null;
        }

        private object GetDateTime(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return dbDataReader.GetDateTime(index);
            }

            return null;
        }

        private object GetNullableDateTime(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return dbDataReader.GetDateTime(index);
            }

            return null;
        }

        private object GetBoolean(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return dbDataReader.GetBoolean(index);
            }

            return null;
        }

        private object GetNullableBoolean(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return dbDataReader.GetBoolean(index);
            }

            return null;
        }

        private object GetChar(DbDataReader dbDataReader, int index)
        {
            return CharsHelperParser.GetCharFromString(dbDataReader, index);
        }

        private object GetNullableChar(DbDataReader dbDataReader, int index)
        {
            return CharsHelperParser.GetNullableCharFromString(dbDataReader, index);
        }

        private object GetGuid(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return dbDataReader.GetGuid(index);
            }

            return null;
        }

        private object GetNullableGuid(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return dbDataReader.GetGuid(index);
            }

            return null;
        }

        private object GetBytes(DbDataReader dbDataReader, int index)
        {
            return BytesHelperParser.GetBytes(dbDataReader, index);
        }

        private object GetChars(DbDataReader dbDataReader, int index)
        {
            return CharsHelperParser.GetChars(dbDataReader, index);
        }

        private object GetStream(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                MemoryStream memoryStream = new MemoryStream();
                dbDataReader.GetStream(index).CopyTo(memoryStream);
                memoryStream.Position = 0;

                return memoryStream;
            }

            return null;
        }

        private object GetSByte(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return Convert.ToSByte(dbDataReader.GetValue(index));
            }

            return null;
        }

        private object GetNullableSByte(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return Convert.ToSByte(dbDataReader.GetValue(index));
            }

            return null;
        }

        private object GetUShort(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return Convert.ToUInt16(dbDataReader.GetValue(index));
            }

            return null;
        }

        private object GetNullableUShort(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return Convert.ToUInt16(dbDataReader.GetValue(index));
            }

            return null;
        }

        private object GetUInt(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return Convert.ToUInt32(dbDataReader.GetValue(index));
            }

            return null;
        }

        private object GetNullableUInt(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return Convert.ToUInt32(dbDataReader.GetValue(index));
            }

            return null;
        }

        private object GetULong(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return Convert.ToUInt64(dbDataReader.GetValue(index));
            }

            return null;
        }

        private object GetNullableULong(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return Convert.ToUInt64(dbDataReader.GetValue(index));
            }

            return null;
        }
    }
}
