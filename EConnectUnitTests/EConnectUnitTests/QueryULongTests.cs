using EConnect;
using EConnectUnitTests.Mockups;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EConnectUnitTests
{
    [TestClass]
    public class QueryULongTests
    {
        private const string CONNECTION_STRING = "connection";
        private const string QUERY = "query";

        [TestMethod]
        public void QueryReturnsULongThrowsExceptionIfValueIsNotULong()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notulong", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => { List<ulong> values = connection.Query<ulong>(QUERY, null); });
        }

        [TestMethod]
        public void QueryAsyncReturnsULongThrowsExceptionIfValueIsNotULong()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notulong", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => { List<ulong> values = await connection.QueryAsync<ulong>(QUERY, null); });
        }

        [TestMethod]
        public void QueryReturnsEmptyULongListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<ulong> values = connection.Query<ulong>(QUERY, null);

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryAsyncReturnsEmptyULongListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<ulong> values = connection.QueryAsync<ulong>(QUERY, null).Result;

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryReturnsULong()
        {
            ulong firstULongValue = 2;
            ulong secondULongValue = 33;
            ulong thirdULongValue = 66;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "ulong", firstULongValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "ulong", secondULongValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "ulong", thirdULongValue },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<ulong> values = connection.Query<ulong>(QUERY, null);

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstULongValue, values[0]);
            Assert.AreEqual(secondULongValue, values[1]);
            Assert.AreEqual(thirdULongValue, values[2]);
        }

        [TestMethod]
        public void QueryAsyncReturnsULong()
        {
            ulong firstULongValue = 2;
            ulong secondULongValue = 33;
            ulong thirdULongValue = 66;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "ulong", firstULongValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "ulong", secondULongValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "ulong", thirdULongValue },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<ulong> values = connection.QueryAsync<ulong>(QUERY, null).Result;

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstULongValue, values[0]);
            Assert.AreEqual(secondULongValue, values[1]);
            Assert.AreEqual(thirdULongValue, values[2]);
        }

        [TestMethod]
        public void QueryReturnsDefaultULongWhenValueIsNull()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "ulong", null },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<ulong> values = connection.Query<ulong>(QUERY, null);

            Assert.AreEqual(1, values.Count);

            Assert.AreEqual(default, values[0]);
        }

        [TestMethod]
        public void QueryAsyncReturnsDefaultULongWhenValueIsNull()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "ulong", null },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<ulong> values = connection.QueryAsync<ulong>(QUERY, null).Result;

            Assert.AreEqual(1, values.Count);

            Assert.AreEqual(default, values[0]);
        }

        [TestMethod]
        public void QueryReturnsNullableULongThrowsExceptionIfValueIsNotNullableULong()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notulong", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => { List<ulong?> values = connection.Query<ulong?>(QUERY, null); });
        }

        [TestMethod]
        public void QueryAsyncReturnsNullableULongThrowsExceptionIfValueIsNotNullableULong()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notulong", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => { List<ulong?> values = await connection.QueryAsync<ulong?>(QUERY, null); });
        }

        [TestMethod]
        public void QueryReturnsEmptyNullableULongListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<ulong?> values = connection.Query<ulong?>(QUERY, null);

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryAsyncReturnsEmptyNullableULongListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<ulong?> values = connection.QueryAsync<ulong?>(QUERY, null).Result;

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryReturnsNullableULong()
        {
            ulong? firstULongValue = 2;
            ulong? secondULongValue = 33;
            ulong? thirdULongValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "ulong", firstULongValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "ulong", secondULongValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "ulong", thirdULongValue },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<ulong?> values = connection.Query<ulong?>(QUERY, null);

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstULongValue, values[0]);
            Assert.AreEqual(secondULongValue, values[1]);
            Assert.AreEqual(thirdULongValue, values[2]);
        }

        [TestMethod]
        public void QueryAsyncReturnsNullableULong()
        {
            ulong? firstULongValue = 2;
            ulong? secondULongValue = 33;
            ulong? thirdULongValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "ulong", firstULongValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "ulong", secondULongValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "ulong", thirdULongValue },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<ulong?> values = connection.QueryAsync<ulong?>(QUERY, null).Result;

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstULongValue, values[0]);
            Assert.AreEqual(secondULongValue, values[1]);
            Assert.AreEqual(thirdULongValue, values[2]);
        }
    }
}
