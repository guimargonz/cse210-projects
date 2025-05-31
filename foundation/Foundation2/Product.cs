// Product.cs
using System;

public class Product
{
    // Attributes
    private string _name;
    private string _productId;
    private double _pricePerUnit;
    private int _quantity;

    // Constructor
    public Product(string name, string productId, double pricePerUnit, int quantity)
    {
        _name = name;
        _productId = productId;
        _pricePerUnit = pricePerUnit;
        _quantity = quantity;
    }

    // Methods
    public double CalculateTotalCost()
    {
        return _pricePerUnit * _quantity;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetProductId()
    {
        return _productId;
    }

    // public double GetPricePerUnit() { return _pricePerUnit; } // Not strictly needed by Order for labels/totals
    // public int GetQuantity() { return _quantity; } // Not strictly needed by Order for labels/totals
}