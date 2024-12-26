using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQLEConnect;
using SQLEConnectUnitTests.Mockups;
using SQLEConnectUnitTests.TestModels;

namespace SQLEConnectUnitTests;

[TestClass]
public class QuerySingleEntityTests
{
    private const string CONNECTION_STRING = "connection";
    private const string QUERY = "query";

    [TestMethod]
    public void QuerySingleGetsCorrectlyEntity()
    {
        const int firstId = 1;
        const int secondId = 2;
        const string firstName = "Test1";
        const string secondName = "Test2";

        MockDbConnection.ClearResults();
        MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
        {
            new List<Dictionary<string, object>>()
            {
                new Dictionary<string, object>()
                {
                    { "id", firstId },
                    { "name", firstName }
                },
                new Dictionary<string, object>()
                {
                    { "id", secondId },
                    { "name", secondName }
                }
            }
        });

        using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

        (bool hasResult, Person person) result = connection.QuerySingle<Person>(
            null,
            QUERY,
            null,
            false,
            false);
        
        Assert.IsTrue(result.hasResult);
        Assert.AreEqual(firstId, result.person.Id);
    }

    [TestMethod]
    public void QuerySingleGetsCorrectlyEntityWithMultipleKeys()
    {
        const int id = 1;
        const string name = "Test1";

        MockDbConnection.ClearResults();
        MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
        {
            new List<Dictionary<string, object>>()
            {
                new Dictionary<string, object>()
                {
                    { "id", id },
                    { "name", name }
                },
                new Dictionary<string, object>()
                {
                    { "id", id },
                    { "name", name }
                }
            }
        });

        using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

        (bool hasResult, Person person) result = connection.QuerySingle<Person>(
            new EntityDescriptor<Person>().HasKey(p => p.Id).HasKey(p => p.Name),
            QUERY,
            null,
            false,
            false);

        Assert.IsTrue(result.hasResult);
        Assert.AreEqual(id, result.person.Id);
    }

    [TestMethod]
    public void QuerySingleReturnsNothingIfThereAreNoEntities()
    {
        MockDbConnection.ClearResults();
        MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
        {
            new List<Dictionary<string, object>>()
        });

        using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

        (bool hasResult, Person person) result = connection.QuerySingle<Person>(
            new EntityDescriptor<Person>().HasKey(p => p.Id).HasKey(p => p.Name),
            QUERY,
            null,
            false,
            false);

        Assert.IsFalse(result.hasResult);
    }
}