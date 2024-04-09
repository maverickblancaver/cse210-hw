using System;
using System.Collections.Generic;

public class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }

    public Address(string street, string city, string state, string country)
    {
        Street = street;
        City = city;
        State = state;
        Country = country;
    }

    public bool IsInUSA()
    {
        return Country.ToLower() == "usa";
    }

    public override string ToString()
    {
        return $"{Street}, {City}, {State}, {Country}";
    }
}

public class Product
{
    public string Name { get; set; }
    public int ProductId { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public decimal TotalCost => Price * Quantity;
}

public class Customer
{
    public string Name { get; set; }
    public Address Address { get; set; }

    public Customer(string name, Address address)
    {
        Name = name;
        Address = address;
    }

    public bool IsInUSA()
    {
        return Address.IsInUSA();
    }
}

public class Order
{
    public List<Product> Products { get; set; }
    public Customer Customer { get; set; }

    public Order(List<Product> products, Customer customer)
    {
        Products = products;
        Customer = customer;
    }

    public decimal CalculateTotalCost()
    {
        decimal totalCost = 0;
        foreach (var product in Products)
        {
            totalCost += product.TotalCost;
        }

        return totalCost + (Customer.IsInUSA() ? 5 : 35);
    }

    public string GetPackingLabel()
    {
        var label = "Packing Label:\n";
        foreach (var product in Products)
        {
            label += $"- {product.Name}, ID: {product.ProductId}\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{Customer.Name}\n{Customer.Address}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        var products = new List<Product>
        {
            new Product { Name = "Laptop", ProductId = 1, Price = 800, Quantity = 2 },
            new Product { Name = "Headphones", ProductId = 2, Price = 100, Quantity = 3 }
        };

        var customer = new Customer("John Doe", new Address("123 Main St", "Anytown", "CA", "USA"));

        var order = new Order(products, customer);

        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total Order Cost: {order.CalculateTotalCost():C}");
    }
}
