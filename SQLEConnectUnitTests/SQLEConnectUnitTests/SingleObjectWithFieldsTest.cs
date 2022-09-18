using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQLEConnect;
using SQLEConnectUnitTests.Mockups;
using SQLEConnectUnitTests.TestModels;
using System;
using System.Collections.Generic;
using System.IO;

namespace SQLEConnectUnitTests
{
    [TestClass]
    public class SingleObjectWithFieldsTest
    {
        private const string CONNECTION_STRING = "connection";
        private const string QUERY = "query";

        [TestMethod]
        public void SingleReturnsClassReturnsDefaultIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, TestClassWithFields value) value = connection.Single<TestClassWithFields>(QUERY, null);

            Assert.IsFalse(value.hasResult);
        }

        [TestMethod]
        public void SingleAsyncReturnsClassReturnsDefaultIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                   
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, TestClassWithFields value) value = connection.SingleAsync<TestClassWithFields>(QUERY, null).Result;

            Assert.IsFalse(value.hasResult);
        }

        [TestMethod]
        public void SingleReturnsObject()
        {
            byte isByte = 0;
            byte? isNullableByte = 13;
            bool isBool = true;
            bool isNullableBool = false;
            byte[] bytes = { 1, 2, 3, 4 };
            char[] chars = { 'a', 'b', 'c' };
            char isChar = 'z';
            char? isNullableChar = 'y';
            DateTime isDateTime = new DateTime(2000, 11, 2);
            DateTime? isNullableDateTime = new DateTime(2002, 6, 5);
            decimal isDecimal = 2m;
            decimal? isNullableDecimal = 21m;
            double isDouble = 2.5d;
            double? isNullableDouble = 3.5d;
            float isFloat = 4.5f;
            float? isNullableFloat = 5.5f;
            Guid isGuid = Guid.NewGuid();
            Guid? isNullableGuid = Guid.NewGuid();
            int isInt = 22;
            int? isNullableInt = 33;
            long isLong = 100;
            long? isNullableLong = 101;
            sbyte isSByte = 11;
            sbyte? isNullableSByte = 12;
            short isShort = 33;
            short? isNullabelShort = 34;
            Stream isStream = new MemoryStream(bytes);
            string isString = "test";
            uint isUInt = 1000;
            uint? isNullableUInt = 1001;
            ulong isULong = 10000;
            ulong? isNullableULong = 100001;
            ushort isUShort = 10033;
            ushort? isNullableUShort = 10034;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { nameof(isByte), isByte },
                        { nameof(isNullableByte), isNullableByte },
                        { nameof(isBool), isBool },
                        { nameof(isNullableBool), isNullableBool },
                        { nameof(bytes), bytes },
                        { nameof(chars), chars },
                        { nameof(isChar), isChar },
                        { nameof(isNullableChar), isNullableChar },
                        { nameof(isDateTime), isDateTime },
                        { nameof(isNullableDateTime), isNullableDateTime },
                        { nameof(isDecimal), isDecimal },
                        { nameof(isNullableDecimal), isNullableDecimal },
                        { nameof(isDouble), isDouble },
                        { nameof(isNullableDouble), isNullableDouble },
                        { nameof(isFloat), isFloat },
                        { nameof(isNullableFloat), isNullableFloat },
                        { nameof(isGuid), isGuid },
                        { nameof(isNullableGuid), isNullableGuid },
                        { nameof(isInt), isInt },
                        { nameof(isNullableInt), isNullableInt },
                        { nameof(isLong), isLong },
                        { nameof(isNullableLong), isNullableLong },
                        { nameof(isSByte), isSByte },
                        { nameof(isNullableSByte), isNullableSByte },
                        { nameof(isShort), isShort },
                        { nameof(isNullabelShort), isNullabelShort },
                        { nameof(isStream), isStream },
                        { nameof(isString), isString },
                        { nameof(isUInt), isUInt },
                        { nameof(isNullableUInt), isNullableUInt },
                        { nameof(isULong), isULong },
                        { nameof(isNullableULong), isNullableULong },
                        { nameof(isUShort), isUShort },
                        { nameof(isNullableUShort), isNullableUShort }
                    },
                    new Dictionary<string, object>()
                    {
                        { nameof(isByte), 100 },
                        { nameof(isNullableByte), 31 },
                        { nameof(isBool), false },
                        { nameof(isNullableBool), true },
                        { nameof(bytes), new byte[] { 4, 3, 2, 1 } },
                        { nameof(chars), new char[] { 'c', 'b', 'a' } },
                        { nameof(isChar), 'a' },
                        { nameof(isNullableChar), 'b' },
                        { nameof(isDateTime), DateTime.Now },
                        { nameof(isNullableDateTime), DateTime.Now.AddDays(1) },
                        { nameof(isDecimal), 8m },
                        { nameof(isNullableDecimal), 12m },
                        { nameof(isDouble), 5.2d },
                        { nameof(isNullableDouble), 5.3d },
                        { nameof(isFloat), 5.4f },
                        { nameof(isNullableFloat), 5.55f },
                        { nameof(isGuid), Guid.NewGuid() },
                        { nameof(isNullableGuid), Guid.NewGuid() },
                        { nameof(isInt), 33 },
                        { nameof(isNullableInt), 22 },
                        { nameof(isLong), 101 },
                        { nameof(isNullableLong), 100 },
                        { nameof(isSByte), 12 },
                        { nameof(isNullableSByte), 11 },
                        { nameof(isShort), 34 },
                        { nameof(isNullabelShort), 33 },
                        { nameof(isStream), new MemoryStream(new byte[] { 4, 3, 2, 1 }) },
                        { nameof(isString), "another test" },
                        { nameof(isUInt), 1001 },
                        { nameof(isNullableUInt), 1000 },
                        { nameof(isULong), 100001 },
                        { nameof(isNullableULong), 10000 },
                        { nameof(isUShort), 10034 },
                        { nameof(isNullableUShort), 10033 }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, TestClassWithFields value) value = connection.Single<TestClassWithFields>(QUERY, null);

            Assert.IsTrue(value.hasResult);
            Assert.AreEqual(isByte, value.value.IsByte);
            Assert.AreEqual(isNullableByte, value.value.IsNullableByte);
            Assert.AreEqual(isBool, value.value.IsBool);
            Assert.AreEqual(isNullableBool, value.value.IsNullableBool);

            Assert.AreEqual(bytes.Length, value.value.Bytes.Length);

            for (int i = 0; i < bytes.Length; i++)
            {
                Assert.AreEqual(bytes[i], value.value.Bytes[i]);
            }

            Assert.AreEqual(chars.Length, value.value.Chars.Length);

            for (int i = 0; i < chars.Length; i++)
            {
                Assert.AreEqual(chars[i], value.value.Chars[i]);
            }

            Assert.AreEqual(isChar, value.value.IsChar);
            Assert.AreEqual(isNullableChar, value.value.IsNullableChar);
            Assert.AreEqual(isDateTime, value.value.IsDateTime);
            Assert.AreEqual(isNullableDateTime, value.value.IsNullableDateTime);
            Assert.AreEqual(isDecimal, value.value.IsDecimal);
            Assert.AreEqual(isNullableDecimal, value.value.IsNullableDecimal);
            Assert.AreEqual(isDouble, value.value.IsDouble);
            Assert.AreEqual(isNullableDouble, value.value.IsNullableDouble);
            Assert.AreEqual(isFloat, value.value.IsFloat);
            Assert.AreEqual(isNullableFloat, value.value.IsNullableFloat);
            Assert.AreEqual(isGuid, value.value.IsGuid);
            Assert.AreEqual(isNullableGuid, value.value.IsNullableGuid);
            Assert.AreEqual(isInt, value.value.IsInt);
            Assert.AreEqual(isNullableInt, value.value.IsNullableInt);
            Assert.AreEqual(isLong, value.value.IsLong);
            Assert.AreEqual(isNullableLong, value.value.IsNullableLong);
            Assert.AreEqual(isSByte, value.value.IsSByte);
            Assert.AreEqual(isNullableSByte, value.value.IsNullableSByte);
            Assert.AreEqual(isShort, value.value.IsShort);
            Assert.AreEqual(isNullabelShort, value.value.IsNullabelShort);

            MemoryStream ms = new MemoryStream();
            value.value.IsStream.CopyTo(ms);

            byte[] streamBytes = ms.ToArray();

            Assert.AreEqual(streamBytes.Length, bytes.Length);

            for (int i = 0; i < bytes.Length; i++)
            {
                Assert.AreEqual(streamBytes[i], bytes[i]);
            }

            Assert.AreEqual(isString, value.value.IsString);
            Assert.AreEqual(isUInt, value.value.IsUInt);
            Assert.AreEqual(isNullableUInt, value.value.IsNullableUInt);
            Assert.AreEqual(isULong, value.value.IsULong);
            Assert.AreEqual(isNullableULong, value.value.IsNullableULong);
            Assert.AreEqual(isUShort, value.value.IsUShort);
            Assert.AreEqual(isNullableUShort, value.value.IsNullableUShort);
        }

        [TestMethod]
        public void SingleAsyncReturnsObject()
        {
            byte isByte = 0;
            byte? isNullableByte = 13;
            bool isBool = true;
            bool isNullableBool = false;
            byte[] bytes = { 1, 2, 3, 4 };
            char[] chars = { 'a', 'b', 'c' };
            char isChar = 'z';
            char? isNullableChar = 'y';
            DateTime isDateTime = new DateTime(2000, 11, 2);
            DateTime? isNullableDateTime = new DateTime(2002, 6, 5);
            decimal isDecimal = 2m;
            decimal? isNullableDecimal = 21m;
            double isDouble = 2.5d;
            double? isNullableDouble = 3.5d;
            float isFloat = 4.5f;
            float? isNullableFloat = 5.5f;
            Guid isGuid = Guid.NewGuid();
            Guid? isNullableGuid = Guid.NewGuid();
            int isInt = 22;
            int? isNullableInt = 33;
            long isLong = 100;
            long? isNullableLong = 101;
            sbyte isSByte = 11;
            sbyte? isNullableSByte = 12;
            short isShort = 33;
            short? isNullabelShort = 34;
            Stream isStream = new MemoryStream(bytes);
            string isString = "test";
            uint isUInt = 1000;
            uint? isNullableUInt = 1001;
            ulong isULong = 10000;
            ulong? isNullableULong = 100001;
            ushort isUShort = 10033;
            ushort? isNullableUShort = 10034;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { nameof(isByte), isByte },
                        { nameof(isNullableByte), isNullableByte },
                        { nameof(isBool), isBool },
                        { nameof(isNullableBool), isNullableBool },
                        { nameof(bytes), bytes },
                        { nameof(chars), chars },
                        { nameof(isChar), isChar },
                        { nameof(isNullableChar), isNullableChar },
                        { nameof(isDateTime), isDateTime },
                        { nameof(isNullableDateTime), isNullableDateTime },
                        { nameof(isDecimal), isDecimal },
                        { nameof(isNullableDecimal), isNullableDecimal },
                        { nameof(isDouble), isDouble },
                        { nameof(isNullableDouble), isNullableDouble },
                        { nameof(isFloat), isFloat },
                        { nameof(isNullableFloat), isNullableFloat },
                        { nameof(isGuid), isGuid },
                        { nameof(isNullableGuid), isNullableGuid },
                        { nameof(isInt), isInt },
                        { nameof(isNullableInt), isNullableInt },
                        { nameof(isLong), isLong },
                        { nameof(isNullableLong), isNullableLong },
                        { nameof(isSByte), isSByte },
                        { nameof(isNullableSByte), isNullableSByte },
                        { nameof(isShort), isShort },
                        { nameof(isNullabelShort), isNullabelShort },
                        { nameof(isStream), isStream },
                        { nameof(isString), isString },
                        { nameof(isUInt), isUInt },
                        { nameof(isNullableUInt), isNullableUInt },
                        { nameof(isULong), isULong },
                        { nameof(isNullableULong), isNullableULong },
                        { nameof(isUShort), isUShort },
                        { nameof(isNullableUShort), isNullableUShort }
                    },
                    new Dictionary<string, object>()
                    {
                        { nameof(isByte), 100 },
                        { nameof(isNullableByte), 31 },
                        { nameof(isBool), false },
                        { nameof(isNullableBool), true },
                        { nameof(bytes), new byte[] { 4, 3, 2, 1 } },
                        { nameof(chars), new char[] { 'c', 'b', 'a' } },
                        { nameof(isChar), 'a' },
                        { nameof(isNullableChar), 'b' },
                        { nameof(isDateTime), DateTime.Now },
                        { nameof(isNullableDateTime), DateTime.Now.AddDays(1) },
                        { nameof(isDecimal), 8m },
                        { nameof(isNullableDecimal), 12m },
                        { nameof(isDouble), 5.2d },
                        { nameof(isNullableDouble), 5.3d },
                        { nameof(isFloat), 5.4f },
                        { nameof(isNullableFloat), 5.55f },
                        { nameof(isGuid), Guid.NewGuid() },
                        { nameof(isNullableGuid), Guid.NewGuid() },
                        { nameof(isInt), 33 },
                        { nameof(isNullableInt), 22 },
                        { nameof(isLong), 101 },
                        { nameof(isNullableLong), 100 },
                        { nameof(isSByte), 12 },
                        { nameof(isNullableSByte), 11 },
                        { nameof(isShort), 34 },
                        { nameof(isNullabelShort), 33 },
                        { nameof(isStream), new MemoryStream(new byte[] { 4, 3, 2, 1 }) },
                        { nameof(isString), "another test" },
                        { nameof(isUInt), 1001 },
                        { nameof(isNullableUInt), 1000 },
                        { nameof(isULong), 100001 },
                        { nameof(isNullableULong), 10000 },
                        { nameof(isUShort), 10034 },
                        { nameof(isNullableUShort), 10033 }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, TestClassWithFields value) value = connection.SingleAsync<TestClassWithFields>(QUERY, null).Result;

            Assert.IsTrue(value.hasResult);
            Assert.AreEqual(isByte, value.value.IsByte);
            Assert.AreEqual(isNullableByte, value.value.IsNullableByte);
            Assert.AreEqual(isBool, value.value.IsBool);
            Assert.AreEqual(isNullableBool, value.value.IsNullableBool);

            Assert.AreEqual(bytes.Length, value.value.Bytes.Length);

            for (int i = 0; i < bytes.Length; i++)
            {
                Assert.AreEqual(bytes[i], value.value.Bytes[i]);
            }

            Assert.AreEqual(chars.Length, value.value.Chars.Length);

            for (int i = 0; i < chars.Length; i++)
            {
                Assert.AreEqual(chars[i], value.value.Chars[i]);
            }

            Assert.AreEqual(isChar, value.value.IsChar);
            Assert.AreEqual(isNullableChar, value.value.IsNullableChar);
            Assert.AreEqual(isDateTime, value.value.IsDateTime);
            Assert.AreEqual(isNullableDateTime, value.value.IsNullableDateTime);
            Assert.AreEqual(isDecimal, value.value.IsDecimal);
            Assert.AreEqual(isNullableDecimal, value.value.IsNullableDecimal);
            Assert.AreEqual(isDouble, value.value.IsDouble);
            Assert.AreEqual(isNullableDouble, value.value.IsNullableDouble);
            Assert.AreEqual(isFloat, value.value.IsFloat);
            Assert.AreEqual(isNullableFloat, value.value.IsNullableFloat);
            Assert.AreEqual(isGuid, value.value.IsGuid);
            Assert.AreEqual(isNullableGuid, value.value.IsNullableGuid);
            Assert.AreEqual(isInt, value.value.IsInt);
            Assert.AreEqual(isNullableInt, value.value.IsNullableInt);
            Assert.AreEqual(isLong, value.value.IsLong);
            Assert.AreEqual(isNullableLong, value.value.IsNullableLong);
            Assert.AreEqual(isSByte, value.value.IsSByte);
            Assert.AreEqual(isNullableSByte, value.value.IsNullableSByte);
            Assert.AreEqual(isShort, value.value.IsShort);
            Assert.AreEqual(isNullabelShort, value.value.IsNullabelShort);

            MemoryStream ms = new MemoryStream();
            value.value.IsStream.CopyTo(ms);

            byte[] streamBytes = ms.ToArray();

            Assert.AreEqual(streamBytes.Length, bytes.Length);

            for (int i = 0; i < bytes.Length; i++)
            {
                Assert.AreEqual(streamBytes[i], bytes[i]);
            }

            Assert.AreEqual(isString, value.value.IsString);
            Assert.AreEqual(isUInt, value.value.IsUInt);
            Assert.AreEqual(isNullableUInt, value.value.IsNullableUInt);
            Assert.AreEqual(isULong, value.value.IsULong);
            Assert.AreEqual(isNullableULong, value.value.IsNullableULong);
            Assert.AreEqual(isUShort, value.value.IsUShort);
            Assert.AreEqual(isNullableUShort, value.value.IsNullableUShort);
        }

        [TestMethod]
        public void SingleReturnsObjectWithNoDefaultConstructor()
        {
            byte isByte = 0;
            byte? isNullableByte = 13;
            bool isBool = true;
            bool isNullableBool = false;
            byte[] bytes = { 1, 2, 3, 4 };
            char[] chars = { 'a', 'b', 'c' };
            char isChar = 'z';
            char? isNullableChar = 'y';
            DateTime isDateTime = new DateTime(2000, 11, 2);
            DateTime? isNullableDateTime = new DateTime(2002, 6, 5);
            decimal isDecimal = 2m;
            decimal? isNullableDecimal = 21m;
            double isDouble = 2.5d;
            double? isNullableDouble = 3.5d;
            float isFloat = 4.5f;
            float? isNullableFloat = 5.5f;
            Guid isGuid = Guid.NewGuid();
            Guid? isNullableGuid = Guid.NewGuid();
            int isInt = 22;
            int? isNullableInt = 33;
            long isLong = 100;
            long? isNullableLong = 101;
            sbyte isSByte = 11;
            sbyte? isNullableSByte = 12;
            short isShort = 33;
            short? isNullabelShort = 34;
            Stream isStream = new MemoryStream(bytes);
            string isString = "test";
            uint isUInt = 1000;
            uint? isNullableUInt = 1001;
            ulong isULong = 10000;
            ulong? isNullableULong = 100001;
            ushort isUShort = 10033;
            ushort? isNullableUShort = 10034;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { nameof(isByte), isByte },
                        { nameof(isNullableByte), isNullableByte },
                        { nameof(isBool), isBool },
                        { nameof(isNullableBool), isNullableBool },
                        { nameof(bytes), bytes },
                        { nameof(chars), chars },
                        { nameof(isChar), isChar },
                        { nameof(isNullableChar), isNullableChar },
                        { nameof(isDateTime), isDateTime },
                        { nameof(isNullableDateTime), isNullableDateTime },
                        { nameof(isDecimal), isDecimal },
                        { nameof(isNullableDecimal), isNullableDecimal },
                        { nameof(isDouble), isDouble },
                        { nameof(isNullableDouble), isNullableDouble },
                        { nameof(isFloat), isFloat },
                        { nameof(isNullableFloat), isNullableFloat },
                        { nameof(isGuid), isGuid },
                        { nameof(isNullableGuid), isNullableGuid },
                        { nameof(isInt), isInt },
                        { nameof(isNullableInt), isNullableInt },
                        { nameof(isLong), isLong },
                        { nameof(isNullableLong), isNullableLong },
                        { nameof(isSByte), isSByte },
                        { nameof(isNullableSByte), isNullableSByte },
                        { nameof(isShort), isShort },
                        { nameof(isNullabelShort), isNullabelShort },
                        { nameof(isStream), isStream },
                        { nameof(isString), isString },
                        { nameof(isUInt), isUInt },
                        { nameof(isNullableUInt), isNullableUInt },
                        { nameof(isULong), isULong },
                        { nameof(isNullableULong), isNullableULong },
                        { nameof(isUShort), isUShort },
                        { nameof(isNullableUShort), isNullableUShort }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, TestClassWithFieldsNoDefaultConstructor value) value = connection.Single<TestClassWithFieldsNoDefaultConstructor>(QUERY, null);

            Assert.IsTrue(value.hasResult);
            Assert.AreEqual(isByte, value.value.IsByte);
            Assert.AreEqual(isNullableByte, value.value.IsNullableByte);
            Assert.AreEqual(isBool, value.value.IsBool);
            Assert.AreEqual(isNullableBool, value.value.IsNullableBool);

            Assert.AreEqual(bytes.Length, value.value.Bytes.Length);

            for (int i = 0; i < bytes.Length; i++)
            {
                Assert.AreEqual(bytes[i], value.value.Bytes[i]);
            }

            Assert.AreEqual(chars.Length, value.value.Chars.Length);

            for (int i = 0; i < chars.Length; i++)
            {
                Assert.AreEqual(chars[i], value.value.Chars[i]);
            }

            Assert.AreEqual(isChar, value.value.IsChar);
            Assert.AreEqual(isNullableChar, value.value.IsNullableChar);
            Assert.AreEqual(isDateTime, value.value.IsDateTime);
            Assert.AreEqual(isNullableDateTime, value.value.IsNullableDateTime);
            Assert.AreEqual(isDecimal, value.value.IsDecimal);
            Assert.AreEqual(isNullableDecimal, value.value.IsNullableDecimal);
            Assert.AreEqual(isDouble, value.value.IsDouble);
            Assert.AreEqual(isNullableDouble, value.value.IsNullableDouble);
            Assert.AreEqual(isFloat, value.value.IsFloat);
            Assert.AreEqual(isNullableFloat, value.value.IsNullableFloat);
            Assert.AreEqual(isGuid, value.value.IsGuid);
            Assert.AreEqual(isNullableGuid, value.value.IsNullableGuid);
            Assert.AreEqual(isInt, value.value.IsInt);
            Assert.AreEqual(isNullableInt, value.value.IsNullableInt);
            Assert.AreEqual(isLong, value.value.IsLong);
            Assert.AreEqual(isNullableLong, value.value.IsNullableLong);
            Assert.AreEqual(isSByte, value.value.IsSByte);
            Assert.AreEqual(isNullableSByte, value.value.IsNullableSByte);
            Assert.AreEqual(isShort, value.value.IsShort);
            Assert.AreEqual(isNullabelShort, value.value.IsNullabelShort);

            MemoryStream ms = new MemoryStream();
            value.value.IsStream.CopyTo(ms);

            byte[] streamBytes = ms.ToArray();

            Assert.AreEqual(streamBytes.Length, bytes.Length);

            for (int i = 0; i < bytes.Length; i++)
            {
                Assert.AreEqual(streamBytes[i], bytes[i]);
            }

            Assert.AreEqual(isString, value.value.IsString);
            Assert.AreEqual(isUInt, value.value.IsUInt);
            Assert.AreEqual(isNullableUInt, value.value.IsNullableUInt);
            Assert.AreEqual(isULong, value.value.IsULong);
            Assert.AreEqual(isNullableULong, value.value.IsNullableULong);
            Assert.AreEqual(isUShort, value.value.IsUShort);
            Assert.AreEqual(isNullableUShort, value.value.IsNullableUShort);
        }

        [TestMethod]
        public void SingleAsyncReturnsWithNoDefaultConstructor()
        {
            byte isByte = 0;
            byte? isNullableByte = 13;
            bool isBool = true;
            bool isNullableBool = false;
            byte[] bytes = { 1, 2, 3, 4 };
            char[] chars = { 'a', 'b', 'c' };
            char isChar = 'z';
            char? isNullableChar = 'y';
            DateTime isDateTime = new DateTime(2000, 11, 2);
            DateTime? isNullableDateTime = new DateTime(2002, 6, 5);
            decimal isDecimal = 2m;
            decimal? isNullableDecimal = 21m;
            double isDouble = 2.5d;
            double? isNullableDouble = 3.5d;
            float isFloat = 4.5f;
            float? isNullableFloat = 5.5f;
            Guid isGuid = Guid.NewGuid();
            Guid? isNullableGuid = Guid.NewGuid();
            int isInt = 22;
            int? isNullableInt = 33;
            long isLong = 100;
            long? isNullableLong = 101;
            sbyte isSByte = 11;
            sbyte? isNullableSByte = 12;
            short isShort = 33;
            short? isNullabelShort = 34;
            Stream isStream = new MemoryStream(bytes);
            string isString = "test";
            uint isUInt = 1000;
            uint? isNullableUInt = 1001;
            ulong isULong = 10000;
            ulong? isNullableULong = 100001;
            ushort isUShort = 10033;
            ushort? isNullableUShort = 10034;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { nameof(isByte), isByte },
                        { nameof(isNullableByte), isNullableByte },
                        { nameof(isBool), isBool },
                        { nameof(isNullableBool), isNullableBool },
                        { nameof(bytes), bytes },
                        { nameof(chars), chars },
                        { nameof(isChar), isChar },
                        { nameof(isNullableChar), isNullableChar },
                        { nameof(isDateTime), isDateTime },
                        { nameof(isNullableDateTime), isNullableDateTime },
                        { nameof(isDecimal), isDecimal },
                        { nameof(isNullableDecimal), isNullableDecimal },
                        { nameof(isDouble), isDouble },
                        { nameof(isNullableDouble), isNullableDouble },
                        { nameof(isFloat), isFloat },
                        { nameof(isNullableFloat), isNullableFloat },
                        { nameof(isGuid), isGuid },
                        { nameof(isNullableGuid), isNullableGuid },
                        { nameof(isInt), isInt },
                        { nameof(isNullableInt), isNullableInt },
                        { nameof(isLong), isLong },
                        { nameof(isNullableLong), isNullableLong },
                        { nameof(isSByte), isSByte },
                        { nameof(isNullableSByte), isNullableSByte },
                        { nameof(isShort), isShort },
                        { nameof(isNullabelShort), isNullabelShort },
                        { nameof(isStream), isStream },
                        { nameof(isString), isString },
                        { nameof(isUInt), isUInt },
                        { nameof(isNullableUInt), isNullableUInt },
                        { nameof(isULong), isULong },
                        { nameof(isNullableULong), isNullableULong },
                        { nameof(isUShort), isUShort },
                        { nameof(isNullableUShort), isNullableUShort }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, TestClassWithFieldsNoDefaultConstructor value) value = connection.SingleAsync<TestClassWithFieldsNoDefaultConstructor>(QUERY, null).Result;

            Assert.IsTrue(value.hasResult);
            Assert.AreEqual(isByte, value.value.IsByte);
            Assert.AreEqual(isNullableByte, value.value.IsNullableByte);
            Assert.AreEqual(isBool, value.value.IsBool);
            Assert.AreEqual(isNullableBool, value.value.IsNullableBool);

            Assert.AreEqual(bytes.Length, value.value.Bytes.Length);

            for (int i = 0; i < bytes.Length; i++)
            {
                Assert.AreEqual(bytes[i], value.value.Bytes[i]);
            }

            Assert.AreEqual(chars.Length, value.value.Chars.Length);

            for (int i = 0; i < chars.Length; i++)
            {
                Assert.AreEqual(chars[i], value.value.Chars[i]);
            }

            Assert.AreEqual(isChar, value.value.IsChar);
            Assert.AreEqual(isNullableChar, value.value.IsNullableChar);
            Assert.AreEqual(isDateTime, value.value.IsDateTime);
            Assert.AreEqual(isNullableDateTime, value.value.IsNullableDateTime);
            Assert.AreEqual(isDecimal, value.value.IsDecimal);
            Assert.AreEqual(isNullableDecimal, value.value.IsNullableDecimal);
            Assert.AreEqual(isDouble, value.value.IsDouble);
            Assert.AreEqual(isNullableDouble, value.value.IsNullableDouble);
            Assert.AreEqual(isFloat, value.value.IsFloat);
            Assert.AreEqual(isNullableFloat, value.value.IsNullableFloat);
            Assert.AreEqual(isGuid, value.value.IsGuid);
            Assert.AreEqual(isNullableGuid, value.value.IsNullableGuid);
            Assert.AreEqual(isInt, value.value.IsInt);
            Assert.AreEqual(isNullableInt, value.value.IsNullableInt);
            Assert.AreEqual(isLong, value.value.IsLong);
            Assert.AreEqual(isNullableLong, value.value.IsNullableLong);
            Assert.AreEqual(isSByte, value.value.IsSByte);
            Assert.AreEqual(isNullableSByte, value.value.IsNullableSByte);
            Assert.AreEqual(isShort, value.value.IsShort);
            Assert.AreEqual(isNullabelShort, value.value.IsNullabelShort);

            MemoryStream ms = new MemoryStream();
            value.value.IsStream.CopyTo(ms);

            byte[] streamBytes = ms.ToArray();

            Assert.AreEqual(streamBytes.Length, bytes.Length);

            for (int i = 0; i < bytes.Length; i++)
            {
                Assert.AreEqual(streamBytes[i], bytes[i]);
            }

            Assert.AreEqual(isString, value.value.IsString);
            Assert.AreEqual(isUInt, value.value.IsUInt);
            Assert.AreEqual(isNullableUInt, value.value.IsNullableUInt);
            Assert.AreEqual(isULong, value.value.IsULong);
            Assert.AreEqual(isNullableULong, value.value.IsNullableULong);
            Assert.AreEqual(isUShort, value.value.IsUShort);
            Assert.AreEqual(isNullableUShort, value.value.IsNullableUShort);
        }

        [TestMethod]
        public void SingleDoesNotSetPropertiesWhichHaveModifiersDifferentFromPublic()
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

            (bool hasResult, TestClassWithFieldsWhichMustNotBeSet value) value = connection.Single<TestClassWithFieldsWhichMustNotBeSet>(QUERY, null);

            Assert.AreEqual(isByte, value.value.IsByte);
            Assert.AreEqual(default(byte?), value.value.IsNullableByte);
            Assert.AreEqual(default(short), value.value.GetIsShort());
            Assert.AreEqual(default(int), value.value.GetIsInteger());
            Assert.AreEqual(default(long), value.value.IsLong);
        }

        [TestMethod]
        public void SingleAsyncDoesNotSetPropertiesWhichHaveModifiersDifferentFromPublic()
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

            (bool hasResult, TestClassWithFieldsWhichMustNotBeSet value) value = connection.SingleAsync<TestClassWithFieldsWhichMustNotBeSet>(QUERY, null).Result;

            Assert.AreEqual(isByte, value.value.IsByte);
            Assert.AreEqual(default(byte?), value.value.IsNullableByte);
            Assert.AreEqual(default(short), value.value.GetIsShort());
            Assert.AreEqual(default(int), value.value.GetIsInteger());
            Assert.AreEqual(default(long), value.value.IsLong);
        }
    }
}
