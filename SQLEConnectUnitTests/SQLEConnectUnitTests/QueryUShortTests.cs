using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQLEConnect;
using SQLEConnectUnitTests.Mockups;
using System;
using System.Collections.Generic;

namespace SQLEConnectUnitTests
{
    [TestClass]
    public class QueryUShortTests
    {
        private const string CONNECTION_STRING = "connection";
        private const string QUERY = "query";

        [TestMethod]
        public void QueryReturnsUShortThrowsExceptionIfValueIsNotUShort()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notushort", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => { List<ushort> values = connection.Query<ushort>(QUERY, null); });
        }

        [TestMethod]
        public void QueryAsyncReturnsUShortThrowsExceptionIfValueIsNotUShort()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notushort", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => { List<ushort> values = await connection.QueryAsync<ushort>(QUERY, null); });
        }

        [TestMethod]
        public void QueryReturnsEmptyUShortListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<ushort> values = connection.Query<ushort>(QUERY, null);

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryAsyncReturnsEmptyUShortListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<ushort> values = connection.QueryAsync<ushort>(QUERY, null).Result;

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryReturnsUShort()
        {
            ushort firstUShortValue = 2;
            ushort secondUShortValue = 13;
            ushort thirdUShortValue = 21;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "ushort", firstUShortValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "ushort", secondUShortValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "ushort", thirdUShortValue },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<ushort> values = connection.Query<ushort>(QUERY, null);

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstUShortValue, values[0]);
            Assert.AreEqual(secondUShortValue, values[1]);
            Assert.AreEqual(thirdUShortValue, values[2]);
        }

        [TestMethod]
        public void QueryAsyncReturnsUShort()
        {
            ushort firstUShortValue = 2;
            ushort secondUShortValue = 13;
            ushort thirdUShortValue = 21;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "ushort", firstUShortValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "ushort", secondUShortValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "ushort", thirdUShortValue },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<ushort> values = connection.QueryAsync<ushort>(QUERY, null).Result;

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstUShortValue, values[0]);
            Assert.AreEqual(secondUShortValue, values[1]);
            Assert.AreEqual(thirdUShortValue, values[2]);
        }

        [TestMethod]
        public void QueryReturnsDefaultUShortWhenValueIsNull()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "ushort", default },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<ushort> values = connection.Query<ushort>(QUERY, null);

            Assert.AreEqual(1, values.Count);

            Assert.AreEqual(default, values[0]);
        }

        [TestMethod]
        public void QueryAsyncReturnsDefaultUShortWhenValueIsNull()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "ushort", default },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<ushort> values = connection.QueryAsync<ushort>(QUERY, null).Result;

            Assert.AreEqual(1, values.Count);

            Assert.AreEqual(default, values[0]);
        }

        [TestMethod]
        public void QueryReturnsNullableUShortThrowsExceptionIfValueIsNotNullableUShort()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notushort", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => { List<ushort?> values = connection.Query<ushort?>(QUERY, null); });
        }

        [TestMethod]
        public void QueryAsyncReturnsNullableUShortThrowsExceptionIfValueIsNotNullableUShort()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notushort", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => { List<ushort?> values = await connection.QueryAsync<ushort?>(QUERY, null); });
        }

        [TestMethod]
        public void QueryReturnsEmptyNullableUShortListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<ushort?> values = connection.Query<ushort?>(QUERY, null);

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryAsyncReturnsEmptyNullableUShortListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<ushort?> values = connection.QueryAsync<ushort?>(QUERY, null).Result;

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryReturnsNullableUShort()
        {
            ushort? firstUShortValue = 2;
            ushort? secondUShortValue = 13;
            ushort? thirdUShortValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "ushort", firstUShortValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "ushort", secondUShortValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "ushort", thirdUShortValue },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<ushort?> values = connection.Query<ushort?>(QUERY, null);

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstUShortValue, values[0]);
            Assert.AreEqual(secondUShortValue, values[1]);
            Assert.AreEqual(thirdUShortValue, values[2]);
        }

        [TestMethod]
        public void QueryAsyncReturnsNullableUShort()
        {
            ushort? firstUShortValue = 2;
            ushort? secondUShortValue = 13;
            ushort? thirdUShortValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "ushort", firstUShortValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "ushort", secondUShortValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "ushort", thirdUShortValue },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<ushort?> values = connection.QueryAsync<ushort?>(QUERY, null).Result;

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstUShortValue, values[0]);
            Assert.AreEqual(secondUShortValue, values[1]);
            Assert.AreEqual(thirdUShortValue, values[2]);
        }
    }
}
