using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQLEConnect;
using SQLEConnectUnitTests.Mockups;
using System;
using System.Collections.Generic;
using System.IO;

namespace SQLEConnectUnitTests
{
    [TestClass]
    public class SingleStreamTests
    {
        private const string CONNECTION_STRING = "connection";
        private const string QUERY = "query";

        [TestMethod]
        public void SingleReturnsStreamThrowsExceptionIfValueIsNotStream()
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

            Assert.ThrowsException<Exception>(() => { (bool hasResult, Stream value) value = connection.Single<Stream>(QUERY, null); });
        }

        [TestMethod]
        public void SingleAsyncReturnsStreamThrowsExceptionIfValueIsNotStream()
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

            Assert.ThrowsExceptionAsync<Exception>(async () => { (bool hasResult, Stream value) value = await connection.SingleAsync<Stream>(QUERY, null); });
        }

        [TestMethod]
        public void SingleReturnsStreamReturnsDefaultIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, Stream value) value = connection.Single<Stream>(QUERY, null);

            Assert.IsFalse(value.hasResult);
        }

        [TestMethod]
        public void SingleAsyncReturnsStreamReturnsDefaultIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, Stream value) value = connection.SingleAsync<Stream>(QUERY, null).Result;

            Assert.IsFalse(value.hasResult);
        }

        [TestMethod]
        public void SingleReturnsStream()
        {
            byte[] initialValues = { 1, 2, 3, 4 };
            MemoryStream streamValue = new MemoryStream(initialValues);

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "stream", streamValue }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, Stream value) value = connection.Single<Stream>(QUERY, null);

            Assert.IsTrue(value.hasResult);

            MemoryStream resultStream = new MemoryStream();
            value.value.CopyTo(resultStream);

            byte[] results = resultStream.ToArray();

            Assert.AreEqual(initialValues.Length, results.Length);

            for (int i = 0; i < initialValues.Length; i++)
            {
                Assert.AreEqual(initialValues[i], results[i]);
            }
        }

        [TestMethod]
        public void SingleAsyncReturnsStream()
        {
            byte[] initialValues = { 1, 2, 3, 4 };
            MemoryStream streamValue = new MemoryStream(initialValues);

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "stream", streamValue }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, Stream value) value = connection.SingleAsync<Stream>(QUERY, null).Result;

            Assert.IsTrue(value.hasResult);

            MemoryStream resultStream = new MemoryStream();
            value.value.CopyTo(resultStream);

            byte[] results = resultStream.ToArray();

            Assert.AreEqual(initialValues.Length, results.Length);

            for (int i = 0; i < initialValues.Length; i++)
            {
                Assert.AreEqual(initialValues[i], results[i]);
            }
        }

        [TestMethod]
        public void SingleReturnsStreamMoreThanOneColumn()
        {
            byte[] initialValues = { 1, 2, 3, 4 };
            MemoryStream streamValue = new MemoryStream(initialValues);

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "stream", streamValue },
                        { "name", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, Stream value) value = connection.Single<Stream>(QUERY, null);

            Assert.IsTrue(value.hasResult);

            MemoryStream resultStream = new MemoryStream();
            value.value.CopyTo(resultStream);

            byte[] results = resultStream.ToArray();

            Assert.AreEqual(initialValues.Length, results.Length);

            for (int i = 0; i < initialValues.Length; i++)
            {
                Assert.AreEqual(initialValues[i], results[i]);
            }
        }

        [TestMethod]
        public void SingleAsyncReturnsStreamMoreThanOneColumn()
        {
            byte[] initialValues = { 1, 2, 3, 4 };
            MemoryStream streamValue = new MemoryStream(initialValues);

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "Stream", streamValue },
                        { "name", "test" }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, Stream value) value = connection.SingleAsync<Stream>(QUERY, null).Result;

            Assert.IsTrue(value.hasResult);

            MemoryStream resultStream = new MemoryStream();
            value.value.CopyTo(resultStream);

            byte[] results = resultStream.ToArray();

            Assert.AreEqual(initialValues.Length, results.Length);

            for (int i = 0; i < initialValues.Length; i++)
            {
                Assert.AreEqual(initialValues[i], results[i]);
            }
        }

        [TestMethod]
        public void SingleReturnsNullForStreamWhenValueIsNull()
        {
            Stream StreamValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "Stream", StreamValue }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, Stream value) value = connection.Single<Stream>(QUERY, null);

            Assert.IsTrue(value.hasResult);
            Assert.IsNull(value.value);
        }

        [TestMethod]
        public void SingleAsyncReturnsNullForStreamWhenValueIsNull()
        {
            Stream StreamValue = null;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "Stream", StreamValue }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, Stream value) value = connection.SingleAsync<Stream>(QUERY, null).Result;

            Assert.IsTrue(value.hasResult);
            Assert.IsNull(value.value);
        }
    }
}
