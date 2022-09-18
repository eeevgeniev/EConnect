using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQLEConnect;
using SQLEConnectUnitTests.Mockups;
using System;
using System.Collections.Generic;

namespace SQLEConnectUnitTests
{
    [TestClass]
    public class QueryShortTests
    {
        private const string CONNECTION_STRING = "connection";
        private const string QUERY = "query";

        [TestMethod]
        public void QueryReturnsShortThrowsExceptionIfValueIsNotShort()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notshort", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => { List<short> values = connection.Query<short>(QUERY, null); });
        }

        [TestMethod]
        public void QueryAsyncReturnsShortThrowsExceptionIfValueIsNotShort()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notshort", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => { List<short> values = await connection.QueryAsync<short>(QUERY, null); });
        }

        [TestMethod]
        public void QueryReturnsEmptyShortListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<short> values = connection.Query<short>(QUERY, null);

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryAsyncEmptyShortListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<short> values = connection.QueryAsync<short>(QUERY, null).Result;

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryReturnsShort()
        {
            short firstShortValue = 2;
            short secondShortValue = 33;
            short thirdShortValue = 44;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "short", firstShortValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "short", secondShortValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "short", thirdShortValue },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<short> values = connection.Query<short>(QUERY, null);

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstShortValue, values[0]);
            Assert.AreEqual(secondShortValue, values[1]);
            Assert.AreEqual(thirdShortValue, values[2]);
        }

        [TestMethod]
        public void QueryAsyncReturnsShort()
        {
            short firstShortValue = 2;
            short secondShortValue = 33;
            short thirdShortValue = 44;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "short", firstShortValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "short", secondShortValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "short", thirdShortValue },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<short> values = connection.QueryAsync<short>(QUERY, null).Result;

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstShortValue, values[0]);
            Assert.AreEqual(secondShortValue, values[1]);
            Assert.AreEqual(thirdShortValue, values[2]);
        }

        [TestMethod]
        public void QueryReturnsDefaultShortWhenValueIsNull()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "short", null },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<short> values = connection.Query<short>(QUERY, null);

            Assert.AreEqual(1, values.Count);

            Assert.AreEqual(default, values[0]);
        }

        [TestMethod]
        public void QueryAsyncReturnsDefaultShortWhenValueIsNull()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "short", null },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<short> values = connection.QueryAsync<short>(QUERY, null).Result;

            Assert.AreEqual(1, values.Count);

            Assert.AreEqual(default, values[0]);
        }

        [TestMethod]
        public void QueryReturnsNullableShortThrowsExceptionIfValueIsNotNullableShort()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notshort", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => { List<short?> values = connection.Query<short?>(QUERY, null); });
        }

        [TestMethod]
        public void QueryAsyncReturnsNullableShortThrowsExceptionIfValueIsNotNullableShort()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notshort", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => { List<short?> values = await connection.QueryAsync<short?>(QUERY, null); });
        }

        [TestMethod]
        public void QueryReturnsEmptyNullableShortListReturnsDefaultIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<short?> values = connection.Query<short?>(QUERY, null);

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryAsyncReturnsEmptyNullableShortListReturnsDefaultIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<short?> values = connection.QueryAsync<short?>(QUERY, null).Result;

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryReturnsNullableShort()
        {
            short? firstShortValue = 2;
            short? secondShortValue = 33;
            short? thirdShortValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "short", firstShortValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "short", secondShortValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "short", thirdShortValue },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<short?> values = connection.Query<short?>(QUERY, null);

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstShortValue, values[0]);
            Assert.AreEqual(secondShortValue, values[1]);
            Assert.AreEqual(thirdShortValue, values[2]);
        }

        [TestMethod]
        public void QueryAsyncReturnsNullableShort()
        {
            short? firstShortValue = 2;
            short? secondShortValue = 33;
            short? thirdShortValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "short", firstShortValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "short", secondShortValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "short", thirdShortValue },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<short?> values = connection.QueryAsync<short?>(QUERY, null).Result;

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstShortValue, values[0]);
            Assert.AreEqual(secondShortValue, values[1]);
            Assert.AreEqual(thirdShortValue, values[2]);
        }
    }
}
