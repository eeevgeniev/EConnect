using EConnect;
using EConnectUnitTests.Mockups;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EConnectUnitTests
{
    [TestClass]
    public class QueryUIntTests
    {
        private const string CONNECTION_STRING = "connection";
        private const string QUERY = "query";

        [TestMethod]
        public void QueryReturnsUIntThrowsExceptionIfValueIsNotUInt()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notuint", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => { List<uint> values = connection.Query<uint>(QUERY, null); });
        }

        [TestMethod]
        public void QueryAsyncReturnsUIntThrowsExceptionIfValueIsNotUInt()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notuint", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => { List<uint> values = await connection.QueryAsync<uint>(QUERY, null); });
        }

        [TestMethod]
        public void QueryReturnsEmptyUIntListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<uint> values = connection.Query<uint>(QUERY, null);

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryAsyncReturnsEmptyUIntListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<uint> values = connection.QueryAsync<uint>(QUERY, null).Result;

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryReturnsUInt()
        {
            uint firstUIntValue = 2;
            uint secondUIntValue = 11;
            uint thirdUIntValue = 44;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "uint", firstUIntValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "uint", secondUIntValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "uint", thirdUIntValue },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<uint> values = connection.Query<uint>(QUERY, null);

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstUIntValue, values[0]);
            Assert.AreEqual(secondUIntValue, values[1]);
            Assert.AreEqual(thirdUIntValue, values[2]);
        }

        [TestMethod]
        public void QueryAsyncReturnsUInt()
        {
            uint firstUIntValue = 2;
            uint secondUIntValue = 11;
            uint thirdUIntValue = 44;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "uint", firstUIntValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "uint", secondUIntValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "uint", thirdUIntValue },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<uint> values = connection.QueryAsync<uint>(QUERY, null).Result;

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstUIntValue, values[0]);
            Assert.AreEqual(secondUIntValue, values[1]);
            Assert.AreEqual(thirdUIntValue, values[2]);
        }

        [TestMethod]
        public void QueryReturnsDefaultUIntWhenValueIsNull()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "uint", null },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<uint> values = connection.Query<uint>(QUERY, null);

            Assert.AreEqual(1, values.Count);

            Assert.AreEqual(default, values[0]);
        }

        [TestMethod]
        public void QueryAsyncReturnsDefaultUIntWhenValueIsNull()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "uint", null },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<uint> values = connection.QueryAsync<uint>(QUERY, null).Result;

            Assert.AreEqual(1, values.Count);

            Assert.AreEqual(default, values[0]);
        }

        [TestMethod]
        public void QueryReturnsNullableUIntThrowsExceptionIfValueIsNotNullableUInt()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notuint", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => { List<uint?> values = connection.Query<uint?>(QUERY, null); });
        }

        [TestMethod]
        public void QueryAsyncReturnsNullableUIntThrowsExceptionIfValueIsNotNullableUInt()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notuint", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => { List<uint?> values = await connection.QueryAsync<uint?>(QUERY, null); });
        }

        [TestMethod]
        public void QueryReturnsEmptyNullableUIntListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<uint?> values = connection.Query<uint?>(QUERY, null);

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryAsyncReturnsEmptyNullableUIntListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<uint?> values = connection.QueryAsync<uint?>(QUERY, null).Result;

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryReturnsNullableUInt()
        {
            uint? firstUIntValue = 2;
            uint? secondUIntValue = 11;
            uint? thirdUIntValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "uint", firstUIntValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "uint", secondUIntValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "uint", thirdUIntValue },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<uint?> values = connection.Query<uint?>(QUERY, null);

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstUIntValue, values[0]);
            Assert.AreEqual(secondUIntValue, values[1]);
            Assert.AreEqual(thirdUIntValue, values[2]);
        }

        [TestMethod]
        public void QueryAsyncReturnsNullableUInt()
        {
            uint? firstUIntValue = 2;
            uint? secondUIntValue = 11;
            uint? thirdUIntValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "uint", firstUIntValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "uint", secondUIntValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "uint", thirdUIntValue },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<uint?> values = connection.QueryAsync<uint?>(QUERY, null).Result;

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstUIntValue, values[0]);
            Assert.AreEqual(secondUIntValue, values[1]);
            Assert.AreEqual(thirdUIntValue, values[2]);
        }
    }
}
