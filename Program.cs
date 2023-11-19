using System;
using System.Collections.Generic;

class Program
{
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }

    static List<Product> products = new List<Product>
    {
        new Product { Id = 1, Name = "Jacket", Price = 999.99 },
        new Product { Id = 2, Name = "T-Shirt", Price = 499.99 },
        new Product { Id = 3, Name = "Shorts", Price = 379.99 }
    };

    static void Main()
    {
        Console.WriteLine("Welcome to Dream n Code Clothing!");

        while (true)
        {
            Console.WriteLine("\n1. View Products");
            Console.WriteLine("2. Add to Cart");
            Console.WriteLine("3. View Cart");
            Console.WriteLine("4. Checkout");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice.ToLower())
            {
                case "one":
                    ViewProducts();
                    break;
                case "2":
                    AddToCart();
                    break;
                case "3":
                    ViewCart();
                    break;
                case "4":
                    Checkout();
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void ViewProducts()
    {
        Console.WriteLine("Products available:");
        foreach (var product in products)
        {
            Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price:C}");
        }
    }

    static void AddToCart()
    {
        Console.WriteLine("Choose a product to add to the cart (enter product ID): ");
        int productId;
        if (int.TryParse(Console.ReadLine(), out productId))
        {
            Product selectedProduct = products.Find(p => p.Id == productId);
            if (selectedProduct != null)
            {
                // Implement your cart logic here
                Console.WriteLine($"{selectedProduct.Name} added to the cart.");
            }
            else
            {
                Console.WriteLine("Invalid product ID. Please try again.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid product ID.");
        }
    }

    static void ViewCart()
    {
        // Add your implementation here
        Console.WriteLine("View Cart functionality is not implemented yet.");
    }

    static void Checkout()
    {
        // Add your implementation here
        Console.WriteLine("Checkout functionality is not implemented yet.");
    }
}
