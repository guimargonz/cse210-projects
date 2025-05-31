// Customer.cs
using System;

public class Customer
{
    // Attributes
    private string _name;
    private Address _address; // Address class object

    // Constructor
    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    // Methods
    public bool LivesInUSA()
    {
        return _address.IsInUSA(); // Delegates to the Address class
    }

    public string GetName()
    {
        return _name;
    }

    public Address GetAddress() // Returns the Address object
    {
        return _address;
    }
}