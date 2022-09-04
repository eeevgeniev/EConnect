using EConnect;
using EConnectUnitTests.Mockups;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EConnectUnitTests
{
    [TestClass]
    public class QueryCharTests
    {
        private const string CONNECTION_STRING = "connection";
        private const string QUERY = "query";

        [TestMethod]
        public void QueryReturnsCharThrowsExceptionIfValueIsNotChar()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notachar", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => { List<char> values = connection.Query<char>(QUERY, null); });
        }

        [TestMethod]
        public void QueryAsyncReturnsCharThrowsExceptionIfValueIsNotChar()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notachar", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => { List<char> values = await connection.QueryAsync<char>(QUERY, null); });
        }

        [TestMethod]
        public void QueryReturnsEmptyCharListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<char> values = connection.Query<char>(QUERY, null);

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryAsyncReturnsEmptyCharListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<char> values = connection.QueryAsync<char>(QUERY, null).Result;

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryReturnsChar()
        {
            char firstCharValue = '2';
            char secondCharValue = 'a';
            char thirdCharValue = 'z';

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "char", firstCharValue },
                        { "second column", 21 }
                    },
                    new Dictionary<string, object>()
                    {
                        { "char", secondCharValue },
                        { "second column", 21 }
                    },
                    new Dictionary<string, object>()
                    {
                        { "char", thirdCharValue },
                        { "second column", 21 }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<char> values = connection.Query<char>(QUERY, null);

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstCharValue, values[0]);
            Assert.AreEqual(secondCharValue, values[1]);
            Assert.AreEqual(thirdCharValue, values[2]);
        }

        [TestMethod]
        public void QueryAsyncReturnsChar()
        {
            char firstCharValue = '2';
            char secondCharValue = 'a';
            char thirdCharValue = 'z';

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "char", firstCharValue },
                        { "second column", 21 }
                    },
                    new Dictionary<string, object>()
                    {
                        { "char", secondCharValue },
                        { "second column", 21 }
                    },
                    new Dictionary<string, object>()
                    {
                        { "char", thirdCharValue },
                        { "second column", 21 }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<char> values = connection.QueryAsync<char>(QUERY, null).Result;

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstCharValue, values[0]);
            Assert.AreEqual(secondCharValue, values[1]);
            Assert.AreEqual(thirdCharValue, values[2]);
        }

        [TestMethod]
        public void QueryReturnsDefaultCharWhenValueIsNull()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "char", null },
                        { "second column", 21 }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<char> values = connection.Query<char>(QUERY, null);

            Assert.AreEqual(1, values.Count);

            Assert.AreEqual(default, values[0]);
        }

        [TestMethod]
        public void QueryAsyncReturnsDefaultCharWhenValueIsNull()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "char", null },
                        { "second column", 21 }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<char> values = connection.QueryAsync<char>(QUERY, null).Result;

            Assert.AreEqual(1, values.Count);

            Assert.AreEqual(default, values[0]);
        }

        [TestMethod]
        public void QueryReturnsNullableCharThrowsExceptionIfValueIsNotNullableChar()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notachar", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => { List<char?> values = connection.Query<char?>(QUERY, null); });
        }

        [TestMethod]
        public void QueryAsyncReturnsNullableCharThrowsExceptionIfValueIsNotNullableChar()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notachar", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => { List<char?> values = await connection.QueryAsync<char?>(QUERY, null); });
        }

        [TestMethod]
        public void QueryReturnsNullableCharReturnsDefaultIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<char?> values = connection.Query<char?>(QUERY, null);

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryAsyncReturnsNullableCharReturnsDefaultIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<char?> values = connection.QueryAsync<char?>(QUERY, null).Result;

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryReturnsNullableChar()
        {
            char? firstCharValue = '2';
            char? secondCharValue = 's';
            char? thirdCharValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "char", firstCharValue },
                        { "second column", 21 }
                    },
                    new Dictionary<string, object>()
                    {
                        { "char", secondCharValue },
                        { "second column", 21 }
                    },
                    new Dictionary<string, object>()
                    {
                        { "char", thirdCharValue },
                        { "second column", 21 }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<char?> values = connection.Query<char?>(QUERY, null);

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstCharValue, values[0]);
            Assert.AreEqual(secondCharValue, values[1]);
            Assert.AreEqual(thirdCharValue, values[2]);
        }

        [TestMethod]
        public void QueryAsyncReturnsNullableChar()
        {
            char? firstCharValue = '2';
            char? secondCharValue = 's';
            char? thirdCharValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "char", firstCharValue },
                        { "second column", 21 }
                    },
                    new Dictionary<string, object>()
                    {
                        { "char", secondCharValue },
                        { "second column", 21 }
                    },
                    new Dictionary<string, object>()
                    {
                        { "char", thirdCharValue },
                        { "second column", 21 }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<char?> values = connection.QueryAsync<char?>(QUERY, null).Result;

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstCharValue, values[0]);
            Assert.AreEqual(secondCharValue, values[1]);
            Assert.AreEqual(thirdCharValue, values[2]);
        }
    }
}
