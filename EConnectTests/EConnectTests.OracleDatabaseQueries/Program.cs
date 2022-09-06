using EConnect;
using EConnectTests.Models;
using EConnectTests.OracleDatabaseQueries.Models;
using EConnectTests.SettingParser;
using EConnectTests.Settings;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace EConnectTests.OracleDatabaseQueries
{
    internal class Program
    {
        private const string SETTING_NAME = "settings.json";
        private const string COMMAND = "SELECT * FROM TEST.GenericTable";
        private const string SINGLECOMMAND = "SELECT * FROM TEST.GenericTable WHERE ByteNumber IS NOT NULL";

        static void Main(string[] args)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), SETTING_NAME);
            Parser settingParser = new Parser();
            Setting setting = settingParser.ParserConfiguration(path);

            InsertData(setting.ConnectionString);

            GetObject(setting.ConnectionString);
            GetDict(setting.ConnectionString);
            GetDynamic(setting.ConnectionString);
            GetByte(setting.ConnectionString);
            GetNullableByte(setting.ConnectionString);
            GetBoolean(setting.ConnectionString);
            GetNullableBoolean(setting.ConnectionString);
            GetBytes(setting.ConnectionString);
            GetChars(setting.ConnectionString);
            GetChar(setting.ConnectionString);
            GetNullableChar(setting.ConnectionString);
            GetDateTime(setting.ConnectionString);
            GetNullableDateTime(setting.ConnectionString);
            GetDecimal(setting.ConnectionString);
            GetNullableDecimal(setting.ConnectionString);
            GetDobule(setting.ConnectionString);
            GetNullableDobule(setting.ConnectionString);
            GetFloat(setting.ConnectionString);
            GetNullableFloat(setting.ConnectionString);
            GetGuid(setting.ConnectionString);
            GetNullableGuid(setting.ConnectionString);
            GetInteger(setting.ConnectionString);
            GetNullableInteger(setting.ConnectionString);
            GetLong(setting.ConnectionString);
            GetNullableLong(setting.ConnectionString);
            GetSByte(setting.ConnectionString);
            GetNullableSByte(setting.ConnectionString);
            GetShort(setting.ConnectionString);
            GetNullableShort(setting.ConnectionString);
            GetStream(setting.ConnectionString);
            GetString(setting.ConnectionString);
            GetUInt(setting.ConnectionString);
            GetNullableUInt(setting.ConnectionString);
            GetULong(setting.ConnectionString);
            GetNullableULong(setting.ConnectionString);
            GetUShort(setting.ConnectionString);
            GetNullableUShort(setting.ConnectionString);

            GetSingleObject(setting.ConnectionString);
            GetSingleDict(setting.ConnectionString);
            GetSingleDynamic(setting.ConnectionString);
            GetSingleByte(setting.ConnectionString);
            GetSingleNullableByte(setting.ConnectionString);
            GetSingleBoolean(setting.ConnectionString);
            GetSingleNullableBoolean(setting.ConnectionString);
            GetSingleBytes(setting.ConnectionString);
            GetSingleChars(setting.ConnectionString);
            GetSingleChar(setting.ConnectionString);
            GetSingleNullableChar(setting.ConnectionString);
            GetSingleDateTime(setting.ConnectionString);
            GetSingleNullableDateTime(setting.ConnectionString);
            GetSingleDecimal(setting.ConnectionString);
            GetSingleNullableDecimal(setting.ConnectionString);
            GetSingleDobule(setting.ConnectionString);
            GetSingleNullableDobule(setting.ConnectionString);
            GetSingleFloat(setting.ConnectionString);
            GetSingleNullableFloat(setting.ConnectionString);
            GetSingleGuid(setting.ConnectionString);
            GetSingleNullableGuid(setting.ConnectionString);
            GetSingleInteger(setting.ConnectionString);
            GetSingleNullableInteger(setting.ConnectionString);
            GetSingleLong(setting.ConnectionString);
            GetSingleNullableLong(setting.ConnectionString);
            GetSingleSByte(setting.ConnectionString);
            GetSingleNullableSByte(setting.ConnectionString);
            GetSingleShort(setting.ConnectionString);
            GetSingleNullableShort(setting.ConnectionString);
            GetSingleStream(setting.ConnectionString);
            GetSingleString(setting.ConnectionString);
            GetSingleUInt(setting.ConnectionString);
            GetSingleNullableUInt(setting.ConnectionString);
            GetSingleULong(setting.ConnectionString);
            GetSingleNullableULong(setting.ConnectionString);
            GetSingleUShort(setting.ConnectionString);
            GetSingleNullableUShort(setting.ConnectionString);
        }

        private static void GetObject(string connectionString)
        {
            List<GenericOracleTable> objectResults;

            using (Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString))
            {
                objectResults = connection.Query<GenericOracleTable>(COMMAND, null);
            }

            CheckObject(objectResults);
        }

        private static void GetDict(string connectionString)
        {
            List<Dictionary<string, object>> dictResults;

            using (Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString))
            {
                dictResults = connection.Query<Dictionary<string, object>>(COMMAND, null);
            }

            CheckDict(dictResults);
        }

        private static void GetDynamic(string connectionString)
        {
            List<dynamic> dictResults;

            using (Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString))
            {
                dictResults = connection.Query<dynamic>(COMMAND, null);
            }

            CheckDynamic(dictResults);
        }

        private static void GetByte(string connectionString)
        {
            string command = "SELECT ByteNumber FROM TEST.GenericTable";
            List<byte> byteResults;

            using (Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString))
            {
                byteResults = connection.Query<byte>(command, null);
            }

            Debug.Assert(byteResults.Count == 2);

            Debug.Assert(byteResults[0] == default);
            Debug.Assert(byteResults[1] == Constants.ByteNumber2);
        }

        private static void GetNullableByte(string connectionString)
        {
            string command = "SELECT NullableByteNumber FROM TEST.GenericTable";
            List<byte?> nullableByteResults;

            using (Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString))
            {
                nullableByteResults = connection.Query<byte?>(command, null);
            }

            Debug.Assert(nullableByteResults.Count == 2);

            Debug.Assert(nullableByteResults[0] == default);
            Debug.Assert(nullableByteResults[1] == Constants.NullableByteNumber2);
        }

        private static void GetBoolean(string connectionString)
        {
            string command = "SELECT BoolValue FROM TEST.GenericTable";
            List<bool> boolResults;

            using (Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString))
            {
                boolResults = connection.Query<bool>(command, null);
            }

            Debug.Assert(boolResults.Count == 2);

            Debug.Assert(boolResults[0] == default);
            Debug.Assert(boolResults[1] == Constants.BoolValue2);
        }

        private static void GetNullableBoolean(string connectionString)
        {
            string command = "SELECT NullableBoolValue FROM TEST.GenericTable";
            List<bool?> nullableBoolResults;

            using (Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString))
            {
                nullableBoolResults = connection.Query<bool?>(command, null);
            }

            Debug.Assert(nullableBoolResults.Count == 2);

            Debug.Assert(nullableBoolResults[0] == default);
            Debug.Assert(nullableBoolResults[1] == Constants.NullableBoolValue2);
        }

        private static void GetBytes(string connectionString)
        {
            string command = "SELECT Bytes FROM TEST.GenericTable";
            List<byte[]> bytesResults;

            using (Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString))
            {
                bytesResults = connection.Query<byte[]>(command, null);
            }

            Debug.Assert(bytesResults.Count == 2);

            Debug.Assert(bytesResults[0] == default);
            Debug.Assert(bytesResults[1].SequenceEqual(Constants.Bytes2));
        }

        private static void GetChars(string connectionString)
        {
            string command = "SELECT Chars FROM TEST.GenericTable";
            List<char[]> charsResults;

            using (Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString))
            {
                charsResults = connection.Query<char[]>(command, null);
            }

            Debug.Assert(charsResults.Count == 2);

            Debug.Assert(charsResults[0] == default);
            Debug.Assert(charsResults[1].SequenceEqual(Constants.Chars2));
        }

        private static void GetChar(string connectionString)
        {
            string command = "SELECT Letter FROM TEST.GenericTable";
            List<char> charResults;

            using (Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString))
            {
                charResults = connection.Query<char>(command, null);
            }

            Debug.Assert(charResults.Count == 2);

            Debug.Assert(charResults[0] == default);
            Debug.Assert(charResults[1] == Constants.Letter2);
        }

        private static void GetNullableChar(string connectionString)
        {
            string command = "SELECT NullableLetter FROM TEST.GenericTable";
            List<char?> nullableCharResults;

            using (Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString))
            {
                nullableCharResults = connection.Query<char?>(command, null);
            }

            Debug.Assert(nullableCharResults.Count == 2);

            Debug.Assert(nullableCharResults[0] == default);
            Debug.Assert(nullableCharResults[1] == Constants.NullableLetter2);
        }

        private static void GetDateTime(string connectionString)
        {
            string command = "SELECT DateTimeValue FROM TEST.GenericTable";
            List<DateTime> dateTimeResults;

            using (Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString))
            {
                dateTimeResults = connection.Query<DateTime>(command, null);
            }

            Debug.Assert(dateTimeResults.Count == 2);

            Debug.Assert(dateTimeResults[0] == default);
            Debug.Assert(dateTimeResults[1] == Constants.DateTimeValue2);
        }

        private static void GetNullableDateTime(string connectionString)
        {
            string command = "SELECT NullableDateTimeValue FROM TEST.GenericTable";
            List<DateTime?> nullableDateTimeResults;

            using (Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString))
            {
                nullableDateTimeResults = connection.Query<DateTime?>(command, null);
            }

            Debug.Assert(nullableDateTimeResults.Count == 2);

            Debug.Assert(nullableDateTimeResults[0] == default);
            Debug.Assert(nullableDateTimeResults[1] == Constants.NullableDateTimeValue2);
        }

        private static void GetDecimal(string connectionString)
        {
            string command = "SELECT DecimalNumber FROM TEST.GenericTable";
            List<decimal> decimalResults;

            using (Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString))
            {
                decimalResults = connection.Query<decimal>(command, null);
            }

            Debug.Assert(decimalResults.Count == 2);

            Debug.Assert(decimalResults[0] == default);
            Debug.Assert(decimalResults[1] == Constants.DecimalNumber2);
        }

        private static void GetNullableDecimal(string connectionString)
        {
            string command = "SELECT NullableDecimalNumber FROM TEST.GenericTable";
            List<decimal?> nullableDecimalResults;

            using (Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString))
            {
                nullableDecimalResults = connection.Query<decimal?>(command, null);
            }

            Debug.Assert(nullableDecimalResults.Count == 2);

            Debug.Assert(nullableDecimalResults[0] == default);
            Debug.Assert(nullableDecimalResults[1] == Constants.NullableDecimalNumber2);
        }

        private static void GetDobule(string connectionString)
        {
            string command = "SELECT DoubleNumber FROM TEST.GenericTable";
            List<double> doubleResults;

            using (Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString))
            {
                doubleResults = connection.Query<double>(command, null);
            }

            Debug.Assert(doubleResults.Count == 2);

            Debug.Assert(doubleResults[0] == default);
            Debug.Assert(doubleResults[1] == Constants.DoubleNumber2);
        }

        private static void GetNullableDobule(string connectionString)
        {
            string command = "SELECT NullableDoubleNumber FROM TEST.GenericTable";
            List<double?> nullableDoubleResults;

            using (Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString))
            {
                nullableDoubleResults = connection.Query<double?>(command, null);
            }

            Debug.Assert(nullableDoubleResults.Count == 2);

            Debug.Assert(nullableDoubleResults[0] == default);
            Debug.Assert(nullableDoubleResults[1] == Constants.NullableDoubleNumber2);
        }

        private static void GetFloat(string connectionString)
        {
            string command = "SELECT FloatNumber FROM TEST.GenericTable";
            List<float> floatResults;

            using (Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString))
            {
                floatResults = connection.Query<float>(command, null);
            }

            Debug.Assert(floatResults.Count == 2);

            Debug.Assert(floatResults[0] == default);
            Debug.Assert(floatResults[1] == Constants.FloatNumber2);
        }

        private static void GetNullableFloat(string connectionString)
        {
            string command = "SELECT NullableFloatNumber FROM TEST.GenericTable";
            List<float?> nullableFloatResults;

            using (Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString))
            {
                nullableFloatResults = connection.Query<float?>(command, null);
            }

            Debug.Assert(nullableFloatResults.Count == 2);

            Debug.Assert(nullableFloatResults[0] == default);
            Debug.Assert(nullableFloatResults[1] == Constants.NullableFloatNumber2);
        }

        private static void GetGuid(string connectionString)
        {
            string command = "SELECT GuidValue FROM TEST.GenericTable";
            List<string> guidResults;

            using (Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString))
            {
                guidResults = connection.Query<string>(command, null);
            }

            Debug.Assert(guidResults.Count == 2);

            Debug.Assert(guidResults[0] == default);
            Debug.Assert(guidResults[1] == Constants.GuidValue2.ToString());
        }

        private static void GetNullableGuid(string connectionString)
        {
            string command = "SELECT NullableGuidValue FROM TEST.GenericTable";
            List<string> nullableGuidResults;

            using (Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString))
            {
                nullableGuidResults = connection.Query<string>(command, null);
            }

            Debug.Assert(nullableGuidResults.Count == 2);

            Debug.Assert(nullableGuidResults[0] == default);
            Debug.Assert(nullableGuidResults[1] == Constants.NullableGuidValue2?.ToString());
        }

        private static void GetInteger(string connectionString)
        {
            string command = "SELECT IntNumber FROM TEST.GenericTable";
            List<int> intResults;

            using (Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString))
            {
                intResults = connection.Query<int>(command, null);
            }

            Debug.Assert(intResults.Count == 2);

            Debug.Assert(intResults[0] == default);
            Debug.Assert(intResults[1] == Constants.IntNumber2);
        }

        private static void GetNullableInteger(string connectionString)
        {
            string command = "SELECT NullableIntNumber FROM TEST.GenericTable";
            List<int?> nullableIntResults;

            using (Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString))
            {
                nullableIntResults = connection.Query<int?>(command, null);
            }

            Debug.Assert(nullableIntResults.Count == 2);

            Debug.Assert(nullableIntResults[0] == default);
            Debug.Assert(nullableIntResults[1] == Constants.NullableIntNumber2);
        }

        private static void GetLong(string connectionString)
        {
            string command = "SELECT LongNumber FROM TEST.GenericTable";
            List<long> longResults;

            using (Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString))
            {
                longResults = connection.Query<long>(command, null);
            }

            Debug.Assert(longResults.Count == 2);

            Debug.Assert(longResults[0] == default);
            Debug.Assert(longResults[1] == Constants.LongNumber2);
        }

        private static void GetNullableLong(string connectionString)
        {
            string command = "SELECT NullableLongNumber FROM TEST.GenericTable";
            List<long?> nullableLongResults;

            using (Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString))
            {
                nullableLongResults = connection.Query<long?>(command, null);
            }

            Debug.Assert(nullableLongResults.Count == 2);

            Debug.Assert(nullableLongResults[0] == default);
            Debug.Assert(nullableLongResults[1] == Constants.NullableLongNumber2);
        }

        private static void GetSByte(string connectionString)
        {
            string command = "SELECT SByteNumber FROM TEST.GenericTable";
            List<sbyte> sByteResults;

            using (Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString))
            {
                sByteResults = connection.Query<sbyte>(command, null);
            }

            Debug.Assert(sByteResults.Count == 2);

            Debug.Assert(sByteResults[0] == default);
            Debug.Assert(sByteResults[1] == Constants.SByteNumber2);
        }

        private static void GetNullableSByte(string connectionString)
        {
            string command = "SELECT NullableSByteNumber FROM TEST.GenericTable";
            List<sbyte?> nullableSByteResults;

            using (Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString))
            {
                nullableSByteResults = connection.Query<sbyte?>(command, null);
            }

            Debug.Assert(nullableSByteResults.Count == 2);

            Debug.Assert(nullableSByteResults[0] == default);
            Debug.Assert(nullableSByteResults[1] == Constants.NullableSByteNumber2);
        }

        private static void GetShort(string connectionString)
        {
            string command = "SELECT ShortNumber FROM TEST.GenericTable";
            List<short> shortResults;

            using (Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString))
            {
                shortResults = connection.Query<short>(command, null);
            }

            Debug.Assert(shortResults.Count == 2);

            Debug.Assert(shortResults[0] == default);
            Debug.Assert(shortResults[1] == Constants.ShortNumber2);
        }

        private static void GetNullableShort(string connectionString)
        {
            string command = "SELECT NullableShortNumber FROM TEST.GenericTable";
            List<short?> nullableShortResults;

            using (Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString))
            {
                nullableShortResults = connection.Query<short?>(command, null);
            }

            Debug.Assert(nullableShortResults.Count == 2);

            Debug.Assert(nullableShortResults[0] == default);
            Debug.Assert(nullableShortResults[1] == Constants.NullableShortNumber2);
        }

        private static void GetStream(string connectionString)
        {
            string command = "SELECT StreamValue FROM TEST.GenericTable";
            List<Stream> streamResults;

            using (Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString))
            {
                streamResults = connection.Query<Stream>(command, null);
            }

            Debug.Assert(streamResults.Count == 2);

            Debug.Assert(streamResults[0] == default);

            MemoryStream ms = new MemoryStream();
            streamResults[1].CopyTo(ms);

            Debug.Assert(ms.ToArray().SequenceEqual(Constants.StreamValue2));
        }

        private static void GetString(string connectionString)
        {
            string command = "SELECT StringValue FROM TEST.GenericTable";
            List<string> stringResults;

            using (Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString))
            {
                stringResults = connection.Query<string>(command, null);
            }

            Debug.Assert(stringResults.Count == 2);

            Debug.Assert(stringResults[0] == default);
            Debug.Assert(stringResults[1] == Constants.StringValue2);
        }

        private static void GetUInt(string connectionString)
        {
            string command = "SELECT UIntNumber FROM TEST.GenericTable";
            List<uint> uIntResults;

            using (Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString))
            {
                uIntResults = connection.Query<uint>(command, null);
            }

            Debug.Assert(uIntResults.Count == 2);

            Debug.Assert(uIntResults[0] == default);
            Debug.Assert(uIntResults[1] == Constants.UIntNumber2);
        }

        private static void GetNullableUInt(string connectionString)
        {
            string command = "SELECT NullableUIntNumber FROM TEST.GenericTable";
            List<uint?> nullableUintResults;

            using (Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString))
            {
                nullableUintResults = connection.Query<uint?>(command, null);
            }

            Debug.Assert(nullableUintResults.Count == 2);

            Debug.Assert(nullableUintResults[0] == default);
            Debug.Assert(nullableUintResults[1] == Constants.NullableUIntNumber2);
        }

        private static void GetULong(string connectionString)
        {
            string command = "SELECT ULongNumber FROM TEST.GenericTable";
            List<ulong> uLongResults;

            using (Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString))
            {
                uLongResults = connection.Query<ulong>(command, null);
            }

            Debug.Assert(uLongResults.Count == 2);

            Debug.Assert(uLongResults[0] == default);
            Debug.Assert(uLongResults[1] == (ulong)Constants.ULongNumber2);
        }

        private static void GetNullableULong(string connectionString)
        {
            string command = "SELECT NullableULongNumber FROM TEST.GenericTable";
            List<ulong?> nullableULongResults;

            using (Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString))
            {
                nullableULongResults = connection.Query<ulong?>(command, null);
            }

            Debug.Assert(nullableULongResults.Count == 2);

            Debug.Assert(nullableULongResults[0] == default);
            Debug.Assert(nullableULongResults[1] == (ulong?)Constants.NullableULongNumber2);
        }

        private static void GetUShort(string connectionString)
        {
            string command = "SELECT UShortNumber FROM TEST.GenericTable";
            List<ushort> uShortResults;

            using (Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString))
            {
                uShortResults = connection.Query<ushort>(command, null);
            }

            Debug.Assert(uShortResults.Count == 2);

            Debug.Assert(uShortResults[0] == default);
            Debug.Assert(uShortResults[1] == Constants.UShortNumber2);
        }

        private static void GetNullableUShort(string connectionString)
        {
            string command = "SELECT NullableUShortNumber FROM TEST.GenericTable";
            List<ushort?> nullableUShortResults;

            using (Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString))
            {
                nullableUShortResults = connection.Query<ushort?>(command, null);
            }

            Debug.Assert(nullableUShortResults.Count == 2);

            Debug.Assert(nullableUShortResults[0] == default);
            Debug.Assert(nullableUShortResults[1] == Constants.NullableUShortNumber2);
        }

        private static void GetSingleObject(string connectionString)
        {
            using Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString);

            var (hasResult, result) = connection.Single<GenericOracleTable>(SINGLECOMMAND, null);

            Debug.Assert(hasResult == true);

            CheckSingleObject(result);
        }

        private static void GetSingleDict(string connectionString)
        {
            using Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString);

            var (hasResult, dict) = connection.Single<Dictionary<string, object>>(SINGLECOMMAND, null);

            Debug.Assert(hasResult == true);

            CheckSingleDict(dict);
        }

        private static void GetSingleDynamic(string connectionString)
        {
            using Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString);

            var (hasResult, result) = connection.Single<dynamic>(SINGLECOMMAND, null);

            Debug.Assert(hasResult == true);

            CheckSingleDynamic(result);
        }

        private static void GetSingleByte(string connectionString)
        {
            string command = "SELECT ByteNumber FROM TEST.GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString);

            var (hasResult, byteResult) = connection.Single<byte>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(byteResult == Constants.ByteNumber2);
        }

        private static void GetSingleNullableByte(string connectionString)
        {
            string command = "SELECT NullableByteNumber FROM TEST.GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString);

            var (hasResult, nullableByteResult) = connection.Single<byte?>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(nullableByteResult == Constants.NullableByteNumber2);
        }

        private static void GetSingleBoolean(string connectionString)
        {
            string command = "SELECT BoolValue FROM TEST.GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString);

            var (hasResult, boolResult) = connection.Single<bool>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(boolResult == Constants.BoolValue2);
        }

        private static void GetSingleNullableBoolean(string connectionString)
        {
            string command = "SELECT NullableBoolValue FROM TEST.GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString);

            var (hasResult, nullableBoolResult) = connection.Single<bool?>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(nullableBoolResult == Constants.NullableBoolValue2);
        }

        private static void GetSingleBytes(string connectionString)
        {
            string command = "SELECT Bytes FROM TEST.GenericTable WHERE ByteNumber IS NOT NULL";
            using Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString);

            var (hasResult, bytesResults) = connection.Single<byte[]>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(bytesResults.SequenceEqual(Constants.Bytes2));
        }

        private static void GetSingleChars(string connectionString)
        {
            string command = "SELECT Chars FROM TEST.GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString);

            var (hasResult, charsResult) = connection.Single<char[]>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(charsResult.SequenceEqual(Constants.Chars2));
        }

        private static void GetSingleChar(string connectionString)
        {
            string command = "SELECT Letter FROM TEST.GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString);

            var (hasResult, charResult) = connection.Single<char>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(charResult == Constants.Letter2);
        }

        private static void GetSingleNullableChar(string connectionString)
        {
            string command = "SELECT NullableLetter FROM TEST.GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString);

            var (hasResult, nullableCharResult) = connection.Single<char?>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(nullableCharResult == Constants.NullableLetter2);
        }

        private static void GetSingleDateTime(string connectionString)
        {
            string command = "SELECT DateTimeValue FROM TEST.GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString);

            var (hasResult, dateTimeResult) = connection.Single<DateTime>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(dateTimeResult == Constants.DateTimeValue2);
        }

        private static void GetSingleNullableDateTime(string connectionString)
        {
            string command = "SELECT NullableDateTimeValue FROM TEST.GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString);

            var (hasResult, nullableDateTimeResult) = connection.Single<DateTime?>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(nullableDateTimeResult == Constants.NullableDateTimeValue2);
        }

        private static void GetSingleDecimal(string connectionString)
        {
            string command = "SELECT DecimalNumber FROM TEST.GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString);

            var (hasResult, decimalResult) = connection.Single<decimal>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(decimalResult == Constants.DecimalNumber2);
        }

        private static void GetSingleNullableDecimal(string connectionString)
        {
            string command = "SELECT NullableDecimalNumber FROM TEST.GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString);

            var (hasResult, nullableDecimalResult) = connection.Single<decimal?>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(nullableDecimalResult == Constants.NullableDecimalNumber2);
        }

        private static void GetSingleDobule(string connectionString)
        {
            string command = "SELECT DoubleNumber FROM TEST.GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString);

            var (hasResult, doubleResult) = connection.Single<double>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(doubleResult == Constants.DoubleNumber2);
        }

        private static void GetSingleNullableDobule(string connectionString)
        {
            string command = "SELECT NullableDoubleNumber FROM TEST.GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString);

            var (hasResult, nullableDoubleResult) = connection.Single<double?>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(nullableDoubleResult == Constants.NullableDoubleNumber2);
        }

        private static void GetSingleFloat(string connectionString)
        {
            string command = "SELECT FloatNumber FROM TEST.GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString);

            var (hasResult, floatResult) = connection.Single<float>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(floatResult == Constants.FloatNumber2);
        }

        private static void GetSingleNullableFloat(string connectionString)
        {
            string command = "SELECT NullableFloatNumber FROM TEST.GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString);

            var (hasResult, nullableFloatResult) = connection.Single<float?>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(nullableFloatResult == Constants.NullableFloatNumber2);
        }

        private static void GetSingleGuid(string connectionString)
        {
            string command = "SELECT GuidValue FROM TEST.GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString);

            var (hasResult, guidResult) = connection.Single<string>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(guidResult == Constants.GuidValue2.ToString());
        }

        private static void GetSingleNullableGuid(string connectionString)
        {
            string command = "SELECT NullableGuidValue FROM TEST.GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString);

            var (hasResult, nullableGuidResult) = connection.Single<string>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(nullableGuidResult == Constants.NullableGuidValue2?.ToString());
        }

        private static void GetSingleInteger(string connectionString)
        {
            string command = "SELECT IntNumber FROM TEST.GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString);

            var (hasResult, intResult) = connection.Single<int>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(intResult == Constants.IntNumber2);
        }

        private static void GetSingleNullableInteger(string connectionString)
        {
            string command = "SELECT NullableIntNumber FROM TEST.GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString);

            var (hasResult, nullableIntResult) = connection.Single<int?>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(nullableIntResult == Constants.NullableIntNumber2);
        }

        private static void GetSingleLong(string connectionString)
        {
            string command = "SELECT LongNumber FROM TEST.GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString);

            var (hasResult, longResult) = connection.Single<long>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(longResult == Constants.LongNumber2);
        }

        private static void GetSingleNullableLong(string connectionString)
        {
            string command = "SELECT NullableLongNumber FROM TEST.GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString);

            var (hasResult, nullableLongResult) = connection.Single<long?>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(nullableLongResult == Constants.NullableLongNumber2);
        }

        private static void GetSingleSByte(string connectionString)
        {
            string command = "SELECT SByteNumber FROM TEST.GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString);

            var (hasResult, sByteResult) = connection.Single<sbyte>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(sByteResult == Constants.SByteNumber2);
        }

        private static void GetSingleNullableSByte(string connectionString)
        {
            string command = "SELECT NullableSByteNumber FROM TEST.GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString);

            var (hasResult, nullableSByteResult) = connection.Single<sbyte?>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(nullableSByteResult == Constants.NullableSByteNumber2);
        }

        private static void GetSingleShort(string connectionString)
        {
            string command = "SELECT ShortNumber FROM TEST.GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString);

            var (hasResult, shortResult) = connection.Single<short>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(shortResult == Constants.ShortNumber2);
        }

        private static void GetSingleNullableShort(string connectionString)
        {
            string command = "SELECT NullableShortNumber FROM TEST.GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString);

            var (hasResult, nullableShortResult) = connection.Single<short?>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(nullableShortResult == Constants.NullableShortNumber2);
        }

        private static void GetSingleStream(string connectionString)
        {
            string command = "SELECT StreamValue FROM TEST.GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString);

            var (hasResult, streamResult) = connection.Single<Stream>(command, null);

            Debug.Assert(hasResult == true);

            MemoryStream ms = new MemoryStream();
            streamResult.CopyTo(ms);

            Debug.Assert(ms.ToArray().SequenceEqual(Constants.StreamValue2));
        }

        private static void GetSingleString(string connectionString)
        {
            string command = "SELECT StringValue FROM TEST.GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString);

            var (hasResult, stringResult) = connection.Single<string>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(stringResult == Constants.StringValue2);
        }

        private static void GetSingleUInt(string connectionString)
        {
            string command = "SELECT UIntNumber FROM TEST.GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString);

            var (hasResult, uIntResult) = connection.Single<uint>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(uIntResult == Constants.UIntNumber2);
        }

        private static void GetSingleNullableUInt(string connectionString)
        {
            string command = "SELECT NullableUIntNumber FROM TEST.GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString);

            var (hasResult, nullableUintResult) = connection.Single<uint?>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(nullableUintResult == Constants.NullableUIntNumber2);
        }

        private static void GetSingleULong(string connectionString)
        {
            string command = "SELECT ULongNumber FROM TEST.GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString);

            var (hasResult, uLongResult) = connection.Single<ulong>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(uLongResult == (ulong)Constants.ULongNumber2);
        }

        private static void GetSingleNullableULong(string connectionString)
        {
            string command = "SELECT NullableULongNumber FROM TEST.GenericTable WHERE ByteNumber IS NOT NULL";
            using Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString);

            var (hasResult, nullableULongResult) = connection.Single<ulong?>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(nullableULongResult == (ulong?)Constants.NullableULongNumber2);
        }

        private static void GetSingleUShort(string connectionString)
        {
            string command = "SELECT UShortNumber FROM TEST.GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString);

            var (hasResult, uShortResult) = connection.Single<ushort>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(uShortResult == Constants.UShortNumber2);
        }

        private static void GetSingleNullableUShort(string connectionString)
        {
            string command = "SELECT NullableUShortNumber FROM TEST.GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString);

            var (hasResult, nullableUShortResult) = connection.Single<ushort?>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(nullableUShortResult == Constants.NullableUShortNumber2);
        }

        private static void CheckObject(List<GenericOracleTable> results)
        {
            Debug.Assert(results.Count == 2);

            Debug.Assert(results[0].ByteNumber == default);
            Debug.Assert(results[0].NullableByteNumber == default);
            Debug.Assert(results[0].BoolValue == default);
            Debug.Assert(results[0].StringValue == default);
            Debug.Assert(results[0].NullableBoolValue == default);
            Debug.Assert(results[0].Bytes == default);
            Debug.Assert(results[0].Chars == default);
            Debug.Assert(results[0].Letter == default);
            Debug.Assert(results[0].NullableLetter == default);
            Debug.Assert(results[0].DateTimeValue == default);
            Debug.Assert(results[0].NullableDateTimeValue == default);
            Debug.Assert(results[0].DecimalNumber == default);
            Debug.Assert(results[0].NullableDecimalNumber == default);
            Debug.Assert(results[0].DoubleNumber == default);
            Debug.Assert(results[0].NullableDoubleNumber == default);
            Debug.Assert(results[0].FloatNumber == default);
            Debug.Assert(results[0].NullableFloatNumber == default);
            Debug.Assert(results[0].GuidValue == default);
            Debug.Assert(results[0].NullableGuidValue == default);
            Debug.Assert(results[0].IntNumber == default);
            Debug.Assert(results[0].NullableIntNumber == default);
            Debug.Assert(results[0].LongNumber == default);
            Debug.Assert(results[0].NullableLongNumber == default);
            Debug.Assert(results[0].SByteNumber == default);
            Debug.Assert(results[0].NullableSByteNumber == default);
            Debug.Assert(results[0].ShortNumber == default);
            Debug.Assert(results[0].NullableShortNumber == default);
            Debug.Assert(results[0].StreamValue == default);
            Debug.Assert(results[0].StringValue == default);
            Debug.Assert(results[0].UIntNumber == default);
            Debug.Assert(results[0].NullableUIntNumber == default);
            Debug.Assert(results[0].ULongNumber == default);
            Debug.Assert(results[0].NullableULongNumber == default);
            Debug.Assert(results[0].UShortNumber == default);
            Debug.Assert(results[0].NullableUShortNumber == default);

            Debug.Assert(results[1].ByteNumber == Constants.ByteNumber2);
            Debug.Assert(results[1].NullableByteNumber == Constants.NullableByteNumber2);
            Debug.Assert(results[1].BoolValue == Constants.BoolValue2);
            Debug.Assert(results[1].NullableBoolValue == Constants.NullableBoolValue2);
            Debug.Assert(results[1].Bytes.SequenceEqual(Constants.Bytes2));
            Debug.Assert(results[1].Chars.SequenceEqual(Constants.Chars2.ToCharArray()));
            Debug.Assert(results[1].Letter == Constants.Letter2);
            Debug.Assert(results[1].NullableLetter == Constants.NullableLetter2);
            Debug.Assert(results[1].DateTimeValue == Constants.DateTimeValue2);
            Debug.Assert(results[1].NullableDateTimeValue == Constants.NullableDateTimeValue2);
            Debug.Assert(results[1].DecimalNumber == Constants.DecimalNumber2);
            Debug.Assert(results[1].NullableDecimalNumber == Constants.NullableDecimalNumber2);
            Debug.Assert(results[1].DoubleNumber == Constants.DoubleNumber2);
            Debug.Assert(results[1].NullableDoubleNumber == Constants.NullableDoubleNumber2);
            Debug.Assert(results[1].FloatNumber == Constants.FloatNumber2);
            Debug.Assert(results[1].NullableFloatNumber == Constants.NullableFloatNumber2);
            Debug.Assert(results[1].GuidValue == Constants.GuidValue2.ToString());
            Debug.Assert(results[1].NullableGuidValue == Constants.NullableGuidValue2?.ToString());
            Debug.Assert(results[1].IntNumber == Constants.IntNumber2);
            Debug.Assert(results[1].NullableIntNumber == Constants.NullableIntNumber2);
            Debug.Assert(results[1].LongNumber == Constants.LongNumber2);
            Debug.Assert(results[1].NullableLongNumber == Constants.NullableLongNumber2);
            Debug.Assert(results[1].SByteNumber == (sbyte)Constants.SByteNumber2);
            Debug.Assert(results[1].NullableSByteNumber == (sbyte?)Constants.NullableSByteNumber2);
            Debug.Assert(results[1].ShortNumber == Constants.ShortNumber2);
            Debug.Assert(results[1].NullableShortNumber == Constants.NullableShortNumber2);

            MemoryStream ms = new MemoryStream();
            results[1].StreamValue.CopyTo(ms);

            Debug.Assert(ms.ToArray().SequenceEqual(Constants.StreamValue2));
            Debug.Assert(results[1].StringValue == Constants.StringValue2);
            Debug.Assert(results[1].UIntNumber == Constants.UIntNumber2);
            Debug.Assert(results[1].NullableUIntNumber == Constants.NullableUIntNumber2);
            Debug.Assert(results[1].ULongNumber == (ulong)Constants.ULongNumber2);
            Debug.Assert(results[1].NullableULongNumber == (ulong?)Constants.NullableULongNumber2);
            Debug.Assert(results[1].UShortNumber == (ushort)Constants.UShortNumber2);
            Debug.Assert(results[1].NullableUShortNumber == (ushort?)Constants.NullableUShortNumber2);
        }

        private static void CheckDict(List<Dictionary<string, object>> results)
        {
            Debug.Assert(results.Count == 2);

            for (int i = 0; i < results.Count; i++)
            {
                Dictionary<string, object> keys = results[i];

                if (i == 0)
                {
                    foreach (string key in keys.Keys)
                    {
                        if (string.Equals(key, nameof(GenericTable.ByteNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert(keys[key] == null);
                        }
                        else if (string.Equals(key, nameof(GenericTable.NullableByteNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert(keys[key] == null);
                        }
                        else if (string.Equals(key, nameof(GenericTable.BoolValue), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert(keys[key] == null);
                        }
                        else if (string.Equals(key, nameof(GenericTable.NullableBoolValue), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert(keys[key] == null);
                        }
                        else if (string.Equals(key, nameof(GenericTable.Bytes), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert(keys[key] == null);
                        }
                        else if (string.Equals(key, nameof(GenericTable.Chars), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert(keys[key] == null);
                        }
                        else if (string.Equals(key, nameof(GenericTable.Letter), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert(keys[key] == null);
                        }
                        else if (string.Equals(key, nameof(GenericTable.NullableLetter), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert(keys[key] == null);
                        }
                        else if (string.Equals(key, nameof(GenericTable.DateTimeValue), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert(keys[key] == null);
                        }
                        else if (string.Equals(key, nameof(GenericTable.NullableDateTimeValue), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert(keys[key] == null);
                        }
                        else if (string.Equals(key, nameof(GenericTable.DecimalNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert(keys[key] == null);
                        }
                        else if (string.Equals(key, nameof(GenericTable.NullableDecimalNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert(keys[key] == null);
                        }
                        else if (string.Equals(key, nameof(GenericTable.DoubleNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert(keys[key] == null);
                        }
                        else if (string.Equals(key, nameof(GenericTable.NullableDoubleNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert(keys[key] == null);
                        }
                        else if (string.Equals(key, nameof(GenericTable.FloatNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert(keys[key] == null);
                        }
                        else if (string.Equals(key, nameof(GenericTable.NullableFloatNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert((float?)keys[key] == null);
                        }
                        else if (string.Equals(key, nameof(GenericTable.GuidValue), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert(keys[key] == null);
                        }
                        else if (string.Equals(key, nameof(GenericTable.NullableGuidValue), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert(keys[key] == null);
                        }
                        else if (string.Equals(key, nameof(GenericTable.IntNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert(keys[key] == null);
                        }
                        else if (string.Equals(key, nameof(GenericTable.NullableIntNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert(keys[key] == null);
                        }
                        else if (string.Equals(key, nameof(GenericTable.LongNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert(keys[key] == null);
                        }
                        else if (string.Equals(key, nameof(GenericTable.NullableLongNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert(keys[key] == null);
                        }
                        else if (string.Equals(key, nameof(GenericTable.SByteNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert(keys[key] == null);
                        }
                        else if (string.Equals(key, nameof(GenericTable.NullableSByteNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert(keys[key] == null);
                        }
                        else if (string.Equals(key, nameof(GenericTable.ShortNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert(keys[key] == null);
                        }
                        else if (string.Equals(key, nameof(GenericTable.NullableShortNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert(keys[key] == null);
                        }
                        else if (string.Equals(key, nameof(GenericTable.StreamValue), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert(keys[key] == null);
                        }
                        else if (string.Equals(key, nameof(GenericTable.StringValue), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert(keys[key] == null);
                        }
                        else if (string.Equals(key, nameof(GenericTable.UIntNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert(keys[key] == null);
                        }
                        else if (string.Equals(key, nameof(GenericTable.NullableUIntNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert(keys[key] == null);
                        }
                        else if (string.Equals(key, nameof(GenericTable.ULongNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert(keys[key] == null);
                        }
                        else if (string.Equals(key, nameof(GenericTable.NullableULongNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert(keys[key] == null);
                        }
                        else if (string.Equals(key, nameof(GenericTable.UShortNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert(keys[key] == null);
                        }
                        else if (string.Equals(key, nameof(GenericTable.NullableUShortNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert(keys[key] == null);
                        }
                        else
                        {
                            throw new Exception("Unexpected key: " + key);
                        }
                    }
                }
                else if (i == 1)
                {
                    foreach (string key in keys.Keys)
                    {
                        if (string.Equals(key, nameof(GenericTable.ByteNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert((decimal)keys[key] == Constants.ByteNumber2);
                        }
                        else if (string.Equals(key, nameof(GenericTable.NullableByteNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert((decimal?)keys[key] == Constants.NullableByteNumber2);
                        }
                        else if (string.Equals(key, nameof(GenericTable.BoolValue), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert((short)keys[key] == Convert.ToInt16(Constants.BoolValue2));
                        }
                        else if (string.Equals(key, nameof(GenericTable.NullableBoolValue), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert((short?)keys[key] == Convert.ToInt16(Constants.NullableBoolValue2));
                        }
                        else if (string.Equals(key, nameof(GenericTable.Bytes), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert(((byte[])keys[key]).SequenceEqual(Constants.Bytes2));
                        }
                        else if (string.Equals(key, nameof(GenericTable.Chars), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert((string)keys[key] == Constants.Chars2);
                        }
                        else if (string.Equals(key, nameof(GenericTable.Letter), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert((string)keys[key] == Constants.Letter2.ToString());
                        }
                        else if (string.Equals(key, nameof(GenericTable.NullableLetter), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert((string)keys[key] == Constants.NullableLetter2.ToString());
                        }
                        else if (string.Equals(key, nameof(GenericTable.DateTimeValue), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert((DateTime)keys[key] == Constants.DateTimeValue2);
                        }
                        else if (string.Equals(key, nameof(GenericTable.NullableDateTimeValue), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert((DateTime?)keys[key] == Constants.NullableDateTimeValue2);
                        }
                        else if (string.Equals(key, nameof(GenericTable.DecimalNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert(Convert.ToDecimal(keys[key], System.Globalization.CultureInfo.InvariantCulture) == Constants.DecimalNumber2);
                        }
                        else if (string.Equals(key, nameof(GenericTable.NullableDecimalNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert(Convert.ToDecimal(keys[key], System.Globalization.CultureInfo.InvariantCulture) == Constants.NullableDecimalNumber2);
                        }
                        else if (string.Equals(key, nameof(GenericTable.DoubleNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert((double)keys[key] == Constants.DoubleNumber2);
                        }
                        else if (string.Equals(key, nameof(GenericTable.NullableDoubleNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert((double?)keys[key] == Constants.NullableDoubleNumber2);
                        }
                        else if (string.Equals(key, nameof(GenericTable.FloatNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert((decimal)keys[key] == Convert.ToDecimal(Constants.FloatNumber2));
                        }
                        else if (string.Equals(key, nameof(GenericTable.NullableFloatNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert((decimal?)keys[key] == Convert.ToDecimal(Constants.NullableFloatNumber2));
                        }
                        else if (string.Equals(key, nameof(GenericTable.GuidValue), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert(Convert.ToString(keys[key]) == Constants.GuidValue2.ToString());
                        }
                        else if (string.Equals(key, nameof(GenericTable.NullableGuidValue), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert(Convert.ToString(keys[key]) == Constants.NullableGuidValue2?.ToString());
                        }
                        else if (string.Equals(key, nameof(GenericTable.IntNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert((decimal)keys[key] == Constants.IntNumber2);
                        }
                        else if (string.Equals(key, nameof(GenericTable.NullableIntNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert((decimal?)keys[key] == Constants.NullableIntNumber2);
                        }
                        else if (string.Equals(key, nameof(GenericTable.LongNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert((decimal)keys[key] == Constants.LongNumber2);
                        }
                        else if (string.Equals(key, nameof(GenericTable.NullableLongNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert((decimal?)keys[key] == Constants.NullableLongNumber2);
                        }
                        else if (string.Equals(key, nameof(GenericTable.SByteNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert((decimal)keys[key] == Constants.SByteNumber2);
                        }
                        else if (string.Equals(key, nameof(GenericTable.NullableSByteNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert((decimal?)keys[key] == Constants.NullableSByteNumber2);
                        }
                        else if (string.Equals(key, nameof(GenericTable.ShortNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert((decimal)keys[key] == Constants.ShortNumber2);
                        }
                        else if (string.Equals(key, nameof(GenericTable.NullableShortNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert((decimal?)keys[key] == Constants.NullableShortNumber2);
                        }
                        else if (string.Equals(key, nameof(GenericTable.StreamValue), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert(((byte[])keys[key]).SequenceEqual(Constants.StreamValue2));
                        }
                        else if (string.Equals(key, nameof(GenericTable.StringValue), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert((string)keys[key] == Constants.StringValue2);
                        }
                        else if (string.Equals(key, nameof(GenericTable.UIntNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert((decimal)keys[key] == Constants.UIntNumber2);
                        }
                        else if (string.Equals(key, nameof(GenericTable.NullableUIntNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert((decimal?)keys[key] == Constants.NullableUIntNumber2);
                        }
                        else if (string.Equals(key, nameof(GenericTable.ULongNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert((decimal)keys[key] == Constants.ULongNumber2);
                        }
                        else if (string.Equals(key, nameof(GenericTable.NullableULongNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert((decimal?)keys[key] == Constants.NullableULongNumber2);
                        }
                        else if (string.Equals(key, nameof(GenericTable.UShortNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert((decimal)keys[key] == Constants.UShortNumber2);
                        }
                        else if (string.Equals(key, nameof(GenericTable.NullableUShortNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert((decimal?)keys[key] == Constants.NullableUShortNumber2);
                        }
                        else
                        {
                            throw new Exception("Unexpected key: " + key);
                        }
                    }
                }
            }
        }

        private static void CheckDynamic(List<dynamic> results)
        {
            Debug.Assert(results.Count == 2);

            if (results[0].BYTENUMBER != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.ByteNumber)} is not null.");
            }

            if (results[0].NULLABLEBYTENUMBER != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableByteNumber)} is not null.");
            }

            if (results[0].BOOLVALUE != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.BoolValue)} is not null.");
            }

            if (results[0].NULLABLEBOOLVALUE != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableBoolValue)} is not null.");
            }

            if (results[0].BYTES != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.Bytes)} is not null.");
            }

            if (results[0].CHARS != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.Chars)} is not null.");
            }

            if (results[0].LETTER != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.Letter)} is not null.");
            }

            if (results[0].NULLABLELETTER != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableLetter)} is not null.");
            }

            if (results[0].DATETIMEVALUE != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.DateTimeValue)} is not null.");
            }

            if (results[0].NULLABLEDATETIMEVALUE != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableDateTimeValue)} is not null.");
            }

            if (results[0].DECIMALNUMBER != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.DecimalNumber)} is not null.");
            }

            if (results[0].NULLABLEDECIMALNUMBER != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableDecimalNumber)} is not null.");
            }

            if (results[0].DOUBLENUMBER != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.DoubleNumber)} is not null.");
            }

            if (results[0].NULLABLEDOUBLENUMBER != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableDoubleNumber)} is not null.");
            }

            if (results[0].FLOATNUMBER != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.FloatNumber)} is not null.");
            }

            if (results[0].NULLABLEFLOATNUMBER != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableFloatNumber)} is not null.");
            }

            if (results[0].GUIDVALUE != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.GuidValue)} is not null.");
            }

            if (results[0].NULLABLEGUIDVALUE != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableGuidValue)} is not null.");
            }

            if (results[0].INTNUMBER != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.IntNumber)} is not null.");
            }

            if (results[0].NULLABLEINTNUMBER != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableIntNumber)} is not null.");
            }

            if (results[0].LONGNUMBER != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.LongNumber)} is not null.");
            }

            if (results[0].NULLABLELONGNUMBER != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableLongNumber)} is not null.");
            }

            if (results[0].SBYTENUMBER != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.SByteNumber)} is not null.");
            }

            if (results[0].NULLABLESBYTENUMBER != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableSByteNumber)} is not null.");
            }

            if (results[0].SHORTNUMBER != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.ShortNumber)} is not null.");
            }

            if (results[0].NULLABLESHORTNUMBER != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableShortNumber)} is not null.");
            }

            if (results[0].STREAMVALUE != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.StreamValue)} is not null.");
            }

            if (results[0].STRINGVALUE != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.StringValue)} is not null.");
            }

            if (results[0].UINTNUMBER != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.UIntNumber)} is not null.");
            }

            if (results[0].NULLABLEUINTNUMBER != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableUIntNumber)} is not null.");
            }

            if (results[0].ULONGNUMBER != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.ULongNumber)} is not null.");
            }

            if (results[0].NULLABLEULONGNUMBER != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableULongNumber)} is not null.");
            }

            if (results[0].USHORTNUMBER != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.UShortNumber)} is not null.");
            }

            if (results[0].NULLABLEUSHORTNUMBER != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableUShortNumber)} is not null.");
            }

            if (results[1].BYTENUMBER != Constants.ByteNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.ByteNumber)} is not equal to {Constants.ByteNumber2}.");
            }

            if (results[1].NULLABLEBYTENUMBER != Constants.NullableByteNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableByteNumber)} is not equal to {Constants.NullableByteNumber2}.");
            }

            if (Convert.ToBoolean(results[1].BOOLVALUE) != Constants.BoolValue2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.BoolValue)} is not equal to {Constants.BoolValue2}.");
            }

            if (Convert.ToBoolean(results[1].NULLABLEBOOLVALUE) != Constants.NullableBoolValue2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableBoolValue)} is not equal to {Constants.NullableBoolValue2}.");
            }

            if (!Constants.Bytes2.SequenceEqual((byte[])results[1].BYTES))
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.Bytes)} is not equal to {Constants.Bytes2}.");
            }

            if (!Constants.Chars2.SequenceEqual((char[])results[1].CHARS.ToString().ToCharArray()))
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.Chars)} is not equal to {Constants.Chars2}.");
            }

            if (results[1].LETTER != Constants.Letter2.ToString())
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.Letter)} is not equal to {Constants.Letter2}.");
            }

            if (results[1].NULLABLELETTER != Constants.NullableLetter2?.ToString())
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableLetter)} is not equal to {Constants.NullableLetter2}.");
            }

            if (results[1].DATETIMEVALUE != Constants.DateTimeValue2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.DateTimeValue)} is not equal to {Constants.DateTimeValue2}.");
            }

            if (results[1].NULLABLEDATETIMEVALUE != Constants.NullableDateTimeValue2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableDateTimeValue)} is not equal to {Constants.NullableDateTimeValue2}.");
            }

            if ((decimal)results[1].DECIMALNUMBER != Constants.DecimalNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.DecimalNumber)} is not equal to {Constants.DecimalNumber2}.");
            }

            if ((decimal?)results[1].NULLABLEDECIMALNUMBER != Constants.NullableDecimalNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableDecimalNumber)} is not equal to {Constants.NullableDecimalNumber2}.");
            }

            if (results[1].DOUBLENUMBER != Constants.DoubleNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.DoubleNumber)} is not equal to {Constants.DoubleNumber2}.");
            }

            if (results[1].NULLABLEDOUBLENUMBER != Constants.NullableDoubleNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableDoubleNumber)} is not equal to {Constants.NullableDoubleNumber2}.");
            }

            if ((float)results[1].FLOATNUMBER != Constants.FloatNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.FloatNumber)} is not equal to {Constants.FloatNumber2}.");
            }

            if ((float?)results[1].NULLABLEFLOATNUMBER != Constants.NullableFloatNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableFloatNumber)} is not equal to {Constants.NullableFloatNumber2}.");
            }

            if (results[1].GUIDVALUE != Constants.GuidValue2.ToString())
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.GuidValue)} is not equal to {Constants.GuidValue2}.");
            }

            if (results[1].NULLABLEGUIDVALUE != Constants.NullableGuidValue2?.ToString())
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableGuidValue)} is not equal to {Constants.NullableGuidValue2}.");
            }

            if (results[1].INTNUMBER != Constants.IntNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.IntNumber)} is not equal to {Constants.IntNumber2}.");
            }

            if (results[1].NULLABLEINTNUMBER != Constants.NullableIntNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableIntNumber)} is not equal to {Constants.NullableIntNumber2}.");
            }

            if (results[1].LONGNUMBER != Constants.LongNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.LongNumber)} is not equal to {Constants.LongNumber2}.");
            }

            if (results[1].NULLABLELONGNUMBER != Constants.NullableLongNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableLongNumber)} is not equal to {Constants.NullableLongNumber2}.");
            }

            if (results[1].SBYTENUMBER != Constants.SByteNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.SByteNumber)} is not equal to {Constants.SByteNumber2}.");
            }

            if (results[1].NULLABLESBYTENUMBER != Constants.NullableSByteNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableSByteNumber)} is not equal to {Constants.NullableSByteNumber2}.");
            }

            if (results[1].SHORTNUMBER != Constants.ShortNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.ShortNumber)} is not equal to {Constants.ShortNumber2}.");
            }

            if (results[1].NULLABLESHORTNUMBER != Constants.NullableShortNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableShortNumber)} is not equal to {Constants.NullableShortNumber2}.");
            }

            if (!Constants.StreamValue2.SequenceEqual((byte[])results[1].STREAMVALUE))
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.StreamValue)} is not equal to {Constants.StreamValue2}.");
            }

            if (results[1].STRINGVALUE != Constants.StringValue2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.StringValue)} is not equal to {Constants.StringValue2}.");
            }

            if (results[1].UINTNUMBER != Constants.UIntNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.UIntNumber)} is not equal to {Constants.UIntNumber2}.");
            }

            if (results[1].NULLABLEUINTNUMBER != Constants.NullableUIntNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableUIntNumber)} is not equal to {Constants.NullableUIntNumber2}.");
            }

            if (results[1].ULONGNUMBER != Constants.ULongNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.ULongNumber)} is not equal to {Constants.ULongNumber2}.");
            }

            if (results[1].NULLABLEULONGNUMBER != Constants.NullableULongNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableULongNumber)} is not equal to {Constants.NullableULongNumber2}.");
            }

            if (results[1].USHORTNUMBER != Constants.UShortNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.UShortNumber)} is not equal to {Constants.UShortNumber2}.");
            }

            if (results[1].NULLABLEUSHORTNUMBER != Constants.NullableUShortNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableUShortNumber)} is not equal to {Constants.NullableUShortNumber2}.");
            }
        }

        private static void CheckSingleObject(GenericOracleTable genericTable)
        {
            Debug.Assert(genericTable.ByteNumber == Constants.ByteNumber2);
            Debug.Assert(genericTable.NullableByteNumber == Constants.NullableByteNumber2);
            Debug.Assert(genericTable.BoolValue == Constants.BoolValue2);
            Debug.Assert(genericTable.NullableBoolValue == Constants.NullableBoolValue2);
            Debug.Assert(genericTable.Bytes.SequenceEqual(Constants.Bytes2));
            Debug.Assert(genericTable.Chars.SequenceEqual(Constants.Chars2.ToCharArray()));
            Debug.Assert(genericTable.Letter == Constants.Letter2);
            Debug.Assert(genericTable.NullableLetter == Constants.NullableLetter2);
            Debug.Assert(genericTable.DateTimeValue == Constants.DateTimeValue2);
            Debug.Assert(genericTable.NullableDateTimeValue == Constants.NullableDateTimeValue2);
            Debug.Assert(genericTable.DecimalNumber == Constants.DecimalNumber2);
            Debug.Assert(genericTable.NullableDecimalNumber == Constants.NullableDecimalNumber2);
            Debug.Assert(genericTable.DoubleNumber == Constants.DoubleNumber2);
            Debug.Assert(genericTable.NullableDoubleNumber == Constants.NullableDoubleNumber2);
            Debug.Assert(genericTable.FloatNumber == Constants.FloatNumber2);
            Debug.Assert(genericTable.NullableFloatNumber == Constants.NullableFloatNumber2);
            Debug.Assert(genericTable.GuidValue == Constants.GuidValue2.ToString());
            Debug.Assert(genericTable.NullableGuidValue == Constants.NullableGuidValue2?.ToString());
            Debug.Assert(genericTable.IntNumber == Constants.IntNumber2);
            Debug.Assert(genericTable.NullableIntNumber == Constants.NullableIntNumber2);
            Debug.Assert(genericTable.LongNumber == Constants.LongNumber2);
            Debug.Assert(genericTable.NullableLongNumber == Constants.NullableLongNumber2);
            Debug.Assert(genericTable.SByteNumber == (sbyte)Constants.SByteNumber2);
            Debug.Assert(genericTable.NullableSByteNumber == (sbyte?)Constants.NullableSByteNumber2);
            Debug.Assert(genericTable.ShortNumber == Constants.ShortNumber2);
            Debug.Assert(genericTable.NullableShortNumber == Constants.NullableShortNumber2);

            MemoryStream ms = new MemoryStream();
            genericTable.StreamValue.CopyTo(ms);

            Debug.Assert(ms.ToArray().SequenceEqual(Constants.StreamValue2));
            Debug.Assert(genericTable.StringValue == Constants.StringValue2);
            Debug.Assert(genericTable.UIntNumber == Constants.UIntNumber2);
            Debug.Assert(genericTable.NullableUIntNumber == Constants.NullableUIntNumber2);
            Debug.Assert(genericTable.ULongNumber == (ulong)Constants.ULongNumber2);
            Debug.Assert(genericTable.NullableULongNumber == (ulong?)Constants.NullableULongNumber2);
            Debug.Assert(genericTable.UShortNumber == (ushort)Constants.UShortNumber2);
            Debug.Assert(genericTable.NullableUShortNumber == (ushort?)Constants.NullableUShortNumber2);
        }

        private static void CheckSingleDict(Dictionary<string, object> dict)
        {
            foreach (string key in dict.Keys)
            {
                if (string.Equals(key, nameof(GenericTable.ByteNumber), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert((decimal)dict[key] == Constants.ByteNumber2);
                }
                else if (string.Equals(key, nameof(GenericTable.NullableByteNumber), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert((decimal?)dict[key] == Constants.NullableByteNumber2);
                }
                else if (string.Equals(key, nameof(GenericTable.BoolValue), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert((short)dict[key] == Convert.ToInt16(Constants.BoolValue2));
                }
                else if (string.Equals(key, nameof(GenericTable.NullableBoolValue), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert((short?)dict[key] == Convert.ToInt16(Constants.NullableBoolValue2));
                }
                else if (string.Equals(key, nameof(GenericTable.Bytes), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert(((byte[])dict[key]).SequenceEqual(Constants.Bytes2));
                }
                else if (string.Equals(key, nameof(GenericTable.Chars), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert((string)dict[key] == Constants.Chars2);
                }
                else if (string.Equals(key, nameof(GenericTable.Letter), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert((string)dict[key] == Constants.Letter2.ToString());
                }
                else if (string.Equals(key, nameof(GenericTable.NullableLetter), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert((string)dict[key] == Constants.NullableLetter2.ToString());
                }
                else if (string.Equals(key, nameof(GenericTable.DateTimeValue), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert((DateTime)dict[key] == Constants.DateTimeValue2);
                }
                else if (string.Equals(key, nameof(GenericTable.NullableDateTimeValue), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert((DateTime?)dict[key] == Constants.NullableDateTimeValue2);
                }
                else if (string.Equals(key, nameof(GenericTable.DecimalNumber), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert(Convert.ToDecimal(dict[key], System.Globalization.CultureInfo.InvariantCulture) == Constants.DecimalNumber2);
                }
                else if (string.Equals(key, nameof(GenericTable.NullableDecimalNumber), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert(Convert.ToDecimal(dict[key], System.Globalization.CultureInfo.InvariantCulture) == Constants.NullableDecimalNumber2);
                }
                else if (string.Equals(key, nameof(GenericTable.DoubleNumber), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert((double)dict[key] == Constants.DoubleNumber2);
                }
                else if (string.Equals(key, nameof(GenericTable.NullableDoubleNumber), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert((double?)dict[key] == Constants.NullableDoubleNumber2);
                }
                else if (string.Equals(key, nameof(GenericTable.FloatNumber), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert((decimal)dict[key] == Convert.ToDecimal(Constants.FloatNumber2));
                }
                else if (string.Equals(key, nameof(GenericTable.NullableFloatNumber), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert((decimal?)dict[key] == Convert.ToDecimal(Constants.NullableFloatNumber2));
                }
                else if (string.Equals(key, nameof(GenericTable.GuidValue), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert(Convert.ToString(dict[key]) == Constants.GuidValue2.ToString());
                }
                else if (string.Equals(key, nameof(GenericTable.NullableGuidValue), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert(Convert.ToString(dict[key]) == Constants.NullableGuidValue2?.ToString());
                }
                else if (string.Equals(key, nameof(GenericTable.IntNumber), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert((decimal)dict[key] == Constants.IntNumber2);
                }
                else if (string.Equals(key, nameof(GenericTable.NullableIntNumber), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert((decimal?)dict[key] == Constants.NullableIntNumber2);
                }
                else if (string.Equals(key, nameof(GenericTable.LongNumber), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert((decimal)dict[key] == Constants.LongNumber2);
                }
                else if (string.Equals(key, nameof(GenericTable.NullableLongNumber), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert((decimal?)dict[key] == Constants.NullableLongNumber2);
                }
                else if (string.Equals(key, nameof(GenericTable.SByteNumber), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert((decimal)dict[key] == Constants.SByteNumber2);
                }
                else if (string.Equals(key, nameof(GenericTable.NullableSByteNumber), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert((decimal?)dict[key] == Constants.NullableSByteNumber2);
                }
                else if (string.Equals(key, nameof(GenericTable.ShortNumber), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert((decimal)dict[key] == Constants.ShortNumber2);
                }
                else if (string.Equals(key, nameof(GenericTable.NullableShortNumber), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert((decimal?)dict[key] == Constants.NullableShortNumber2);
                }
                else if (string.Equals(key, nameof(GenericTable.StreamValue), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert(((byte[])dict[key]).SequenceEqual(Constants.StreamValue2));
                }
                else if (string.Equals(key, nameof(GenericTable.StringValue), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert((string)dict[key] == Constants.StringValue2);
                }
                else if (string.Equals(key, nameof(GenericTable.UIntNumber), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert((decimal)dict[key] == Constants.UIntNumber2);
                }
                else if (string.Equals(key, nameof(GenericTable.NullableUIntNumber), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert((decimal?)dict[key] == Constants.NullableUIntNumber2);
                }
                else if (string.Equals(key, nameof(GenericTable.ULongNumber), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert((decimal)dict[key] == Constants.ULongNumber2);
                }
                else if (string.Equals(key, nameof(GenericTable.NullableULongNumber), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert((decimal?)dict[key] == Constants.NullableULongNumber2);
                }
                else if (string.Equals(key, nameof(GenericTable.UShortNumber), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert((decimal)dict[key] == Constants.UShortNumber2);
                }
                else if (string.Equals(key, nameof(GenericTable.NullableUShortNumber), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert((decimal?)dict[key] == Constants.NullableUShortNumber2);
                }
                else
                {
                    throw new Exception("Unexpected key: " + key);
                }
            }
        }

        private static void CheckSingleDynamic(dynamic value)
        {
            if (value.BYTENUMBER != Constants.ByteNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.ByteNumber)} is not equal to {Constants.ByteNumber2}.");
            }

            if (value.NULLABLEBYTENUMBER != Constants.NullableByteNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableByteNumber)} is not equal to {Constants.NullableByteNumber2}.");
            }

            if (Convert.ToBoolean(value.BOOLVALUE) != Constants.BoolValue2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.BoolValue)} is not equal to {Constants.BoolValue2}.");
            }

            if (Convert.ToBoolean(value.NULLABLEBOOLVALUE) != Constants.NullableBoolValue2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableBoolValue)} is not equal to {Constants.NullableBoolValue2}.");
            }

            if (!Constants.Bytes2.SequenceEqual((byte[])value.BYTES))
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.Bytes)} is not equal to {Constants.Bytes2}.");
            }

            if (!Constants.Chars2.SequenceEqual((char[])value.CHARS.ToString().ToCharArray()))
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.Chars)} is not equal to {Constants.Chars2}.");
            }

            if (value.LETTER != Constants.Letter2.ToString())
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.Letter)} is not equal to {Constants.Letter2}.");
            }

            if (value.NULLABLELETTER != Constants.NullableLetter2?.ToString())
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableLetter)} is not equal to {Constants.NullableLetter2}.");
            }

            if (value.DATETIMEVALUE != Constants.DateTimeValue2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.DateTimeValue)} is not equal to {Constants.DateTimeValue2}.");
            }

            if (value.NULLABLEDATETIMEVALUE != Constants.NullableDateTimeValue2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableDateTimeValue)} is not equal to {Constants.NullableDateTimeValue2}.");
            }

            if ((decimal)value.DECIMALNUMBER != Constants.DecimalNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.DecimalNumber)} is not equal to {Constants.DecimalNumber2}.");
            }

            if ((decimal)value.NULLABLEDECIMALNUMBER != Constants.NullableDecimalNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableDecimalNumber)} is not equal to {Constants.NullableDecimalNumber2}.");
            }

            if (value.DOUBLENUMBER != Constants.DoubleNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.DoubleNumber)} is not equal to {Constants.DoubleNumber2}.");
            }

            if (value.NULLABLEDOUBLENUMBER != Constants.NullableDoubleNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableDoubleNumber)} is not equal to {Constants.NullableDoubleNumber2}.");
            }

            if ((float)value.FLOATNUMBER != Constants.FloatNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.FloatNumber)} is not equal to {Constants.FloatNumber2}.");
            }

            if ((float)value.NULLABLEFLOATNUMBER != Constants.NullableFloatNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableFloatNumber)} is not equal to {Constants.NullableFloatNumber2}.");
            }

            if (value.GUIDVALUE != Constants.GuidValue2.ToString())
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.GuidValue)} is not equal to {Constants.GuidValue2}.");
            }

            if (value.NULLABLEGUIDVALUE != Constants.NullableGuidValue2?.ToString())
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableGuidValue)} is not equal to {Constants.NullableGuidValue2}.");
            }

            if (value.INTNUMBER != Constants.IntNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.IntNumber)} is not equal to {Constants.IntNumber2}.");
            }

            if (value.NULLABLEINTNUMBER != Constants.NullableIntNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableIntNumber)} is not equal to {Constants.NullableIntNumber2}.");
            }

            if (value.LONGNUMBER != Constants.LongNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.LongNumber)} is not equal to {Constants.LongNumber2}.");
            }

            if (value.NULLABLELONGNUMBER != Constants.NullableLongNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableLongNumber)} is not equal to {Constants.NullableLongNumber2}.");
            }

            if (value.SBYTENUMBER != Constants.SByteNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.SByteNumber)} is not equal to {Constants.SByteNumber2}.");
            }

            if (value.NULLABLESBYTENUMBER != Constants.NullableSByteNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableSByteNumber)} is not equal to {Constants.NullableSByteNumber2}.");
            }

            if (value.SHORTNUMBER != Constants.ShortNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.ShortNumber)} is not equal to {Constants.ShortNumber2}.");
            }

            if (value.NULLABLESHORTNUMBER != Constants.NullableShortNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableShortNumber)} is not equal to {Constants.NullableShortNumber2}.");
            }

            if (!Constants.StreamValue2.SequenceEqual((byte[])value.STREAMVALUE))
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.StreamValue)} is not equal to {Constants.StreamValue2}.");
            }

            if (value.STRINGVALUE != Constants.StringValue2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.StringValue)} is not equal to {Constants.StringValue2}.");
            }

            if (value.UINTNUMBER != Constants.UIntNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.UIntNumber)} is not equal to {Constants.UIntNumber2}.");
            }

            if (value.NULLABLEUINTNUMBER != Constants.NullableUIntNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableUIntNumber)} is not equal to {Constants.NullableUIntNumber2}.");
            }

            if (value.ULONGNUMBER != Constants.ULongNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.ULongNumber)} is not equal to {Constants.ULongNumber2}.");
            }

            if (value.NULLABLEULONGNUMBER != Constants.NullableULongNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableULongNumber)} is not equal to {Constants.NullableULongNumber2}.");
            }

            if (value.USHORTNUMBER != Constants.UShortNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.UShortNumber)} is not equal to {Constants.UShortNumber2}.");
            }

            if (value.NULLABLEUSHORTNUMBER != Constants.NullableUShortNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableUShortNumber)} is not equal to {Constants.NullableUShortNumber2}.");
            }
        }

        private static void InsertData(string connectionString)
        {
            using (Connection<OracleConnection> connection = new Connection<OracleConnection>(connectionString, true))
            {
                connection.NonQuery(@"DECLARE cnt NUMBER;
                                    BEGIN
                                    SELECT count(*) INTO cnt FROM all_tables WHERE owner = 'TEST' AND table_name = 'GENERICTABLE';
                                    IF cnt = 0 THEN 
                                    EXECUTE IMMEDIATE 'CREATE TABLE TEST.GENERICTABLE (
                                ByteNumber INT NULL,
                                NullableByteNumber INT NULL,
                                BoolValue NUMBER(1) NULL,
                                NullableBoolValue NUMBER(1) NULL,
                                Bytes BLOB NULL,
                                Chars VARCHAR(10) NULL,
                                Letter VARCHAR(1) NULL,
                                NullableLetter VARCHAR(1) NULL,
                                DateTimeValue TIMESTAMP NULL,
                                NullableDateTimeValue TIMESTAMP NULL,
                                DecimalNumber NUMBER(14, 4) NULL,
                                NullableDecimalNumber NUMBER(14, 4) NULL,
                                DoubleNumber NUMBER(14, 6) NULL,
                                NullableDoubleNumber NUMBER(14, 6) NULL,
                                FloatNumber FLOAT NULL,
                                NullableFloatNumber FLOAT NULL,
                                GuidValue VARCHAR(50) NULL,
                                NullableGuidValue VARCHAR(50) NULL,
                                IntNumber INT NULL,
                                NullableIntNumber INT NULL,
                                LongNumber NUMBER(20,0) NULL,
                                NullableLongNumber NUMBER(20,0) NULL,
                                SByteNumber INT NULL,
                                NullableSByteNumber INT NULL,
                                ShortNumber SMALLINT NULL,
                                NullableShortNumber SMALLINT NULL,
                                StreamValue BLOB NULL,
                                StringValue VARCHAR(250) NULL,
                                UIntNumber INT NULL,
                                NullableUIntNumber INT NULL,
                                ULongNumber NUMBER(20,0) NULL,
                                NullableULongNumber NUMBER(20,0) NULL,
                                UShortNumber SMALLINT NULL,
                                NullableUShortNumber SMALLINT NULL)';
                            END IF;
                            END;", null);

                connection.NonQuery(@"DELETE FROM TEST.GENERICTABLE", null);

                connection.NonQuery(
                    @"INSERT INTO TEST.GENERICTABLE
                        (
                            ByteNumber,
                            NullableByteNumber,
                            BoolValue,
                            NullableBoolValue,
                            Bytes,
                            Chars,
                            Letter,
                            NullableLetter,
                            DateTimeValue,
                            NullableDateTimeValue,
                            DecimalNumber,
                            NullableDecimalNumber,
                            DoubleNumber,
                            NullableDoubleNumber,
                            FloatNumber,
                            NullableFloatNumber,
                            GuidValue,
                            NullableGuidValue,
                            IntNumber,
                            NullableIntNumber,
                            LongNumber,
                            NullableLongNumber,
                            SByteNumber,
                            NullableSByteNumber,
                            ShortNumber,
                            NullableShortNumber,
                            StreamValue,
                            StringValue,
                            UIntNumber,
                            NullableUIntNumber,
                            ULongNumber,
                            NullableULongNumber,
                            UShortNumber,
                            NullableUShortNumber
                        )
                    VALUES
                        (
                            Null,
                            Null,
                            Null,
                            Null,
                            Null,
                            Null,
                            Null,
                            Null,
                            Null,
                            Null,
                            Null,
                            Null,
                            Null,
                            Null,
                            Null,
                            Null,
                            Null,
                            Null,
                            Null,
                            Null,
                            Null,
                            Null,
                            Null,
                            Null,
                            Null,
                            Null,
                            Null,
                            Null,
                            Null,
                            Null,
                            Null,
                            Null,
                            Null,
                            Null
                        )", null, false, false);

                connection.NonQuery(
                    @"INSERT INTO TEST.GENERICTABLE
                        (
                            ByteNumber,
                            NullableByteNumber,
                            BoolValue,
                            NullableBoolValue,
                            Bytes,
                            Chars,
                            Letter,
                            NullableLetter,
                            DateTimeValue,
                            NullableDateTimeValue,
                            DecimalNumber,
                            NullableDecimalNumber,
                            DoubleNumber,
                            NullableDoubleNumber,
                            FloatNumber,
                            NullableFloatNumber,
                            GuidValue,
                            NullableGuidValue,
                            IntNumber,
                            NullableIntNumber,
                            LongNumber,
                            NullableLongNumber,
                            SByteNumber,
                            NullableSByteNumber,
                            ShortNumber,
                            NullableShortNumber,
                            StreamValue,
                            StringValue,
                            UIntNumber,
                            NullableUIntNumber,
                            ULongNumber,
                            NullableULongNumber,
                            UShortNumber,
                            NullableUShortNumber
                        )
                    VALUES
                        (
                            :ByteNumber2,
                            :NullableByteNumber2,
                            :BoolValue2,
                            :NullableBoolValue2,
                            :Bytes2,
                            :Chars2,
                            :Letter2,
                            :NullableLetter2,
                            :DateTimeValue2,
                            :NullableDateTimeValue2,
                            :DecimalNumber2,
                            :NullableDecimalNumber2,
                            :DoubleNumber2,
                            :NullableDoubleNumber2,
                            :FloatNumber2,
                            :NullableFloatNumber2,
                            :GuidValue2,
                            :NullableGuidValue2,
                            :IntNumber2,
                            :NullableIntNumber2,
                            :LongNumber2,
                            :NullableLongNumber2,
                            :SByteNumber2,
                            :NullableSByteNumber2,
                            :ShortNumber2,
                            :NullableShortNumber2,
                            :StreamValue2,
                            :StringValue2,
                            :UIntNumber2,
                            :NullableUIntNumber2,
                            :ULongNumber2,
                            :NullableULongNumber2,
                            :UShortNumber2,
                            :NullableUShortNumber2
                        )",
                    new List<SqlEParameter>()
                    {
                        new SqlEParameter("@ByteNumber2", Constants.ByteNumber2),
                        new SqlEParameter("@NullableByteNumber2", Constants.NullableByteNumber2),
                        new SqlEParameter("@BoolValue2", Convert.ToInt32(Constants.BoolValue2)),
                        new SqlEParameter("@NullableBoolValue2", Convert.ToInt32(Constants.NullableBoolValue2)),
                        new SqlEParameter("@Bytes2", Constants.Bytes2),
                        new SqlEParameter("@Chars2", Constants.Chars2),
                        new SqlEParameter("@Letter2", Constants.Letter2),
                        new SqlEParameter("@NullableLetter2", Constants.NullableLetter2),
                        new SqlEParameter("@DateTimeValue2", Constants.DateTimeValue2.ToString("yyyy-MM-dd HH:mm:ss")),
                        new SqlEParameter("@NullableDateTimeValue2", Constants.NullableDateTimeValue2?.ToString("yyyy-MM-dd HH:mm:ss")),
                        new SqlEParameter("@DecimalNumber2", Constants.DecimalNumber2),
                        new SqlEParameter("@NullableDecimalNumber2",Constants.NullableDecimalNumber2),
                        new SqlEParameter("@DoubleNumber2", Constants.DoubleNumber2),
                        new SqlEParameter("@NullableDoubleNumber2", Constants.NullableDoubleNumber2),
                        new SqlEParameter("@FloatNumber2", Constants.FloatNumber2),
                        new SqlEParameter("@NullableFloatNumber2", Constants.NullableFloatNumber2),
                        new SqlEParameter("@GuidValue2", Constants.GuidValue2.ToString()),
                        new SqlEParameter("@NullableGuidValue2", Constants.NullableGuidValue2.ToString()),
                        new SqlEParameter("@IntNumber2", Constants.IntNumber2),
                        new SqlEParameter("@NullableIntNumber2", Constants.NullableIntNumber2),
                        new SqlEParameter("@LongNumber2", Constants.LongNumber2),
                        new SqlEParameter("@NullableLongNumber2", Constants.NullableLongNumber2),
                        new SqlEParameter("@SByteNumber2", Constants.SByteNumber2),
                        new SqlEParameter("@NullableSByteNumber2", Constants.NullableSByteNumber2),
                        new SqlEParameter("@ShortNumber2", Constants.ShortNumber2),
                        new SqlEParameter("@NullableShortNumber2", Constants.NullableShortNumber2),
                        new SqlEParameter("@StreamValue2", Constants.StreamValue2),
                        new SqlEParameter("@StringValue2", Constants.StringValue2),
                        new SqlEParameter("@UIntNumber2", Constants.UIntNumber2),
                        new SqlEParameter("@NullableUIntNumber2", Constants.NullableUIntNumber2),
                        new SqlEParameter("@ULongNumber2", Constants.ULongNumber2),
                        new SqlEParameter("@NullableULongNumber2", Constants.NullableULongNumber2),
                        new SqlEParameter("@UShortNumber2", Constants.UShortNumber2),
                        new SqlEParameter("@NullableUShortNumber2", Constants.NullableUShortNumber2)
                    }, false, false);
            }
        }
    }
}
