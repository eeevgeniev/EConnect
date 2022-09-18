using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQLEConnect;
using SQLEConnectUnitTests.Mockups;
using System;
using System.Collections.Generic;

namespace SQLEConnectUnitTests
{
    [TestClass]
    public class QueryIntTests
    {
        private const string CONNECTION_STRING = "connection";
        private const string QUERY = "query";

        [TestMethod]
        public void QueryReturnsIntThrowsExceptionIfValueIsNotInt()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notint", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => { List<int> values = connection.Query<int>(QUERY, null); });
        }

        [TestMethod]
        public void QueryAsyncReturnsIntThrowsExceptionIfValueIsNotInt()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notint", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => { List<int> values = await connection.QueryAsync<int>(QUERY, null); });
        }

        [TestMethod]
        public void QueryReturnsEmptyIntListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<int> values = connection.Query<int>(QUERY, null);

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryAsyncReturnsEmptyIntListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<int> values = connection.QueryAsync<int>(QUERY, null).Result;

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryReturnsInt()
        {
            int firstIntValue = 2;
            int secondIntValue = 21;
            int thirdIntValue = 34;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "int", firstIntValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "int", secondIntValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "int", thirdIntValue },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<int> values = connection.Query<int>(QUERY, null);

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstIntValue, values[0]);
            Assert.AreEqual(secondIntValue, values[1]);
            Assert.AreEqual(thirdIntValue, values[2]);
        }

        [TestMethod]
        public void QueryAsyncReturnsInt()
        {
            int firstIntValue = 2;
            int secondIntValue = 21;
            int thirdIntValue = 34;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "int", firstIntValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "int", secondIntValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "int", thirdIntValue },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<int> values = connection.QueryAsync<int>(QUERY, null).Result;

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstIntValue, values[0]);
            Assert.AreEqual(secondIntValue, values[1]);
            Assert.AreEqual(thirdIntValue, values[2]);
        }

        [TestMethod]
        public void QueryReturnsDefaultIntWhenValueIsNull()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "int", null },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<int> values = connection.Query<int>(QUERY, null);

            Assert.AreEqual(1, values.Count);

            Assert.AreEqual(default, values[0]);
        }

        [TestMethod]
        public void QueryAsyncReturnsDefaultIntWhenValueIsNull()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "int", null },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<int> values = connection.QueryAsync<int>(QUERY, null).Result;

            Assert.AreEqual(1, values.Count);

            Assert.AreEqual(default, values[0]);
        }

        [TestMethod]
        public void QueryReturnsNullableIntThrowsExceptionIfValueIsNotNullableInt()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notint", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => { List<int?> values = connection.Query<int?>(QUERY, null); });
        }

        [TestMethod]
        public void QueryAsyncReturnsNullableIntThrowsExceptionIfValueIsNotNullableInt()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notint", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => { List<int?> values = await connection.QueryAsync<int?>(QUERY, null); });
        }

        [TestMethod]
        public void QueryReturnsEmptyNullableIntListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<int?> values = connection.Query<int?>(QUERY, null);

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryAsyncReturnsEmptyNullableIntListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<int?> values = connection.QueryAsync<int?>(QUERY, null).Result;

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryReturnsNullableInt()
        {
            int? firstIntValue = 2;
            int? secondIntValue = 21;
            int? thirdIntValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "int", firstIntValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "int", secondIntValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "int", thirdIntValue },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<int?> values = connection.Query<int?>(QUERY, null);

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstIntValue, values[0]);
            Assert.AreEqual(secondIntValue, values[1]);
            Assert.AreEqual(thirdIntValue, values[2]);
        }

        [TestMethod]
        public void QueryAsyncReturnsNullableInt()
        {
            int? firstIntValue = 2;
            int? secondIntValue = 21;
            int? thirdIntValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "int", firstIntValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "int", secondIntValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "int", thirdIntValue },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<int?> values = connection.QueryAsync<int?>(QUERY, null).Result;

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstIntValue, values[0]);
            Assert.AreEqual(secondIntValue, values[1]);
            Assert.AreEqual(thirdIntValue, values[2]);
        }
    }
}
