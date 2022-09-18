using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQLEConnect;
using SQLEConnectUnitTests.Mockups;
using System;
using System.Collections.Generic;

namespace SQLEConnectUnitTests
{
    [TestClass]
    public class QueryCharsTest
    {
        private const string CONNECTION_STRING = "connection";
        private const string QUERY = "query";

        [TestMethod]
        public void QueryReturnsCharsThrowsExceptionIfValueIsNotChars()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notchars", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => { List<char[]> values = connection.Query<char[]>(QUERY, null); });
        }

        [TestMethod]
        public void QueryAsyncReturnsCharsThrowsExceptionIfValueIsNotChars()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notchars", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => {
                List<char[]> values = await connection.QueryAsync<char[]>(QUERY, null);
            });
        }

        [TestMethod]
        public void QueryReturnsEmptyCharsListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<char[]> values = connection.Query<char[]>(QUERY, null);

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryAsyncEmptyCharsListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<char[]> values = connection.QueryAsync<char[]>(QUERY, null).Result;

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryReturnsChars()
        {
            char[] firstCharsValue = { '1', '2', 'c' };
            char[] secondCharsValue = { '1', 'a', 'c' };
            char[] thirdCharValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "chars", firstCharsValue },
                        { "second column", 21 }
                    },
                    new Dictionary<string, object>()
                    {
                        { "chars", secondCharsValue },
                        { "second column", 21 }
                    },
                    new Dictionary<string, object>()
                    {
                        { "chars", thirdCharValue },
                        { "second column", 21 }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<char[]> values = connection.Query<char[]>(QUERY, null);

            Assert.AreEqual(3, values.Count);

            for (int i = 0; i < firstCharsValue.Length; i++)
            {
                Assert.AreEqual(firstCharsValue[i], values[0][i]);
            }

            for (int i = 0; i < secondCharsValue.Length; i++)
            {
                Assert.AreEqual(secondCharsValue[i], values[1][i]);
            }

            Assert.AreEqual(thirdCharValue, values[2]);
        }

        [TestMethod]
        public void QueryAsyncReturnsChars()
        {
            char[] firstCharsValue = { '1', '2', 'c' };
            char[] secondCharsValue = { '1', 'a', 'c' };
            char[] thirdCharValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "chars", firstCharsValue },
                        { "second column", 21 }
                    },
                    new Dictionary<string, object>()
                    {
                        { "chars", secondCharsValue },
                        { "second column", 21 }
                    },
                    new Dictionary<string, object>()
                    {
                        { "chars", thirdCharValue },
                        { "second column", 21 }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<char[]> values = connection.QueryAsync<char[]>(QUERY, null).Result;

            Assert.AreEqual(3, values.Count);

            for (int i = 0; i < firstCharsValue.Length; i++)
            {
                Assert.AreEqual(firstCharsValue[i], values[0][i]);
            }

            for (int i = 0; i < secondCharsValue.Length; i++)
            {
                Assert.AreEqual(secondCharsValue[i], values[1][i]);
            }

            Assert.AreEqual(thirdCharValue, values[2]);
        }
    }
}
