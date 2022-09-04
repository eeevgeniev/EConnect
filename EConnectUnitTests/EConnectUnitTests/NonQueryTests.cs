using EConnect;
using EConnectUnitTests.Mockups;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EConnectUnitTests
{
    [TestClass]
    public class NonQueryTests
    {
        private const string WHITE_SPACE = " ";
        private const string CONNECTION_STRING = "connection";
        private const string QUERY = "query";

        [TestMethod]
        public void NonQueryThrowsExceptionIfQueryIsNull()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => connection.NonQuery(null, null));
        }

        [TestMethod]
        public void NonQueryThrowsExceptionIfQueryIsStringEmpty()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => connection.NonQuery(string.Empty, null));
        }

        [TestMethod]
        public void NonQueryThrowsExceptionIfQueryIsWhiteSpace()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => connection.NonQuery(WHITE_SPACE, null));
        }

        [TestMethod]
        public void NonQueryAsyncThrowsExceptionIfQueryIsNull()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.NonQueryAsync(null, null));
        }

        [TestMethod]
        public void NonQueryAsyncThrowsExceptionIfQueryIsStringEmpty()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.NonQueryAsync(string.Empty, null));
        }

        [TestMethod]
        public void NonQueryAsyncThrowsExceptionIfQueryIsWhiteSpace()
        {
            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.NonQueryAsync(WHITE_SPACE, null));
        }

        [TestMethod]
        public void NonQueryThrowsExceptionIfConnectionWasDisposed()
        {
            Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);
            connection.Dispose();

            Assert.ThrowsException<Exception>(() => connection.NonQuery(QUERY, null));
        }

        [TestMethod]
        public void NonQueryAsyncThrowsExceptionIfConnectionWasDisposed()
        {
            Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);
            connection.Dispose();

            Assert.ThrowsExceptionAsync<Exception>(async () => await connection.NonQueryAsync(QUERY, null));
        }
    }
}