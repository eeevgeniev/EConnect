using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQLEConnect;
using SQLEConnectUnitTests.Mockups;
using System;
using System.Collections.Generic;

namespace SQLEConnectUnitTests
{
    [TestClass]
    public class QueryDateTimeTests
    {
        private const string CONNECTION_STRING = "connection";
        private const string QUERY = "query";

        [TestMethod]
        public void QueryReturnsDateTimeThrowsExceptionIfValueIsNotDateTime()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notadatetime", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => { List<DateTime> values = connection.Query<DateTime>(QUERY, null); });
        }

        [TestMethod]
        public void QueryAsyncReturnsDateTimeThrowsExceptionIfValueIsNotDateTime()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notadatetime", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => { List<DateTime> values = await connection.QueryAsync<DateTime>(QUERY, null); });
        }

        [TestMethod]
        public void QueryReturnsEmptyDateTimeListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<DateTime> values = connection.Query<DateTime>(QUERY, null);

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryAsyncReturnsEmptyDateTimeListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<DateTime> values = connection.Query<DateTime>(QUERY, null);

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryReturnsDateTime()
        {
            DateTime firstDateTimeValue = DateTime.Now;
            DateTime secondDateTimeValue = DateTime.Now.AddDays(1);
            DateTime thirdDateTimeValue = DateTime.Now.AddDays(2);

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "datetime", firstDateTimeValue },
                        { "second column", 33 }
                    },
                    new Dictionary<string, object>()
                    {
                        { "datetime", secondDateTimeValue },
                        { "second column", 33 }
                    },
                    new Dictionary<string, object>()
                    {
                        { "datetime", thirdDateTimeValue },
                        { "second column", 33 }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<DateTime> values = connection.Query<DateTime>(QUERY, null);

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstDateTimeValue, values[0]);
            Assert.AreEqual(secondDateTimeValue, values[1]);
            Assert.AreEqual(thirdDateTimeValue, values[2]);
        }

        [TestMethod]
        public void QueryAsyncReturnsDateTime()
        {
            DateTime firstDateTimeValue = DateTime.Now;
            DateTime secondDateTimeValue = DateTime.Now.AddDays(1);
            DateTime thirdDateTimeValue = DateTime.Now.AddDays(2);

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "datetime", firstDateTimeValue },
                        { "second column", 33 }
                    },
                    new Dictionary<string, object>()
                    {
                        { "datetime", secondDateTimeValue },
                        { "second column", 33 }
                    },
                    new Dictionary<string, object>()
                    {
                        { "datetime", thirdDateTimeValue },
                        { "second column", 33 }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<DateTime> values = connection.QueryAsync<DateTime>(QUERY, null).Result;

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstDateTimeValue, values[0]);
            Assert.AreEqual(secondDateTimeValue, values[1]);
            Assert.AreEqual(thirdDateTimeValue, values[2]);
        }

        [TestMethod]
        public void QueryReturnsDefaultDateTimeWhenValueIsNull()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "datetime", null },
                        { "second column", 33 }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<DateTime> values = connection.Query<DateTime>(QUERY, null);

            Assert.AreEqual(1, values.Count);

            Assert.AreEqual(default, values[0]);
        }

        [TestMethod]
        public void QueryAsyncReturnsDefaultDateTimeWhenValueIsNull()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "datetime", null },
                        { "second column", 33 }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<DateTime> values = connection.QueryAsync<DateTime>(QUERY, null).Result;

            Assert.AreEqual(1, values.Count);

            Assert.AreEqual(default, values[0]);
        }

        [TestMethod]
        public void QueryReturnsNullableDateTimeThrowsExceptionIfValueIsNotNullableDateTime()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notadatetime", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => { List<DateTime?> values = connection.Query<DateTime?>(QUERY, null); });
        }

        [TestMethod]
        public void QueryAsyncReturnsNullableDateTimeThrowsExceptionIfValueIsNotNullableDateTime()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notadatetime", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => { List<DateTime?> values = await connection.QueryAsync<DateTime?>(QUERY, null); });
        }

        [TestMethod]
        public void QueryReturnsEmptyNullableDateTimeListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<DateTime?> values = connection.Query<DateTime?>(QUERY, null);

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryAsyncReturnsEmptyNullableDateTimeListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<DateTime?> values = connection.Query<DateTime?>(QUERY, null);

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryReturnsNullableDateTime()
        {
            DateTime? firstDateTimeValue = DateTime.Now;
            DateTime? secondDateTimeValue = DateTime.Now.AddDays(1);
            DateTime? thirdDateTimeValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "datetime", firstDateTimeValue },
                        { "second column", 33 }
                    },
                    new Dictionary<string, object>()
                    {
                        { "datetime", secondDateTimeValue },
                        { "second column", 33 }
                    },
                    new Dictionary<string, object>()
                    {
                        { "datetime", thirdDateTimeValue },
                        { "second column", 33 }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<DateTime?> values = connection.Query<DateTime?>(QUERY, null);

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstDateTimeValue, values[0]);
            Assert.AreEqual(secondDateTimeValue, values[1]);
            Assert.AreEqual(thirdDateTimeValue, values[2]);
        }

        [TestMethod]
        public void QueryAsyncReturnsNullableDateTime()
        {
            DateTime? firstDateTimeValue = DateTime.Now;
            DateTime? secondDateTimeValue = DateTime.Now.AddDays(1);
            DateTime? thirdDateTimeValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "datetime", firstDateTimeValue },
                        { "second column", 33 }
                    },
                    new Dictionary<string, object>()
                    {
                        { "datetime", secondDateTimeValue },
                        { "second column", 33 }
                    },
                    new Dictionary<string, object>()
                    {
                        { "datetime", thirdDateTimeValue },
                        { "second column", 33 }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<DateTime?> values = connection.QueryAsync<DateTime?>(QUERY, null).Result;

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstDateTimeValue, values[0]);
            Assert.AreEqual(secondDateTimeValue, values[1]);
            Assert.AreEqual(thirdDateTimeValue, values[2]);
        }
    }
}
