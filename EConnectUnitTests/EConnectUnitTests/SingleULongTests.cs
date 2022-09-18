using EConnect;
using EConnectUnitTests.Mockups;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EConnectUnitTests
{
    [TestClass]
    public class SingleULongTests
    {
        private const string CONNECTION_STRING = "connection";
        private const string QUERY = "query";

        [TestMethod]
        public void SingleReturnsULongThrowsExceptionIfValueIsNotULong()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notulong", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => { (bool hasResult, ulong value) value = connection.Single<ulong>(QUERY, null); });
        }

        [TestMethod]
        public void SingleAsyncReturnsULongThrowsExceptionIfValueIsNotULong()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notulong", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => { (bool hasResult, ulong value) value = await connection.SingleAsync<ulong>(QUERY, null); });
        }

        [TestMethod]
        public void SingleReturnsULongReturnsDefaultIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, ulong value) value = connection.Single<ulong>(QUERY, null);

            Assert.IsFalse(value.hasResult);
        }

        [TestMethod]
        public void SingleAsyncReturnsULongReturnsDefaultIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, ulong value) value = connection.SingleAsync<ulong>(QUERY, null).Result;

            Assert.IsFalse(value.hasResult);
        }

        [TestMethod]
        public void SingleReturnsULong()
        {
            ulong ulongValue = 2;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "ulong", ulongValue }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, ulong value) value = connection.Single<ulong>(QUERY, null);

            Assert.IsTrue(value.hasResult);
            Assert.AreEqual(ulongValue, value.value);
        }

        [TestMethod]
        public void SingleAsyncReturnsULong()
        {
            ulong ulongValue = 1;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "ulong", ulongValue }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, ulong value) value = connection.SingleAsync<ulong>(QUERY, null).Result;

            Assert.IsTrue(value.hasResult);
            Assert.AreEqual(ulongValue, value.value);
        }

        [TestMethod]
        public void SingleReturnsDefaultULongWhenValueIsNull()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "ulong", null }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, ulong value) value = connection.Single<ulong>(QUERY, null);

            Assert.IsTrue(value.hasResult);
            Assert.AreEqual(default, value.value);
        }

        [TestMethod]
        public void SingleAsyncDefaultULongWhenValueIsNull()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "ulong", null }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, ulong value) value = connection.SingleAsync<ulong>(QUERY, null).Result;

            Assert.IsTrue(value.hasResult);
            Assert.AreEqual(default, value.value);
        }

        [TestMethod]
        public void SingleReturnsULongMoreThanOneColumn()
        {
            ulong ulongValue = 2;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "ulong", ulongValue },
                        { "name", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, ulong value) value = connection.Single<ulong>(QUERY, null);

            Assert.IsTrue(value.hasResult);
            Assert.AreEqual(ulongValue, value.value);
        }

        [TestMethod]
        public void SingleAsyncReturnsULongMoreThanOneColumn()
        {
            ulong ulongValue = 1;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "ulong", ulongValue },
                        { "name", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, ulong value) value = connection.SingleAsync<ulong>(QUERY, null).Result;

            Assert.IsTrue(value.hasResult);
            Assert.AreEqual(ulongValue, value.value);
        }

        [TestMethod]
        public void SingleReturnsNullableULongThrowsExceptionIfValueIsNotNullableULong()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notulong", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => { (bool hasResult, ulong? value) value = connection.Single<ulong?>(QUERY, null); });
        }

        [TestMethod]
        public void SingleAsyncReturnsNullableULongThrowsExceptionIfValueIsNotNullableULong()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notulong", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => { (bool hasResult, ulong? value) value = await connection.SingleAsync<ulong?>(QUERY, null); });
        }

        [TestMethod]
        public void SingleReturnsNullableULongReturnsDefaultIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, ulong? value) value = connection.Single<ulong?>(QUERY, null);

            Assert.IsFalse(value.hasResult);
        }

        [TestMethod]
        public void SingleAsyncReturnsNullableULongReturnsDefaultIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, ulong? value) value = connection.SingleAsync<ulong?>(QUERY, null).Result;

            Assert.IsFalse(value.hasResult);
        }

        [TestMethod]
        public void SingleReturnsNullableULong()
        {
            ulong? ulongValue = 2;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "ulong", ulongValue }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, ulong? value) value = connection.Single<ulong?>(QUERY, null);

            Assert.IsTrue(value.hasResult);
            Assert.AreEqual(ulongValue, value.value);
        }

        [TestMethod]
        public void SingleReturnsNullableULongWhenValueIsNull()
        {
            ulong? ulongValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "ulong", ulongValue }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, ulong? value) value = connection.Single<ulong?>(QUERY, null);

            Assert.IsTrue(value.hasResult);
            Assert.IsNull(value.value);
        }

        [TestMethod]
        public void SingleReturnsNullableULongMoreThanOneColumn()
        {
            ulong? ulongValue = 2;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "ulong", ulongValue },
                        { "name", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, ulong? value) value = connection.Single<ulong?>(QUERY, null);

            Assert.IsTrue(value.hasResult);
            Assert.AreEqual(ulongValue, value.value);
        }

        [TestMethod]
        public void SingleReturnsNullableULongMoreThanOneColumnWhenValueIsNull()
        {
            ulong? ulongValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "ulong", ulongValue },
                        { "name", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, ulong? value) value = connection.Single<ulong?>(QUERY, null);

            Assert.IsTrue(value.hasResult);
            Assert.IsNull(value.value);
        }

        [TestMethod]
        public void SingleAsyncReturnsNullableULong()
        {
            ulong? ulongValue = 2;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "ulong", ulongValue }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, ulong? value) value = connection.SingleAsync<ulong?>(QUERY, null).Result;

            Assert.IsTrue(value.hasResult);
            Assert.AreEqual(ulongValue, value.value);
        }

        [TestMethod]
        public void SingleAsyncReturnsNullableULongWhenValueIsNull()
        {
            ulong? ulongValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "ulong", ulongValue }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, ulong? value) value = connection.SingleAsync<ulong?>(QUERY, null).Result;

            Assert.IsTrue(value.hasResult);
            Assert.IsNull(value.value);
        }

        [TestMethod]
        public void SingleAsyncReturnsNullableULongMoreThanOneColumn()
        {
            ulong? ulongValue = 2;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "ulong", ulongValue },
                        { "name", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, ulong? value) value = connection.SingleAsync<ulong?>(QUERY, null).Result;

            Assert.IsTrue(value.hasResult);
            Assert.AreEqual(ulongValue, value.value);
        }

        [TestMethod]
        public void SingleAsyncReturnsNullableULongMoreThanOneColumnWhenValueIsNull()
        {
            ulong? ulongValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "ulong", ulongValue },
                        { "name", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, ulong? value) value = connection.SingleAsync<ulong?>(QUERY, null).Result;

            Assert.IsTrue(value.hasResult);
            Assert.IsNull(value.value);
        }
    }
}
