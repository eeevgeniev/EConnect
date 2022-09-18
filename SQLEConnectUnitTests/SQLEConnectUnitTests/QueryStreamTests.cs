using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQLEConnect;
using SQLEConnectUnitTests.Mockups;
using System;
using System.Collections.Generic;
using System.IO;

namespace SQLEConnectUnitTests
{
    [TestClass]
    public class QueryStreamTests
    {
        private const string CONNECTION_STRING = "connection";
        private const string QUERY = "query";

        [TestMethod]
        public void QueryReturnsStreamThrowsExceptionIfValueIsNotStream()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notstream", "not a stream" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsException<Exception>(() => { List<Stream> values = connection.Query<Stream>(QUERY, null); });
        }

        [TestMethod]
        public void QueryAsyncReturnsStreamThrowsExceptionIfValueIsNotStream()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "notstream", "not a stream" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            Assert.ThrowsExceptionAsync<Exception>(async () => { List<Stream> values = await connection.QueryAsync<Stream>(QUERY, null); });
        }

        [TestMethod]
        public void QueryReturnsEmptyStreamListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<Stream> values = connection.Query<Stream>(QUERY, null);

            Assert.AreEqual(values.Count, 0);
        }

        [TestMethod]
        public void QueryAsyncReturnsEmptyStreamListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<Stream> values = connection.QueryAsync<Stream>(QUERY, null).Result;

            Assert.AreEqual(values.Count, 0);
        }

        [TestMethod]
        public void QueryReturnsStream()
        {
            byte[] firstStreamValues = { 1, 2, 3, 4 };
            MemoryStream firstStreamValue = new MemoryStream(firstStreamValues);

            byte[] secondStreamValues = { 4, 8, 16, 32 };
            MemoryStream secondStreamValue = new MemoryStream(secondStreamValues);

            MemoryStream thirdStreamValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "stream", firstStreamValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "stream", secondStreamValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "stream", thirdStreamValue },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<Stream> values = connection.Query<Stream>(QUERY, null);

            Assert.AreEqual(3, values.Count);

            MemoryStream resultStream = new MemoryStream();
            values[0].CopyTo(resultStream);

            byte[] results = resultStream.ToArray();

            Assert.AreEqual(firstStreamValues.Length, results.Length);

            for (int i = 0; i < firstStreamValues.Length; i++)
            {
                Assert.AreEqual(firstStreamValues[i], results[i]);
            }

            MemoryStream secondResultStream = new MemoryStream();

            values[1].CopyTo(secondResultStream);

            results = secondResultStream.ToArray();

            for (int i = 0; i < secondStreamValues.Length; i++)
            {
                Assert.AreEqual(secondStreamValues[i], results[i]);
            }

            Assert.AreEqual(thirdStreamValue, values[2]);
        }

        [TestMethod]
        public void QueryAsyncReturnsStream()
        {
            byte[] firstStreamValues = { 1, 2, 3, 4 };
            MemoryStream firstStreamValue = new MemoryStream(firstStreamValues);

            byte[] secondStreamValues = { 4, 8, 16, 32 };
            MemoryStream secondStreamValue = new MemoryStream(secondStreamValues);

            MemoryStream thirdStreamValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "stream", firstStreamValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "stream", secondStreamValue },
                        { "second column", "test" }
                    },
                    new Dictionary<string, object>()
                    {
                        { "stream", thirdStreamValue },
                        { "second column", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<Stream> values = connection.QueryAsync<Stream>(QUERY, null).Result;

            Assert.AreEqual(3, values.Count);

            MemoryStream firstResultStream = new MemoryStream();
            values[0].CopyTo(firstResultStream);

            byte[] results = firstResultStream.ToArray();

            Assert.AreEqual(firstStreamValues.Length, results.Length);

            for (int i = 0; i < firstStreamValues.Length; i++)
            {
                Assert.AreEqual(firstStreamValues[i], results[i]);
            }

            MemoryStream secondResultStream = new MemoryStream();

            values[1].CopyTo(secondResultStream);

            results = secondResultStream.ToArray();

            for (int i = 0; i < secondStreamValues.Length; i++)
            {
                Assert.AreEqual(secondStreamValues[i], results[i]);
            }

            Assert.AreEqual(thirdStreamValue, values[2]);
        }
    }
}
