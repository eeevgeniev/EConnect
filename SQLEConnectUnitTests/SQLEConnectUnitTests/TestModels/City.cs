using System.Collections.Generic;

namespace SQLEConnectUnitTests.TestModels;

public class City
{
    public string CityName { get; set; }

    public ICollection<Address> Addresses { get; set; }
}