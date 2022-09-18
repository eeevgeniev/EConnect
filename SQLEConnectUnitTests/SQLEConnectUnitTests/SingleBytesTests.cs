using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQLEConnect;
using SQLEConnectUnitTests.Mockups;
using System;
using System.Collections.Generic;

namespace SQLEConnectUnitTests
{
    [TestClass]
    public class SingleBytesTests
    {
        private const string CONNECTION_STRING = "connection";
        private const string QUERY = "query";

        [TestMethod]
        public void SingleReturnsBytesThrowsExceptionIfValueIsNotBytes()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notbytes", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => { (bool hasResult, byte[] value) value = connection.Single<byte[]>(QUERY, null); });
        }

        [TestMethod]
        public void SingleAsyncReturnsBytesThrowsExceptionIfValueIsNotBytes()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notbytes", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => { (bool hasResult, byte[] value) value = await connection.SingleAsync<byte[]>(QUERY, null); });
        }

        [TestMethod]
        public void SingleReturnsBytesReturnsDefaultIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, byte[] value) value = connection.Single<byte[]>(QUERY, null);

            Assert.IsFalse(value.hasResult);
        }

        [TestMethod]
        public void SingleAsyncReturnsBytesReturnsDefaultIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, byte[] value) value = connection.SingleAsync<byte[]>(QUERY, null).Result;

            Assert.IsFalse(value.hasResult);
        }

        [TestMethod]
        public void SingleReturnsBytes()
        {
            byte[] bytesValue = { 1, 2, 4 };

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "bytes", bytesValue }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, byte[] value) value = connection.Single<byte[]>(QUERY, null);

            Assert.IsTrue(value.hasResult);
            Assert.AreEqual(value.value.Length, bytesValue.Length);

            for (int i = 0; i < bytesValue.Length; i++)
            {
                Assert.AreEqual(bytesValue[i], value.value[i]);
            }
        }

        [TestMethod]
        public void SingleReturnsBytesWhenValueIsNull()
        {
            byte[] bytesValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "bytes", bytesValue }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, byte[] value) value = connection.Single<byte[]>(QUERY, null);

            Assert.IsTrue(value.hasResult);
            Assert.IsNull(value.value);
        }

        [TestMethod]
        public void SingleAsyncReturnsBytes()
        {
            byte[] bytesValue = { 1, 2, 4 };

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "bytes", bytesValue }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, byte[] value) value = connection.SingleAsync<byte[]>(QUERY, null).Result;

            Assert.IsTrue(value.hasResult);
            Assert.AreEqual(value.value.Length, bytesValue.Length);

            for (int i = 0; i < bytesValue.Length; i++)
            {
                Assert.AreEqual(bytesValue[i], value.value[i]);
            }
        }

        [TestMethod]
        public void SingleAsyncReturnsBytesWhenValueIsNull()
        {
            byte[] bytesValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "bytes", bytesValue }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, byte[] value) value = connection.SingleAsync<byte[]>(QUERY, null).Result;

            Assert.IsTrue(value.hasResult);
            Assert.IsNull(value.value);
        }

        [TestMethod]
        public void SingleReturnsBytesMoreThanOneColumn()
        {
            byte[] bytesValue = { 1, 2, 4 };

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "bytes", bytesValue },
                        { "name", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, byte[] value) value = connection.Single<byte[]>(QUERY, null);

            Assert.IsTrue(value.hasResult);
            Assert.AreEqual(value.value.Length, bytesValue.Length);

            for (int i = 0; i < bytesValue.Length; i++)
            {
                Assert.AreEqual(bytesValue[i], value.value[i]);
            }
        }

        [TestMethod]
        public void SingleReturnsBytesMoreThanOneColumnWhenValueIsNull()
        {
            byte[] bytesValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "bytes", bytesValue },
                        { "name", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, byte[] value) value = connection.Single<byte[]>(QUERY, null);

            Assert.IsTrue(value.hasResult);
            Assert.IsNull(value.value);
        }

        [TestMethod]
        public void SingleAsyncReturnsBytesMoreThanOneColumn()
        {
            byte[] bytesValue = { 1, 2, 4 };

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "bytes", bytesValue },
                        { "name", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, byte[] value) value = connection.SingleAsync<byte[]>(QUERY, null).Result;

            Assert.IsTrue(value.hasResult);
            Assert.AreEqual(bytesValue.Length, value.value.Length);

            for (int i = 0; i < bytesValue.Length; i++)
            {
                Assert.AreEqual(bytesValue[i], value.value[i]);
            }
        }

        [TestMethod]
        public void SingleAsyncReturnsBytesMoreThanOneColumnWhenValueIsNull()
        {
            byte[] bytesValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "bytes", bytesValue },
                        { "name", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, byte[] value) value = connection.SingleAsync<byte[]>(QUERY, null).Result;

            Assert.IsTrue(value.hasResult);
            Assert.IsNull(value.value);
        }
    }
}
