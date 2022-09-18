using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQLEConnect;
using SQLEConnectUnitTests.Mockups;
using System;
using System.Collections.Generic;

namespace SQLEConnectUnitTests
{
    [TestClass]
    public class SingleUIntTests
    {
        private const string CONNECTION_STRING = "connection";
        private const string QUERY = "query";

        [TestMethod]
        public void SingleReturnsUIntThrowsExceptionIfValueIsNotUInt()
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

            Assert.ThrowsException<Exception>(() => { (bool hasResult, uint value) value = connection.Single<uint>(QUERY, null); });
        }

        [TestMethod]
        public void SingleAsyncReturnsUIntThrowsExceptionIfValueIsNotUInt()
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

            Assert.ThrowsExceptionAsync<Exception>(async () => { (bool hasResult, uint value) value = await connection.SingleAsync<uint>(QUERY, null); });
        }

        [TestMethod]
        public void SingleReturnsUIntReturnsDefaultIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, uint value) value = connection.Single<uint>(QUERY, null);

            Assert.IsFalse(value.hasResult);
        }

        [TestMethod]
        public void SingleAsyncReturnsUIntReturnsDefaultIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, uint value) value = connection.SingleAsync<uint>(QUERY, null).Result;

            Assert.IsFalse(value.hasResult);
        }

        [TestMethod]
        public void SingleReturnsUInt()
        {
            uint uintValue = 2;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "uint", uintValue }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, uint value) value = connection.Single<uint>(QUERY, null);

            Assert.IsTrue(value.hasResult);
            Assert.AreEqual(uintValue, value.value);
        }

        [TestMethod]
        public void SingleAsyncReturnsUInt()
        {
            uint uintValue = 1;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "uint", uintValue }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, uint value) value = connection.SingleAsync<uint>(QUERY, null).Result;

            Assert.IsTrue(value.hasResult);
            Assert.AreEqual(uintValue, value.value);
        }

        [TestMethod]
        public void SingleReturnsDefaultUIntWhenValueIsNull()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "uint", null }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, uint value) value = connection.Single<uint>(QUERY, null);

            Assert.IsTrue(value.hasResult);
            Assert.AreEqual(default, value.value);
        }

        [TestMethod]
        public void SingleAsyncReturnsDefaultUIntWhenValueIsNull()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "uint", null }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, uint value) value = connection.SingleAsync<uint>(QUERY, null).Result;

            Assert.IsTrue(value.hasResult);
            Assert.AreEqual(default, value.value);
        }

        [TestMethod]
        public void SingleReturnsUIntMoreThanOneColumn()
        {
            uint uintValue = 2;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "uint", uintValue },
                        { "name", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, uint value) value = connection.Single<uint>(QUERY, null);

            Assert.IsTrue(value.hasResult);
            Assert.AreEqual(uintValue, value.value);
        }

        [TestMethod]
        public void SingleAsyncReturnsUIntMoreThanOneColumn()
        {
            uint uintValue = 1;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "uint", uintValue },
                        { "name", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, uint value) value = connection.SingleAsync<uint>(QUERY, null).Result;

            Assert.IsTrue(value.hasResult);
            Assert.AreEqual(uintValue, value.value);
        }

        [TestMethod]
        public void SingleReturnsNullableUIntThrowsExceptionIfValueIsNotNullableUInt()
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

            Assert.ThrowsException<Exception>(() => { (bool hasResult, uint? value) value = connection.Single<uint?>(QUERY, null); });
        }

        [TestMethod]
        public void SingleAsyncReturnsNullableUIntThrowsExceptionIfValueIsNotNullableUInt()
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

            Assert.ThrowsExceptionAsync<Exception>(async () => { (bool hasResult, uint? value) value = await connection.SingleAsync<uint?>(QUERY, null); });
        }

        [TestMethod]
        public void SingleReturnsNullableUIntReturnsDefaultIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, uint? value) value = connection.Single<uint?>(QUERY, null);

            Assert.IsFalse(value.hasResult);
        }

        [TestMethod]
        public void SingleAsyncReturnsNullableUIntReturnsDefaultIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, uint? value) value = connection.SingleAsync<uint?>(QUERY, null).Result;

            Assert.IsFalse(value.hasResult);
        }

        [TestMethod]
        public void SingleReturnsNullableUInt()
        {
            uint? uintValue = 2;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "uint", uintValue }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, uint? value) value = connection.Single<uint?>(QUERY, null);

            Assert.IsTrue(value.hasResult);
            Assert.AreEqual(uintValue, value.value);
        }

        [TestMethod]
        public void SingleReturnsNullableUIntWhenValueIsNull()
        {
            uint? uintValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "uint", uintValue }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, uint? value) value = connection.Single<uint?>(QUERY, null);

            Assert.IsTrue(value.hasResult);
            Assert.IsNull(value.value);
        }

        [TestMethod]
        public void SingleReturnsNullableUIntMoreThanOneColumn()
        {
            uint? uintValue = 2;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "uint", uintValue },
                        { "name", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, uint? value) value = connection.Single<uint?>(QUERY, null);

            Assert.IsTrue(value.hasResult);
            Assert.AreEqual(uintValue, value.value);
        }

        [TestMethod]
        public void SingleReturnsNullableUIntMoreThanOneColumnWhenValueIsNull()
        {
            uint? uintValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "uint", uintValue },
                        { "name", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, uint? value) value = connection.Single<uint?>(QUERY, null);

            Assert.IsTrue(value.hasResult);
            Assert.IsNull(value.value);
        }

        [TestMethod]
        public void SingleAsyncReturnsNullableUInt()
        {
            uint? uintValue = 2;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "uint", uintValue }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, uint? value) value = connection.SingleAsync<uint?>(QUERY, null).Result;

            Assert.IsTrue(value.hasResult);
            Assert.AreEqual(uintValue, value.value);
        }

        [TestMethod]
        public void SingleAsyncReturnsNullableUIntWhenValueIsNull()
        {
            uint? uintValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "uint", uintValue }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, uint? value) value = connection.SingleAsync<uint?>(QUERY, null).Result;

            Assert.IsTrue(value.hasResult);
            Assert.IsNull(value.value);
        }

        [TestMethod]
        public void SingleAsyncReturnsNullableUIntMoreThanOneColumn()
        {
            uint? uintValue = 2;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "uint", uintValue },
                        { "name", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, uint? value) value = connection.SingleAsync<uint?>(QUERY, null).Result;

            Assert.IsTrue(value.hasResult);
            Assert.AreEqual(uintValue, value.value);
        }

        [TestMethod]
        public void SingleAsyncReturnsNullableUIntMoreThanOneColumnWhenValueIsNull()
        {
            uint? uintValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "uint", uintValue },
                        { "name", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, uint? value) value = connection.SingleAsync<uint?>(QUERY, null).Result;

            Assert.IsTrue(value.hasResult);
            Assert.IsNull(value.value);
        }
    }
}
