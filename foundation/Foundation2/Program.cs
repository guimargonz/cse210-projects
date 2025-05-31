// Program.cs
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- Online Ordering System ---");

        // Create products
        Product product1 = new Product("Laptop Pro 15", "LP15-001", 1200.50, 1);
        Product product2 = new Product("Wireless Mouse", "WM-002", 25.99, 2);
        Product product3 = new Product("Keyboard K200", "KB-200", 49.75, 1);
        Product product4 = new Product("USB-C Hub", "UCH-003", 39.99, 1);
        Product product5 = new Product("Monitor 27 inch", "MON27-004", 299.00, 1);

        // --- Order 1 ---
        Console.WriteLine("\n--- Order 1 ---");
        Address address1 = new Address("123 Main St", "Anytown", "CA", "USA");
        Customer customer1 = new Customer("John Doe", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product4);

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.CalculateTotalPrice():0.00}");

        // --- Order 2 ---
        Console.WriteLine("\n--- Order 2 ---");
        Address address2 = new Address("456 Oak Ave", "Otherville", "ON", "Canada");
        Customer customer2 = new Customer("Jane Smith", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product5);

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.CalculateTotalPrice():0.00}");
        
        // --- Order 3 (Optional, for variety) ---
        Console.WriteLine("\n--- Order 3 ---");
        Address address3 = new Address("789 Pine Rd", "Metropolis", "NY", "USA");
        Customer customer3 = new Customer("Peter Jones", address3);
        Order order3 = new Order(customer3);
        order3.AddProduct(product1); // Same laptop
        order3.AddProduct(product3); // Keyboard
        order3.AddProduct(product4); // Hub
        order3.AddProduct(product2); // Two mice (but added as a new product instance if you redefine it, or reuse product2)

        Console.WriteLine(order3.GetPackingLabel());
        Console.WriteLine(order3.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order3.CalculateTotalPrice():0.00}");


        Console.WriteLine("\nProgram finished. Press any key to exit if running in a standalone console.");
        // Console.ReadKey(); // Uncomment if need to pause the console
    }
}