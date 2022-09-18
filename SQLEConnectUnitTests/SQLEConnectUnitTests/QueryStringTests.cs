using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQLEConnect;
using SQLEConnectUnitTests.Mockups;
using System;
using System.Collections.Generic;

namespace SQLEConnectUnitTests
{
    [TestClass]
    public class QueryStringTests
    {
        private const string CONNECTION_STRING = "connection";
        private const string QUERY = "query";

        [TestMethod]
        public void QueryReturnsStringThrowsExceptionIfValueIsNotString()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notstring", 2 }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => { List<string> values = connection.Query<string>(QUERY, null); });
        }

        [TestMethod]
        public void QueryAsyncReturnsStringThrowsExceptionIfValueIsNotString()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notstring", 2 }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => { List<string> values = await connection.QueryAsync<string>(QUERY, null); });
        }

        [TestMethod]
        public void QueryReturnsEmptyStringListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<string> values = connection.Query<string>(QUERY, null);

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryAsyncReturnsEmptyStringListIfThereAreNoValue()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<string> values = connection.QueryAsync<string>(QUERY, null).Result;

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryReturnsString()
        {
            string firstStringValue = "test";
            string secondStringValue = "another test";
            string thirdStringValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "string", firstStringValue },
                        { "second column", 1 }
                    },
                    new Dictionary<string, object>()
                    {
                        { "string", secondStringValue },
                        { "second column", 1 }
                    },
                    new Dictionary<string, object>()
                    {
                        { "string", thirdStringValue },
                        { "second column", 1 }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<string> values = connection.Query<string>(QUERY, null);

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstStringValue, values[0]);
            Assert.AreEqual(secondStringValue, values[1]);
            Assert.AreEqual(thirdStringValue, values[2]);
        }

        [TestMethod]
        public void QueryAsyncReturnsString()
        {
            string firstStringValue = "test";
            string secondStringValue = "another test";
            string thirdStringValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "string", firstStringValue },
                        { "second column", 1 }
                    },
                    new Dictionary<string, object>()
                    {
                        { "string", secondStringValue },
                        { "second column", 1 }
                    },
                    new Dictionary<string, object>()
                    {
                        { "string", thirdStringValue },
                        { "second column", 1 }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<string> values = connection.QueryAsync<string>(QUERY, null).Result;

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstStringValue, values[0]);
            Assert.AreEqual(secondStringValue, values[1]);
            Assert.AreEqual(thirdStringValue, values[2]);
        }
    }
}
