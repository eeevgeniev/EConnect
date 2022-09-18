using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQLEConnect;
using SQLEConnectUnitTests.Mockups;
using System;
using System.Collections.Generic;

namespace SQLEConnectUnitTests
{
    [TestClass]
    public class SingleCharsTests
    {
        private const string CONNECTION_STRING = "connection";
        private const string QUERY = "query";

        [TestMethod]
        public void SingleReturnsCharsThrowsExceptionIfValueIsNotChars()
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

            Assert.ThrowsException<Exception>(() => { (bool hasResult, char[] value) value = connection.Single<char[]>(QUERY, null); });
        }

        [TestMethod]
        public void SingleAsyncReturnsCharsThrowsExceptionIfValueIsNotChars()
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
                (bool hasResult, char[] value) value = await connection.SingleAsync<char[]>(QUERY, null);
            });
        }

        [TestMethod]
        public void SingleReturnsCharsReturnsDefaultIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, char[] value) value = connection.Single<char[]>(QUERY, null);

            Assert.IsFalse(value.hasResult);
        }

        [TestMethod]
        public void SingleAsyncReturnsCharsReturnsDefaultIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, char[] value) value = connection.SingleAsync<char[]>(QUERY, null).Result;

            Assert.IsFalse(value.hasResult);
        }

        [TestMethod]
        public void SingleReturnsChars()
        {
            char[] charsValue = { '1', '2', 'c' };

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "chars", charsValue }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, char[] value) value = connection.Single<char[]>(QUERY, null);

            Assert.IsTrue(value.hasResult);
            Assert.AreEqual(charsValue.Length, value.value.Length);

            for (int i = 0; i < charsValue.Length; i++)
            {
                Assert.AreEqual(charsValue[i], value.value[i]);
            }
        }

        [TestMethod]
        public void SingleReturnsCharsWhenValueIsNull()
        {
            char[] charsValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "chars", charsValue }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, char[] value) value = connection.Single<char[]>(QUERY, null);

            Assert.IsTrue(value.hasResult);
            Assert.IsNull(value.value);
        }

        [TestMethod]
        public void SingleAsyncReturnsChars()
        {
            char[] charsValue = { 'a', 'b', 'c' };

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "chars", charsValue }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, char[] value) value = connection.SingleAsync<char[]>(QUERY, null).Result;

            Assert.IsTrue(value.hasResult);
            Assert.AreEqual(charsValue.Length, value.value.Length);

            for (int i = 0; i < charsValue.Length; i++)
            {
                Assert.AreEqual(charsValue[i], value.value[i]);
            }
        }

        [TestMethod]
        public void SingleAsyncReturnsCharsWhenValueIsNull()
        {
            char[] charsValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "chars", charsValue }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, char[] value) value = connection.SingleAsync<char[]>(QUERY, null).Result;

            Assert.IsTrue(value.hasResult);
            Assert.IsNull(value.value);
        }

        [TestMethod]
        public void SingleReturnsCharsMoreThanOneColumn()
        {
            char[] charsValue = { 'a', 'b', 'c' };

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "chars", charsValue },
                        { "name", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, char[] value) value = connection.Single<char[]>(QUERY, null);

            Assert.IsTrue(value.hasResult);
            Assert.AreEqual(value.value.Length, charsValue.Length);

            for (int i = 0; i < charsValue.Length; i++)
            {
                Assert.AreEqual(charsValue[i], value.value[i]);
            }
        }

        [TestMethod]
        public void SingleReturnsCharsMoreThanOneColumnWhenValueIsNull()
        {
            char[] charsValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "chars", charsValue },
                        { "name", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, char[] value) value = connection.Single<char[]>(QUERY, null);

            Assert.IsTrue(value.hasResult);
            Assert.IsNull(value.value);
        }

        [TestMethod]
        public void SingleAsyncReturnsCharsMoreThanOneColumn()
        {
            char[] charsValue = { '1', '2', '3' };

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "chars", charsValue },
                        { "name", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, char[] value) value = connection.SingleAsync<char[]>(QUERY, null).Result;

            Assert.IsTrue(value.hasResult);
            Assert.AreEqual(value.value.Length, charsValue.Length);

            for (int i = 0; i < charsValue.Length; i++)
            {
                Assert.AreEqual(charsValue[i], value.value[i]);
            }
        }

        [TestMethod]
        public void SingleAsyncReturnsCharsMoreThanOneColumnWhenValueIsNull()
        {
            char[] charsValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "chars", charsValue },
                        { "name", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, char[] value) value = connection.SingleAsync<char[]>(QUERY, null).Result;

            Assert.IsTrue(value.hasResult);
            Assert.IsNull(value.value);
        }
    }
}
