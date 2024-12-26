using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQLEConnect;
using SQLEConnectUnitTests.Mockups;
using SQLEConnectUnitTests.TestModels;

namespace SQLEConnectUnitTests;

[TestClass]
public class QueryEntityAsyncTests
{
    private const string CONNECTION_STRING = "connection";
    private const string QUERY = "query";

    [TestMethod]
    public void QueryAsyncGetsCorrectlyEntities()
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

        List<Person> persons = connection.QueryAsync<Person>(
            null,
            QUERY,
            null,
            false,
            false).Result;

        Assert.AreEqual(2, persons.Count);
        Assert.AreEqual(firstId, persons[0].Id);
        Assert.AreEqual(secondId, persons[1].Id);
    }

    [TestMethod]
    public void QueryAsyncGetsCorrectlyEntitiesWithMultipleKeys()
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

        List<Person> persons = connection.QueryAsync<Person>(
            new EntityDescriptor<Person>().HasKey(p => p.Id).HasKey(p => p.Name),
            QUERY,
            null,
            false,
            false).Result;

        Assert.AreEqual(1, persons.Count);
        Assert.AreEqual(id, persons[0].Id);
    }

    [TestMethod]
    public void QueryAsyncGetsCorrectlyEntitiesWithMultipleKeysIfOneOfTheKeysIsNotCorrect()
    {
        const int id = 1;
        const string name = "Test1";
        const string secondName = "Test2";

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
                    { "name", secondName }
                }
            }
        });

        using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

        List<Person> persons = connection.QueryAsync<Person>(
            new EntityDescriptor<Person>().HasKey(p => p.Id).HasKey(p => p.Name),
            QUERY,
            null,
            false,
            false).Result;

        Assert.AreEqual(2, persons.Count);
        Assert.AreEqual(name, persons[0].Name);
        Assert.AreEqual(secondName, persons[1].Name);
    }

    [TestMethod]
    public void QueryAsyncGetsCorrectlyEntityWithChildEntity()
    {
        const string firstLine = "Address 1";
        const string secondLine = "Address 2";
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
                    { "Line", firstLine },
                    { "id", firstId },
                    { "name", firstName }
                },
                new Dictionary<string, object>()
                {
                    { "Line", secondLine },
                    { "id", secondId },
                    { "name", secondName }
                }
            }
        });

        using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

        List<Address> addresses = connection.QueryAsync<Address>(
            new EntityDescriptor<Address>()
                .HasMember(a => a.Person, new EntityDescriptor<Person>()),
            QUERY,
            null,
            false,
            false).Result;

        Assert.AreEqual(2, addresses.Count);
        Assert.AreEqual(firstLine, addresses[0].Line);
        Assert.AreEqual(secondLine, addresses[1].Line);
    }

    [TestMethod]
    public void QueryAsyncGetsCorrectlyEntityWithChildCollectionEntity()
    {
        const string city = "City 1";
        const int personFirstId = 1;
        const string firstLine = "Address 1";
        const string personFirstName = "Test1";
        const string secondLine = "Address 2";
        const int personSecondId = 2;
        const string personSecondName = "Test1";

        MockDbConnection.ClearResults();
        MockDbConnection.AddResults(new List<List<Dictionary<string, object>>>()
        {
            new List<Dictionary<string, object>>()
            {
                new Dictionary<string, object>()
                {
                    { "cityname", city },
                    { "Line", firstLine },
                    { "id", personFirstId },
                    { "name", personFirstName }
                },
                new Dictionary<string, object>()
                {
                    { "cityname", city },
                    { "Line", secondLine },
                    { "id", personSecondId },
                    { "name", personSecondName }
                }
            }
        });

        using Connection<MockDbConnection> connection = new Connection<MockDbConnection>(CONNECTION_STRING);

        List<City> cities = connection.QueryAsync<City>(
            new EntityDescriptor<City>()
                .HasKey(c => c.CityName)
                .HasMemberCollection(c => c.Addresses,
                    new EntityDescriptor<Address>()
                        .HasKey(c => c.Line)
                        .HasMember(a => a.Person, new EntityDescriptor<Person>().HasKey(p => p.Id))),
            QUERY,
            null,
            false,
            false).Result;

        Assert.AreEqual(1, cities.Count);
        Assert.AreEqual(city, cities[0].CityName);
    }
}