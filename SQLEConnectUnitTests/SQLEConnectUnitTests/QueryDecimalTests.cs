using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQLEConnect;
using SQLEConnectUnitTests.Mockups;
using System;
using System.Collections.Generic;

namespace SQLEConnectUnitTests
{
    [TestClass]
    public class QueryDecimalTests
    {
        private const string CONNECTION_STRING = "connection";
        private const string QUERY = "query";

        [TestMethod]
        public void QueryReturnsDecimalThrowsExceptionIfValueIsNotDecimal()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notdecimal", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => { List<decimal> values = connection.Query<decimal>(QUERY, null); });
        }

        [TestMethod]
        public void QueryAsyncReturnsDecimalThrowsExceptionIfValueIsNotDecimal()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notdecimal", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => { List<decimal> values = await connection.QueryAsync<decimal>(QUERY, null); });
        }

        [TestMethod]
        public void QueryReturnsEmptyDecimalListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<decimal> values = connection.Query<decimal>(QUERY, null);

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryAsyncReturnsEmptyDecimalListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<decimal> values = connection.Query<decimal>(QUERY, null);

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryReturnsDecimal()
        {
            decimal firstDecimalValue = 2.1m;
            decimal secondDecimalValue = 4.1m;
            decimal thirdDecimalValue = 6.1m;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "decimal", firstDecimalValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "decimal", secondDecimalValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "decimal", thirdDecimalValue },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<decimal> values = connection.Query<decimal>(QUERY, null);

            Assert.AreEqual(3, values.Count);
            
            Assert.AreEqual(firstDecimalValue, values[0]);
            Assert.AreEqual(secondDecimalValue, values[1]);
            Assert.AreEqual(thirdDecimalValue, values[2]);
        }

        [TestMethod]
        public void QueryAsyncReturnsDecimal()
        {
            decimal firstDecimalValue = 3.1m;
            decimal secondDecimalValue = 7.1m;
            decimal thirdDecimalValue = 9.1m;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "decimal", firstDecimalValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "decimal", secondDecimalValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "decimal", thirdDecimalValue },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<decimal> values = connection.QueryAsync<decimal>(QUERY, null).Result;

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstDecimalValue, values[0]);
            Assert.AreEqual(secondDecimalValue, values[1]);
            Assert.AreEqual(thirdDecimalValue, values[2]);
        }

        [TestMethod]
        public void QueryReturnsDefaultDecimalWhenValueIsNull()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "decimal", null },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<decimal> values = connection.Query<decimal>(QUERY, null);

            Assert.AreEqual(1, values.Count);

            Assert.AreEqual(default, values[0]);
        }

        [TestMethod]
        public void QueryAsyncDefaultDecimalWhenValueIsNull()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "decimal", null },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<decimal> values = connection.QueryAsync<decimal>(QUERY, null).Result;

            Assert.AreEqual(1, values.Count);

            Assert.AreEqual(default, values[0]);
        }

        [TestMethod]
        public void QueryReturnsNullableDecimalThrowsExceptionIfValueIsNotNullableDecimal()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notdecimal", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => { List<decimal?> values = connection.Query<decimal?>(QUERY, null); });
        }

        [TestMethod]
        public void QueryAsyncReturnsNullableDecimalThrowsExceptionIfValueIsNotNullableDecimal()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notdecimal", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => { List<decimal?> values = await connection.QueryAsync<decimal?>(QUERY, null); });
        }

        [TestMethod]
        public void QueryReturnsEmptyNullableDecimalListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<decimal?> values = connection.Query<decimal?>(QUERY, null);

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryAsyncReturnsEmptyNullableDecimalListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<decimal?> values = connection.QueryAsync<decimal?>(QUERY, null).Result;

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryReturnsNullableDecimal()
        {
            decimal? firstDecimalValue = 3.1m;
            decimal? secondDecimalValue = 7.1m;
            decimal? thirdDecimalValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                     {
                        { "decimal", firstDecimalValue },
                        { "second column", "test" }
                     },
                    new Dictionary<string, object>()
                    {
                        { "decimal", secondDecimalValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "decimal", thirdDecimalValue },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<decimal?> values = connection.Query<decimal?>(QUERY, null);

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstDecimalValue, values[0]);
            Assert.AreEqual(secondDecimalValue, values[1]);
            Assert.AreEqual(thirdDecimalValue, values[2]);
        }

        [TestMethod]
        public void QueryAsyncReturnsNullableDecimal()
        {
            decimal? firstDecimalValue = 3.1m;
            decimal? secondDecimalValue = 7.1m;
            decimal? thirdDecimalValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                     {
                        { "decimal", firstDecimalValue },
                        { "second column", "test" }
                     },
                    new Dictionary<string, object>()
                    {
                        { "decimal", secondDecimalValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "decimal", thirdDecimalValue },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<decimal?> values = connection.QueryAsync<decimal?>(QUERY, null).Result;

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstDecimalValue, values[0]);
            Assert.AreEqual(secondDecimalValue, values[1]);
            Assert.AreEqual(thirdDecimalValue, values[2]);
        }
    }
}
