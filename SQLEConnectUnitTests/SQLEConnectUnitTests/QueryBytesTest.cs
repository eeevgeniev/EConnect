using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQLEConnect;
using SQLEConnectUnitTests.Mockups;
using System;
using System.Collections.Generic;

namespace SQLEConnectUnitTests
{
    [TestClass]
    public class QueryBytesTest
    {
        private const string CONNECTION_STRING = "connection";
        private const string QUERY = "query";

        [TestMethod]
        public void QueryReturnsBytesThrowsExceptionIfValueIsNotBytes()
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

            Assert.ThrowsException<Exception>(() => { List<byte[]> values = connection.Query<byte[]>(QUERY, null); });
        }

        [TestMethod]
        public void QueryAsyncReturnsBytesThrowsExceptionIfValueIsNotBytes()
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

            Assert.ThrowsExceptionAsync<Exception>(async () => {
                List<byte[]> values = await connection.QueryAsync<byte[]>(QUERY, null);
            });
        }

        [TestMethod]
        public void QueryReturnsEmptyBytesListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<byte[]> values = connection.Query<byte[]>(QUERY, null);

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryAsyncReturnsEmptyBytesListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<byte[]> values = connection.QueryAsync<byte[]>(QUERY, null).Result;

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryReturnsBytes()
        {
            byte[] firstBytesValue = { 1, 2, 4 };
            byte[] secondBytesValue = { 5, 3, 1 };

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "bytes", firstBytesValue },
                        { "second column", 21 }
                    },
                    new Dictionary<string, object>()
                    {
                        { "bytes", secondBytesValue },
                        { "second column", 21 }
                    },
                    new Dictionary<string, object>()
                    {
                        { "bytes", null },
                        { "second column", 21 }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<byte[]> values = connection.Query<byte[]>(QUERY, null);

            Assert.AreEqual(3, values.Count);

            for (int i = 0; i < firstBytesValue.Length; i++)
            {
                Assert.AreEqual(firstBytesValue[i], values[0][i]);
            }

            for (int i = 0; i < secondBytesValue.Length; i++)
            {
                Assert.AreEqual(secondBytesValue[i], values[1][i]);
            }

            Assert.IsNull(values[2]);
        }

        [TestMethod]
        public void QueryAsyncReturnsBytes()
        {
            byte[] firstBytesValue = { 1, 2, 4 };
            byte[] secondBytesValue = { 5, 3, 1 };

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "bytes", firstBytesValue },
                        { "second column", 21 }
                    },
                    new Dictionary<string, object>()
                    {
                        { "bytes", secondBytesValue },
                        { "second column", 21 }
                    },
                    new Dictionary<string, object>()
                    {
                        { "bytes", null },
                        { "second column", 21 }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<byte[]> values = connection.QueryAsync<byte[]>(QUERY, null).Result;

            Assert.AreEqual(3, values.Count);

            for (int i = 0; i < firstBytesValue.Length; i++)
            {
                Assert.AreEqual(firstBytesValue[i], values[0][i]);
            }

            for (int i = 0; i < secondBytesValue.Length; i++)
            {
                Assert.AreEqual(secondBytesValue[i], values[1][i]);
            }

            Assert.IsNull(values[2]);
        }
    }
}
