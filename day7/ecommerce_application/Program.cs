using System;
using System.Collections.Generic;

class Product
{
    private string name;
    private double price;
    private int quantity;

    // Property for Name
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    // Property for Price
    public double Price
    {
        get { return price; }
        set
        {
            if (value >= 0)
                price = value;
            else
                Console.WriteLine("Price cannot be negative.");
        }
    }

    // Property for Quantity
    public int Quantity
    {
        get { return quantity; }
        set
        {
            if (value >= 0)
                quantity = value;
            else
                Console.WriteLine("Quantity cannot be negative.");
        }
    }

    // Constructor
    public Product(string name, double price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    // Display Method
    public void Display()
    {
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("Price: " + Price);
        Console.WriteLine("Quantity: " + Quantity);
        Console.WriteLine();
    }
}

class ProductCollection
{
    private List<Product> products = new List<Product>();

    // Add Product Method
    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    // Indexer
    public Product this[int index]
    {
        get
        {
            if (index >= 0 && index < products.Count)
                return products[index];
            else
                return null;
        }
        set
        {
            if (index >= 0 && index < products.Count)
                products[index] = value;
            else
                Console.WriteLine("Invalid index.");
        }
    }
}

class Program
{
    static void Main()
    {
        ProductCollection inventory = new ProductCollection();

        // Adding products
        inventory.AddProduct(new Product("Laptop", 90000, 10));
        inventory.AddProduct(new Product("Mobile", 20000, 15));
        inventory.AddProduct(new Product("Headphones", 2000, 25));

        Console.WriteLine("Accessing products using indexer:\n");

        // Access using indexer
        inventory[0].Display();
        inventory[1].Display();

        Console.WriteLine("Modifying product using indexer:\n");

        // Modify using indexer
        inventory[1] = new Product("TV", 125000, 20);

        inventory[1].Display();

        Console.WriteLine("Testing validation:\n");

        // Negative value test
        inventory[2].Price = -100;
        inventory[2].Quantity = -5;

        inventory[2].Display();
    }
}