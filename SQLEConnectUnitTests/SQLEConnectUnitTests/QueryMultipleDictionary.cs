using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQLEConnect;
using SQLEConnectUnitTests.Mockups;
using System.Collections.Generic;

namespace SQLEConnectUnitTests
{
    [TestClass]
    public class QueryMultipleDictionary
    {
        private const string CONNECTION_STRING = "connection";
        private const string QUERY = "query";

        [TestMethod]
        public void QueryReturnsEmptyDictionaryListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<Dictionary<string, object>> values = connection.Query<Dictionary<string, object>>(QUERY, null);

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryAsyncReturnsEmptyDictionaryListIfThereAreNoValues()
        {
            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<Dictionary<string, object>> values = connection.QueryAsync<Dictionary<string, object>>(QUERY, null).Result;

            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void QueryReturnsDictionary()
        {
            string columnKey = "int";

            int firstIntValue = 2;
            int secondIntValue = 21;
            int thirdIntValue = 34;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { columnKey, firstIntValue }
                    },
                    new Dictionary<string, object>()
                    {
                        { columnKey, secondIntValue }
                    },
                    new Dictionary<string, object>()
                    {
                        { columnKey, thirdIntValue }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<Dictionary<string, object>> values = connection.Query<Dictionary<string, object>>(QUERY, null);

            Assert.AreEqual(3, values.Count);

            Assert.IsTrue(values[0].ContainsKey(columnKey));
            Assert.AreEqual(firstIntValue, values[0][columnKey]);

            Assert.IsTrue(values[1].ContainsKey(columnKey));
            Assert.AreEqual(secondIntValue, values[1][columnKey]);

            Assert.IsTrue(values[2].ContainsKey(columnKey));
            Assert.AreEqual(thirdIntValue, values[2][columnKey]);
        }

        [TestMethod]
        public void QueryAsyncReturnsInt()
        {
            string columnKey = "int";

            int firstIntValue = 2;
            int secondIntValue = 21;
            int thirdIntValue = 34;

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { columnKey, firstIntValue }
                    },
                    new Dictionary<string, object>()
                    {
                        { columnKey, secondIntValue }
                    },
                    new Dictionary<string, object>()
                    {
                        { columnKey, thirdIntValue }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<Dictionary<string, object>> values = connection.QueryAsync<Dictionary<string, object>>(QUERY, null).Result;

            Assert.AreEqual(3, values.Count);

            Assert.IsTrue(values[0].ContainsKey(columnKey));
            Assert.AreEqual(firstIntValue, values[0][columnKey]);

            Assert.IsTrue(values[1].ContainsKey(columnKey));
            Assert.AreEqual(secondIntValue, values[1][columnKey]);

            Assert.IsTrue(values[2].ContainsKey(columnKey));
            Assert.AreEqual(thirdIntValue, values[2][columnKey]);
        }
    }
}
