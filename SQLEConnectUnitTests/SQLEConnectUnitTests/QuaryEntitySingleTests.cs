using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQLEConnect;
using SQLEConnectUnitTests.Mockups;
using System.Collections.Generic;

namespace SQLEConnectUnitTests
{
	[TestClass]
	public class QuaryEntitySingleTests
	{
		private const string CONNECTION_STRING = "connection";
		private const string QUERY = "query";

		public class Person
		{
			public int Id { get; set; }

			public string Name { get; set; }
		}

		public class Address
		{
			public string Line { get; set; }

			public Person Person { get; set; }
		}

		public class City
		{
			public string CityName { get; set; }

			public ICollection<Address> Addresses { get; set; }
		}

		[TestMethod]
		public void QueryEntityPopulatesCorrectlyEntities()
		{
			int firstId = 1;
			int secondId = 2;
			string firstName = "Test1";
			string secondName = "Test2";
			
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

			List<Person> persons = connection.QueryEntities<Person>(
				null, 
				QUERY, 
				null, 
				false, 
				false);

			Assert.AreEqual(2, persons.Count);
		}

		[TestMethod]
		public void QueryEntityPopulatesCorrectlyEntityWithChildEndity()
		{
			string firstLine = "Address 1";
			string secondLine = "Address 2";
			int firstId = 1;
			int secondId = 2;
			string firstName = "Test1";
			string secondName = "Test2";

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

			List<Address> addresses = connection.QueryEntities<Address>(
				new EntityDescriptor<Address>()
					.HasMember(a => a.Person, new EntityDescriptor<Person>()), 
				QUERY, 
				null, 
				false, 
				false);

			Assert.AreEqual(2, addresses.Count);
		}

		[TestMethod]
		public void QueryEntityPopulatesCorrectlyEntityWithChildCollectionEndity()
		{
			string city = "City 1";
			int personFirstId = 1;
			string firstLine = "Address 1";
			string personFirstName = "Test1";
			string secondLine = "Address 2";
			int personSecondId = 1;
			string personSecondName = "Test1";

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


			List<City> cities = connection.QueryEntities<City>(
				new EntityDescriptor<City>((x, y) => string.Equals(x.CityName, y.CityName, System.StringComparison.OrdinalIgnoreCase))
					.HasMemberCollection(c => c.Addresses, 
						new EntityDescriptor<Address>((x, y) => string.Equals(x.Line, y.Line, System.StringComparison.OrdinalIgnoreCase))
							.HasMember(a => a.Person, new EntityDescriptor<Person>((x, y) => x.Id == y.Id ))), 
				QUERY, 
				null, 
				false, 
				false);

			Assert.AreEqual(1, cities.Count);
		}
	}
}
