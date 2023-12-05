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
        Console.WriteLine("Welcome to Luis Clothing Shop!");

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
                    Console.WriteLine("Invalid choice. Please Enter between 1-5 only.");
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
                Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {string.Format("{0:C}", product.Price)}");
            }

            Console.WriteLine(" Press 0 to go back home page. ");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            if (choice == "0")
            {
                backToMainMenu = true;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter between 1 to 5 only.");
            }
        }
    }
    static void AddToCart()
    {
        bool backToMainMenu = false;

        while (!backToMainMenu)
        {
            Console.WriteLine(" Press 0 to go back home page. ");
            Console.WriteLine("Choose a product to add to the cart (enter product ID): ");
            string input = Console.ReadLine();

            if (input == "0")
            {
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
                        
                        CartItem existingItem = cart.Find(item => item.Product.Id == productId);

                        if (existingItem != null)
                        {
                            
                            existingItem.Quantity += quantity;
                        }
                        else
                        {
                            
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

    Console.WriteLine("Press 0 to go back home page.");
    string choice = Console.ReadLine();

    if (choice == "0")
    {
        
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
    Console.WriteLine(" Press 0 to go back home page. ");
    Console.WriteLine("Items in the cart:");
    foreach (var item in cart)
    {
        Console.WriteLine($"{item.Quantity} {item.Product.Name}(s) - {item.Product.Price:C} each");
    }

    
    double totalPrice = cart.Sum(item => item.Quantity * item.Product.Price);
    Console.WriteLine($"Total Price: {totalPrice:C}");

    cart.Clear();

    Console.WriteLine("Checkout successful. Thank you for choosing Luis Clothing Shop!");
}
static void Exit()
{
    Console.WriteLine("Exiting the program. Thank you for choosing Luis Clothing Shop!");
    Environment.Exit(0);

}

    private string GetDebuggerDisplay()
    {
        return ToString();
    }

}