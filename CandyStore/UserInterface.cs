﻿using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CandyStore.Enums;

namespace CandyStore
{
    internal static class UserInterface
    {
        internal const string divide = "-------------------------------------";

        internal static void RunMainMenu()
        {
            //create an instance of the ProductController to access the methods
            var productsController = new ProductController();
            var isMenuRunning = true;


            while (isMenuRunning)
            {
                PrintHeader();

                var usersChoice = AnsiConsole.Prompt(
                    new SelectionPrompt<MainMenuOptions>()
                    .Title("What would like to do?")
                    .AddChoices(
                        MainMenuOptions.ViewProducts,
                        MainMenuOptions.ViewSingleProduct,
                        MainMenuOptions.AddProduct,
                        MainMenuOptions.UpdateProduct,
                        MainMenuOptions.DeleteProduct,
                        MainMenuOptions.QuitProgram)
                    );
                var menuMessage = "Press Any Key To Go Back to Menu";

                switch (usersChoice)
                {
                    case MainMenuOptions.AddProduct:
                        //trigger the GetProductInput() and pass the product Type and its data to the AddProduct() below
                        var product = GetProductInput();
                        productsController.AddProduct(product);
                        break;
                    case MainMenuOptions.DeleteProduct:
                        productsController.DeleteProduct("User chose D");
                        break;
                    case MainMenuOptions.ViewProducts:
                        var products = productsController.GetProducts();
                        ViewProduct(products);
                        break;
                    case MainMenuOptions.ViewSingleProduct:
                        var productChoice = GetProductsChoice();    //GetProductsChoice is returning a type Product in productChoice variable
                        ViewSingleProductChoice(productChoice);     //pass the productChoice to ViewSingleProductChoice(productChoice)
                        break;
                    case MainMenuOptions.UpdateProduct:
                        productsController.UpdateProduct("User chose U");
                        break;
                    case MainMenuOptions.QuitProgram:
                        menuMessage = "Goodbye"; //will be displayed at bottom of program
                        //productsController.SaveProducts(); //will save the file to the history txt file
                        isMenuRunning = false; //menu will stop running if user selects Q
                        break;
                    default:
                        Console.WriteLine("Invalid choice, Please choose one of the above");
                        break;
                } // end switch statement

                Console.WriteLine(menuMessage); //prints either for the user to go back or when user quits program
                Console.ReadLine();
                Console.Clear();

            } // end while loop
        }

        // takes in a type Product productChoice
        private static void ViewSingleProductChoice(Product productChoice)
        {
            //create an ansiconsole heading after GetProductForPanel() is executed
            var panel = new Panel(productChoice.GetProductForPanel());
            panel.Header = new PanelHeader("Product Info");
            panel.Padding = new Padding(2, 2, 2, 2);

            AnsiConsole.Write(panel);

            Console.WriteLine("Press Any Key to Return to Menu");
            Console.ReadLine();
            Console.Clear();
        }

        
        //Note that signature is changed to type Product as we are returning a Product
        private static Product GetProductsChoice()
        {
            var productsControlelr = new ProductController();
            var products = productsControlelr.GetProducts(); //return a list of products
            var productsArray = products.Select(x => x.Name).ToArray(); //store names in an array of strings
            var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Choose Product")
                .AddChoices(productsArray)); //in the .AddChoice prompt box will display a list of Product names using the .AddChoices

            var product = products.Single(x => x.Name == option);   //we are using a .Single LINQ method where x.Name == option (products list equals the users selection)

            return product;
        }

        internal static void ViewProduct(List<Product> products)
        {
            Console.WriteLine(divide);
            foreach (var product in products)
            {
                //return all the properties of Product
                Console.WriteLine(product.GetProductForCsv(product.Id));
            }
            Console.WriteLine(divide);
        }

        internal static void PrintHeader()
        {
            string title = "The Candy Shop";
            string divide = "-------------------------------------";
            DateTime datetime = DateTime.Now;
            int daysSinceOpening = Helpers.GetDaysSinceOpening();
            decimal todaysProfit = 5.5m;
            bool targetAchieved = false;
           // string menu = GetMenu();

            Console.WriteLine($@"{title}
{divide}
Today's date: {datetime}
Days since opening: {daysSinceOpening}
Today's profit: {todaysProfit}
Today's target achieved {targetAchieved}
{divide}");
        }

        // method to Get the product information from the user, we moved the user input from the UserInterFace class in the AddProduct() and moved it here
        private static Product GetProductInput()
        {
            // get a product name
            Console.WriteLine("Product name:");
            var name = Console.ReadLine();

            // get a product price
            Console.WriteLine("Product price:");
            var price = decimal.Parse(Console.ReadLine());

            //this will prompt the user to select either a lolipop or chocolate bar
            var type = AnsiConsole.Prompt(
                new SelectionPrompt<ProductType>()
                .Title("Product Type: ")
                .AddChoices(
                    ProductType.Lolipop,
                    ProductType.ChcolateBar)
                );

            //check if it a chocolate bar or lolipop and return that product, Lolipop or chocolatebar
            if(type == ProductType.ChcolateBar)
            {
                //Get the percentage of coca from the user
                Console.WriteLine("Cocoa %");
                var coca = int.Parse(Console.ReadLine());

                //return a ChocolateBar object
                return new ChocolateBar()
                {
                    Name = name,
                    Price = price,
                    CocoaPercentage = coca
                };
            }

            //Get the percentage of coca from the user
            Console.WriteLine("Shape: ");
            var shape = Console.ReadLine();

            //return a Lolipop object
            return new Lolipop
            {
                Name = name,
                Price = price,
                Shape = shape
            };
        } //end GetProductInput


    } // end UserInterface
}   // end CandyStore



