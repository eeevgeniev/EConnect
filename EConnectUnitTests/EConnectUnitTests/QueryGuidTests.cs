using EConnect;
using EConnectUnitTests.Mockups;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EConnectUnitTests
{
    [TestClass]
    public class QueryGuidTests
    {
        private const string CONNECTION_STRING = "connection";
        private const string QUERY = "query";

        [TestMethod]
        public void QueryReturnsGuidThrowsExceptionIfValueIsNotGuid()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notaguid", 2 }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => { List<Guid> values = connection.Query<Guid>(QUERY, null); });
        }

        [TestMethod]
        public void QueryAsyncReturnsGuidThrowsExceptionIfValueIsNotGuid()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notaguid", 2 }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => { List<Guid> values = await connection.QueryAsync<Guid>(QUERY, null); });
        }

        [TestMethod]
        public void QueryReturnsEmptyGuidListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<Guid> values = connection.Query<Guid>(QUERY, null);

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryAsyncReturnsEmptyGuidListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<Guid> values = connection.QueryAsync<Guid>(QUERY, null).Result;

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryReturnsGuid()
        {
            Guid firstGuidValue = Guid.NewGuid();
            Guid secondGuidValue = Guid.NewGuid();
            Guid thirdGuidValue = Guid.NewGuid();

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "guid", firstGuidValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "guid", secondGuidValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "guid", thirdGuidValue },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<Guid> values = connection.Query<Guid>(QUERY, null);

            Assert.AreEqual(3, values.Count);
            
            Assert.AreEqual(firstGuidValue, values[0]);
            Assert.AreEqual(secondGuidValue, values[1]);
            Assert.AreEqual(thirdGuidValue, values[2]);
        }

        [TestMethod]
        public void QueryAsyncReturnsGuid()
        {
            Guid firstGuidValue = Guid.NewGuid();
            Guid secondGuidValue = Guid.NewGuid();
            Guid thirdGuidValue = Guid.NewGuid();

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "guid", firstGuidValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "guid", secondGuidValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "guid", thirdGuidValue },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<Guid> values = connection.QueryAsync<Guid>(QUERY, null).Result;

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstGuidValue, values[0]);
            Assert.AreEqual(secondGuidValue, values[1]);
            Assert.AreEqual(thirdGuidValue, values[2]);
        }

        [TestMethod]
        public void QueryReturnsDefaultGuidWhenValueIsNull()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "guid", null },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<Guid> values = connection.Query<Guid>(QUERY, null);

            Assert.AreEqual(1, values.Count);

            Assert.AreEqual(default, values[0]);
        }

        [TestMethod]
        public void QueryAsyncReturnsDefaultGuidWhenValueIsNull()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "guid", null },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<Guid> values = connection.QueryAsync<Guid>(QUERY, null).Result;

            Assert.AreEqual(1, values.Count);

            Assert.AreEqual(default, values[0]);
        }

        [TestMethod]
        public void QueryReturnsNullableGuidThrowsExceptionIfValueIsNotNullableGuid()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notaguid", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => { List<Guid?> values = connection.Query<Guid?>(QUERY, null); });
        }

        [TestMethod]
        public void QueryAsyncReturnsNullableGuidThrowsExceptionIfValueIsNotNullableGuid()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notaguid", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => { List<Guid?> values = await connection.QueryAsync<Guid?>(QUERY, null); });
        }

        [TestMethod]
        public void QueryReturnsEmptyNullableGuidListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<Guid?> values = connection.Query<Guid?>(QUERY, null);

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryAsyncReturnsEmptyNullableGuidListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<Guid?> values = connection.QueryAsync<Guid?>(QUERY, null).Result;

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryReturnsNullableGuid()
        {
            Guid? firstGuidValue = Guid.NewGuid();
            Guid? secondGuidValue = Guid.NewGuid();
            Guid? thirdGuidValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "guid", firstGuidValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "guid", secondGuidValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "guid", thirdGuidValue },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<Guid?> values = connection.Query<Guid?>(QUERY, null);

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstGuidValue, values[0]);
            Assert.AreEqual(secondGuidValue, values[1]);
            Assert.AreEqual(thirdGuidValue, values[2]);
        }

        [TestMethod]
        public void QueryAsyncReturnsNullableGuid()
        {
            Guid? firstGuidValue = Guid.NewGuid();
            Guid? secondGuidValue = Guid.NewGuid();
            Guid? thirdGuidValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "guid", firstGuidValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "guid", secondGuidValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "guid", thirdGuidValue },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<Guid?> values = connection.QueryAsync<Guid?>(QUERY, null).Result;

            Assert.AreEqual(3, values.Count);

            Assert.AreEqual(firstGuidValue, values[0]);
            Assert.AreEqual(secondGuidValue, values[1]);
            Assert.AreEqual(thirdGuidValue, values[2]);
        }
    }
}
