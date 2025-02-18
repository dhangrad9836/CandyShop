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
                        productsController.AddProduct();
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
                Console.WriteLine($"{product.Id}, {product.Name}, {product.Price}");
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

        // display menu
        //private static string GetMenu()
        //{
        //    return "Choose one option:\n"
        //   + 'V' + " to view products\n"
        //   + 'A' + " to Add products:\n"
        //   + 'D' + " to Delete products:\n"
        //   + 'U' + " to Update products:\n"
        //   + 'Q' + " to quit the program:\n";
        //}
    } // end UserInterface
}
