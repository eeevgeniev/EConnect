using EConnect;
using EConnectUnitTests.Mockups;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EConnectUnitTests
{
    [TestClass]
    public class QueryTests
    {
        private const string WHITE_SPACE = " ";
        private const string CONNECTION_STRING = "connection";
        private const string QUERY = "query";

        [TestMethod]
        public void QueryDictionaryThrowsExceptionIfQueryIsNull()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => connection.Query(null, null));
        }

        [TestMethod]
        public void QueryDictionaryThrowsExceptionIfQueryIsStringEmpty()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => connection.Query(string.Empty, null));
        }

        [TestMethod]
        public void QueryDictionaryThrowsExceptionIfQueryIsWhiteSpace()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => connection.Query(WHITE_SPACE, null));
        }

        [TestMethod]
        public void QueryDictionaryAsyncThrowsExceptionIfQueryIsNull()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.QueryAsync(null, null));
        }

        [TestMethod]
        public void QueryDictionaryAsyncThrowsExceptionIfQueryIsStringEmpty()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.QueryAsync(string.Empty, null));
        }

        [TestMethod]
        public void QueryDictionaryAsyncThrowsExceptionIfQueryIsWhiteSpace()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.QueryAsync(WHITE_SPACE, null));
        }

        [TestMethod]
        public void QueryGenericThrowsExceptionIfQueryIsNull()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => connection.Query<int>(null, null));
        }

        [TestMethod]
        public void QueryGenericThrowsExceptionIfQueryIsStringEmpty()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => connection.Query<int>(string.Empty, null));
        }

        [TestMethod]
        public void QueryGenericThrowsExceptionIfQueryIsWhiteSpace()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => connection.Query<int>(WHITE_SPACE, null));
        }

        [TestMethod]
        public void QueryGenericAsyncThrowsExceptionIfQueryIsNull()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.QueryAsync<int>(null, null));
        }

        [TestMethod]
        public void QueryGenericAsyncThrowsExceptionIfQueryIsStringEmpty()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.QueryAsync<int>(string.Empty, null));
        }

        [TestMethod]
        public void QueryGenericAsyncThrowsExceptionIfQueryIsWhiteSpace()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.QueryAsync<int>(WHITE_SPACE, null));
        }

        [TestMethod]
        public void QueryThrowsExceptionIfConnectionWasDisposed()
        {
            Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);
            connection.Dispose();

            Assert.ThrowsException<Exception>(() => connection.Query(QUERY, null));
        }

        [TestMethod]
        public void QueryAsyncThrowsExceptionIfConnectionWasDisposed()
        {
            Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);
            connection.Dispose();

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.QueryAsync(QUERY, null));
        }
    }
}
