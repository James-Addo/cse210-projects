public class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    public Address(string streetAddress, string cityName, string stateName, string countryName)
    {
        _street = streetAddress;
        _city = cityName;
        _state = stateName;
        _country = countryName;
    }

    public bool IsUSA()
    {
        return _country == "USA";
    }

    public string GetFullAddress()
    {
        return $"{_street}\n{_city}, {_state}\n{_country}";
    }
}