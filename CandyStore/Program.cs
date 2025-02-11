// docPath to save history of document in a text file
string docPath = @"C:\Users\dhang\Desktop\c_repos\CandyStore\CandyStore\history.txt";

//seed data will be processed to alist
string[] candyNames = { "Rainbow Lollipop", "Cotton Candy Clouds", "Choco-Caramel", "Gummy Bear Bonanza", "Minty Chocolate Truffles", "Jellybean Jamboree", "Fruity Taffy Twists", "Sour Patch Surprise", "Crispy Peanut Butter Cups", "Rocky Candy Crystals" };
// list to store seeded data
var products = new List<string>();
//call method to process seed data and store it inside the products list
SeedData();

var divide = "-------------------------------------";

var isMenuRunning = true;


while (isMenuRunning)
{
    PrintHeader();

    var usersChoice = Console.ReadLine().Trim().ToUpper();
    var menuMessage = "Press Any Key To Go Back to Menu";

    switch (usersChoice)
    {
        case "A":
            AddProduct();
            break;
        case "D":
            DeleteProduct("User chose D");
            break;
        case "V":
            ViewProduct("User chose V");
            break;
        case "U":
            UpdateProduct("User chose U");
            break;
        case "Q":
            menuMessage = "Goodbye"; //will be displayed at bottom of program
            SaveProducts(); //will save the file to the history txt file
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

// method that will process the seed data from the candyNames array and store it inside products list
void SeedData()
{
    for (int i = 0; i < candyNames.Length; i++)
    {
        products.Add(candyNames[i]);
    }
}


// display menu
string GetMenu()
{
    return "Choose one option:\n"
   + 'V' + " to view products\n"
   + 'A' + " to Add products:\n"
   + 'D' + " to Delete products:\n"
   + 'U' + " to Update products:\n"
   + 'Q' + " to quit the program:\n";
}


// methods
void AddProduct()
{
    Console.WriteLine("Product name:");
    var product = Console.ReadLine();
    products.Add(product);
}

void DeleteProduct(string message)
{
    Console.WriteLine(message);
}

void ViewProduct(string message)
{
    Console.WriteLine(message);
}

void UpdateProduct(string message)
{
    Console.WriteLine(message);
}

void PrintHeader()
{
    string title = "The Candy Shop";
    string divide = "-------------------------------------";
    DateTime datetime = DateTime.Now;
    int daysSinceOpening = GetDaysSinceOpening();
    decimal todaysProfit = 5.5m;
    bool targetAchieved = false;
    string menu = GetMenu();

    Console.WriteLine($@"{title}
{divide}
Today's date: {datetime}
Days since opening: {daysSinceOpening}
Today's profit: {todaysProfit}
Today's target achieved {targetAchieved}
{divide}
{menu} ");
}

int GetDaysSinceOpening()
{
    var openingDate = new DateTime(2023, 1, 1);
    TimeSpan timeDifference = DateTime.Now - openingDate;

    return timeDifference.Days;
}

void SaveProducts()
{
    using (StreamWriter outputFile = new StreamWriter(docPath))
    {
        foreach (string product in products)
        {
            outputFile.WriteLine(product);
        }
        Console.WriteLine("Products saved");
    }
}

Console.ReadLine();

