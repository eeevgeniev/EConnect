using EConnect;
using EConnectUnitTests.Mockups;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace EConnectUnitTests
{
    [TestClass]
    public class SingleDictionaryTests
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

            (bool hasResult, Dictionary<string, object> value) value = connection.Single<Dictionary<string, object>>(QUERY, null);

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

            (bool hasResult, Dictionary<string, object> value) value = connection.SingleAsync<Dictionary<string, object>>(QUERY, null).Result;

            Assert.IsFalse(value.hasResult);
            Assert.IsNull(value.value);
        }

        [TestMethod]
        public void SingleReturnsDictionary()
        {
            string firstKey = "firstkey";
            string secondKey = "secondkey";
            
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

            (bool hasResult, Dictionary<string, object> value) value = connection.Single<Dictionary<string, object>>(QUERY, null);

            Assert.IsTrue(value.hasResult);

            Assert.IsTrue(value.value.ContainsKey(firstKey));

            Assert.AreEqual(intValue, value.value[firstKey]);

            Assert.IsTrue(value.value.ContainsKey(secondKey));

            Assert.AreEqual(stringValue, value.value[secondKey]);
        }

        [TestMethod]
        public void SingleAsyncReturnsInt()
        {
            string firstKey = "firstkey";
            string secondKey = "secondkey";

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

            (bool hasResult, Dictionary<string, object> value) value = connection.SingleAsync<Dictionary<string, object>>(QUERY, null).Result;

            Assert.IsTrue(value.hasResult);

            Assert.IsTrue(value.value.ContainsKey(firstKey));

            Assert.AreEqual(intValue, value.value[firstKey]);

            Assert.IsTrue(value.value.ContainsKey(secondKey));

            Assert.AreEqual(stringValue, value.value[secondKey]);
        }
    }
}
