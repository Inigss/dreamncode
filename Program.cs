using System;
using System.Collections.Generic;

using System;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }

    class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }

    static List<Product> products = new List<Product>
    {
        new Product { Id = 1, Name = "Jacket", Price = 999.99 },
        new Product { Id = 2, Name = "T-Shirt", Price = 499.99 },
        new Product { Id = 3, Name = "Shorts", Price = 379.99 }
    };

    static List<CartItem> cart = new List<CartItem>();

    static void Main()
    {
        Console.WriteLine("Welcome to Dream n Code Clothing!");

        bool backToMainMenu = false;

        while (!backToMainMenu)
        {
            Console.WriteLine("1. View Products");
            Console.WriteLine("2. Add to Cart");
            Console.WriteLine("3. View Cart");
            Console.WriteLine("4. Checkout");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine(choice);

            switch (choice)
            {
                case 1:
                    ViewProducts();
                    break;
                case 2:
                    AddToCart();
                    break;
                case 3:
                    ViewCart();
                    break;
                case 4:
                    Checkout();
                    break;
                case 5:
                    Exit();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void ViewProducts()
    {
        bool backToMainMenu = false;
        while (!backToMainMenu)
        {
            Console.WriteLine("Products available:");
            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price:C}");
            }

            Console.WriteLine(" Press 0 to go back home page. ");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            if (choice == "0")
            {
                // If the user enters 0, break out of the loop and return to the main menu
                backToMainMenu = true;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }

    static void AddToCart()
    {
        bool backToMainMenu = false;

        while (!backToMainMenu)
        {
            Console.WriteLine("Choose a product to add to the cart (enter product ID): ");
            string input = Console.ReadLine();

            if (input == "0")
            {
                // If the user enters 0, set the variable to true to exit the loop
                backToMainMenu = true;
            }
            else if (int.TryParse(input, out int productId))
            {
                Product selectedProduct = products.Find(p => p.Id == productId);
                if (selectedProduct != null)
                {
                    Console.Write($"Enter the quantity for {selectedProduct.Name}: ");
                    int quantity;
                    if (int.TryParse(Console.ReadLine(), out quantity) && quantity > 0)
                    {
                        // Check if the product is already in the cart
                        CartItem existingItem = cart.Find(item => item.Product.Id == productId);

                        if (existingItem != null)
                        {
                            // If the product is already in the cart, update the quantity
                            existingItem.Quantity += quantity;
                        }
                        else
                        {
                            // If the product is not in the cart, add a new item
                            cart.Add(new CartItem { Product = selectedProduct, Quantity = quantity });
                        }

                        Console.WriteLine($"{quantity} {selectedProduct.Name}(s) added to the cart.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid quantity. Please enter a valid positive integer.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid product ID. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid product ID or press 0 to go back home.");
            }
        }
    }

    static void ViewCart()
{
    if (cart.Count > 0)
    {
        Console.WriteLine("Items in the cart:");
        foreach (var item in cart)
        {
            Console.WriteLine($"{item.Quantity} {item.Product.Name}(s) - {item.Product.Price:C} each");
        }
    }
    else
    {
        Console.WriteLine("Your cart is empty.");
    }

    Console.WriteLine("Press 0 to go back to the main menu.");
    string choice = Console.ReadLine();

    if (choice == "0")
    {
        // If the user enters 0, return to the main menu
        return;
    }
    else
    {
        Console.WriteLine("Invalid choice. Returning to the main menu.");
    }
}

    static void Checkout()
{
    if (cart.Count == 0)
    {
        Console.WriteLine("Your cart is empty. Unable to proceed with checkout.");
        return;
    }

    Console.WriteLine("Items in the cart:");
    foreach (var item in cart)
    {
        Console.WriteLine($"{item.Quantity} {item.Product.Name}(s) - {item.Product.Price:C} each");
    }

    // Calculate the total price
    double totalPrice = cart.Sum(item => item.Quantity * item.Product.Price);
    Console.WriteLine($"Total Price: {totalPrice:C}");

    // Add any additional checkout steps here

    // Clear the cart after checkout
    cart.Clear();

    Console.WriteLine("Checkout successful. Thank you for choosing Dream n Code Clothing!");
}
static void Exit()
{
    Console.WriteLine("Exiting the program. Thank you for choosing Dream n Code Clothing!");
    Environment.Exit(0);

}

    private string GetDebuggerDisplay()
    {
        return ToString();
    }

}