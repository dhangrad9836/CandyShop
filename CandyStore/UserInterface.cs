using Spectre.Console;
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



