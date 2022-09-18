using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQLEConnect;
using SQLEConnectUnitTests.Mockups;
using System;
using System.Collections.Generic;

namespace SQLEConnectUnitTests
{
    [TestClass]
    public class QuerySByteTests
    {
        private const string CONNECTION_STRING = "connection";
        private const string QUERY = "query";

        [TestMethod]
        public void QueryReturnsSByteThrowsExceptionIfValueIsNotSByte()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notsbyte", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => { List<sbyte> values = connection.Query<sbyte>(QUERY, null); });
        }

        [TestMethod]
        public void QueryAsyncReturnsSByteThrowsExceptionIfValueIsNotSByte()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notsbyte", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => { List<sbyte> values = await connection.QueryAsync<sbyte>(QUERY, null); });
        }

        [TestMethod]
        public void QueryReturnsEmptySByteListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<sbyte> values = connection.Query<sbyte>(QUERY, null);

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryAsyncReturnsEmptySByteListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<sbyte> values = connection.QueryAsync<sbyte>(QUERY, null).Result;

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryReturnsSByte()
        {
            sbyte firstSByteValue = 2;
            sbyte secondSByteValue = 22;
            sbyte thirdSByteValue = 33;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "sbyte", firstSByteValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "sbyte", secondSByteValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "sbyte", thirdSByteValue },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<sbyte> values = connection.Query<sbyte>(QUERY, null);

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstSByteValue, values[0]);
            Assert.AreEqual(secondSByteValue, values[1]);
            Assert.AreEqual(thirdSByteValue, values[2]);
        }

        [TestMethod]
        public void QueryAsyncReturnsSByte()
        {
            sbyte firstSByteValue = 2;
            sbyte secondSByteValue = 22;
            sbyte thirdSByteValue = 33;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "sbyte", firstSByteValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "sbyte", secondSByteValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "sbyte", thirdSByteValue },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<sbyte> values = connection.QueryAsync<sbyte>(QUERY, null).Result;

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstSByteValue, values[0]);
            Assert.AreEqual(secondSByteValue, values[1]);
            Assert.AreEqual(thirdSByteValue, values[2]);
        }

        [TestMethod]
        public void QueryReturnsDefaultSByteWhenValueIsNull()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "sbyte", null },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<sbyte> values = connection.Query<sbyte>(QUERY, null);

            Assert.AreEqual(1, values.Count);

            Assert.AreEqual(default, values[0]);
        }

        [TestMethod]
        public void QueryAsyncReturnsDefaultSByteWhenValueIsNull()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "sbyte", null },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<sbyte> values = connection.QueryAsync<sbyte>(QUERY, null).Result;

            Assert.AreEqual(1, values.Count);

            Assert.AreEqual(default, values[0]);
        }

        [TestMethod]
        public void QueryReturnsNullableSByteThrowsExceptionIfValueIsNotNullableSByte()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notsbyte", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => { List<sbyte?> values = connection.Query<sbyte?>(QUERY, null); });
        }

        [TestMethod]
        public void QueryAsyncReturnsNullableSByteThrowsExceptionIfValueIsNotNullableSByte()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notsbyte", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => { List<sbyte?> values = await connection.QueryAsync<sbyte?>(QUERY, null); });
        }

        [TestMethod]
        public void QueryReturnsEmptyNullableSByteListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<sbyte?> values = connection.Query<sbyte?>(QUERY, null);

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryAsyncReturnsEmptyNullableSByteListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<sbyte?> values = connection.QueryAsync<sbyte?>(QUERY, null).Result;

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryReturnsNullableSByte()
        {
            sbyte? firstSByteValue = 2;
            sbyte? secondSByteValue = 22;
            sbyte? thirdSByteValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "sbyte", firstSByteValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "sbyte", secondSByteValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "sbyte", thirdSByteValue },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<sbyte?> values = connection.Query<sbyte?>(QUERY, null);

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstSByteValue, values[0]);
            Assert.AreEqual(secondSByteValue, values[1]);
            Assert.AreEqual(thirdSByteValue, values[2]);
        }
        
        [TestMethod]
        public void QueryAsyncReturnsNullableSByte()
        {
            sbyte? firstSByteValue = 2;
            sbyte? secondSByteValue = 22;
            sbyte? thirdSByteValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "sbyte", firstSByteValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "sbyte", secondSByteValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "sbyte", thirdSByteValue },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<sbyte?> values = connection.QueryAsync<sbyte?>(QUERY, null).Result;

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstSByteValue, values[0]);
            Assert.AreEqual(secondSByteValue, values[1]);
            Assert.AreEqual(thirdSByteValue, values[2]);
        }
    }
}
