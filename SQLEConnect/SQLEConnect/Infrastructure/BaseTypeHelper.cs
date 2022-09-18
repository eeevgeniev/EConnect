using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;

namespace SQLEConnect.Infrastructure
{
    /// <summary>
    /// Helper class, contains all supported types.
    /// </summary>
    internal static class BaseTypeHelper
    {
        internal static Type StringType => typeof(string);

        internal static Type CharType => typeof(char);

        internal static Type NullableCharType => typeof(char?);

        internal static Type ByteType => typeof(byte);

        internal static Type NullableByteType => typeof(byte?);

        internal static Type SByteType => typeof(sbyte);

        internal static Type NullableSByteType => typeof(sbyte?);

        internal static Type ShortType => typeof(short);

        internal static Type NullableShortType => typeof(short?);

        internal static Type UShortType => typeof(ushort);

        internal static Type NullableUShortType => typeof(ushort?);

        internal static Type IntegerType => typeof(int);

        internal static Type NullableIntegerType => typeof(int?);

        internal static Type UIntegerType => typeof(uint);

        internal static Type NullableUIntegerType => typeof(uint?);

        internal static Type LongType => typeof(long);

        internal static Type NullableLongType => typeof(long?);

        internal static Type ULongType => typeof(ulong);

        internal static Type NullableULongType => typeof(ulong?);

        internal static Type FloatType => typeof(float);

        internal static Type NullableFloatType => typeof(float?);

        internal static Type DoubleType => typeof(double);

        internal static Type NullableDoubleType => typeof(double?);

        internal static Type DecimalType => typeof(decimal);

        internal static Type NullableDecimalType => typeof(decimal?);

        internal static Type DateTimeType => typeof(DateTime);

        internal static Type NullableDateTimeType => typeof(DateTime?);

        internal static Type BooleanType => typeof(bool);

        internal static Type NullableBooleanType => typeof(bool?);

        internal static Type GuidType => typeof(Guid);

        internal static Type NullableGuidType => typeof(Guid?);

        internal static Type ByteArrayType => typeof(byte[]);

        internal static Type CharArrayType => typeof(char[]);

        internal static Type StreamType => typeof(Stream);

        internal static Type DictionaryType => typeof(Dictionary<string, object>);

        internal static Type ObjectType => typeof(object);
    }
}
