using CandyStore;
using System.Linq;

DataSeed.SeedData();



//LINQ practice
//var productName = products.Select(product => product.Price).ToList();
//var productName = products.Where(product => product.Price < 2).ToList();
//var productName = products.Where(product => product.Name.Contains("MI")).ToList();
//var productName = products.OrderBy(product => product.Name).ToList();
//var productName = products
//    .Where(x => x.Price < 2 )   //select prices that are less than 2
//    .OrderBy(x => x.Name)       //OrderBy Name
//    .Select(x => x.Name)        // Select only names
//    .ToList();                  //Put in a list with .ToList()

//foreach ( var price in productName)
//{
//    Console.WriteLine(price);
//}


UserInterface.RunMainMenu();


//var chcolateBar = new ChocolateBar(1);
//chcolateBar.

Console.ReadLine();

