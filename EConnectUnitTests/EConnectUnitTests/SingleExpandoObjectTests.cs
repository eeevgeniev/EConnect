using EConnect;
using EConnectUnitTests.Mockups;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace EConnectUnitTests
{
    [TestClass]
    public class SingleExpandoObjectTests
    {
        private const string CONNECTION_STRING = "connection";
        private const string QUERY = "query";

        [TestMethod]
        public void SingleReturnsDictionaryReturnsDefaultIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, dynamic value) value = connection.Single<dynamic>(QUERY, null);

            Assert.IsFalse(value.hasResult);
            Assert.IsNull(value.value);
        }

        [TestMethod]
        public void SingleAsyncReturnsDictionaryReturnsDefaultIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, dynamic value) value = connection.SingleAsync<dynamic>(QUERY, null).Result;

            Assert.IsFalse(value.hasResult);
            Assert.IsNull(value.value);
        }

        [TestMethod]
        public void SingleReturnsDictionary()
        {
            string firstKey = "firstKey";
            string secondKey = "secondKey";

            int intValue = 2;
            string stringValue = "test";

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { firstKey, intValue },
                        { secondKey, stringValue }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, dynamic value) value = connection.Single<dynamic>(QUERY, null);

            Assert.IsTrue(value.hasResult);

            Assert.AreEqual(intValue, value.value.firstKey);

            Assert.AreEqual(stringValue, value.value.secondKey);
        }

        [TestMethod]
        public void SingleAsyncReturnsInt()
        {
            string firstKey = "firstKey";
            string secondKey = "secondKey";

            int intValue = 2;
            string stringValue = "test";

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { firstKey, intValue },
                        { secondKey, stringValue }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            (bool hasResult, dynamic value) value = connection.SingleAsync<dynamic>(QUERY, null).Result;

            Assert.IsTrue(value.hasResult);

            Assert.AreEqual(intValue, value.value.firstKey);

            Assert.AreEqual(stringValue, value.value.secondKey);
        }
    }
}
