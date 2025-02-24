using CandyStore;
using System.Linq;

List<Product> products = new List<Product>
            {
                // 5 ChocolateBar objects
                new ChocolateBar(1) { Name = "Dark Delight", Price = 2.99m, CocoaPercentage = 85 },
                new ChocolateBar(2) { Name = "Milk Marvel", Price = 2.49m, CocoaPercentage = 50 },
                new ChocolateBar(3) { Name = "White Wonder", Price = 2.79m, CocoaPercentage = 30 },
                new ChocolateBar(4) { Name = "Hazelnut Heaven", Price = 3.29m, CocoaPercentage = 70 },
                new ChocolateBar(5) { Name = "Caramel Crunch", Price = 3.49m, CocoaPercentage = 60 },

                // 5 Lollipop objects
                new Lolipop(6) { Name = "Cherry Swirl", Price = 1.49m, Shape = "Round" },
                new Lolipop(7) { Name = "Blueberry Blast", Price = 1.59m, Shape = "Star" },
                new Lolipop(8) { Name = "Grape Twirl", Price = 1.39m, Shape = "Spiral" },
                new Lolipop(9) { Name = "Lemon Pop", Price = 1.69m, Shape = "Heart" },
                new Lolipop(10) { Name = "Strawberry Twist", Price = 1.79m, Shape = "Oval" }
            };

//LINQ practice
//var productName = products.Select(product => product.Price).ToList();
//var productName = products.Where(product => product.Price < 2).ToList();
//var productName = products.Where(product => product.Name.Contains("MI")).ToList();
//var productName = products.OrderBy(product => product.Name).ToList();
var productName = products
    .Where(x => x.Price < 2 )   //select prices that are less than 2
    .OrderBy(x => x.Name)       //OrderBy Name
    .Select(x => x.Name)        // Select only names
    .ToList();                  //Put in a list with .ToList()

foreach ( var price in productName)
{
    Console.WriteLine(price);
}


//UserInterface.RunMainMenu();


//var chcolateBar = new ChocolateBar(1);
//chcolateBar.

Console.ReadLine();

