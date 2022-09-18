using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQLEConnect;
using SQLEConnectUnitTests.Mockups;
using System;
using System.Collections.Generic;

namespace SQLEConnectUnitTests
{
    [TestClass]
    public class QueryFloatTests
    {
        private const string CONNECTION_STRING = "connection";
        private const string QUERY = "query";

        [TestMethod]
        public void QueryReturnsFloatThrowsExceptionIfValueIsNotFloat()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notfloat", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => { List<float> values = connection.Query<float>(QUERY, null); });
        }

        [TestMethod]
        public void QueryAsyncReturnsFloatThrowsExceptionIfValueIsNotFloat()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notfloat", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => { List<float> values = await connection.QueryAsync<float>(QUERY, null); });
        }

        [TestMethod]
        public void QueryReturnsEmptyFloatListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<float> values = connection.Query<float>(QUERY, null);

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryAsyncReturnsEmptyFloatListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<float> values = connection.QueryAsync<float>(QUERY, null).Result;

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryReturnsFloat()
        {
            float firstFloatValue = 2.1f;
            float secondFloatValue = 21.1f;
            float thirdFloatValue = 23.1f;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "float", firstFloatValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "float", secondFloatValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "float", thirdFloatValue },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<float> values = connection.Query<float>(QUERY, null);

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstFloatValue, values[0]);
            Assert.AreEqual(secondFloatValue, values[1]);
            Assert.AreEqual(thirdFloatValue, values[2]);
        }

        [TestMethod]
        public void QueryAsyncReturnsFloat()
        {
            float firstFloatValue = 2.1f;
            float secondFloatValue = 21.1f;
            float thirdFloatValue = 23.1f;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "float", firstFloatValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "float", secondFloatValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "float", thirdFloatValue },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<float> values = connection.QueryAsync<float>(QUERY, null).Result;

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstFloatValue, values[0]);
            Assert.AreEqual(secondFloatValue, values[1]);
            Assert.AreEqual(thirdFloatValue, values[2]);
        }

        [TestMethod]
        public void QueryReturnsDefaultFloatWhenValueIsNull()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "float", null },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<float> values = connection.Query<float>(QUERY, null);

            Assert.AreEqual(1, values.Count);

            Assert.AreEqual(default, values[0]);
        }

        [TestMethod]
        public void QueryAsyncDefaultFloatWhenValueIsNull()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "float", null },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<float> values = connection.QueryAsync<float>(QUERY, null).Result;

            Assert.AreEqual(1, values.Count);

            Assert.AreEqual(default, values[0]);
        }

        [TestMethod]
        public void QueryReturnsNullableFloatThrowsExceptionIfValueIsNotNullableFloat()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "test", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => { List<float?> values = connection.Query<float?>(QUERY, null); });
        }

        [TestMethod]
        public void QueryAsyncReturnsNullableFloatThrowsExceptionIfValueIsNotNullableFloat()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "test", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => { List<float?> values = await connection.QueryAsync<float?>(QUERY, null); });
        }

        [TestMethod]
        public void QueryReturnsEmptyNullableFloatListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<float?> values = connection.Query<float?>(QUERY, null);

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryAsyncReturnsEmptyNullableFloatListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<float?> values = connection.QueryAsync<float?>(QUERY, null).Result;

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryReturnsNullableFloat()
        {
            float? firstFloatValue = 2.1f;
            float? secondFloatValue = 21.1f;
            float? thirdFloatValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "float", firstFloatValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "float", secondFloatValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "float", thirdFloatValue },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<float?> values = connection.Query<float?>(QUERY, null);

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstFloatValue, values[0]);
            Assert.AreEqual(secondFloatValue, values[1]);
            Assert.AreEqual(thirdFloatValue, values[2]);
        }

        [TestMethod]
        public void QueryAsyncReturnsNullableFloat()
        {
            float? firstFloatValue = 2.1f;
            float? secondFloatValue = 21.1f;
            float? thirdFloatValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "float", firstFloatValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "float", secondFloatValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "float", thirdFloatValue },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<float?> values = connection.QueryAsync<float?>(QUERY, null).Result;

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstFloatValue, values[0]);
            Assert.AreEqual(secondFloatValue, values[1]);
            Assert.AreEqual(thirdFloatValue, values[2]);
        }
    }
}
