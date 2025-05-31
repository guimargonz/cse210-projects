// Order.cs
using System;
using System.Collections.Generic;
using System.Text; // For StringBuilder

public class Order
{
    // Attributes
    private List<Product> _products;
    private Customer _customer;

    // Constructor
    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    // Methods
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    private double CalculateShippingCost()
    {
        if (_customer.LivesInUSA())
        {
            return 5.00;
        }
        else
        {
            return 35.00;
        }
    }

    private double CalculateSubtotal()
    {
        double subtotal = 0;
        foreach (Product product in _products)
        {
            subtotal += product.CalculateTotalCost();
        }
        return subtotal;
    }

    public double CalculateTotalPrice()
    {
        return CalculateSubtotal() + CalculateShippingCost();
    }

    public string GetPackingLabel()
    {
        StringBuilder label = new StringBuilder();
        label.AppendLine("--- Packing Label ---");
        foreach (Product product in _products)
        {
            label.AppendLine($"Product: {product.GetName()} (ID: {product.GetProductId()})");
        }
        return label.ToString();
    }

    public string GetShippingLabel()
    {
        StringBuilder label = new StringBuilder();
        label.AppendLine("--- Shipping Label ---");
        label.AppendLine($"Customer: {_customer.GetName()}");
        label.AppendLine(_customer.GetAddress().GetFullAddressString()); // Uses Address's method
        return label.ToString();
    }

    // public List<Product> GetProducts() { return _products; } // Getter if needed
    // public Customer GetCustomer() { return _customer; } // Getter if needed
}