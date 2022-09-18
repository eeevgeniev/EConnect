using SQLEConnect.Infrastructure;
using System;
using System.Data.Common;
using System.IO;

namespace SQLEConnect.Parsers.Base
{
    internal class BaseKeyValueParser : BaseParser
    {
        protected Func<DbDataReader, int, object> GetFunc(Type type)
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

        protected object GetString(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return dbDataReader.GetString(index);
            }

            return null;
        }

        protected object GetByte(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return dbDataReader.GetByte(index);
            }

            return null;
        }

        protected object GetNullableByte(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return dbDataReader.GetByte(index);
            }

            return null;
        }

        protected object GetShort(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return dbDataReader.GetInt16(index);
            }

            return null;
        }

        protected object GetNullableShort(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return dbDataReader.GetInt16(index);
            }

            return null;
        }

        protected object GetInt(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return dbDataReader.GetInt32(index);
            }

            return null;
        }

        protected object GetNullableInt(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return dbDataReader.GetInt32(index);
            }

            return null;
        }

        protected object GetLong(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return dbDataReader.GetInt64(index);
            }

            return null;
        }

        protected object GetNullableLong(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return dbDataReader.GetInt64(index);
            }

            return null;
        }

        protected object GetFloat(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return dbDataReader.GetFloat(index);
            }

            return null;
        }

        protected object GetNullableFloat(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return dbDataReader.GetFloat(index);
            }

            return null;
        }

        protected object GetDouble(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return dbDataReader.GetDouble(index);
            }

            return null;
        }

        protected object GetNullableDouble(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return dbDataReader.GetDouble(index);
            }

            return null;
        }

        protected object GetDecimal(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return dbDataReader.GetDecimal(index);
            }

            return null;
        }

        protected object GetNullableDecimal(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return dbDataReader.GetDecimal(index);
            }

            return null;
        }

        protected object GetDateTime(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return dbDataReader.GetDateTime(index);
            }

            return null;
        }

        protected object GetNullableDateTime(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return dbDataReader.GetDateTime(index);
            }

            return null;
        }

        protected object GetBoolean(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return dbDataReader.GetBoolean(index);
            }

            return null;
        }

        protected object GetNullableBoolean(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return dbDataReader.GetBoolean(index);
            }

            return null;
        }

        protected object GetChar(DbDataReader dbDataReader, int index)
        {
            return CharsHelperParser.GetCharFromString(dbDataReader, index);
        }

        protected object GetNullableChar(DbDataReader dbDataReader, int index)
        {
            return CharsHelperParser.GetNullableCharFromString(dbDataReader, index);
        }

        protected object GetGuid(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return dbDataReader.GetGuid(index);
            }

            return null;
        }

        protected object GetNullableGuid(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return dbDataReader.GetGuid(index);
            }

            return null;
        }

        protected object GetBytes(DbDataReader dbDataReader, int index)
        {
            return BytesHelperParser.GetBytes(dbDataReader, index);
        }

        protected object GetChars(DbDataReader dbDataReader, int index)
        {
            return CharsHelperParser.GetChars(dbDataReader, index);
        }

        protected object GetStream(DbDataReader dbDataReader, int index)
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

        protected object GetSByte(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return Convert.ToSByte(dbDataReader.GetValue(index));
            }

            return null;
        }

        protected object GetNullableSByte(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return Convert.ToSByte(dbDataReader.GetValue(index));
            }

            return null;
        }

        protected object GetUShort(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return Convert.ToUInt16(dbDataReader.GetValue(index));
            }

            return null;
        }

        protected object GetNullableUShort(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return Convert.ToUInt16(dbDataReader.GetValue(index));
            }

            return null;
        }

        protected object GetUInt(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return Convert.ToUInt32(dbDataReader.GetValue(index));
            }

            return null;
        }

        protected object GetNullableUInt(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return Convert.ToUInt32(dbDataReader.GetValue(index));
            }

            return null;
        }

        protected object GetULong(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return Convert.ToUInt64(dbDataReader.GetValue(index));
            }

            return null;
        }

        protected object GetNullableULong(DbDataReader dbDataReader, int index)
        {
            if (!dbDataReader.IsDBNull(index))
            {
                return Convert.ToUInt64(dbDataReader.GetValue(index));
            }

            return null;
        }
    }
}
