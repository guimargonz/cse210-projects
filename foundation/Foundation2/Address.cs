// Address.cs
using System;

public class Address
{
    // Attributes
    private string _streetAddress;
    private string _city;
    private string _stateProvince;
    private string _country;

    // Constructor
    public Address(string streetAddress, string city, string stateProvince, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _stateProvince = stateProvince;
        _country = country;
    }

    // Methods
    public bool IsInUSA()
    {
        // Case-insensitive check for USA
        return _country.Equals("USA", StringComparison.OrdinalIgnoreCase) ||
               _country.Equals("United States", StringComparison.OrdinalIgnoreCase) ||
               _country.Equals("United States of America", StringComparison.OrdinalIgnoreCase);
    }

    public string GetFullAddressString()
    {
        return $"{_streetAddress}\n{_city}, {_stateProvince}\n{_country}";
    }
}