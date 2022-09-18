using EConnect;
using EConnectUnitTests.Mockups;
using EConnectUnitTests.TestModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace EConnectUnitTests
{
    [TestClass]
    public class QueryObjectWithFieldsTest
    {
        private const string CONNECTION_STRING = "connection";
        private const string QUERY = "query";

        [TestMethod]
        public void QueryReturnsEmptyListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<TestClassWithFields> values = connection.Query<TestClassWithFields>(QUERY, null);

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryAsyncReturnsEmptyListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<TestClassWithFields> values = connection.QueryAsync<TestClassWithFields>(QUERY, null).Result;

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryReturnsObject()
        {
            byte firstIsByte = 0;
            byte? firstIsNullableByte = 13;
            bool firstIsBool = true;
            bool firstIsNullableBool = false;
            byte[] firstIsBytes = { 1, 2, 3, 4 };
            char[] firstIsChars = { 'a', 'b', 'c' };
            char firstIsChar = 'z';
            char? firstIsNullableChar = 'y';
            DateTime firstIsDateTime = new DateTime(2000, 11, 2);
            DateTime? firstIsNullableDateTime = new DateTime(2002, 6, 5);
            decimal firstIsDecimal = 2m;
            decimal? firstIsNullableDecimal = 21m;
            double firstIsDouble = 2.5d;
            double? firstIsNullableDouble = 3.5d;
            float firstIsFloat = 4.5f;
            float? firstIsNullableFloat = 5.5f;
            Guid firstIsGuid = Guid.NewGuid();
            Guid? firstIsNullableGuid = Guid.NewGuid();
            int firstIsInt = 22;
            int? firstIsNullableInt = 33;
            long firstIsLong = 100;
            long? firstIsNullableLong = 101;
            sbyte firstIsSByte = 11;
            sbyte? firstIsNullableSByte = 12;
            short firstIsShort = 33;
            short? firstIsNullabelShort = 34;
            Stream firstIsStream = new MemoryStream(firstIsBytes);
            string firstIsString = "test one";
            uint firstIsUInt = 1000;
            uint? firstIsNullableUInt = 1001;
            ulong firstIsULong = 10000;
            ulong? firstIsNullableULong = 100001;
            ushort firstIsUShort = 10033;
            ushort? firstIsNullableUShort = 10034;

            byte secondIsByte = 10;
            byte? secondIsNullableByte = 113;
            bool secondIsBool = false;
            bool secondIsNullableBool = true;
            byte[] secondIsBytes = { 4, 3, 2, 1 };
            char[] secondIsChars = { 'c', 'b', 'a' };
            char secondIsChar = 'x';
            char? secondIsNullableChar = 'q';
            DateTime secondIsDateTime = new DateTime(2000, 10, 2);
            DateTime? secondIsNullableDateTime = new DateTime(2002, 1, 5);
            decimal secondIsDecimal = 12m;
            decimal? secondIsNullableDecimal = 31m;
            double secondIsDouble = 6.5d;
            double? secondIsNullableDouble = 9.5d;
            float secondIsFloat = 21.5f;
            float? secondIsNullableFloat = 14.5f;
            Guid secondIsGuid = Guid.NewGuid();
            Guid? secondIsNullableGuid = Guid.NewGuid();
            int secondIsInt = 33;
            int? secondIsNullableInt = 90;
            long secondIsLong = 110;
            long? secondIsNullableLong = 141;
            sbyte secondIsSByte = 112;
            sbyte? secondIsNullableSByte = 121;
            short secondIsShort = 42;
            short? secondIsNullabelShort = 56;
            Stream secondIsStream = new MemoryStream(secondIsBytes);
            string secondIsString = "test two";
            uint secondIsUInt = 1010;
            uint? secondIsNullableUInt = 1011;
            ulong secondIsULong = 10230;
            ulong? secondIsNullableULong = 100045;
            ushort secondIsUShort = 10144;
            ushort? secondIsNullableUShort = 10434;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "IsByte", firstIsByte },
                        { "IsNullableByte", firstIsNullableByte },
                        { "IsBool", firstIsBool },
                        { "IsNullableBool", firstIsNullableBool },
                        { "Bytes", firstIsBytes },
                        { "Chars", firstIsChars },
                        { "IsChar", firstIsChar },
                        { "IsNullableChar", firstIsNullableChar },
                        { "IsDateTime", firstIsDateTime },
                        { "IsNullableDateTime", firstIsNullableDateTime },
                        { "IsDecimal", firstIsDecimal },
                        { "IsNullableDecimal", firstIsNullableDecimal },
                        { "IsDouble", firstIsDouble },
                        { "IsNullableDouble", firstIsNullableDouble },
                        { "IsFloat", firstIsFloat },
                        { "IsNullableFloat", firstIsNullableFloat },
                        { "IsGuid", firstIsGuid },
                        { "IsNullableGuid", firstIsNullableGuid },
                        { "IsInt", firstIsInt },
                        { "IsNullableInt", firstIsNullableInt },
                        { "IsLong", firstIsLong },
                        { "IsNullableLong", firstIsNullableLong },
                        { "IsSByte", firstIsSByte },
                        { "IsNullableSByte", firstIsNullableSByte },
                        { "IsShort", firstIsShort },
                        { "IsNullabelShort", firstIsNullabelShort },
                        { "IsStream", firstIsStream },
                        { "IsString", firstIsString },
                        { "IsUInt", firstIsUInt },
                        { "IsNullableUInt", firstIsNullableUInt },
                        { "IsULong", firstIsULong },
                        { "IsNullableULong", firstIsNullableULong },
                        { "IsUShort", firstIsUShort },
                        { "IsNullableUShort", firstIsNullableUShort }
                    },
                    new Dictionary<string, object>()
                    {
                        { "IsByte", secondIsByte },
                        { "IsNullableByte", secondIsNullableByte },
                        { "IsBool", secondIsBool },
                        { "IsNullableBool", secondIsNullableBool },
                        { "Bytes", secondIsBytes },
                        { "Chars", secondIsChars },
                        { "IsChar", secondIsChar },
                        { "IsNullableChar", secondIsNullableChar },
                        { "IsDateTime", secondIsDateTime },
                        { "IsNullableDateTime", secondIsNullableDateTime },
                        { "IsDecimal", secondIsDecimal },
                        { "IsNullableDecimal", secondIsNullableDecimal },
                        { "IsDouble", secondIsDouble },
                        { "IsNullableDouble", secondIsNullableDouble },
                        { "IsFloat", secondIsFloat },
                        { "IsNullableFloat", secondIsNullableFloat },
                        { "IsGuid", secondIsGuid },
                        { "IsNullableGuid", secondIsNullableGuid },
                        { "IsInt", secondIsInt },
                        { "IsNullableInt", secondIsNullableInt },
                        { "IsLong", secondIsLong },
                        { "IsNullableLong", secondIsNullableLong },
                        { "IsSByte", secondIsSByte },
                        { "IsNullableSByte", secondIsNullableSByte },
                        { "IsShort", secondIsShort },
                        { "IsNullabelShort", secondIsNullabelShort },
                        { "IsStream", secondIsStream },
                        { "IsString", secondIsString },
                        { "IsUInt", secondIsUInt },
                        { "IsNullableUInt", secondIsNullableUInt },
                        { "IsULong", secondIsULong },
                        { "IsNullableULong", secondIsNullableULong },
                        { "IsUShort", secondIsUShort },
                        { "IsNullableUShort", secondIsNullableUShort }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<TestClassWithFields> values = connection.Query<TestClassWithFields>(QUERY, null);

            Assert.AreEqual(2, values.Count);
            
            Assert.AreEqual(firstIsByte, values[0].IsByte);
            Assert.AreEqual(firstIsNullableByte, values[0].IsNullableByte);
            Assert.AreEqual(firstIsBool, values[0].IsBool);
            Assert.AreEqual(firstIsNullableBool, values[0].IsNullableBool);

            Assert.AreEqual(firstIsBytes.Length, values[0].Bytes.Length);

            for (int i = 0; i < firstIsBytes.Length; i++)
            {
                Assert.AreEqual(firstIsBytes[i], values[0].Bytes[i]);
            }

            Assert.AreEqual(firstIsChars.Length, values[0].Chars.Length);

            for (int i = 0; i < firstIsChars.Length; i++)
            {
                Assert.AreEqual(firstIsChars[i], values[0].Chars[i]);
            }

            Assert.AreEqual(firstIsChar, values[0].IsChar);
            Assert.AreEqual(firstIsNullableChar, values[0].IsNullableChar);
            Assert.AreEqual(firstIsDateTime, values[0].IsDateTime);
            Assert.AreEqual(firstIsNullableDateTime, values[0].IsNullableDateTime);
            Assert.AreEqual(firstIsDecimal, values[0].IsDecimal);
            Assert.AreEqual(firstIsNullableDecimal, values[0].IsNullableDecimal);
            Assert.AreEqual(firstIsDouble, values[0].IsDouble);
            Assert.AreEqual(firstIsNullableDouble, values[0].IsNullableDouble);
            Assert.AreEqual(firstIsFloat, values[0].IsFloat);
            Assert.AreEqual(firstIsNullableFloat, values[0].IsNullableFloat);
            Assert.AreEqual(firstIsGuid, values[0].IsGuid);
            Assert.AreEqual(firstIsNullableGuid, values[0].IsNullableGuid);
            Assert.AreEqual(firstIsInt, values[0].IsInt);
            Assert.AreEqual(firstIsNullableInt, values[0].IsNullableInt);
            Assert.AreEqual(firstIsLong, values[0].IsLong);
            Assert.AreEqual(firstIsNullableLong, values[0].IsNullableLong);
            Assert.AreEqual(firstIsSByte, values[0].IsSByte);
            Assert.AreEqual(firstIsNullableSByte, values[0].IsNullableSByte);
            Assert.AreEqual(firstIsShort, values[0].IsShort);
            Assert.AreEqual(firstIsNullabelShort, values[0].IsNullabelShort);

            MemoryStream firstMS = new MemoryStream();
            values[0].IsStream.CopyTo(firstMS);

            byte[] firstStreamBytes = firstMS.ToArray();

            Assert.AreEqual(firstIsBytes.Length, firstStreamBytes.Length);

            for (int i = 0; i < firstIsBytes.Length; i++)
            {
                Assert.AreEqual(firstIsBytes[i], firstStreamBytes[i]);
            }

            Assert.AreEqual(firstIsString, values[0].IsString);
            Assert.AreEqual(firstIsUInt, values[0].IsUInt);
            Assert.AreEqual(firstIsNullableUInt, values[0].IsNullableUInt);
            Assert.AreEqual(firstIsULong, values[0].IsULong);
            Assert.AreEqual(firstIsNullableULong, values[0].IsNullableULong);
            Assert.AreEqual(firstIsUShort, values[0].IsUShort);
            Assert.AreEqual(firstIsNullableUShort, values[0].IsNullableUShort);

            Assert.AreEqual(secondIsByte, values[1].IsByte);
            Assert.AreEqual(secondIsNullableByte, values[1].IsNullableByte);
            Assert.AreEqual(secondIsBool, values[1].IsBool);
            Assert.AreEqual(secondIsNullableBool, values[1].IsNullableBool);

            Assert.AreEqual(secondIsBytes.Length, values[1].Bytes.Length);

            for (int i = 0; i < secondIsBytes.Length; i++)
            {
                Assert.AreEqual(secondIsBytes[i], values[1].Bytes[i]);
            }

            Assert.AreEqual(secondIsChars.Length, values[1].Chars.Length);

            for (int i = 0; i < secondIsChars.Length; i++)
            {
                Assert.AreEqual(secondIsChars[i], values[1].Chars[i]);
            }

            Assert.AreEqual(secondIsChar, values[1].IsChar);
            Assert.AreEqual(secondIsNullableChar, values[1].IsNullableChar);
            Assert.AreEqual(secondIsDateTime, values[1].IsDateTime);
            Assert.AreEqual(secondIsNullableDateTime, values[1].IsNullableDateTime);
            Assert.AreEqual(secondIsDecimal, values[1].IsDecimal);
            Assert.AreEqual(secondIsNullableDecimal, values[1].IsNullableDecimal);
            Assert.AreEqual(secondIsDouble, values[1].IsDouble);
            Assert.AreEqual(secondIsNullableDouble, values[1].IsNullableDouble);
            Assert.AreEqual(secondIsFloat, values[1].IsFloat);
            Assert.AreEqual(secondIsNullableFloat, values[1].IsNullableFloat);
            Assert.AreEqual(secondIsGuid, values[1].IsGuid);
            Assert.AreEqual(secondIsNullableGuid, values[1].IsNullableGuid);
            Assert.AreEqual(secondIsInt, values[1].IsInt);
            Assert.AreEqual(secondIsNullableInt, values[1].IsNullableInt);
            Assert.AreEqual(secondIsLong, values[1].IsLong);
            Assert.AreEqual(secondIsNullableLong, values[1].IsNullableLong);
            Assert.AreEqual(secondIsSByte, values[1].IsSByte);
            Assert.AreEqual(secondIsNullableSByte, values[1].IsNullableSByte);
            Assert.AreEqual(secondIsShort, values[1].IsShort);
            Assert.AreEqual(secondIsNullabelShort, values[1].IsNullabelShort);

            MemoryStream secondMS = new MemoryStream();
            values[1].IsStream.CopyTo(secondMS);

            byte[] secondStreamBytes = secondMS.ToArray();

            Assert.AreEqual(secondIsBytes.Length, secondStreamBytes.Length);

            for (int i = 0; i < secondIsBytes.Length; i++)
            {
                Assert.AreEqual(secondIsBytes[i], secondStreamBytes[i]);
            }

            Assert.AreEqual(secondIsString, values[1].IsString);
            Assert.AreEqual(secondIsUInt, values[1].IsUInt);
            Assert.AreEqual(secondIsNullableUInt, values[1].IsNullableUInt);
            Assert.AreEqual(secondIsULong, values[1].IsULong);
            Assert.AreEqual(secondIsNullableULong, values[1].IsNullableULong);
            Assert.AreEqual(secondIsUShort, values[1].IsUShort);
            Assert.AreEqual(secondIsNullableUShort, values[1].IsNullableUShort);
        }

        [TestMethod]
        public void QueryAsyncReturnsObject()
        {
            byte firstIsByte = 0;
            byte? firstIsNullableByte = 13;
            bool firstIsBool = true;
            bool firstIsNullableBool = false;
            byte[] firstIsBytes = { 1, 2, 3, 4 };
            char[] firstIsChars = { 'a', 'b', 'c' };
            char firstIsChar = 'z';
            char? firstIsNullableChar = 'y';
            DateTime firstIsDateTime = new DateTime(2000, 11, 2);
            DateTime? firstIsNullableDateTime = new DateTime(2002, 6, 5);
            decimal firstIsDecimal = 2m;
            decimal? firstIsNullableDecimal = 21m;
            double firstIsDouble = 2.5d;
            double? firstIsNullableDouble = 3.5d;
            float firstIsFloat = 4.5f;
            float? firstIsNullableFloat = 5.5f;
            Guid firstIsGuid = Guid.NewGuid();
            Guid? firstIsNullableGuid = Guid.NewGuid();
            int firstIsInt = 22;
            int? firstIsNullableInt = 33;
            long firstIsLong = 100;
            long? firstIsNullableLong = 101;
            sbyte firstIsSByte = 11;
            sbyte? firstIsNullableSByte = 12;
            short firstIsShort = 33;
            short? firstIsNullabelShort = 34;
            Stream firstIsStream = new MemoryStream(firstIsBytes);
            string firstIsString = "test one";
            uint firstIsUInt = 1000;
            uint? firstIsNullableUInt = 1001;
            ulong firstIsULong = 10000;
            ulong? firstIsNullableULong = 100001;
            ushort firstIsUShort = 10033;
            ushort? firstIsNullableUShort = 10034;

            byte secondIsByte = 10;
            byte? secondIsNullableByte = 113;
            bool secondIsBool = false;
            bool secondIsNullableBool = true;
            byte[] secondIsBytes = { 4, 3, 2, 1 };
            char[] secondIsChars = { 'c', 'b', 'a' };
            char secondIsChar = 'x';
            char? secondIsNullableChar = 'q';
            DateTime secondIsDateTime = new DateTime(2000, 10, 2);
            DateTime? secondIsNullableDateTime = new DateTime(2002, 1, 5);
            decimal secondIsDecimal = 12m;
            decimal? secondIsNullableDecimal = 31m;
            double secondIsDouble = 6.5d;
            double? secondIsNullableDouble = 9.5d;
            float secondIsFloat = 21.5f;
            float? secondIsNullableFloat = 14.5f;
            Guid secondIsGuid = Guid.NewGuid();
            Guid? secondIsNullableGuid = Guid.NewGuid();
            int secondIsInt = 33;
            int? secondIsNullableInt = 90;
            long secondIsLong = 110;
            long? secondIsNullableLong = 141;
            sbyte secondIsSByte = 112;
            sbyte? secondIsNullableSByte = 121;
            short secondIsShort = 42;
            short? secondIsNullabelShort = 56;
            Stream secondIsStream = new MemoryStream(secondIsBytes);
            string secondIsString = "test two";
            uint secondIsUInt = 1010;
            uint? secondIsNullableUInt = 1011;
            ulong secondIsULong = 10230;
            ulong? secondIsNullableULong = 100045;
            ushort secondIsUShort = 10144;
            ushort? secondIsNullableUShort = 10434;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "IsByte", firstIsByte },
                        { "IsNullableByte", firstIsNullableByte },
                        { "IsBool", firstIsBool },
                        { "IsNullableBool", firstIsNullableBool },
                        { "Bytes", firstIsBytes },
                        { "Chars", firstIsChars },
                        { "IsChar", firstIsChar },
                        { "IsNullableChar", firstIsNullableChar },
                        { "IsDateTime", firstIsDateTime },
                        { "IsNullableDateTime", firstIsNullableDateTime },
                        { "IsDecimal", firstIsDecimal },
                        { "IsNullableDecimal", firstIsNullableDecimal },
                        { "IsDouble", firstIsDouble },
                        { "IsNullableDouble", firstIsNullableDouble },
                        { "IsFloat", firstIsFloat },
                        { "IsNullableFloat", firstIsNullableFloat },
                        { "IsGuid", firstIsGuid },
                        { "IsNullableGuid", firstIsNullableGuid },
                        { "IsInt", firstIsInt },
                        { "IsNullableInt", firstIsNullableInt },
                        { "IsLong", firstIsLong },
                        { "IsNullableLong", firstIsNullableLong },
                        { "IsSByte", firstIsSByte },
                        { "IsNullableSByte", firstIsNullableSByte },
                        { "IsShort", firstIsShort },
                        { "IsNullabelShort", firstIsNullabelShort },
                        { "IsStream", firstIsStream },
                        { "IsString", firstIsString },
                        { "IsUInt", firstIsUInt },
                        { "IsNullableUInt", firstIsNullableUInt },
                        { "IsULong", firstIsULong },
                        { "IsNullableULong", firstIsNullableULong },
                        { "IsUShort", firstIsUShort },
                        { "IsNullableUShort", firstIsNullableUShort }
                    },
                    new Dictionary<string, object>()
                    {
                        { "IsByte", secondIsByte },
                        { "IsNullableByte", secondIsNullableByte },
                        { "IsBool", secondIsBool },
                        { "IsNullableBool", secondIsNullableBool },
                        { "Bytes", secondIsBytes },
                        { "Chars", secondIsChars },
                        { "IsChar", secondIsChar },
                        { "IsNullableChar", secondIsNullableChar },
                        { "IsDateTime", secondIsDateTime },
                        { "IsNullableDateTime", secondIsNullableDateTime },
                        { "IsDecimal", secondIsDecimal },
                        { "IsNullableDecimal", secondIsNullableDecimal },
                        { "IsDouble", secondIsDouble },
                        { "IsNullableDouble", secondIsNullableDouble },
                        { "IsFloat", secondIsFloat },
                        { "IsNullableFloat", secondIsNullableFloat },
                        { "IsGuid", secondIsGuid },
                        { "IsNullableGuid", secondIsNullableGuid },
                        { "IsInt", secondIsInt },
                        { "IsNullableInt", secondIsNullableInt },
                        { "IsLong", secondIsLong },
                        { "IsNullableLong", secondIsNullableLong },
                        { "IsSByte", secondIsSByte },
                        { "IsNullableSByte", secondIsNullableSByte },
                        { "IsShort", secondIsShort },
                        { "IsNullabelShort", secondIsNullabelShort },
                        { "IsStream", secondIsStream },
                        { "IsString", secondIsString },
                        { "IsUInt", secondIsUInt },
                        { "IsNullableUInt", secondIsNullableUInt },
                        { "IsULong", secondIsULong },
                        { "IsNullableULong", secondIsNullableULong },
                        { "IsUShort", secondIsUShort },
                        { "IsNullableUShort", secondIsNullableUShort }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<TestClassWithFields> values = connection.QueryAsync<TestClassWithFields>(QUERY, null).Result;

            Assert.AreEqual(2, values.Count);

            Assert.AreEqual(firstIsByte, values[0].IsByte);
            Assert.AreEqual(firstIsNullableByte, values[0].IsNullableByte);
            Assert.AreEqual(firstIsBool, values[0].IsBool);
            Assert.AreEqual(firstIsNullableBool, values[0].IsNullableBool);

            Assert.AreEqual(firstIsBytes.Length, values[0].Bytes.Length);

            for (int i = 0; i < firstIsBytes.Length; i++)
            {
                Assert.AreEqual(firstIsBytes[i], values[0].Bytes[i]);
            }

            Assert.AreEqual(firstIsChars.Length, values[0].Chars.Length);

            for (int i = 0; i < firstIsChars.Length; i++)
            {
                Assert.AreEqual(firstIsChars[i], values[0].Chars[i]);
            }

            Assert.AreEqual(firstIsChar, values[0].IsChar);
            Assert.AreEqual(firstIsNullableChar, values[0].IsNullableChar);
            Assert.AreEqual(firstIsDateTime, values[0].IsDateTime);
            Assert.AreEqual(firstIsNullableDateTime, values[0].IsNullableDateTime);
            Assert.AreEqual(firstIsDecimal, values[0].IsDecimal);
            Assert.AreEqual(firstIsNullableDecimal, values[0].IsNullableDecimal);
            Assert.AreEqual(firstIsDouble, values[0].IsDouble);
            Assert.AreEqual(firstIsNullableDouble, values[0].IsNullableDouble);
            Assert.AreEqual(firstIsFloat, values[0].IsFloat);
            Assert.AreEqual(firstIsNullableFloat, values[0].IsNullableFloat);
            Assert.AreEqual(firstIsGuid, values[0].IsGuid);
            Assert.AreEqual(firstIsNullableGuid, values[0].IsNullableGuid);
            Assert.AreEqual(firstIsInt, values[0].IsInt);
            Assert.AreEqual(firstIsNullableInt, values[0].IsNullableInt);
            Assert.AreEqual(firstIsLong, values[0].IsLong);
            Assert.AreEqual(firstIsNullableLong, values[0].IsNullableLong);
            Assert.AreEqual(firstIsSByte, values[0].IsSByte);
            Assert.AreEqual(firstIsNullableSByte, values[0].IsNullableSByte);
            Assert.AreEqual(firstIsShort, values[0].IsShort);
            Assert.AreEqual(firstIsNullabelShort, values[0].IsNullabelShort);

            MemoryStream firstMS = new MemoryStream();
            values[0].IsStream.CopyTo(firstMS);

            byte[] firstStreamBytes = firstMS.ToArray();

            Assert.AreEqual(firstIsBytes.Length, firstStreamBytes.Length);

            for (int i = 0; i < firstIsBytes.Length; i++)
            {
                Assert.AreEqual(firstIsBytes[i], firstStreamBytes[i]);
            }

            Assert.AreEqual(firstIsString, values[0].IsString);
            Assert.AreEqual(firstIsUInt, values[0].IsUInt);
            Assert.AreEqual(firstIsNullableUInt, values[0].IsNullableUInt);
            Assert.AreEqual(firstIsULong, values[0].IsULong);
            Assert.AreEqual(firstIsNullableULong, values[0].IsNullableULong);
            Assert.AreEqual(firstIsUShort, values[0].IsUShort);
            Assert.AreEqual(firstIsNullableUShort, values[0].IsNullableUShort);

            Assert.AreEqual(secondIsByte, values[1].IsByte);
            Assert.AreEqual(secondIsNullableByte, values[1].IsNullableByte);
            Assert.AreEqual(secondIsBool, values[1].IsBool);
            Assert.AreEqual(secondIsNullableBool, values[1].IsNullableBool);

            Assert.AreEqual(secondIsBytes.Length, values[1].Bytes.Length);

            for (int i = 0; i < secondIsBytes.Length; i++)
            {
                Assert.AreEqual(secondIsBytes[i], values[1].Bytes[i]);
            }

            Assert.AreEqual(secondIsChars.Length, values[1].Chars.Length);

            for (int i = 0; i < secondIsChars.Length; i++)
            {
                Assert.AreEqual(secondIsChars[i], values[1].Chars[i]);
            }

            Assert.AreEqual(secondIsChar, values[1].IsChar);
            Assert.AreEqual(secondIsNullableChar, values[1].IsNullableChar);
            Assert.AreEqual(secondIsDateTime, values[1].IsDateTime);
            Assert.AreEqual(secondIsNullableDateTime, values[1].IsNullableDateTime);
            Assert.AreEqual(secondIsDecimal, values[1].IsDecimal);
            Assert.AreEqual(secondIsNullableDecimal, values[1].IsNullableDecimal);
            Assert.AreEqual(secondIsDouble, values[1].IsDouble);
            Assert.AreEqual(secondIsNullableDouble, values[1].IsNullableDouble);
            Assert.AreEqual(secondIsFloat, values[1].IsFloat);
            Assert.AreEqual(secondIsNullableFloat, values[1].IsNullableFloat);
            Assert.AreEqual(secondIsGuid, values[1].IsGuid);
            Assert.AreEqual(secondIsNullableGuid, values[1].IsNullableGuid);
            Assert.AreEqual(secondIsInt, values[1].IsInt);
            Assert.AreEqual(secondIsNullableInt, values[1].IsNullableInt);
            Assert.AreEqual(secondIsLong, values[1].IsLong);
            Assert.AreEqual(secondIsNullableLong, values[1].IsNullableLong);
            Assert.AreEqual(secondIsSByte, values[1].IsSByte);
            Assert.AreEqual(secondIsNullableSByte, values[1].IsNullableSByte);
            Assert.AreEqual(secondIsShort, values[1].IsShort);
            Assert.AreEqual(secondIsNullabelShort, values[1].IsNullabelShort);

            MemoryStream secondMS = new MemoryStream();
            values[1].IsStream.CopyTo(secondMS);

            byte[] secondStreamBytes = secondMS.ToArray();

            Assert.AreEqual(secondIsBytes.Length, secondStreamBytes.Length);

            for (int i = 0; i < secondIsBytes.Length; i++)
            {
                Assert.AreEqual(secondIsBytes[i], secondStreamBytes[i]);
            }

            Assert.AreEqual(secondIsString, values[1].IsString);
            Assert.AreEqual(secondIsUInt, values[1].IsUInt);
            Assert.AreEqual(secondIsNullableUInt, values[1].IsNullableUInt);
            Assert.AreEqual(secondIsULong, values[1].IsULong);
            Assert.AreEqual(secondIsNullableULong, values[1].IsNullableULong);
            Assert.AreEqual(secondIsUShort, values[1].IsUShort);
            Assert.AreEqual(secondIsNullableUShort, values[1].IsNullableUShort);
        }

        [TestMethod]
        public void QueryReturnsObjectWithNoDefaultConstructor()
        {
            byte firstIsByte = 0;
            byte? firstIsNullableByte = 13;
            bool firstIsBool = true;
            bool firstIsNullableBool = false;
            byte[] firstIsBytes = { 1, 2, 3, 4 };
            char[] firstIsChars = { 'a', 'b', 'c' };
            char firstIsChar = 'z';
            char? firstIsNullableChar = 'y';
            DateTime firstIsDateTime = new DateTime(2000, 11, 2);
            DateTime? firstIsNullableDateTime = new DateTime(2002, 6, 5);
            decimal firstIsDecimal = 2m;
            decimal? firstIsNullableDecimal = 21m;
            double firstIsDouble = 2.5d;
            double? firstIsNullableDouble = 3.5d;
            float firstIsFloat = 4.5f;
            float? firstIsNullableFloat = 5.5f;
            Guid firstIsGuid = Guid.NewGuid();
            Guid? firstIsNullableGuid = Guid.NewGuid();
            int firstIsInt = 22;
            int? firstIsNullableInt = 33;
            long firstIsLong = 100;
            long? firstIsNullableLong = 101;
            sbyte firstIsSByte = 11;
            sbyte? firstIsNullableSByte = 12;
            short firstIsShort = 33;
            short? firstIsNullabelShort = 34;
            Stream firstIsStream = new MemoryStream(firstIsBytes);
            string firstIsString = "test one";
            uint firstIsUInt = 1000;
            uint? firstIsNullableUInt = 1001;
            ulong firstIsULong = 10000;
            ulong? firstIsNullableULong = 100001;
            ushort firstIsUShort = 10033;
            ushort? firstIsNullableUShort = 10034;

            byte secondIsByte = 10;
            byte? secondIsNullableByte = 113;
            bool secondIsBool = false;
            bool secondIsNullableBool = true;
            byte[] secondIsBytes = { 4, 3, 2, 1 };
            char[] secondIsChars = { 'c', 'b', 'a' };
            char secondIsChar = 'x';
            char? secondIsNullableChar = 'q';
            DateTime secondIsDateTime = new DateTime(2000, 10, 2);
            DateTime? secondIsNullableDateTime = new DateTime(2002, 1, 5);
            decimal secondIsDecimal = 12m;
            decimal? secondIsNullableDecimal = 31m;
            double secondIsDouble = 6.5d;
            double? secondIsNullableDouble = 9.5d;
            float secondIsFloat = 21.5f;
            float? secondIsNullableFloat = 14.5f;
            Guid secondIsGuid = Guid.NewGuid();
            Guid? secondIsNullableGuid = Guid.NewGuid();
            int secondIsInt = 33;
            int? secondIsNullableInt = 90;
            long secondIsLong = 110;
            long? secondIsNullableLong = 141;
            sbyte secondIsSByte = 112;
            sbyte? secondIsNullableSByte = 121;
            short secondIsShort = 42;
            short? secondIsNullabelShort = 56;
            Stream secondIsStream = new MemoryStream(secondIsBytes);
            string secondIsString = "test two";
            uint secondIsUInt = 1010;
            uint? secondIsNullableUInt = 1011;
            ulong secondIsULong = 10230;
            ulong? secondIsNullableULong = 100045;
            ushort secondIsUShort = 10144;
            ushort? secondIsNullableUShort = 10434;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "IsByte", firstIsByte },
                        { "IsNullableByte", firstIsNullableByte },
                        { "IsBool", firstIsBool },
                        { "IsNullableBool", firstIsNullableBool },
                        { "Bytes", firstIsBytes },
                        { "Chars", firstIsChars },
                        { "IsChar", firstIsChar },
                        { "IsNullableChar", firstIsNullableChar },
                        { "IsDateTime", firstIsDateTime },
                        { "IsNullableDateTime", firstIsNullableDateTime },
                        { "IsDecimal", firstIsDecimal },
                        { "IsNullableDecimal", firstIsNullableDecimal },
                        { "IsDouble", firstIsDouble },
                        { "IsNullableDouble", firstIsNullableDouble },
                        { "IsFloat", firstIsFloat },
                        { "IsNullableFloat", firstIsNullableFloat },
                        { "IsGuid", firstIsGuid },
                        { "IsNullableGuid", firstIsNullableGuid },
                        { "IsInt", firstIsInt },
                        { "IsNullableInt", firstIsNullableInt },
                        { "IsLong", firstIsLong },
                        { "IsNullableLong", firstIsNullableLong },
                        { "IsSByte", firstIsSByte },
                        { "IsNullableSByte", firstIsNullableSByte },
                        { "IsShort", firstIsShort },
                        { "IsNullabelShort", firstIsNullabelShort },
                        { "IsStream", firstIsStream },
                        { "IsString", firstIsString },
                        { "IsUInt", firstIsUInt },
                        { "IsNullableUInt", firstIsNullableUInt },
                        { "IsULong", firstIsULong },
                        { "IsNullableULong", firstIsNullableULong },
                        { "IsUShort", firstIsUShort },
                        { "IsNullableUShort", firstIsNullableUShort }
                    },
                    new Dictionary<string, object>()
                    {
                        { "IsByte", secondIsByte },
                        { "IsNullableByte", secondIsNullableByte },
                        { "IsBool", secondIsBool },
                        { "IsNullableBool", secondIsNullableBool },
                        { "Bytes", secondIsBytes },
                        { "Chars", secondIsChars },
                        { "IsChar", secondIsChar },
                        { "IsNullableChar", secondIsNullableChar },
                        { "IsDateTime", secondIsDateTime },
                        { "IsNullableDateTime", secondIsNullableDateTime },
                        { "IsDecimal", secondIsDecimal },
                        { "IsNullableDecimal", secondIsNullableDecimal },
                        { "IsDouble", secondIsDouble },
                        { "IsNullableDouble", secondIsNullableDouble },
                        { "IsFloat", secondIsFloat },
                        { "IsNullableFloat", secondIsNullableFloat },
                        { "IsGuid", secondIsGuid },
                        { "IsNullableGuid", secondIsNullableGuid },
                        { "IsInt", secondIsInt },
                        { "IsNullableInt", secondIsNullableInt },
                        { "IsLong", secondIsLong },
                        { "IsNullableLong", secondIsNullableLong },
                        { "IsSByte", secondIsSByte },
                        { "IsNullableSByte", secondIsNullableSByte },
                        { "IsShort", secondIsShort },
                        { "IsNullabelShort", secondIsNullabelShort },
                        { "IsStream", secondIsStream },
                        { "IsString", secondIsString },
                        { "IsUInt", secondIsUInt },
                        { "IsNullableUInt", secondIsNullableUInt },
                        { "IsULong", secondIsULong },
                        { "IsNullableULong", secondIsNullableULong },
                        { "IsUShort", secondIsUShort },
                        { "IsNullableUShort", secondIsNullableUShort }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<TestClassWithFieldsNoDefaultConstructor> values = connection.Query<TestClassWithFieldsNoDefaultConstructor>(QUERY, null);

            Assert.AreEqual(2, values.Count);

            Assert.AreEqual(firstIsByte, values[0].IsByte);
            Assert.AreEqual(firstIsNullableByte, values[0].IsNullableByte);
            Assert.AreEqual(firstIsBool, values[0].IsBool);
            Assert.AreEqual(firstIsNullableBool, values[0].IsNullableBool);

            Assert.AreEqual(firstIsBytes.Length, values[0].Bytes.Length);

            for (int i = 0; i < firstIsBytes.Length; i++)
            {
                Assert.AreEqual(firstIsBytes[i], values[0].Bytes[i]);
            }

            Assert.AreEqual(firstIsChars.Length, values[0].Chars.Length);

            for (int i = 0; i < firstIsChars.Length; i++)
            {
                Assert.AreEqual(firstIsChars[i], values[0].Chars[i]);
            }

            Assert.AreEqual(firstIsChar, values[0].IsChar);
            Assert.AreEqual(firstIsNullableChar, values[0].IsNullableChar);
            Assert.AreEqual(firstIsDateTime, values[0].IsDateTime);
            Assert.AreEqual(firstIsNullableDateTime, values[0].IsNullableDateTime);
            Assert.AreEqual(firstIsDecimal, values[0].IsDecimal);
            Assert.AreEqual(firstIsNullableDecimal, values[0].IsNullableDecimal);
            Assert.AreEqual(firstIsDouble, values[0].IsDouble);
            Assert.AreEqual(firstIsNullableDouble, values[0].IsNullableDouble);
            Assert.AreEqual(firstIsFloat, values[0].IsFloat);
            Assert.AreEqual(firstIsNullableFloat, values[0].IsNullableFloat);
            Assert.AreEqual(firstIsGuid, values[0].IsGuid);
            Assert.AreEqual(firstIsNullableGuid, values[0].IsNullableGuid);
            Assert.AreEqual(firstIsInt, values[0].IsInt);
            Assert.AreEqual(firstIsNullableInt, values[0].IsNullableInt);
            Assert.AreEqual(firstIsLong, values[0].IsLong);
            Assert.AreEqual(firstIsNullableLong, values[0].IsNullableLong);
            Assert.AreEqual(firstIsSByte, values[0].IsSByte);
            Assert.AreEqual(firstIsNullableSByte, values[0].IsNullableSByte);
            Assert.AreEqual(firstIsShort, values[0].IsShort);
            Assert.AreEqual(firstIsNullabelShort, values[0].IsNullabelShort);

            MemoryStream firstMS = new MemoryStream();
            values[0].IsStream.CopyTo(firstMS);

            byte[] firstStreamBytes = firstMS.ToArray();

            Assert.AreEqual(firstIsBytes.Length, firstStreamBytes.Length);

            for (int i = 0; i < firstIsBytes.Length; i++)
            {
                Assert.AreEqual(firstIsBytes[i], firstStreamBytes[i]);
            }

            Assert.AreEqual(firstIsString, values[0].IsString);
            Assert.AreEqual(firstIsUInt, values[0].IsUInt);
            Assert.AreEqual(firstIsNullableUInt, values[0].IsNullableUInt);
            Assert.AreEqual(firstIsULong, values[0].IsULong);
            Assert.AreEqual(firstIsNullableULong, values[0].IsNullableULong);
            Assert.AreEqual(firstIsUShort, values[0].IsUShort);
            Assert.AreEqual(firstIsNullableUShort, values[0].IsNullableUShort);

            Assert.AreEqual(secondIsByte, values[1].IsByte);
            Assert.AreEqual(secondIsNullableByte, values[1].IsNullableByte);
            Assert.AreEqual(secondIsBool, values[1].IsBool);
            Assert.AreEqual(secondIsNullableBool, values[1].IsNullableBool);

            Assert.AreEqual(secondIsBytes.Length, values[1].Bytes.Length);

            for (int i = 0; i < secondIsBytes.Length; i++)
            {
                Assert.AreEqual(secondIsBytes[i], values[1].Bytes[i]);
            }

            Assert.AreEqual(secondIsChars.Length, values[1].Chars.Length);

            for (int i = 0; i < secondIsChars.Length; i++)
            {
                Assert.AreEqual(secondIsChars[i], values[1].Chars[i]);
            }

            Assert.AreEqual(secondIsChar, values[1].IsChar);
            Assert.AreEqual(secondIsNullableChar, values[1].IsNullableChar);
            Assert.AreEqual(secondIsDateTime, values[1].IsDateTime);
            Assert.AreEqual(secondIsNullableDateTime, values[1].IsNullableDateTime);
            Assert.AreEqual(secondIsDecimal, values[1].IsDecimal);
            Assert.AreEqual(secondIsNullableDecimal, values[1].IsNullableDecimal);
            Assert.AreEqual(secondIsDouble, values[1].IsDouble);
            Assert.AreEqual(secondIsNullableDouble, values[1].IsNullableDouble);
            Assert.AreEqual(secondIsFloat, values[1].IsFloat);
            Assert.AreEqual(secondIsNullableFloat, values[1].IsNullableFloat);
            Assert.AreEqual(secondIsGuid, values[1].IsGuid);
            Assert.AreEqual(secondIsNullableGuid, values[1].IsNullableGuid);
            Assert.AreEqual(secondIsInt, values[1].IsInt);
            Assert.AreEqual(secondIsNullableInt, values[1].IsNullableInt);
            Assert.AreEqual(secondIsLong, values[1].IsLong);
            Assert.AreEqual(secondIsNullableLong, values[1].IsNullableLong);
            Assert.AreEqual(secondIsSByte, values[1].IsSByte);
            Assert.AreEqual(secondIsNullableSByte, values[1].IsNullableSByte);
            Assert.AreEqual(secondIsShort, values[1].IsShort);
            Assert.AreEqual(secondIsNullabelShort, values[1].IsNullabelShort);

            MemoryStream secondMS = new MemoryStream();
            values[1].IsStream.CopyTo(secondMS);

            byte[] secondStreamBytes = secondMS.ToArray();

            Assert.AreEqual(secondIsBytes.Length, secondStreamBytes.Length);

            for (int i = 0; i < secondIsBytes.Length; i++)
            {
                Assert.AreEqual(secondIsBytes[i], secondStreamBytes[i]);
            }

            Assert.AreEqual(secondIsString, values[1].IsString);
            Assert.AreEqual(secondIsUInt, values[1].IsUInt);
            Assert.AreEqual(secondIsNullableUInt, values[1].IsNullableUInt);
            Assert.AreEqual(secondIsULong, values[1].IsULong);
            Assert.AreEqual(secondIsNullableULong, values[1].IsNullableULong);
            Assert.AreEqual(secondIsUShort, values[1].IsUShort);
            Assert.AreEqual(secondIsNullableUShort, values[1].IsNullableUShort);
        }

        [TestMethod]
        public void QueryAsyncReturnsWithNoDefaultConstructor()
        {
            byte firstIsByte = 0;
            byte? firstIsNullableByte = 13;
            bool firstIsBool = true;
            bool firstIsNullableBool = false;
            byte[] firstIsBytes = { 1, 2, 3, 4 };
            char[] firstIsChars = { 'a', 'b', 'c' };
            char firstIsChar = 'z';
            char? firstIsNullableChar = 'y';
            DateTime firstIsDateTime = new DateTime(2000, 11, 2);
            DateTime? firstIsNullableDateTime = new DateTime(2002, 6, 5);
            decimal firstIsDecimal = 2m;
            decimal? firstIsNullableDecimal = 21m;
            double firstIsDouble = 2.5d;
            double? firstIsNullableDouble = 3.5d;
            float firstIsFloat = 4.5f;
            float? firstIsNullableFloat = 5.5f;
            Guid firstIsGuid = Guid.NewGuid();
            Guid? firstIsNullableGuid = Guid.NewGuid();
            int firstIsInt = 22;
            int? firstIsNullableInt = 33;
            long firstIsLong = 100;
            long? firstIsNullableLong = 101;
            sbyte firstIsSByte = 11;
            sbyte? firstIsNullableSByte = 12;
            short firstIsShort = 33;
            short? firstIsNullabelShort = 34;
            Stream firstIsStream = new MemoryStream(firstIsBytes);
            string firstIsString = "test one";
            uint firstIsUInt = 1000;
            uint? firstIsNullableUInt = 1001;
            ulong firstIsULong = 10000;
            ulong? firstIsNullableULong = 100001;
            ushort firstIsUShort = 10033;
            ushort? firstIsNullableUShort = 10034;

            byte secondIsByte = 10;
            byte? secondIsNullableByte = 113;
            bool secondIsBool = false;
            bool secondIsNullableBool = true;
            byte[] secondIsBytes = { 4, 3, 2, 1 };
            char[] secondIsChars = { 'c', 'b', 'a' };
            char secondIsChar = 'x';
            char? secondIsNullableChar = 'q';
            DateTime secondIsDateTime = new DateTime(2000, 10, 2);
            DateTime? secondIsNullableDateTime = new DateTime(2002, 1, 5);
            decimal secondIsDecimal = 12m;
            decimal? secondIsNullableDecimal = 31m;
            double secondIsDouble = 6.5d;
            double? secondIsNullableDouble = 9.5d;
            float secondIsFloat = 21.5f;
            float? secondIsNullableFloat = 14.5f;
            Guid secondIsGuid = Guid.NewGuid();
            Guid? secondIsNullableGuid = Guid.NewGuid();
            int secondIsInt = 33;
            int? secondIsNullableInt = 90;
            long secondIsLong = 110;
            long? secondIsNullableLong = 141;
            sbyte secondIsSByte = 112;
            sbyte? secondIsNullableSByte = 121;
            short secondIsShort = 42;
            short? secondIsNullabelShort = 56;
            Stream secondIsStream = new MemoryStream(secondIsBytes);
            string secondIsString = "test two";
            uint secondIsUInt = 1010;
            uint? secondIsNullableUInt = 1011;
            ulong secondIsULong = 10230;
            ulong? secondIsNullableULong = 100045;
            ushort secondIsUShort = 10144;
            ushort? secondIsNullableUShort = 10434;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "IsByte", firstIsByte },
                        { "IsNullableByte", firstIsNullableByte },
                        { "IsBool", firstIsBool },
                        { "IsNullableBool", firstIsNullableBool },
                        { "Bytes", firstIsBytes },
                        { "Chars", firstIsChars },
                        { "IsChar", firstIsChar },
                        { "IsNullableChar", firstIsNullableChar },
                        { "IsDateTime", firstIsDateTime },
                        { "IsNullableDateTime", firstIsNullableDateTime },
                        { "IsDecimal", firstIsDecimal },
                        { "IsNullableDecimal", firstIsNullableDecimal },
                        { "IsDouble", firstIsDouble },
                        { "IsNullableDouble", firstIsNullableDouble },
                        { "IsFloat", firstIsFloat },
                        { "IsNullableFloat", firstIsNullableFloat },
                        { "IsGuid", firstIsGuid },
                        { "IsNullableGuid", firstIsNullableGuid },
                        { "IsInt", firstIsInt },
                        { "IsNullableInt", firstIsNullableInt },
                        { "IsLong", firstIsLong },
                        { "IsNullableLong", firstIsNullableLong },
                        { "IsSByte", firstIsSByte },
                        { "IsNullableSByte", firstIsNullableSByte },
                        { "IsShort", firstIsShort },
                        { "IsNullabelShort", firstIsNullabelShort },
                        { "IsStream", firstIsStream },
                        { "IsString", firstIsString },
                        { "IsUInt", firstIsUInt },
                        { "IsNullableUInt", firstIsNullableUInt },
                        { "IsULong", firstIsULong },
                        { "IsNullableULong", firstIsNullableULong },
                        { "IsUShort", firstIsUShort },
                        { "IsNullableUShort", firstIsNullableUShort }
                    },
                    new Dictionary<string, object>()
                    {
                        { "IsByte", secondIsByte },
                        { "IsNullableByte", secondIsNullableByte },
                        { "IsBool", secondIsBool },
                        { "IsNullableBool", secondIsNullableBool },
                        { "Bytes", secondIsBytes },
                        { "Chars", secondIsChars },
                        { "IsChar", secondIsChar },
                        { "IsNullableChar", secondIsNullableChar },
                        { "IsDateTime", secondIsDateTime },
                        { "IsNullableDateTime", secondIsNullableDateTime },
                        { "IsDecimal", secondIsDecimal },
                        { "IsNullableDecimal", secondIsNullableDecimal },
                        { "IsDouble", secondIsDouble },
                        { "IsNullableDouble", secondIsNullableDouble },
                        { "IsFloat", secondIsFloat },
                        { "IsNullableFloat", secondIsNullableFloat },
                        { "IsGuid", secondIsGuid },
                        { "IsNullableGuid", secondIsNullableGuid },
                        { "IsInt", secondIsInt },
                        { "IsNullableInt", secondIsNullableInt },
                        { "IsLong", secondIsLong },
                        { "IsNullableLong", secondIsNullableLong },
                        { "IsSByte", secondIsSByte },
                        { "IsNullableSByte", secondIsNullableSByte },
                        { "IsShort", secondIsShort },
                        { "IsNullabelShort", secondIsNullabelShort },
                        { "IsStream", secondIsStream },
                        { "IsString", secondIsString },
                        { "IsUInt", secondIsUInt },
                        { "IsNullableUInt", secondIsNullableUInt },
                        { "IsULong", secondIsULong },
                        { "IsNullableULong", secondIsNullableULong },
                        { "IsUShort", secondIsUShort },
                        { "IsNullableUShort", secondIsNullableUShort }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<TestClassWithFieldsNoDefaultConstructor> values = connection.QueryAsync<TestClassWithFieldsNoDefaultConstructor>(QUERY, null).Result;

            Assert.AreEqual(2, values.Count);

            Assert.AreEqual(firstIsByte, values[0].IsByte);
            Assert.AreEqual(firstIsNullableByte, values[0].IsNullableByte);
            Assert.AreEqual(firstIsBool, values[0].IsBool);
            Assert.AreEqual(firstIsNullableBool, values[0].IsNullableBool);

            Assert.AreEqual(firstIsBytes.Length, values[0].Bytes.Length);

            for (int i = 0; i < firstIsBytes.Length; i++)
            {
                Assert.AreEqual(firstIsBytes[i], values[0].Bytes[i]);
            }

            Assert.AreEqual(firstIsChars.Length, values[0].Chars.Length);

            for (int i = 0; i < firstIsChars.Length; i++)
            {
                Assert.AreEqual(firstIsChars[i], values[0].Chars[i]);
            }

            Assert.AreEqual(firstIsChar, values[0].IsChar);
            Assert.AreEqual(firstIsNullableChar, values[0].IsNullableChar);
            Assert.AreEqual(firstIsDateTime, values[0].IsDateTime);
            Assert.AreEqual(firstIsNullableDateTime, values[0].IsNullableDateTime);
            Assert.AreEqual(firstIsDecimal, values[0].IsDecimal);
            Assert.AreEqual(firstIsNullableDecimal, values[0].IsNullableDecimal);
            Assert.AreEqual(firstIsDouble, values[0].IsDouble);
            Assert.AreEqual(firstIsNullableDouble, values[0].IsNullableDouble);
            Assert.AreEqual(firstIsFloat, values[0].IsFloat);
            Assert.AreEqual(firstIsNullableFloat, values[0].IsNullableFloat);
            Assert.AreEqual(firstIsGuid, values[0].IsGuid);
            Assert.AreEqual(firstIsNullableGuid, values[0].IsNullableGuid);
            Assert.AreEqual(firstIsInt, values[0].IsInt);
            Assert.AreEqual(firstIsNullableInt, values[0].IsNullableInt);
            Assert.AreEqual(firstIsLong, values[0].IsLong);
            Assert.AreEqual(firstIsNullableLong, values[0].IsNullableLong);
            Assert.AreEqual(firstIsSByte, values[0].IsSByte);
            Assert.AreEqual(firstIsNullableSByte, values[0].IsNullableSByte);
            Assert.AreEqual(firstIsShort, values[0].IsShort);
            Assert.AreEqual(firstIsNullabelShort, values[0].IsNullabelShort);

            MemoryStream firstMS = new MemoryStream();
            values[0].IsStream.CopyTo(firstMS);

            byte[] firstStreamBytes = firstMS.ToArray();

            Assert.AreEqual(firstIsBytes.Length, firstStreamBytes.Length);

            for (int i = 0; i < firstIsBytes.Length; i++)
            {
                Assert.AreEqual(firstIsBytes[i], firstStreamBytes[i]);
            }

            Assert.AreEqual(firstIsString, values[0].IsString);
            Assert.AreEqual(firstIsUInt, values[0].IsUInt);
            Assert.AreEqual(firstIsNullableUInt, values[0].IsNullableUInt);
            Assert.AreEqual(firstIsULong, values[0].IsULong);
            Assert.AreEqual(firstIsNullableULong, values[0].IsNullableULong);
            Assert.AreEqual(firstIsUShort, values[0].IsUShort);
            Assert.AreEqual(firstIsNullableUShort, values[0].IsNullableUShort);

            Assert.AreEqual(secondIsByte, values[1].IsByte);
            Assert.AreEqual(secondIsNullableByte, values[1].IsNullableByte);
            Assert.AreEqual(secondIsBool, values[1].IsBool);
            Assert.AreEqual(secondIsNullableBool, values[1].IsNullableBool);

            Assert.AreEqual(secondIsBytes.Length, values[1].Bytes.Length);

            for (int i = 0; i < secondIsBytes.Length; i++)
            {
                Assert.AreEqual(secondIsBytes[i], values[1].Bytes[i]);
            }

            Assert.AreEqual(secondIsChars.Length, values[1].Chars.Length);

            for (int i = 0; i < secondIsChars.Length; i++)
            {
                Assert.AreEqual(secondIsChars[i], values[1].Chars[i]);
            }

            Assert.AreEqual(secondIsChar, values[1].IsChar);
            Assert.AreEqual(secondIsNullableChar, values[1].IsNullableChar);
            Assert.AreEqual(secondIsDateTime, values[1].IsDateTime);
            Assert.AreEqual(secondIsNullableDateTime, values[1].IsNullableDateTime);
            Assert.AreEqual(secondIsDecimal, values[1].IsDecimal);
            Assert.AreEqual(secondIsNullableDecimal, values[1].IsNullableDecimal);
            Assert.AreEqual(secondIsDouble, values[1].IsDouble);
            Assert.AreEqual(secondIsNullableDouble, values[1].IsNullableDouble);
            Assert.AreEqual(secondIsFloat, values[1].IsFloat);
            Assert.AreEqual(secondIsNullableFloat, values[1].IsNullableFloat);
            Assert.AreEqual(secondIsGuid, values[1].IsGuid);
            Assert.AreEqual(secondIsNullableGuid, values[1].IsNullableGuid);
            Assert.AreEqual(secondIsInt, values[1].IsInt);
            Assert.AreEqual(secondIsNullableInt, values[1].IsNullableInt);
            Assert.AreEqual(secondIsLong, values[1].IsLong);
            Assert.AreEqual(secondIsNullableLong, values[1].IsNullableLong);
            Assert.AreEqual(secondIsSByte, values[1].IsSByte);
            Assert.AreEqual(secondIsNullableSByte, values[1].IsNullableSByte);
            Assert.AreEqual(secondIsShort, values[1].IsShort);
            Assert.AreEqual(secondIsNullabelShort, values[1].IsNullabelShort);

            MemoryStream secondMS = new MemoryStream();
            values[1].IsStream.CopyTo(secondMS);

            byte[] secondStreamBytes = secondMS.ToArray();

            Assert.AreEqual(secondIsBytes.Length, secondStreamBytes.Length);

            for (int i = 0; i < secondIsBytes.Length; i++)
            {
                Assert.AreEqual(secondIsBytes[i], secondStreamBytes[i]);
            }

            Assert.AreEqual(secondIsString, values[1].IsString);
            Assert.AreEqual(secondIsUInt, values[1].IsUInt);
            Assert.AreEqual(secondIsNullableUInt, values[1].IsNullableUInt);
            Assert.AreEqual(secondIsULong, values[1].IsULong);
            Assert.AreEqual(secondIsNullableULong, values[1].IsNullableULong);
            Assert.AreEqual(secondIsUShort, values[1].IsUShort);
            Assert.AreEqual(secondIsNullableUShort, values[1].IsNullableUShort);
        }

        [TestMethod]
        public void QueryDoesNotSetPropertiesWhichHaveModifiersDifferentFromPublic()
        {
            byte isByte = 2;
            byte? isNullableByte = 21;
            short isShort = 22;
            int isInteger = 33;
            long isLong = 44;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { nameof(isByte), isByte },
                        { nameof(isNullableByte), isNullableByte },
                        { nameof(isShort), isShort },
                        { nameof(isInteger), isInteger },
                        { nameof(isLong), isLong },
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<TestClassWithFieldsWhichMustNotBeSet> values = connection.Query<TestClassWithFieldsWhichMustNotBeSet>(QUERY, null);

            Assert.AreEqual(1, values.Count);

            Assert.AreEqual(isByte, values[0].IsByte);
            Assert.AreEqual(default(byte?), values[0].IsNullableByte);
            Assert.AreEqual(default(short), values[0].GetIsShort());
            Assert.AreEqual(default(int), values[0].GetIsInteger());
            Assert.AreEqual(default(long), values[0].IsLong);
        }

        [TestMethod]
        public void QueryAsyncDoesNotSetPropertiesWhichHaveModifiersDifferentFromPublic()
        {
            byte isByte = 2;
            byte? isNullableByte = 21;
            short isShort = 22;
            int isInteger = 33;
            long isLong = 44;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { nameof(isByte), isByte },
                        { nameof(isNullableByte), isNullableByte },
                        { nameof(isShort), isShort },
                        { nameof(isInteger), isInteger },
                        { nameof(isLong), isLong },
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<TestClassWithFieldsWhichMustNotBeSet> values = connection.QueryAsync<TestClassWithFieldsWhichMustNotBeSet>(QUERY, null).Result;

            Assert.AreEqual(1, values.Count);

            Assert.AreEqual(isByte, values[0].IsByte);
            Assert.AreEqual(default(byte?), values[0].IsNullableByte);
            Assert.AreEqual(default(short), values[0].GetIsShort());
            Assert.AreEqual(default(int), values[0].GetIsInteger());
            Assert.AreEqual(default(long), values[0].IsLong);
        }
    }
}
