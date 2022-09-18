using EConnect;
using EConnectUnitTests.Mockups;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EConnectUnitTests
{
    [TestClass]
    public class QueryDoubleTests
    {
        private const string CONNECTION_STRING = "connection";
        private const string QUERY = "query";

        [TestMethod]
        public void QueryReturnsDoubleThrowsExceptionIfValueIsNotDouble()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notdouble", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => { List<double> values = connection.Query<double>(QUERY, null); });
        }

        [TestMethod]
        public void QueryAsyncReturnsDoubleThrowsExceptionIfValueIsNotDouble()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notdouble", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => { List<double> values = await connection.QueryAsync<double>(QUERY, null); });
        }

        [TestMethod]
        public void QueryReturnsEmptyDoubleListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<double> values = connection.Query<double>(QUERY, null);

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryAsyncReturnsEmptyDoubleListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<double> values = connection.QueryAsync<double>(QUERY, null).Result;

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryReturnsDouble()
        {
            double firstDoubleValue = 2.1d;
            double secondDoubleValue = 4.1d;
            double thirdDoubleValue = 12.1d;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "double", firstDoubleValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "double", secondDoubleValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "double", thirdDoubleValue },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<double> values = connection.Query<double>(QUERY, null);

            Assert.AreEqual(3, values.Count);
            Assert.AreEqual(firstDoubleValue, values[0]);
            Assert.AreEqual(secondDoubleValue, values[1]);
            Assert.AreEqual(thirdDoubleValue, values[2]);
        }

        [TestMethod]
        public void QueryAsyncReturnsDouble()
        {
            double firstDoubleValue = 2.1d;
            double secondDoubleValue = 4.1d;
            double thirdDoubleValue = 12.1d;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "double", firstDoubleValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "double", secondDoubleValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "double", thirdDoubleValue },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<double> values = connection.QueryAsync<double>(QUERY, null).Result;

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstDoubleValue, values[0]);
            Assert.AreEqual(secondDoubleValue, values[1]);
            Assert.AreEqual(thirdDoubleValue, values[2]);
        }

        [TestMethod]
        public void QueryReturnsDefaultDoubleWhenValueIsNull()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "double", null },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<double> values = connection.Query<double>(QUERY, null);

            Assert.AreEqual(1, values.Count);
            
            Assert.AreEqual(default, values[0]);
        }

        [TestMethod]
        public void QueryAsyncReturnsDefaultDoubleWhenValueIsNull()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "double", null },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<double> values = connection.QueryAsync<double>(QUERY, null).Result;

            Assert.AreEqual(1, values.Count);

            Assert.AreEqual(default, values[0]);
        }

        [TestMethod]
        public void QueryReturnsNullableDoubleThrowsExceptionIfValueIsNotNullableDouble()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notdouble", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => { List<double?> values = connection.Query<double?>(QUERY, null); });
        }

        [TestMethod]
        public void QueryAsyncReturnsNullableDoubleThrowsExceptionIfValueIsNotNullableDouble()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notdouble", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => { List<double?> values = await connection.QueryAsync<double?>(QUERY, null); });
        }

        [TestMethod]
        public void QueryReturnsEmptyNullableDoubleListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<double?> values = connection.Query<double?>(QUERY, null);

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryAsyncReturnsEmptyNullableDoubleListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<double?> values = connection.QueryAsync<double?>(QUERY, null).Result;

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryReturnsNullableDouble()
        {
            double? firstDoubleValue = 2.1d;
            double? secondDoubleValue = 4.1d;
            double? thirdDoubleValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "double", firstDoubleValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "double", secondDoubleValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "double", thirdDoubleValue },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<double?> values = connection.Query<double?>(QUERY, null);

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstDoubleValue, values[0]);
            Assert.AreEqual(secondDoubleValue, values[1]);
            Assert.AreEqual(thirdDoubleValue, values[2]);
        }

        [TestMethod]
        public void QueryAsyncReturnsNullableDouble()
        {
            double? firstDoubleValue = 2.1d;
            double? secondDoubleValue = 4.1d;
            double? thirdDoubleValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "double", firstDoubleValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "double", secondDoubleValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "double", thirdDoubleValue },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<double?> values = connection.QueryAsync<double?>(QUERY, null).Result;

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstDoubleValue, values[0]);
            Assert.AreEqual(secondDoubleValue, values[1]);
            Assert.AreEqual(thirdDoubleValue, values[2]);
        }
    }
}
