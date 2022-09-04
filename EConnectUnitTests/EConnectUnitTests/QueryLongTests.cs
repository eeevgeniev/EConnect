using EConnect;
using EConnectUnitTests.Mockups;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EConnectUnitTests
{
    [TestClass]
    public class QueryLongTests
    {
        private const string CONNECTION_STRING = "connection";
        private const string QUERY = "query";

        [TestMethod]
        public void QueryReturnsLongThrowsExceptionIfValueIsNotLong()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notlong", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => { List<long> values = connection.Query<long>(QUERY, null); });
        }

        [TestMethod]
        public void QueryAsyncReturnsLongThrowsExceptionIfValueIsNotLong()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notlong", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => { List<long> values = await connection.QueryAsync<long>(QUERY, null); });
        }

        [TestMethod]
        public void QueryReturnsEmptyLongListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<long> values = connection.Query<long>(QUERY, null);

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryAsyncEmptyLongListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<long> values = connection.QueryAsync<long>(QUERY, null).Result;

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryReturnsLong()
        {
            long firstLongValue = 2;
            long secondLongValue = 33;
            long thirdLongValue = 44;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "long", firstLongValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "long", secondLongValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "long", thirdLongValue },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<long> values = connection.Query<long>(QUERY, null);

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstLongValue, values[0]);
            Assert.AreEqual(secondLongValue, values[1]);
            Assert.AreEqual(thirdLongValue, values[2]);
        }

        [TestMethod]
        public void QueryAsyncReturnsLong()
        {
            long firstLongValue = 2;
            long secondLongValue = 33;
            long thirdLongValue = 44;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "long", firstLongValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "long", secondLongValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "long", thirdLongValue },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<long> values = connection.QueryAsync<long>(QUERY, null).Result;

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstLongValue, values[0]);
            Assert.AreEqual(secondLongValue, values[1]);
            Assert.AreEqual(thirdLongValue, values[2]);
        }

        [TestMethod]
        public void QueryReturnsDefaultLongWhenValueIsNull()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "long", null },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<long> values = connection.Query<long>(QUERY, null);

            Assert.AreEqual(1, values.Count);

            Assert.AreEqual(default, values[0]);
        }

        [TestMethod]
        public void QueryAsyncReturnsDefaultLongWhenValueIsNull()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "long", null },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<long> values = connection.QueryAsync<long>(QUERY, null).Result;

            Assert.AreEqual(1, values.Count);

            Assert.AreEqual(default, values[0]);
        }

        [TestMethod]
        public void QueryReturnsNullableLongThrowsExceptionIfValueIsNotNullableLong()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notlong", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => { List<long?> values = connection.Query<long?>(QUERY, null); });
        }

        [TestMethod]
        public void QueryAsyncReturnsNullableLongThrowsExceptionIfValueIsNotNullableLong()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notlong", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => { List<long?> values = await connection.QueryAsync<long?>(QUERY, null); });
        }

        [TestMethod]
        public void QueryReturnsEmptyNullableLongListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<long?> values = connection.Query<long?>(QUERY, null);

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryAsyncReturnsEmptyNullableLongListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<long?> values = connection.QueryAsync<long?>(QUERY, null).Result;

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryReturnsNullableLong()
        {
            long? firstLongValue = 2;
            long? secondLongValue = 33;
            long? thirdLongValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "long", firstLongValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "long", secondLongValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "long", thirdLongValue },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<long?> values = connection.Query<long?>(QUERY, null);

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstLongValue, values[0]);
            Assert.AreEqual(secondLongValue, values[1]);
            Assert.AreEqual(thirdLongValue, values[2]);
        }

        [TestMethod]
        public void QueryAsyncReturnsNullableLong()
        {
            long? firstLongValue = 2;
            long? secondLongValue = 33;
            long? thirdLongValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "long", firstLongValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "long", secondLongValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "long", thirdLongValue },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<long?> values = connection.QueryAsync<long?>(QUERY, null).Result;

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstLongValue, values[0]);
            Assert.AreEqual(secondLongValue, values[1]);
            Assert.AreEqual(thirdLongValue, values[2]);
        }
    }
}
