using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQLEConnect;
using SQLEConnectUnitTests.Mockups;
using System;
using System.Collections.Generic;

namespace SQLEConnectUnitTests
{
    [TestClass]
    public class SingleLongTests
    {
        private const string CONNECTION_STRING = "connection";
        private const string QUERY = "query";

        [TestMethod]
        public void SingleReturnsLongThrowsExceptionIfValueIsNotLong()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notlong", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => { (bool hasResult, long value) value = connection.Single<long>(QUERY, null); });
        }

        [TestMethod]
        public void SingleAsyncReturnsLongThrowsExceptionIfValueIsNotLong()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notlong", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => { (bool hasResult, long value) value = await connection.SingleAsync<long>(QUERY, null); });
        }

        [TestMethod]
        public void SingleReturnsLongReturnsDefaultIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, long value) value = connection.Single<long>(QUERY, null);

            Assert.IsFalse(value.hasResult);
        }

        [TestMethod]
        public void SingleAsyncReturnsLongReturnsDefaultIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, long value) value = connection.SingleAsync<long>(QUERY, null).Result;

            Assert.IsFalse(value.hasResult);
        }

        [TestMethod]
        public void SingleReturnsLong()
        {
            long longValue = 2;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "long", longValue }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, long value) value = connection.Single<long>(QUERY, null);

            Assert.IsTrue(value.hasResult);
            Assert.AreEqual(longValue, value.value);
        }

        [TestMethod]
        public void SingleAsyncReturnsLong()
        {
            long longValue = 1;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "long", longValue }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, long value) value = connection.SingleAsync<long>(QUERY, null).Result;

            Assert.IsTrue(value.hasResult);
            Assert.AreEqual(longValue, value.value);
        }

        [TestMethod]
        public void SingleReturnsDefaultLongWhenValueIsNull()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "long", null }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, long value) value = connection.Single<long>(QUERY, null);

            Assert.IsTrue(value.hasResult);
            Assert.AreEqual(default, value.value);
        }

        [TestMethod]
        public void SingleAsyncReturnsDefaultLongWhenValueIsNull()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "long", null }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, long value) value = connection.SingleAsync<long>(QUERY, null).Result;

            Assert.IsTrue(value.hasResult);
            Assert.AreEqual(default, value.value);
        }

        [TestMethod]
        public void SingleReturnsLongMoreThanOneColumn()
        {
            long longValue = 2;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "long", longValue },
                        { "name", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, long value) value = connection.Single<long>(QUERY, null);

            Assert.IsTrue(value.hasResult);
            Assert.AreEqual(longValue, value.value);
        }

        [TestMethod]
        public void SingleAsyncReturnsLongMoreThanOneColumn()
        {
            long longValue = 1;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "long", longValue },
                        { "name", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, long value) value = connection.SingleAsync<long>(QUERY, null).Result;

            Assert.IsTrue(value.hasResult);
            Assert.AreEqual(longValue, value.value);
        }

        [TestMethod]
        public void SingleReturnsNullableLongThrowsExceptionIfValueIsNotNullableLong()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notlong", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => { (bool hasResult, long? value) value = connection.Single<long?>(QUERY, null); });
        }

        [TestMethod]
        public void SingleAsyncReturnsNullableLongThrowsExceptionIfValueIsNotNullableLong()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notlong", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => { (bool hasResult, long? value) value = await connection.SingleAsync<long?>(QUERY, null); });
        }

        [TestMethod]
        public void SingleReturnsNullableLongReturnsDefaultIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, long? value) value = connection.Single<long?>(QUERY, null);

            Assert.IsFalse(value.hasResult);
        }

        [TestMethod]
        public void SingleAsyncReturnsNullableLongReturnsDefaultIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, long? value) value = connection.SingleAsync<long?>(QUERY, null).Result;

            Assert.IsFalse(value.hasResult);
        }

        [TestMethod]
        public void SingleReturnsNullableLong()
        {
            long? longValue = 2;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "long", longValue }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, long? value) value = connection.Single<long?>(QUERY, null);

            Assert.IsTrue(value.hasResult);
            Assert.AreEqual(longValue, value.value);
        }

        [TestMethod]
        public void SingleReturnsNullableLongWhenValueIsNull()
        {
            long? longValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "long", longValue }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, long? value) value = connection.Single<long?>(QUERY, null);

            Assert.IsTrue(value.hasResult);
            Assert.IsNull(value.value);
        }

        [TestMethod]
        public void SingleReturnsNullableLongMoreThanOneColumn()
        {
            long? longValue = 2;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "long", longValue },
                        { "name", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, long? value) value = connection.Single<long?>(QUERY, null);

            Assert.IsTrue(value.hasResult);
            Assert.AreEqual(longValue, value.value);
        }

        [TestMethod]
        public void SingleReturnsNullableLongMoreThanOneColumnWhenValueIsNull()
        {
            long? longValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "long", longValue },
                        { "name", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, long? value) value = connection.Single<long?>(QUERY, null);

            Assert.IsTrue(value.hasResult);
            Assert.IsNull(value.value);
        }

        [TestMethod]
        public void SingleAsyncReturnsNullableLong()
        {
            long? longValue = 2;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "long", longValue }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, long? value) value = connection.SingleAsync<long?>(QUERY, null).Result;

            Assert.IsTrue(value.hasResult);
            Assert.AreEqual(longValue, value.value);
        }

        [TestMethod]
        public void SingleAsyncReturnsNullableLongWhenValueIsNull()
        {
            long? longValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "long", longValue }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, long? value) value = connection.SingleAsync<long?>(QUERY, null).Result;

            Assert.IsTrue(value.hasResult);
            Assert.IsNull(value.value);
        }

        [TestMethod]
        public void SingleAsyncReturnsNullableLongMoreThanOneColumn()
        {
            long? longValue = 2;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "long", longValue },
                        { "name", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, long? value) value = connection.SingleAsync<long?>(QUERY, null).Result;

            Assert.IsTrue(value.hasResult);
            Assert.AreEqual(longValue, value.value);
        }

        [TestMethod]
        public void SingleAsyncReturnsNullableLongMoreThanOneColumnWhenValueIsNull()
        {
            long? longValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "long", longValue },
                        { "name", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, long? value) value = connection.SingleAsync<long?>(QUERY, null).Result;

            Assert.IsTrue(value.hasResult);
            Assert.IsNull(value.value);
        }
    }
}
