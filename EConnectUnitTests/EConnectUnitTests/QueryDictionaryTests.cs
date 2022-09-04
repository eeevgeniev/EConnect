using EConnect;
using EConnectUnitTests.Mockups;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace EConnectUnitTests
{
    [TestClass]
    public class QueryDictionaryTests
    {
        private const string CONNECTION_STRING = "connection";
        private const string QUERY = "query";

        [TestMethod]
        public void QueryReturnsDictionaryReturnsDefaultIfThereAreNoValues()
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
        public void QueryAsyncReturnsDictionaryReturnsDefaultIfThereAreNoValues()
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
        public void QueryReturnsListOfDictionaries()
        {
            string firstKey = "firstkey";
            string secondKey = "secondkey";

            int intFirstValue = 2;
            string stringFirstValue = "test";

            int intSecondValue = 3;
            string stringSecondValue = "another test";

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { firstKey, intFirstValue },
                        { secondKey, stringFirstValue }
                    },
                    new Dictionary<string, object>()
                    {
                        { firstKey, intSecondValue },
                        { secondKey, stringSecondValue }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<Dictionary<string, object>> values = connection.Query<Dictionary<string, object>>(QUERY, null);

            Assert.AreEqual(2, values.Count);

            Assert.IsTrue(values[0].ContainsKey(firstKey));
            Assert.IsTrue(values[0].ContainsKey(secondKey));

            Assert.AreEqual(intFirstValue, values[0][firstKey]);
            Assert.AreEqual(stringFirstValue, values[0][secondKey]);

            Assert.IsTrue(values[1].ContainsKey(firstKey));
            Assert.IsTrue(values[1].ContainsKey(secondKey));

            Assert.AreEqual(intSecondValue, values[1][firstKey]);
            Assert.AreEqual(stringSecondValue, values[1][secondKey]);
        }

        [TestMethod]
        public void QueryAsyncReturnsListOfDictionaries()
        {
            string firstKey = "firstkey";
            string secondKey = "secondkey";

            int intFirstValue = 2;
            string stringFirstValue = "test";

            int intSecondValue = 3;
            string stringSecondValue = "another test";

            MockDbConnection.ClearResults();
            MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
            {
                new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { firstKey, intFirstValue },
                        { secondKey, stringFirstValue }
                    },
                    new Dictionary<string, object>()
                    {
                        { firstKey, intSecondValue },
                        { secondKey, stringSecondValue }
                    }
                }
            });

            using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

            List<Dictionary<string, object>> values = connection.QueryAsync<Dictionary<string, object>>(QUERY, null).Result;

            Assert.AreEqual(2, values.Count);

            Assert.IsTrue(values[0].ContainsKey(firstKey));
            Assert.IsTrue(values[0].ContainsKey(secondKey));

            Assert.AreEqual(intFirstValue, values[0][firstKey]);
            Assert.AreEqual(stringFirstValue, values[0][secondKey]);

            Assert.IsTrue(values[1].ContainsKey(firstKey));
            Assert.IsTrue(values[1].ContainsKey(secondKey));

            Assert.AreEqual(intSecondValue, values[1][firstKey]);
            Assert.AreEqual(stringSecondValue, values[1][secondKey]);
        }
    }
}
