using EConnect;
using EConnectTests.Models;
using EConnectTests.SettingParser;
using EConnectTests.Settings;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace EConnectTests.SQLiteQueries
{
    internal class Program
    {
        private const string SETTING_NAME = "settings.json";
        private const string COMMAND = "SELECT * FROM GenericTable";
        private const string SINGLECOMMAND = "SELECT * FROM GenericTable WHERE ByteNumber IS NOT NULL";

        static void Main(string[] args)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), SETTING_NAME);
            Parser settingParser = new Parser();
            Setting setting = settingParser.ParserConfiguration(path);

            if (setting.IsSqLiteConnection)
            {
                setting.ConnectionString = setting.ConnectionString.Replace("{0}", Directory.GetCurrentDirectory());
            }

            InsertData(setting.ConnectionString);

            GetObject(setting.ConnectionString);
            GetDict(setting.ConnectionString);
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
            List<GenericTable> objectResults;

            using (Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString))
            {
                objectResults = connection.Query<GenericTable>(COMMAND, null);
            }

            CheckObject(objectResults);
        }

        private static void GetDict(string connectionString)
        {
            List<Dictionary<string, object>> dictResults;

            using (Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString))
            {
                dictResults = connection.Query<Dictionary<string, object>>(COMMAND, null);
            }

            CheckDict(dictResults);
        }

        private static void GetDynamic(string connectionString)
        {
            List<dynamic> dictResults;

            using (Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString))
            {
                dictResults = connection.Query<dynamic>(COMMAND, null);
            }

            CheckDynamic(dictResults);
        }

        private static void GetByte(string connectionString)
        {
            string command = "SELECT ByteNumber FROM GenericTable";
            List<byte> byteResults;

            using (Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString))
            {
                byteResults = connection.Query<byte>(command, null);
            }

            Debug.Assert(byteResults.Count == 2);

            Debug.Assert(byteResults[0] == default);
            Debug.Assert(byteResults[1] == Constants.ByteNumber2);
        }

        private static void GetNullableByte(string connectionString)
        {
            string command = "SELECT NullableByteNumber FROM GenericTable";
            List<byte?> nullableByteResults;

            using (Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString))
            {
                nullableByteResults = connection.Query<byte?>(command, null);
            }

            Debug.Assert(nullableByteResults.Count == 2);

            Debug.Assert(nullableByteResults[0] == default);
            Debug.Assert(nullableByteResults[1] == Constants.NullableByteNumber2);
        }

        private static void GetBoolean(string connectionString)
        {
            string command = "SELECT BoolValue FROM GenericTable";
            List<bool> boolResults;

            using (Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString))
            {
                boolResults = connection.Query<bool>(command, null);
            }

            Debug.Assert(boolResults.Count == 2);

            Debug.Assert(boolResults[0] == default);
            Debug.Assert(boolResults[1] == Constants.BoolValue2);
        }

        private static void GetNullableBoolean(string connectionString)
        {
            string command = "SELECT NullableBoolValue FROM GenericTable";
            List<bool?> nullableBoolResults;

            using (Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString))
            {
                nullableBoolResults = connection.Query<bool?>(command, null);
            }

            Debug.Assert(nullableBoolResults.Count == 2);

            Debug.Assert(nullableBoolResults[0] == default);
            Debug.Assert(nullableBoolResults[1] == Constants.NullableBoolValue2);
        }

        private static void GetBytes(string connectionString)
        {
            string command = "SELECT Bytes FROM GenericTable";
            List<byte[]> bytesResults;

            using (Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString))
            {
                bytesResults = connection.Query<byte[]>(command, null);
            }

            Debug.Assert(bytesResults.Count == 2);

            Debug.Assert(bytesResults[0] == default);
            Debug.Assert(bytesResults[1].SequenceEqual(Constants.Bytes2));
        }

        private static void GetChars(string connectionString)
        {
            string command = "SELECT Chars FROM GenericTable";
            List<char[]> charsResults;

            using (Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString))
            {
                charsResults = connection.Query<char[]>(command, null);
            }

            Debug.Assert(charsResults.Count == 2);

            Debug.Assert(charsResults[0] == default);
            Debug.Assert(charsResults[1].SequenceEqual(Constants.Chars2));
        }

        private static void GetChar(string connectionString)
        {
            string command = "SELECT Letter FROM GenericTable";
            List<char> charResults;

            using (Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString))
            {
                charResults = connection.Query<char>(command, null);
            }

            Debug.Assert(charResults.Count == 2);

            Debug.Assert(charResults[0] == default);
            Debug.Assert(charResults[1] == Constants.Letter2);
        }

        private static void GetNullableChar(string connectionString)
        {
            string command = "SELECT NullableLetter FROM GenericTable";
            List<char?> nullableCharResults;

            using (Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString))
            {
                nullableCharResults = connection.Query<char?>(command, null);
            }

            Debug.Assert(nullableCharResults.Count == 2);

            Debug.Assert(nullableCharResults[0] == default);
            Debug.Assert(nullableCharResults[1] == Constants.NullableLetter2);
        }

        private static void GetDateTime(string connectionString)
        {
            string command = "SELECT DateTimeValue FROM GenericTable";
            List<DateTime> dateTimeResults;

            using (Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString))
            {
                dateTimeResults = connection.Query<DateTime>(command, null);
            }

            Debug.Assert(dateTimeResults.Count == 2);

            Debug.Assert(dateTimeResults[0] == default);
            Debug.Assert(dateTimeResults[1] == Constants.DateTimeValue2);
        }

        private static void GetNullableDateTime(string connectionString)
        {
            string command = "SELECT NullableDateTimeValue FROM GenericTable";
            List<DateTime?> nullableDateTimeResults;

            using (Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString))
            {
                nullableDateTimeResults = connection.Query<DateTime?>(command, null);
            }

            Debug.Assert(nullableDateTimeResults.Count == 2);

            Debug.Assert(nullableDateTimeResults[0] == default);
            Debug.Assert(nullableDateTimeResults[1] == Constants.NullableDateTimeValue2);
        }

        private static void GetDecimal(string connectionString)
        {
            string command = "SELECT DecimalNumber FROM GenericTable";
            List<decimal> decimalResults;

            using (Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString))
            {
                decimalResults = connection.Query<decimal>(command, null);
            }

            Debug.Assert(decimalResults.Count == 2);

            Debug.Assert(decimalResults[0] == default);
            Debug.Assert(decimalResults[1] == Constants.DecimalNumber2);
        }

        private static void GetNullableDecimal(string connectionString)
        {
            string command = "SELECT NullableDecimalNumber FROM GenericTable";
            List<decimal?> nullableDecimalResults;

            using (Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString))
            {
                nullableDecimalResults = connection.Query<decimal?>(command, null);
            }

            Debug.Assert(nullableDecimalResults.Count == 2);

            Debug.Assert(nullableDecimalResults[0] == default);
            Debug.Assert(nullableDecimalResults[1] == Constants.NullableDecimalNumber2);
        }

        private static void GetDobule(string connectionString)
        {
            string command = "SELECT DoubleNumber FROM GenericTable";
            List<double> doubleResults;

            using (Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString))
            {
                doubleResults = connection.Query<double>(command, null);
            }

            Debug.Assert(doubleResults.Count == 2);

            Debug.Assert(doubleResults[0] == default);
            Debug.Assert(doubleResults[1] == Constants.DoubleNumber2);
        }

        private static void GetNullableDobule(string connectionString)
        {
            string command = "SELECT NullableDoubleNumber FROM GenericTable";
            List<double?> nullableDoubleResults;

            using (Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString))
            {
                nullableDoubleResults = connection.Query<double?>(command, null);
            }

            Debug.Assert(nullableDoubleResults.Count == 2);

            Debug.Assert(nullableDoubleResults[0] == default);
            Debug.Assert(nullableDoubleResults[1] == Constants.NullableDoubleNumber2);
        }

        private static void GetFloat(string connectionString)
        {
            string command = "SELECT FloatNumber FROM GenericTable";
            List<float> floatResults;

            using (Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString))
            {
                floatResults = connection.Query<float>(command, null);
            }

            Debug.Assert(floatResults.Count == 2);

            Debug.Assert(floatResults[0] == default);
            Debug.Assert(floatResults[1] == Constants.FloatNumber2);
        }

        private static void GetNullableFloat(string connectionString)
        {
            string command = "SELECT NullableFloatNumber FROM GenericTable";
            List<float?> nullableFloatResults;

            using (Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString))
            {
                nullableFloatResults = connection.Query<float?>(command, null);
            }

            Debug.Assert(nullableFloatResults.Count == 2);

            Debug.Assert(nullableFloatResults[0] == default);
            Debug.Assert(nullableFloatResults[1] == Constants.NullableFloatNumber2);
        }

        private static void GetGuid(string connectionString)
        {
            string command = "SELECT GuidValue FROM GenericTable";
            List<Guid> guidResults;

            using (Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString))
            {
                guidResults = connection.Query<Guid>(command, null);
            }

            Debug.Assert(guidResults.Count == 2);

            Debug.Assert(guidResults[0] == default);
            Debug.Assert(guidResults[1] == Constants.GuidValue2);
        }

        private static void GetNullableGuid(string connectionString)
        {
            string command = "SELECT NullableGuidValue FROM GenericTable";
            List<Guid?> nullableGuidResults;

            using (Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString))
            {
                nullableGuidResults = connection.Query<Guid?>(command, null);
            }

            Debug.Assert(nullableGuidResults.Count == 2);

            Debug.Assert(nullableGuidResults[0] == default);
            Debug.Assert(nullableGuidResults[1] == Constants.NullableGuidValue2);
        }

        private static void GetInteger(string connectionString)
        {
            string command = "SELECT IntNumber FROM GenericTable";
            List<int> intResults;

            using (Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString))
            {
                intResults = connection.Query<int>(command, null);
            }

            Debug.Assert(intResults.Count == 2);

            Debug.Assert(intResults[0] == default);
            Debug.Assert(intResults[1] == Constants.IntNumber2);
        }

        private static void GetNullableInteger(string connectionString)
        {
            string command = "SELECT NullableIntNumber FROM GenericTable";
            List<int?> nullableIntResults;

            using (Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString))
            {
                nullableIntResults = connection.Query<int?>(command, null);
            }

            Debug.Assert(nullableIntResults.Count == 2);

            Debug.Assert(nullableIntResults[0] == default);
            Debug.Assert(nullableIntResults[1] == Constants.NullableIntNumber2);
        }

        private static void GetLong(string connectionString)
        {
            string command = "SELECT LongNumber FROM GenericTable";
            List<long> longResults;

            using (Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString))
            {
                longResults = connection.Query<long>(command, null);
            }

            Debug.Assert(longResults.Count == 2);

            Debug.Assert(longResults[0] == default);
            Debug.Assert(longResults[1] == Constants.LongNumber2);
        }

        private static void GetNullableLong(string connectionString)
        {
            string command = "SELECT NullableLongNumber FROM GenericTable";
            List<long?> nullableLongResults;

            using (Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString))
            {
                nullableLongResults = connection.Query<long?>(command, null);
            }

            Debug.Assert(nullableLongResults.Count == 2);

            Debug.Assert(nullableLongResults[0] == default);
            Debug.Assert(nullableLongResults[1] == Constants.NullableLongNumber2);
        }

        private static void GetSByte(string connectionString)
        {
            string command = "SELECT SByteNumber FROM GenericTable";
            List<sbyte> sByteResults;

            using (Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString))
            {
                sByteResults = connection.Query<sbyte>(command, null);
            }

            Debug.Assert(sByteResults.Count == 2);

            Debug.Assert(sByteResults[0] == default);
            Debug.Assert(sByteResults[1] == Constants.SByteNumber2);
        }

        private static void GetNullableSByte(string connectionString)
        {
            string command = "SELECT NullableSByteNumber FROM GenericTable";
            List<sbyte?> nullableSByteResults;

            using (Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString))
            {
                nullableSByteResults = connection.Query<sbyte?>(command, null);
            }

            Debug.Assert(nullableSByteResults.Count == 2);

            Debug.Assert(nullableSByteResults[0] == default);
            Debug.Assert(nullableSByteResults[1] == Constants.NullableSByteNumber2);
        }

        private static void GetShort(string connectionString)
        {
            string command = "SELECT ShortNumber FROM GenericTable";
            List<short> shortResults;

            using (Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString))
            {
                shortResults = connection.Query<short>(command, null);
            }

            Debug.Assert(shortResults.Count == 2);

            Debug.Assert(shortResults[0] == default);
            Debug.Assert(shortResults[1] == Constants.ShortNumber2);
        }

        private static void GetNullableShort(string connectionString)
        {
            string command = "SELECT NullableShortNumber FROM GenericTable";
            List<short?> nullableShortResults;

            using (Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString))
            {
                nullableShortResults = connection.Query<short?>(command, null);
            }

            Debug.Assert(nullableShortResults.Count == 2);

            Debug.Assert(nullableShortResults[0] == default);
            Debug.Assert(nullableShortResults[1] == Constants.NullableShortNumber2);
        }

        private static void GetStream(string connectionString)
        {
            string command = "SELECT StreamValue FROM GenericTable";
            List<Stream> streamResults;

            using (Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString))
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
            string command = "SELECT StringValue FROM GenericTable";
            List<string> stringResults;

            using (Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString))
            {
                stringResults = connection.Query<string>(command, null);
            }

            Debug.Assert(stringResults.Count == 2);

            Debug.Assert(stringResults[0] == default);
            Debug.Assert(stringResults[1] == Constants.StringValue2);
        }

        private static void GetUInt(string connectionString)
        {
            string command = "SELECT UIntNumber FROM GenericTable";
            List<uint> uIntResults;

            using (Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString))
            {
                uIntResults = connection.Query<uint>(command, null);
            }

            Debug.Assert(uIntResults.Count == 2);

            Debug.Assert(uIntResults[0] == default);
            Debug.Assert(uIntResults[1] == Constants.UIntNumber2);
        }

        private static void GetNullableUInt(string connectionString)
        {
            string command = "SELECT NullableUIntNumber FROM GenericTable";
            List<uint?> nullableUintResults;

            using (Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString))
            {
                nullableUintResults = connection.Query<uint?>(command, null);
            }

            Debug.Assert(nullableUintResults.Count == 2);

            Debug.Assert(nullableUintResults[0] == default);
            Debug.Assert(nullableUintResults[1] == Constants.NullableUIntNumber2);
        }

        private static void GetULong(string connectionString)
        {
            string command = "SELECT ULongNumber FROM GenericTable";
            List<ulong> uLongResults;

            using (Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString))
            {
                uLongResults = connection.Query<ulong>(command, null);
            }

            Debug.Assert(uLongResults.Count == 2);

            Debug.Assert(uLongResults[0] == default);
            Debug.Assert(uLongResults[1] == (ulong)Constants.ULongNumber2);
        }

        private static void GetNullableULong(string connectionString)
        {
            string command = "SELECT NullableULongNumber FROM GenericTable";
            List<ulong?> nullableULongResults;

            using (Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString))
            {
                nullableULongResults = connection.Query<ulong?>(command, null);
            }

            Debug.Assert(nullableULongResults.Count == 2);

            Debug.Assert(nullableULongResults[0] == default);
            Debug.Assert(nullableULongResults[1] == (ulong?)Constants.NullableULongNumber2);
        }

        private static void GetUShort(string connectionString)
        {
            string command = "SELECT UShortNumber FROM GenericTable";
            List<ushort> uShortResults;

            using (Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString))
            {
                uShortResults = connection.Query<ushort>(command, null);
            }

            Debug.Assert(uShortResults.Count == 2);

            Debug.Assert(uShortResults[0] == default);
            Debug.Assert(uShortResults[1] == Constants.UShortNumber2);
        }

        private static void GetNullableUShort(string connectionString)
        {
            string command = "SELECT NullableUShortNumber FROM GenericTable";
            List<ushort?> nullableUShortResults;

            using (Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString))
            {
                nullableUShortResults = connection.Query<ushort?>(command, null);
            }

            Debug.Assert(nullableUShortResults.Count == 2);

            Debug.Assert(nullableUShortResults[0] == default);
            Debug.Assert(nullableUShortResults[1] == Constants.NullableUShortNumber2);
        }

        private static void GetSingleObject(string connectionString)
        {
            using Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString);

            var (hasResult, result) = connection.Single<GenericTable>(SINGLECOMMAND, null);

            Debug.Assert(hasResult == true);

            CheckSingleObject(result);
        }

        private static void GetSingleDict(string connectionString)
        {
            using Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString);

            var (hasResult, dict) = connection.Single<Dictionary<string, object>>(SINGLECOMMAND, null);

            Debug.Assert(hasResult == true);

            CheckSingleDict(dict);
        }

        private static void GetSingleDynamic(string connectionString)
        {
            using Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString);

            var (hasResult, result) = connection.Single<dynamic>(SINGLECOMMAND, null);

            Debug.Assert(hasResult == true);

            CheckSingleDynamic(result);
        }

        private static void GetSingleByte(string connectionString)
        {
            string command = "SELECT ByteNumber FROM GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString);

            var (hasResult, byteResult) = connection.Single<byte>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(byteResult == Constants.ByteNumber2);
        }

        private static void GetSingleNullableByte(string connectionString)
        {
            string command = "SELECT NullableByteNumber FROM GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString);

            var (hasResult, nullableByteResult) = connection.Single<byte?>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(nullableByteResult == Constants.NullableByteNumber2);
        }

        private static void GetSingleBoolean(string connectionString)
        {
            string command = "SELECT BoolValue FROM GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString);

            var (hasResult, boolResult) = connection.Single<bool>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(boolResult == Constants.BoolValue2);
        }

        private static void GetSingleNullableBoolean(string connectionString)
        {
            string command = "SELECT NullableBoolValue FROM GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString);

            var (hasResult, nullableBoolResult) = connection.Single<bool?>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(nullableBoolResult == Constants.NullableBoolValue2);
        }

        private static void GetSingleBytes(string connectionString)
        {
            string command = "SELECT Bytes FROM GenericTable WHERE ByteNumber IS NOT NULL";
            using Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString);

            var (hasResult, bytesResults) = connection.Single<byte[]>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(bytesResults.SequenceEqual(Constants.Bytes2));
        }

        private static void GetSingleChars(string connectionString)
        {
            string command = "SELECT Chars FROM GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString);

            var (hasResult, charsResult) = connection.Single<char[]>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(charsResult.SequenceEqual(Constants.Chars2));
        }

        private static void GetSingleChar(string connectionString)
        {
            string command = "SELECT Letter FROM GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString);

            var (hasResult, charResult) = connection.Single<char>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(charResult == Constants.Letter2);
        }

        private static void GetSingleNullableChar(string connectionString)
        {
            string command = "SELECT NullableLetter FROM GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString);

            var (hasResult, nullableCharResult) = connection.Single<char?>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(nullableCharResult == Constants.NullableLetter2);
        }

        private static void GetSingleDateTime(string connectionString)
        {
            string command = "SELECT DateTimeValue FROM GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString);

            var (hasResult, dateTimeResult) = connection.Single<DateTime>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(dateTimeResult == Constants.DateTimeValue2);
        }

        private static void GetSingleNullableDateTime(string connectionString)
        {
            string command = "SELECT NullableDateTimeValue FROM GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString);

            var (hasResult, nullableDateTimeResult) = connection.Single<DateTime?>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(nullableDateTimeResult == Constants.NullableDateTimeValue2);
        }

        private static void GetSingleDecimal(string connectionString)
        {
            string command = "SELECT DecimalNumber FROM GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString);

            var (hasResult, decimalResult) = connection.Single<decimal>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(decimalResult == Constants.DecimalNumber2);
        }

        private static void GetSingleNullableDecimal(string connectionString)
        {
            string command = "SELECT NullableDecimalNumber FROM GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString);

            var (hasResult, nullableDecimalResult) = connection.Single<decimal?>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(nullableDecimalResult == Constants.NullableDecimalNumber2);
        }

        private static void GetSingleDobule(string connectionString)
        {
            string command = "SELECT DoubleNumber FROM GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString);

            var (hasResult, doubleResult) = connection.Single<double>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(doubleResult == Constants.DoubleNumber2);
        }

        private static void GetSingleNullableDobule(string connectionString)
        {
            string command = "SELECT NullableDoubleNumber FROM GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString);

            var (hasResult, nullableDoubleResult) = connection.Single<double?>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(nullableDoubleResult == Constants.NullableDoubleNumber2);
        }

        private static void GetSingleFloat(string connectionString)
        {
            string command = "SELECT FloatNumber FROM GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString);

            var (hasResult, floatResult) = connection.Single<float>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(floatResult == Constants.FloatNumber2);
        }

        private static void GetSingleNullableFloat(string connectionString)
        {
            string command = "SELECT NullableFloatNumber FROM GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString);

            var (hasResult, nullableFloatResult) = connection.Single<float?>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(nullableFloatResult == Constants.NullableFloatNumber2);
        }

        private static void GetSingleGuid(string connectionString)
        {
            string command = "SELECT GuidValue FROM GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString);

            var (hasResult, guidResult) = connection.Single<Guid>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(guidResult == Constants.GuidValue2);
        }

        private static void GetSingleNullableGuid(string connectionString)
        {
            string command = "SELECT NullableGuidValue FROM GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString);

            var (hasResult, nullableGuidResult) = connection.Single<Guid?>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(nullableGuidResult == Constants.NullableGuidValue2);
        }

        private static void GetSingleInteger(string connectionString)
        {
            string command = "SELECT IntNumber FROM GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString);

            var (hasResult, intResult) = connection.Single<int>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(intResult == Constants.IntNumber2);
        }

        private static void GetSingleNullableInteger(string connectionString)
        {
            string command = "SELECT NullableIntNumber FROM GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString);

            var (hasResult, nullableIntResult) = connection.Single<int?>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(nullableIntResult == Constants.NullableIntNumber2);
        }

        private static void GetSingleLong(string connectionString)
        {
            string command = "SELECT LongNumber FROM GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString);

            var (hasResult, longResult) = connection.Single<long>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(longResult == Constants.LongNumber2);
        }

        private static void GetSingleNullableLong(string connectionString)
        {
            string command = "SELECT NullableLongNumber FROM GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString);

            var (hasResult, nullableLongResult) = connection.Single<long?>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(nullableLongResult == Constants.NullableLongNumber2);
        }

        private static void GetSingleSByte(string connectionString)
        {
            string command = "SELECT SByteNumber FROM GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString);

            var (hasResult, sByteResult) = connection.Single<sbyte>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(sByteResult == Constants.SByteNumber2);
        }

        private static void GetSingleNullableSByte(string connectionString)
        {
            string command = "SELECT NullableSByteNumber FROM GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString);

            var (hasResult, nullableSByteResult) = connection.Single<sbyte?>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(nullableSByteResult == Constants.NullableSByteNumber2);
        }

        private static void GetSingleShort(string connectionString)
        {
            string command = "SELECT ShortNumber FROM GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString);

            var (hasResult, shortResult) = connection.Single<short>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(shortResult == Constants.ShortNumber2);
        }

        private static void GetSingleNullableShort(string connectionString)
        {
            string command = "SELECT NullableShortNumber FROM GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString);

            var (hasResult, nullableShortResult) = connection.Single<short?>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(nullableShortResult == Constants.NullableShortNumber2);
        }

        private static void GetSingleStream(string connectionString)
        {
            string command = "SELECT StreamValue FROM GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString);

            var (hasResult, streamResult) = connection.Single<Stream>(command, null);

            Debug.Assert(hasResult == true);

            MemoryStream ms = new MemoryStream();
            streamResult.CopyTo(ms);

            Debug.Assert(ms.ToArray().SequenceEqual(Constants.StreamValue2));
        }

        private static void GetSingleString(string connectionString)
        {
            string command = "SELECT StringValue FROM GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString);

            var (hasResult, stringResult) = connection.Single<string>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(stringResult == Constants.StringValue2);
        }

        private static void GetSingleUInt(string connectionString)
        {
            string command = "SELECT UIntNumber FROM GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString);

            var (hasResult, uIntResult) = connection.Single<uint>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(uIntResult == Constants.UIntNumber2);
        }

        private static void GetSingleNullableUInt(string connectionString)
        {
            string command = "SELECT NullableUIntNumber FROM GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString);

            var (hasResult, nullableUintResult) = connection.Single<uint?>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(nullableUintResult == Constants.NullableUIntNumber2);
        }

        private static void GetSingleULong(string connectionString)
        {
            string command = "SELECT ULongNumber FROM GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString);

            var (hasResult, uLongResult) = connection.Single<ulong>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(uLongResult == (ulong)Constants.ULongNumber2);
        }

        private static void GetSingleNullableULong(string connectionString)
        {
            string command = "SELECT NullableULongNumber FROM GenericTable WHERE ByteNumber IS NOT NULL";
            using Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString);

            var (hasResult, nullableULongResult) = connection.Single<ulong?>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(nullableULongResult == (ulong?)Constants.NullableULongNumber2);
        }

        private static void GetSingleUShort(string connectionString)
        {
            string command = "SELECT UShortNumber FROM GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString);

            var (hasResult, uShortResult) = connection.Single<ushort>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(uShortResult == Constants.UShortNumber2);
        }

        private static void GetSingleNullableUShort(string connectionString)
        {
            string command = "SELECT NullableUShortNumber FROM GenericTable WHERE ByteNumber IS NOT NULL";

            using Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString);

            var (hasResult, nullableUShortResult) = connection.Single<ushort?>(command, null);

            Debug.Assert(hasResult == true);

            Debug.Assert(nullableUShortResult == Constants.NullableUShortNumber2);
        }

        private static void CheckObject(List<GenericTable> results)
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
            Debug.Assert(results[1].GuidValue == Constants.GuidValue2);
            Debug.Assert(results[1].NullableGuidValue == Constants.NullableGuidValue2);
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
                            Debug.Assert((long)keys[key] == Constants.ByteNumber2);
                        }
                        else if (string.Equals(key, nameof(GenericTable.NullableByteNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert((long?)keys[key] == Constants.NullableByteNumber2);
                        }
                        else if (string.Equals(key, nameof(GenericTable.BoolValue), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert(Convert.ToInt32(keys[key]) == Convert.ToInt32(Constants.BoolValue2));
                        }
                        else if (string.Equals(key, nameof(GenericTable.NullableBoolValue), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert(Convert.ToInt32(keys[key]) == Convert.ToInt32(Constants.NullableBoolValue2));
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
                            Debug.Assert(Convert.ToDateTime(keys[key]) == Constants.DateTimeValue2);
                        }
                        else if (string.Equals(key, nameof(GenericTable.NullableDateTimeValue), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert(Convert.ToDateTime(keys[key]) == Constants.NullableDateTimeValue2);
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
                            Debug.Assert((double)keys[key] == Constants.FloatNumber2);
                        }
                        else if (string.Equals(key, nameof(GenericTable.NullableFloatNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert((double?)keys[key] == Constants.NullableFloatNumber2);
                        }
                        else if (string.Equals(key, nameof(GenericTable.GuidValue), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert(string.Equals(Convert.ToString(keys[key]), Constants.GuidValue2.ToString(), StringComparison.OrdinalIgnoreCase));
                        }
                        else if (string.Equals(key, nameof(GenericTable.NullableGuidValue), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert(string.Equals(Convert.ToString(keys[key]), Constants.NullableGuidValue2?.ToString(), StringComparison.OrdinalIgnoreCase));
                        }
                        else if (string.Equals(key, nameof(GenericTable.IntNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert((long)keys[key] == Constants.IntNumber2);
                        }
                        else if (string.Equals(key, nameof(GenericTable.NullableIntNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert((long?)keys[key] == Constants.NullableIntNumber2);
                        }
                        else if (string.Equals(key, nameof(GenericTable.LongNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert((long)keys[key] == Constants.LongNumber2);
                        }
                        else if (string.Equals(key, nameof(GenericTable.NullableLongNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert((long?)keys[key] == Constants.NullableLongNumber2);
                        }
                        else if (string.Equals(key, nameof(GenericTable.SByteNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert((long)keys[key] == Constants.SByteNumber2);
                        }
                        else if (string.Equals(key, nameof(GenericTable.NullableSByteNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert((long?)keys[key] == Constants.NullableSByteNumber2);
                        }
                        else if (string.Equals(key, nameof(GenericTable.ShortNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert((long)keys[key] == Constants.ShortNumber2);
                        }
                        else if (string.Equals(key, nameof(GenericTable.NullableShortNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert((long?)keys[key] == Constants.NullableShortNumber2);
                        }
                        else if (string.Equals(key, nameof(GenericTable.StreamValue), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert(Encoding.UTF8.GetBytes(Convert.ToString(keys[key])).SequenceEqual(Constants.StreamValue2));
                        }
                        else if (string.Equals(key, nameof(GenericTable.StringValue), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert((string)keys[key] == Constants.StringValue2);
                        }
                        else if (string.Equals(key, nameof(GenericTable.UIntNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert((long)keys[key] == Constants.UIntNumber2);
                        }
                        else if (string.Equals(key, nameof(GenericTable.NullableUIntNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert((long?)keys[key] == Constants.NullableUIntNumber2);
                        }
                        else if (string.Equals(key, nameof(GenericTable.ULongNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert((long)keys[key] == Constants.ULongNumber2);
                        }
                        else if (string.Equals(key, nameof(GenericTable.NullableULongNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert((long?)keys[key] == Constants.NullableULongNumber2);
                        }
                        else if (string.Equals(key, nameof(GenericTable.UShortNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert((long)keys[key] == Constants.UShortNumber2);
                        }
                        else if (string.Equals(key, nameof(GenericTable.NullableUShortNumber), StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Assert((long?)keys[key] == Constants.NullableUShortNumber2);
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

            if (results[0].ByteNumber != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.ByteNumber)} is not null.");
            }

            if (results[0].NullableByteNumber != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableByteNumber)} is not null.");
            }

            if (results[0].BoolValue != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.BoolValue)} is not null.");
            }

            if (results[0].NullableBoolValue != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableBoolValue)} is not null.");
            }

            if (results[0].Bytes != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.Bytes)} is not null.");
            }

            if (results[0].Chars != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.Chars)} is not null.");
            }

            if (results[0].Letter != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.Letter)} is not null.");
            }

            if (results[0].NullableLetter != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableLetter)} is not null.");
            }

            if (results[0].DateTimeValue != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.DateTimeValue)} is not null.");
            }

            if (results[0].NullableDateTimeValue != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableDateTimeValue)} is not null.");
            }

            if (results[0].DecimalNumber != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.DecimalNumber)} is not null.");
            }

            if (results[0].NullableDecimalNumber != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableDecimalNumber)} is not null.");
            }

            if (results[0].DoubleNumber != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.DoubleNumber)} is not null.");
            }

            if (results[0].NullableDoubleNumber != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableDoubleNumber)} is not null.");
            }

            if (results[0].FloatNumber != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.FloatNumber)} is not null.");
            }

            if (results[0].NullableFloatNumber != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableFloatNumber)} is not null.");
            }

            if (results[0].GuidValue != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.GuidValue)} is not null.");
            }

            if (results[0].NullableGuidValue != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableGuidValue)} is not null.");
            }

            if (results[0].IntNumber != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.IntNumber)} is not null.");
            }

            if (results[0].NullableIntNumber != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableIntNumber)} is not null.");
            }

            if (results[0].LongNumber != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.LongNumber)} is not null.");
            }

            if (results[0].NullableLongNumber != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableLongNumber)} is not null.");
            }

            if (results[0].SByteNumber != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.SByteNumber)} is not null.");
            }

            if (results[0].NullableSByteNumber != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableSByteNumber)} is not null.");
            }

            if (results[0].ShortNumber != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.ShortNumber)} is not null.");
            }

            if (results[0].NullableShortNumber != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableShortNumber)} is not null.");
            }

            if (results[0].StreamValue != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.StreamValue)} is not null.");
            }

            if (results[0].StringValue != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.StringValue)} is not null.");
            }

            if (results[0].UIntNumber != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.UIntNumber)} is not null.");
            }

            if (results[0].NullableUIntNumber != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableUIntNumber)} is not null.");
            }

            if (results[0].ULongNumber != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.ULongNumber)} is not null.");
            }

            if (results[0].NullableULongNumber != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableULongNumber)} is not null.");
            }

            if (results[0].UShortNumber != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.UShortNumber)} is not null.");
            }

            if (results[0].NullableUShortNumber != null)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableUShortNumber)} is not null.");
            }

            if (results[1].ByteNumber != Constants.ByteNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.ByteNumber)} is not equal to {Constants.ByteNumber2}.");
            }

            if (results[1].NullableByteNumber != Constants.NullableByteNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableByteNumber)} is not equal to {Constants.NullableByteNumber2}.");
            }

            if (results[1].BoolValue != Constants.BoolValue2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.BoolValue)} is not equal to {Constants.BoolValue2}.");
            }

            if (results[1].NullableBoolValue != Constants.NullableBoolValue2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableBoolValue)} is not equal to {Constants.NullableBoolValue2}.");
            }

            if (!Constants.Bytes2.SequenceEqual((byte[])results[1].Bytes))
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.Bytes)} is not equal to {Constants.Bytes2}.");
            }

            if (!Constants.Chars2.SequenceEqual((char[])results[1].Chars.ToString().ToCharArray()))
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.Chars)} is not equal to {Constants.Chars2}.");
            }

            if (results[1].Letter != Constants.Letter2.ToString())
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.Letter)} is not equal to {Constants.Letter2}.");
            }

            if (results[1].NullableLetter != Constants.NullableLetter2?.ToString())
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableLetter)} is not equal to {Constants.NullableLetter2}.");
            }

            if (results[1].DateTimeValue != Constants.DateTimeValue2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.DateTimeValue)} is not equal to {Constants.DateTimeValue2}.");
            }

            if (results[1].NullableDateTimeValue != Constants.NullableDateTimeValue2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableDateTimeValue)} is not equal to {Constants.NullableDateTimeValue2}.");
            }

            if (results[1].DecimalNumber != Constants.DecimalNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.DecimalNumber)} is not equal to {Constants.DecimalNumber2}.");
            }

            if (results[1].NullableDecimalNumber != Constants.NullableDecimalNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableDecimalNumber)} is not equal to {Constants.NullableDecimalNumber2}.");
            }

            if (results[1].DoubleNumber != Constants.DoubleNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.DoubleNumber)} is not equal to {Constants.DoubleNumber2}.");
            }

            if (results[1].NullableDoubleNumber != Constants.NullableDoubleNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableDoubleNumber)} is not equal to {Constants.NullableDoubleNumber2}.");
            }

            if (results[1].FloatNumber != Constants.FloatNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.FloatNumber)} is not equal to {Constants.FloatNumber2}.");
            }

            if (results[1].NullableFloatNumber != Constants.NullableFloatNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableFloatNumber)} is not equal to {Constants.NullableFloatNumber2}.");
            }

            if (results[1].GuidValue != Constants.GuidValue2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.GuidValue)} is not equal to {Constants.GuidValue2}.");
            }

            if (results[1].NullableGuidValue != Constants.NullableGuidValue2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableGuidValue)} is not equal to {Constants.NullableGuidValue2}.");
            }

            if (results[1].IntNumber != Constants.IntNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.IntNumber)} is not equal to {Constants.IntNumber2}.");
            }

            if (results[1].NullableIntNumber != Constants.NullableIntNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableIntNumber)} is not equal to {Constants.NullableIntNumber2}.");
            }

            if (results[1].LongNumber != Constants.LongNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.LongNumber)} is not equal to {Constants.LongNumber2}.");
            }

            if (results[1].NullableLongNumber != Constants.NullableLongNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableLongNumber)} is not equal to {Constants.NullableLongNumber2}.");
            }

            if (results[1].SByteNumber != Constants.SByteNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.SByteNumber)} is not equal to {Constants.SByteNumber2}.");
            }

            if (results[1].NullableSByteNumber != Constants.NullableSByteNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableSByteNumber)} is not equal to {Constants.NullableSByteNumber2}.");
            }

            if (results[1].ShortNumber != Constants.ShortNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.ShortNumber)} is not equal to {Constants.ShortNumber2}.");
            }

            if (results[1].NullableShortNumber != Constants.NullableShortNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableShortNumber)} is not equal to {Constants.NullableShortNumber2}.");
            }

            if (!Constants.StreamValue2.SequenceEqual((byte[])results[1].StreamValue))
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.StreamValue)} is not equal to {Constants.StreamValue2}.");
            }

            if (results[1].StringValue != Constants.StringValue2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.StringValue)} is not equal to {Constants.StringValue2}.");
            }

            if (results[1].UIntNumber != Constants.UIntNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.UIntNumber)} is not equal to {Constants.UIntNumber2}.");
            }

            if (results[1].NullableUIntNumber != Constants.NullableUIntNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableUIntNumber)} is not equal to {Constants.NullableUIntNumber2}.");
            }

            if (results[1].ULongNumber != Constants.ULongNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.ULongNumber)} is not equal to {Constants.ULongNumber2}.");
            }

            if (results[1].NullableULongNumber != Constants.NullableULongNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableULongNumber)} is not equal to {Constants.NullableULongNumber2}.");
            }

            if (results[1].UShortNumber != Constants.UShortNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.UShortNumber)} is not equal to {Constants.UShortNumber2}.");
            }

            if (results[1].NullableUShortNumber != Constants.NullableUShortNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableUShortNumber)} is not equal to {Constants.NullableUShortNumber2}.");
            }
        }

        private static void CheckSingleObject(GenericTable genericTable)
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
            Debug.Assert(genericTable.GuidValue == Constants.GuidValue2);
            Debug.Assert(genericTable.NullableGuidValue == Constants.NullableGuidValue2);
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
                    Debug.Assert((long)dict[key] == Constants.ByteNumber2);
                }
                else if (string.Equals(key, nameof(GenericTable.NullableByteNumber), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert((long?)dict[key] == Constants.NullableByteNumber2);
                }
                else if (string.Equals(key, nameof(GenericTable.BoolValue), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert(Convert.ToInt32(dict[key]) == Convert.ToInt32(Constants.BoolValue2));
                }
                else if (string.Equals(key, nameof(GenericTable.NullableBoolValue), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert(Convert.ToInt32(dict[key]) == Convert.ToInt32(Constants.NullableBoolValue2));
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
                    Debug.Assert(Convert.ToDateTime(dict[key]) == Constants.DateTimeValue2);
                }
                else if (string.Equals(key, nameof(GenericTable.NullableDateTimeValue), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert(Convert.ToDateTime(dict[key]) == Constants.NullableDateTimeValue2);
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
                    Debug.Assert((double)dict[key] == Constants.FloatNumber2);
                }
                else if (string.Equals(key, nameof(GenericTable.NullableFloatNumber), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert((double?)dict[key] == Constants.NullableFloatNumber2);
                }
                else if (string.Equals(key, nameof(GenericTable.GuidValue), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert(string.Equals(Convert.ToString(dict[key]), Constants.GuidValue2.ToString(), StringComparison.OrdinalIgnoreCase));
                }
                else if (string.Equals(key, nameof(GenericTable.NullableGuidValue), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert(string.Equals(Convert.ToString(dict[key]), Constants.NullableGuidValue2?.ToString(), StringComparison.OrdinalIgnoreCase));
                }
                else if (string.Equals(key, nameof(GenericTable.IntNumber), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert((long)dict[key] == Constants.IntNumber2);
                }
                else if (string.Equals(key, nameof(GenericTable.NullableIntNumber), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert((long?)dict[key] == Constants.NullableIntNumber2);
                }
                else if (string.Equals(key, nameof(GenericTable.LongNumber), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert((long)dict[key] == Constants.LongNumber2);
                }
                else if (string.Equals(key, nameof(GenericTable.NullableLongNumber), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert((long?)dict[key] == Constants.NullableLongNumber2);
                }
                else if (string.Equals(key, nameof(GenericTable.SByteNumber), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert((long)dict[key] == Constants.SByteNumber2);
                }
                else if (string.Equals(key, nameof(GenericTable.NullableSByteNumber), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert((long?)dict[key] == Constants.NullableSByteNumber2);
                }
                else if (string.Equals(key, nameof(GenericTable.ShortNumber), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert((long)dict[key] == Constants.ShortNumber2);
                }
                else if (string.Equals(key, nameof(GenericTable.NullableShortNumber), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert((long?)dict[key] == Constants.NullableShortNumber2);
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
                    Debug.Assert((long)dict[key] == Constants.UIntNumber2);
                }
                else if (string.Equals(key, nameof(GenericTable.NullableUIntNumber), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert((long?)dict[key] == Constants.NullableUIntNumber2);
                }
                else if (string.Equals(key, nameof(GenericTable.ULongNumber), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert((long)dict[key] == Constants.ULongNumber2);
                }
                else if (string.Equals(key, nameof(GenericTable.NullableULongNumber), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert((long?)dict[key] == Constants.NullableULongNumber2);
                }
                else if (string.Equals(key, nameof(GenericTable.UShortNumber), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert((long)dict[key] == Constants.UShortNumber2);
                }
                else if (string.Equals(key, nameof(GenericTable.NullableUShortNumber), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Assert((long?)dict[key] == Constants.NullableUShortNumber2);
                }
                else
                {
                    throw new Exception("Unexpected key: " + key);
                }
            }
        }

        private static void CheckSingleDynamic(dynamic value)
        {
            if (value.ByteNumber != Constants.ByteNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.ByteNumber)} is not equal to {Constants.ByteNumber2}.");
            }

            if (value.NullableByteNumber != Constants.NullableByteNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableByteNumber)} is not equal to {Constants.NullableByteNumber2}.");
            }

            if (value.BoolValue != Constants.BoolValue2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.BoolValue)} is not equal to {Constants.BoolValue2}.");
            }

            if (value.NullableBoolValue != Constants.NullableBoolValue2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableBoolValue)} is not equal to {Constants.NullableBoolValue2}.");
            }

            if (!Constants.Bytes2.SequenceEqual((byte[])value.Bytes))
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.Bytes)} is not equal to {Constants.Bytes2}.");
            }

            if (!Constants.Chars2.SequenceEqual((char[])value.Chars.ToString().ToCharArray()))
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.Chars)} is not equal to {Constants.Chars2}.");
            }

            if (value.Letter != Constants.Letter2.ToString())
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.Letter)} is not equal to {Constants.Letter2}.");
            }

            if (value.NullableLetter != Constants.NullableLetter2?.ToString())
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableLetter)} is not equal to {Constants.NullableLetter2}.");
            }

            if (value.DateTimeValue != Constants.DateTimeValue2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.DateTimeValue)} is not equal to {Constants.DateTimeValue2}.");
            }

            if (value.NullableDateTimeValue != Constants.NullableDateTimeValue2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableDateTimeValue)} is not equal to {Constants.NullableDateTimeValue2}.");
            }

            if (value.DecimalNumber != Constants.DecimalNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.DecimalNumber)} is not equal to {Constants.DecimalNumber2}.");
            }

            if (value.NullableDecimalNumber != Constants.NullableDecimalNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableDecimalNumber)} is not equal to {Constants.NullableDecimalNumber2}.");
            }

            if (value.DoubleNumber != Constants.DoubleNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.DoubleNumber)} is not equal to {Constants.DoubleNumber2}.");
            }

            if (value.NullableDoubleNumber != Constants.NullableDoubleNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableDoubleNumber)} is not equal to {Constants.NullableDoubleNumber2}.");
            }

            if (value.FloatNumber != Constants.FloatNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.FloatNumber)} is not equal to {Constants.FloatNumber2}.");
            }

            if (value.NullableFloatNumber != Constants.NullableFloatNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableFloatNumber)} is not equal to {Constants.NullableFloatNumber2}.");
            }

            if (value.GuidValue != Constants.GuidValue2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.GuidValue)} is not equal to {Constants.GuidValue2}.");
            }

            if (value.NullableGuidValue != Constants.NullableGuidValue2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableGuidValue)} is not equal to {Constants.NullableGuidValue2}.");
            }

            if (value.IntNumber != Constants.IntNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.IntNumber)} is not equal to {Constants.IntNumber2}.");
            }

            if (value.NullableIntNumber != Constants.NullableIntNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableIntNumber)} is not equal to {Constants.NullableIntNumber2}.");
            }

            if (value.LongNumber != Constants.LongNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.LongNumber)} is not equal to {Constants.LongNumber2}.");
            }

            if (value.NullableLongNumber != Constants.NullableLongNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableLongNumber)} is not equal to {Constants.NullableLongNumber2}.");
            }

            if (value.SByteNumber != Constants.SByteNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.SByteNumber)} is not equal to {Constants.SByteNumber2}.");
            }

            if (value.NullableSByteNumber != Constants.NullableSByteNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableSByteNumber)} is not equal to {Constants.NullableSByteNumber2}.");
            }

            if (value.ShortNumber != Constants.ShortNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.ShortNumber)} is not equal to {Constants.ShortNumber2}.");
            }

            if (value.NullableShortNumber != Constants.NullableShortNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableShortNumber)} is not equal to {Constants.NullableShortNumber2}.");
            }

            if (!Constants.StreamValue2.SequenceEqual((byte[])value.StreamValue))
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.StreamValue)} is not equal to {Constants.StreamValue2}.");
            }

            if (value.StringValue != Constants.StringValue2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.StringValue)} is not equal to {Constants.StringValue2}.");
            }

            if (value.UIntNumber != Constants.UIntNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.UIntNumber)} is not equal to {Constants.UIntNumber2}.");
            }

            if (value.NullableUIntNumber != Constants.NullableUIntNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableUIntNumber)} is not equal to {Constants.NullableUIntNumber2}.");
            }

            if (value.ULongNumber != Constants.ULongNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.ULongNumber)} is not equal to {Constants.ULongNumber2}.");
            }

            if (value.NullableULongNumber != Constants.NullableULongNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableULongNumber)} is not equal to {Constants.NullableULongNumber2}.");
            }

            if (value.UShortNumber != Constants.UShortNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.UShortNumber)} is not equal to {Constants.UShortNumber2}.");
            }

            if (value.NullableUShortNumber != Constants.NullableUShortNumber2)
            {
                throw new InvalidDataException($"Parameter {nameof(GenericTable.NullableUShortNumber)} is not equal to {Constants.NullableUShortNumber2}.");
            }
        }

        private static void InsertData(string connectionString)
        {
            using (Connection<SqliteConnection> connection = new Connection<SqliteConnection>(connectionString, true))
            {
                connection.NonQuery(@"
                            CREATE TABLE IF NOT EXISTS GenericTable 
                            (
                                ByteNumber INTEGER NULL,
                                NullableByteNumber INTEGER NULL,
                                BoolValue BOOLEAN NULL,
                                NullableBoolValue BOOLEAN NULL,
                                Bytes BLOB NULL,
                                Chars TEXT NULL,
                                Letter TEXT NULL,
                                NullableLetter TEXT NULL,
                                DateTimeValue DATETIME NULL,
                                NullableDateTimeValue DATETIME NULL,
                                DecimalNumber DECIMAL(10, 5) NULL,
                                NullableDecimalNumber DECIMAL(10, 5) NULL,
                                DoubleNumber REAL NULL,
                                NullableDoubleNumber REAL NULL,
                                FloatNumber REAL NULL,
                                NullableFloatNumber REAL NULL,
                                GuidValue TEXT NULL,
                                NullableGuidValue TEXT NULL,
                                IntNumber INTEGER NULL,
                                NullableIntNumber INTEGER NULL,
                                LongNumber INTEGER NULL,
                                NullableLongNumber INTEGER NULL,
                                SByteNumber INTEGER NULL,
                                NullableSByteNumber INTEGER NULL,
                                ShortNumber INTEGER NULL,
                                NullableShortNumber INTEGER NULL,
                                StreamValue TEXT NULL,
                                StringValue TEXT NULL,
                                UIntNumber INTEGER NULL,
                                NullableUIntNumber INTEGER NULL,
                                ULongNumber INTEGER NULL,
                                NullableULongNumber INTEGER NULL,
                                UShortNumber INTEGER NULL,
                                NullableUShortNumber INTEGER NULL
                            );", null);

                connection.NonQuery(@"DELETE FROM GenericTable;", null);

                connection.NonQuery(
                    @"
                        INSERT INTO GenericTable
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
                                @ByteNumber1,
                                @NullableByteNumber1,
                                @BoolValue1,
                                @NullableBoolValue1,
                                @Bytes1,
                                @Chars1,
                                @Letter1,
                                @NullableLetter1,
                                @DateTimeValue1,
                                @NullableDateTimeValue1,
                                @DecimalNumber1,
                                @NullableDecimalNumber1,
                                @DoubleNumber1,
                                @NullableDoubleNumber1,
                                @FloatNumber1,
                                @NullableFloatNumber1,
                                @GuidValue1,
                                @NullableGuidValue1,
                                @IntNumber1,
                                @NullableIntNumber1,
                                @LongNumber1,
                                @NullableLongNumber1,
                                @SByteNumber1,
                                @NullableSByteNumber1,
                                @ShortNumber1,
                                @NullableShortNumber1,
                                @StreamValue1,
                                @StringValue1,
                                @UIntNumber1,
                                @NullableUIntNumber1,
                                @ULongNumber1,
                                @NullableULongNumber1,
                                @UShortNumber1,
                                @NullableUShortNumber1
                            ),
                            (
                                @ByteNumber2,
                                @NullableByteNumber2,
                                @BoolValue2,
                                @NullableBoolValue2,
                                @Bytes2,
                                @Chars2,
                                @Letter2,
                                @NullableLetter2,
                                @DateTimeValue2,
                                @NullableDateTimeValue2,
                                @DecimalNumber2,
                                @NullableDecimalNumber2,
                                @DoubleNumber2,
                                @NullableDoubleNumber2,
                                @FloatNumber2,
                                @NullableFloatNumber2,
                                @GuidValue2,
                                @NullableGuidValue2,
                                @IntNumber2,
                                @NullableIntNumber2,
                                @LongNumber2,
                                @NullableLongNumber2,
                                @SByteNumber2,
                                @NullableSByteNumber2,
                                @ShortNumber2,
                                @NullableShortNumber2,
                                @StreamValue2,
                                @StringValue2,
                                @UIntNumber2,
                                @NullableUIntNumber2,
                                @ULongNumber2,
                                @NullableULongNumber2,
                                @UShortNumber2,
                                @NullableUShortNumber2
                            );",
                    new List<SqlEParameter>()
                    {
                        new SqlEParameter("@ByteNumber1", typeof(byte)),
                        new SqlEParameter("@NullableByteNumber1", typeof(byte?)),
                        new SqlEParameter("@BoolValue1", typeof(bool)),
                        new SqlEParameter("@NullableBoolValue1", typeof(bool?)),
                        new SqlEParameter("@Bytes1", typeof(byte[])),
                        new SqlEParameter("@Chars1", typeof(char[])),
                        new SqlEParameter("@Letter1", typeof(char)),
                        new SqlEParameter("@NullableLetter1", typeof(char?)),
                        new SqlEParameter("@DateTimeValue1", typeof(DateTime)),
                        new SqlEParameter("@NullableDateTimeValue1", typeof(DateTime?)),
                        new SqlEParameter("@DecimalNumber1", typeof(decimal)),
                        new SqlEParameter("@NullableDecimalNumber1", typeof(decimal?)),
                        new SqlEParameter("@DoubleNumber1", typeof(double)),
                        new SqlEParameter("@NullableDoubleNumber1", typeof(double?)),
                        new SqlEParameter("@FloatNumber1", typeof(float)),
                        new SqlEParameter("@NullableFloatNumber1", typeof(float?)),
                        new SqlEParameter("@GuidValue1", typeof(Guid)),
                        new SqlEParameter("@NullableGuidValue1", typeof(Guid?)),
                        new SqlEParameter("@IntNumber1", typeof(int)),
                        new SqlEParameter("@NullableIntNumber1", typeof(int?)),
                        new SqlEParameter("@LongNumber1", typeof(long)),
                        new SqlEParameter("@NullableLongNumber1", typeof(long?)),
                        new SqlEParameter("@SByteNumber1", typeof(byte)),
                        new SqlEParameter("@NullableSByteNumber1", typeof(byte?)),
                        new SqlEParameter("@ShortNumber1", typeof(short)),
                        new SqlEParameter("@NullableShortNumber1", typeof(short?)),
                        new SqlEParameter("@StreamValue1", typeof(byte[])),
                        new SqlEParameter("@StringValue1", typeof(string)),
                        new SqlEParameter("@UIntNumber1", typeof(int)),
                        new SqlEParameter("@NullableUIntNumber1", typeof(int?)),
                        new SqlEParameter("@ULongNumber1", typeof(long)),
                        new SqlEParameter("@NullableULongNumber1", typeof(long?)),
                        new SqlEParameter("@UShortNumber1", typeof(short)),
                        new SqlEParameter("@NullableUShortNumber1", typeof(short?)),
                        new SqlEParameter("@ByteNumber2", Constants.ByteNumber2),
                        new SqlEParameter("@NullableByteNumber2", Constants.NullableByteNumber2),
                        new SqlEParameter("@BoolValue2", Constants.BoolValue2),
                        new SqlEParameter("@NullableBoolValue2", Constants.NullableBoolValue2),
                        new SqlEParameter("@Bytes2", Constants.Bytes2),
                        new SqlEParameter("@Chars2", Constants.Chars2),
                        new SqlEParameter("@Letter2", Constants.Letter2),
                        new SqlEParameter("@NullableLetter2", Constants.NullableLetter2),
                        new SqlEParameter("@DateTimeValue2", Constants.DateTimeValue2),
                        new SqlEParameter("@NullableDateTimeValue2", Constants.NullableDateTimeValue2),
                        new SqlEParameter("@DecimalNumber2", Constants.DecimalNumber2),
                        new SqlEParameter("@NullableDecimalNumber2",Constants.NullableDecimalNumber2),
                        new SqlEParameter("@DoubleNumber2", Constants.DoubleNumber2),
                        new SqlEParameter("@NullableDoubleNumber2", Constants.NullableDoubleNumber2),
                        new SqlEParameter("@FloatNumber2", Constants.FloatNumber2),
                        new SqlEParameter("@NullableFloatNumber2", Constants.NullableFloatNumber2),
                        new SqlEParameter("@GuidValue2", Constants.GuidValue2),
                        new SqlEParameter("@NullableGuidValue2", Constants.NullableGuidValue2),
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
