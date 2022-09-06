using EConnect.Infrastructure;
using EConnect.Interfaces;
using EConnect.Parsers;
using System;

namespace EConnect.ParserFactories
{
    /// <summary>
    /// Base Class for creating Parsers
    /// </summary>
    internal class BaseParserFactory : IParserFactory
    {
        /// <summary>
        /// Returns Parser for specific Type, the default Parser is ObjectParser
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <returns>Specific parser for specific Type</returns>
        public IBaseParser CreateParser<TModel>()
        {
            Type modelType = typeof(TModel);

            if (modelType == BaseTypeHelper.StringType)
            {
                return new StringParser();
            }
            else if (modelType == BaseTypeHelper.ByteType)
            {
                return new ByteParser();
            }
            else if (modelType == BaseTypeHelper.NullableByteType)
            {
                return new NullableByteParser();
            }
            else if (modelType == BaseTypeHelper.ShortType)
            {
                return new ShortParser();
            }
            else if (modelType == BaseTypeHelper.NullableShortType)
            {
                return new NullableShortParser();
            }
            else if (modelType == BaseTypeHelper.IntegerType)
            {
                return new IntParser();
            }
            else if (modelType == BaseTypeHelper.NullableIntegerType)
            {
                return new NullableIntParser();
            }
            else if (modelType == BaseTypeHelper.LongType)
            {
                return new LongParser();
            }
            else if (modelType == BaseTypeHelper.NullableLongType)
            {
                return new NullableLongParser();
            }
            else if (modelType == BaseTypeHelper.FloatType)
            {
                return new FloatParser();
            }
            else if (modelType == BaseTypeHelper.NullableFloatType)
            {
                return new NullableFloatParser();
            }
            else if (modelType == BaseTypeHelper.DoubleType)
            {
                return new DoubleParser();
            }
            else if (modelType == BaseTypeHelper.NullableDoubleType)
            {
                return new NullableDoubleParser();
            }
            else if (modelType == BaseTypeHelper.DecimalType)
            {
                return new DecimalParser();
            }
            else if (modelType == BaseTypeHelper.NullableDecimalType)
            {
                return new NullableDecimalParser();
            }
            else if (modelType == BaseTypeHelper.DateTimeType)
            {
                return new DateTimeParser();
            }
            else if (modelType == BaseTypeHelper.NullableDateTimeType)
            {
                return new NullableDateTimeParser();
            }
            else if (modelType == BaseTypeHelper.BooleanType)
            {
                return new BooleanParser();
            }
            else if (modelType == BaseTypeHelper.CharType)
            {
                return new CharParser();
            }
            else if (modelType == BaseTypeHelper.NullableCharType)
            {
                return new NullableCharParser();
            }
            else if (modelType == BaseTypeHelper.NullableBooleanType)
            {
                return new NullableBooleanParser();
            }
            else if (modelType == BaseTypeHelper.GuidType)
            {
                return new GuidParser();
            }
            else if (modelType == BaseTypeHelper.NullableGuidType)
            {
                return new NullableGuidParser();
            }
            else if (modelType == BaseTypeHelper.DictionaryType)
            {
                return new DictionaryParser();
            }
            else if (modelType == BaseTypeHelper.ByteArrayType)
            {
                return new BytesParser();
            }
            else if (modelType == BaseTypeHelper.CharArrayType)
            {
                return new CharsParser();
            }
            else if (BaseTypeHelper.StreamType.IsAssignableFrom(modelType))
            {
                return new StreamParser();
            }
            else if (modelType == BaseTypeHelper.SByteType)
            {
                return new SByteParser();
            }
            else if (modelType == BaseTypeHelper.NullableSByteType)
            {
                return new NullableSByteParser();
            }
            else if (modelType == BaseTypeHelper.UShortType)
            {
                return new UShortParser();
            }
            else if (modelType == BaseTypeHelper.NullableUShortType)
            {
                return new NullableUShortParser();
            }
            else if (modelType == BaseTypeHelper.UIntegerType)
            {
                return new UIntegerParser();
            }
            else if (modelType == BaseTypeHelper.NullableUIntegerType)
            {
                return new NullableUIntegerParser();
            }
            else if (modelType == BaseTypeHelper.ULongType)
            {
                return new ULongParser();
            }
            else if (modelType == BaseTypeHelper.NullableULongType)
            {
                return new NullableULongParser();
            }
            else if (modelType == BaseTypeHelper.ObjectType)
            {
                return new ExpandoObjectParser();
            }

            return new ObjectParser<TModel>();
        }
    }
}
