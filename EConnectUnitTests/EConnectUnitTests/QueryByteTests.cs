using EConnect;
using EConnectUnitTests.Mockups;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EConnectUnitTests
{
    [TestClass]
    public class QueryByteTests
    {
        private const string CONNECTION_STRING = "connection";
        private const string QUERY = "query";

        [TestMethod]
        public void QueryReturnsByteThrowsExceptionIfValueIsNotByte()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notbyte", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => { List<byte> values = connection.Query<byte>(QUERY, null); });
        }

        [TestMethod]
        public void QueryAsyncReturnsByteThrowsExceptionIfValueIsNotByte()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notbyte", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => { List<byte> values = await connection.QueryAsync<byte>(QUERY, null); });
        }

        [TestMethod]
        public void QueryReturnsEmptyByteListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<byte> values = connection.Query<byte>(QUERY, null);

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryAsyncReturnsEmptyByteListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<byte> values = connection.QueryAsync<byte>(QUERY, null).Result;

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryReturnsByte()
        {
            byte firstByteValue = 2;
            byte secondByteValue = 22;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "byte", firstByteValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "byte", secondByteValue },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<byte> values = connection.Query<byte>(QUERY, null);

            Assert.AreEqual(2, values.Count);

            Assert.AreEqual(firstByteValue, values[0]);
            Assert.AreEqual(secondByteValue, values[1]);
        }

        [TestMethod]
        public void QueryAsyncReturnsByte()
        {
            byte firstByteValue = 1;
            byte secondByteValue = 22;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "byte", firstByteValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "byte", secondByteValue },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<byte> values = connection.QueryAsync<byte>(QUERY, null).Result;

            Assert.AreEqual(values.Count, 2);

            Assert.AreEqual(firstByteValue, values[0]);
            Assert.AreEqual(secondByteValue, values[1]);
        }

        [TestMethod]
        public void QueryReturnsDefaultByteWhenValueIsNull()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "byte", null },
                    },
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<byte> values = connection.Query<byte>(QUERY, null);

            Assert.AreEqual(1, values.Count);

            Assert.AreEqual(default, values[0]);
        }

        [TestMethod]
        public void QueryAsyncReturnsDefaultByteWhenValueIsNull()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "byte", null },
                    },
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<byte> values = connection.QueryAsync<byte>(QUERY, null).Result;

            Assert.AreEqual(1, values.Count);

            Assert.AreEqual(default, values[0]);
        }

        [TestMethod]
        public void QueryReturnsNullableByteThrowsExceptionIfValueIsNotNullableByte()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notbyte", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => { List<byte?> value = connection.Query<byte?>(QUERY, null); });
        }

        [TestMethod]
        public void QueryAsyncReturnsNullableByteThrowsExceptionIfValueIsNotNullableByte()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notbyte", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => { List<byte?> value = await connection.QueryAsync<byte?>(QUERY, null); });
        }

        [TestMethod]
        public void QueryReturnsEmptyNullableByteListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<byte?> values = connection.Query<byte?>(QUERY, null);

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryAsyncReturnsEmptyNullableByteListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<byte?> values = connection.Query<byte?>(QUERY, null);

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryReturnsNullableByte()
        {
            byte? firstByteValue = 2;
            byte? secondByteValue = 33;
            byte? thirdByteValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "byte", firstByteValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "byte", secondByteValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "byte", thirdByteValue },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<byte?> values = connection.Query<byte?>(QUERY, null);

            Assert.AreEqual(3, values.Count);
            
            Assert.AreEqual(firstByteValue, values[0]);
            Assert.AreEqual(secondByteValue, values[1]);
            Assert.AreEqual(thirdByteValue, values[2]);
        }

        [TestMethod]
        public void QueryAsyncReturnsNullableByte()
        {
            byte? firstByteValue = 2;
            byte? secondByteValue = 33;
            byte? thirdByteValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "byte", firstByteValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "byte", secondByteValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "byte", thirdByteValue },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<byte?> values = connection.QueryAsync<byte?>(QUERY, null).Result;

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstByteValue, values[0]);
            Assert.AreEqual(secondByteValue, values[1]);
            Assert.AreEqual(thirdByteValue, values[2]);
        }
    }
}
