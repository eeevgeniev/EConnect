using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQLEConnect;
using SQLEConnectUnitTests.Mockups;
using System;
using System.Collections.Generic;

namespace SQLEConnectUnitTests
{
    [TestClass]
    public class SingleTests
    {
        private const string WHITE_SPACE = " ";
        private const string CONNECTION_STRING = "connection";
        private const string QUERY = "query";

        [TestMethod]
        public void SingleDictionaryThrowsExceptionIfQueryIsNull()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => connection.Single(null, null));
        }

        [TestMethod]
        public void SingleDictionaryThrowsExceptionIfQueryIsStringEmpty()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => connection.Single(string.Empty, null));
        }

        [TestMethod]
        public void SingleDictionaryThrowsExceptionIfQueryIsWhiteSpace()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => connection.Single(WHITE_SPACE, null));
        }

        [TestMethod]
        public void SingleDictionaryAsyncThrowsExceptionIfQueryIsNull()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.SingleAsync(null, null));
        }

        [TestMethod]
        public void SingleDictionaryAsyncThrowsExceptionIfQueryIsStringEmpty()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.SingleAsync(string.Empty, null));
        }

        [TestMethod]
        public void SingleDictionaryAsyncThrowsExceptionIfQueryIsWhiteSpace()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.SingleAsync(WHITE_SPACE, null));
        }

        [TestMethod]
        public void SingleGenericThrowsExceptionIfQueryIsNull()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => connection.Single<int>(null, null));
        }

        [TestMethod]
        public void SingleGenericThrowsExceptionIfQueryIsStringEmpty()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => connection.Single<int>(string.Empty, null));
        }

        [TestMethod]
        public void SingleGenericThrowsExceptionIfQueryIsWhiteSpace()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => connection.Single<int>(WHITE_SPACE, null));
        }

        [TestMethod]
        public void SingleGenericAsyncThrowsExceptionIfQueryIsNull()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.SingleAsync<int>(null, null));
        }

        [TestMethod]
        public void SingleGenericAsyncThrowsExceptionIfQueryIsStringEmpty()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.SingleAsync<int>(string.Empty, null));
        }

        [TestMethod]
        public void SingleGenericAsyncThrowsExceptionIfQueryIsWhiteSpace()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.SingleAsync<int>(WHITE_SPACE, null));
        }

        [TestMethod]
        public void SingleReturnsEmptyIfNoThereAreNoResults()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, byte value) value = connection.Single<byte>(QUERY, null);

            Assert.IsFalse(value.hasResult);
            Assert.AreEqual(default, value.value);
        }

        [TestMethod]
        public void SingleThrowsExceptionIfConnectionWasDisposed()
        {
            Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);
            connection.Dispose();

            Assert.ThrowsException<Exception>(() => connection.Query(QUERY, null));
        }

        [TestMethod]
        public void SingleAsyncThrowsExceptionIfConnectionWasDisposed()
        {
            Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);
            connection.Dispose();

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.QueryAsync(QUERY, null));
        }
    }
}
