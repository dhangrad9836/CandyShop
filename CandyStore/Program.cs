using CandyStore;

//create some Product objects

Product product = new Product("Cherry Cake");
Product product2 = new Product("Caramel Donut");
Product product3 = new Product("Gummy Bear");

//print out the Product objects
Console.WriteLine($"{product.Name}, {product2.Name}, {product3.Name}");






//SeedData();

//check if the file exists and if yes then read in the data
//if (File.Exists(Configuration.docPath))
//{
//    //call the method
//    LoadData();
//}

//LoadData();


// method that will process the seed data from the candyNames array and store it inside products list



int GetDaysSinceOpening()
{
    var openingDate = new DateTime(2023, 1, 1);
    TimeSpan timeDifference = DateTime.Now - openingDate;

    return timeDifference.Days;
}




Console.ReadLine();

