using EConnect;
using EConnectUnitTests.Mockups;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EConnectUnitTests
{
    [TestClass]
    public class QueryBoolTests
    {
        private const string CONNECTION_STRING = "connection";
        private const string QUERY = "query";

        [TestMethod]
        public void QueryReturnsBoolThrowsExceptionIfValueIsNotBool()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notabool", "test" },
                    },
                    new Dictionary<string, object>()
                    {
                        { "notabool", "test" },
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => { List<bool> values = connection.Query<bool>(QUERY, null); });
        }

        [TestMethod]
        public void QueryAsyncReturnsBoolThrowsExceptionIfValueIsNotBool()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notabool", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "notabool", "test" },
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => { List<bool> values = await connection.QueryAsync<bool>(QUERY, null); });
        }

        [TestMethod]
        public void QueryReturnsEmptyBoolListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<bool> values = connection.Query<bool>(QUERY, null);

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryAsyncReturnsEmptyBoolListIfIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<bool> values = connection.Query<bool>(QUERY, null);

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryReturnsBool()
        {
            bool firstBoolValue = true;
            bool secondBoolValue = false;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "bool", firstBoolValue },
                        { "second column", 21 }
                    },
                    new Dictionary<string, object>()
                    {
                        { "bool", secondBoolValue },
                        { "second column", 21 }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<bool> values = connection.Query<bool>(QUERY, null);

            Assert.AreEqual(2, values.Count);

            Assert.AreEqual(firstBoolValue, values[0]);
            Assert.AreEqual(secondBoolValue, values[1]);
        }

        [TestMethod]
        public void QueryAsyncReturnsBool()
        {
            bool firstBoolValue = true;
            bool secondBoolValue = false;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "bool", firstBoolValue },
                        { "second column", 21 }
                    },
                    new Dictionary<string, object>()
                    {
                        { "bool", secondBoolValue },
                        { "second column", 21 }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<bool> values = connection.QueryAsync<bool>(QUERY, null).Result;

            Assert.AreEqual(2, values.Count);

            Assert.AreEqual(firstBoolValue, values[0]);
            Assert.AreEqual(secondBoolValue, values[1]);
        }

        [TestMethod]
        public void QueryReturnsDefaultBoolWhenValueIsNull()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "bool", null },
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<bool> values = connection.Query<bool>(QUERY, null);

            Assert.AreEqual(1, values.Count);
            
            Assert.AreEqual(default, values[0]);
        }

        [TestMethod]
        public void QueryAsyncReturnsDefaultBoolWhenValueIsNull()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "bool", null },
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<bool> values = connection.QueryAsync<bool>(QUERY, null).Result;

            Assert.AreEqual(1, values.Count);
            
            Assert.AreEqual(default, values[0]);
        }

        [TestMethod]
        public void QueryReturnsNullableBoolThrowsExceptionIfValueIsNotNullableBool()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notabool", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "notabool", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => { List<bool?> values = connection.Query<bool?>(QUERY, null); });
        }

        [TestMethod]
        public void QueryAsyncReturnsNullableBoolThrowsExceptionIfValueIsNotNullableBool()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notabool", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "notabool", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => { List<bool?> values = await connection.QueryAsync<bool?>(QUERY, null); });
        }

        [TestMethod]
        public void QueryReturnsEmptyNullableBoolListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<bool?> values = connection.Query<bool?>(QUERY, null);

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryAsyncReturnsEmptyNullableBoolListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<bool?> values = connection.QueryAsync<bool?>(QUERY, null).Result;

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryReturnsNullableBool()
        {
            bool? firstBoolValue = true;
            bool? secondBoolValue = false;
            bool? thirdBoolValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "bool", firstBoolValue },
                        { "second column", 21 }
                    },
                    new Dictionary<string, object>()
                    {
                        { "bool", secondBoolValue },
                        { "second column", 21 }
                    },
                    new Dictionary<string, object>()
                    {
                        { "bool", thirdBoolValue },
                        { "second column", 21 }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<bool?> values = connection.Query<bool?>(QUERY, null);

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstBoolValue, values[0]);
            Assert.AreEqual(secondBoolValue, values[1]);
            Assert.AreEqual(thirdBoolValue, values[2]);
        }

        [TestMethod]
        public void QueryAsyncReturnsNullableBool()
        {
            bool? firstBoolValue = true;
            bool? secondBoolValue = false;
            bool? thirdBoolValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "bool", firstBoolValue },
                        { "second column", 21 }
                    },
                    new Dictionary<string, object>()
                    {
                        { "bool", secondBoolValue },
                        { "second column", 21 }
                    },
                    new Dictionary<string, object>()
                    {
                        { "bool", thirdBoolValue },
                        { "second column", 21 }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<bool?> values = connection.QueryAsync<bool?>(QUERY, null).Result;

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstBoolValue, values[0]);
            Assert.AreEqual(secondBoolValue, values[1]);
            Assert.AreEqual(thirdBoolValue, values[2]);
        }
    }
}
