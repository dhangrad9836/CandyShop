string title = "The Candy Shop";
string divide = "-------------------------------------";
DateTime datetime = DateTime.Now;
int daysSinceOpening = 1;
decimal todaysProfit = 5.5m;
bool targetAchieved = false;
string menu = GetMenu();

Console.WriteLine(title);
Console.WriteLine(divide);
Console.WriteLine($"Today's date: {datetime}" );
Console.WriteLine("Days since opening: " + daysSinceOpening);
Console.WriteLine($"Today's profit: {todaysProfit} $");
Console.WriteLine($"Today's target achieved {targetAchieved}");
Console.WriteLine(divide);
Console.WriteLine(menu);

var usersChoice = Console.ReadLine().Trim().ToUpper();

switch (usersChoice)
{
    case "A":
        AddProduct("User chose A");
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
    default:
        Console.WriteLine("Invalid choice, Please choose one of the above");
        break;
} // end switch statement

// display menu
string GetMenu()
{
     return "Choose one option:\n"
    + 'V' + " to view products\n"
    + 'A' + " to Add products:\n"
    + 'D' + " to Delete products:\n"
    + 'U' + " to Update products:\n";
}

// methods
void AddProduct(string message)
{
    Console.WriteLine(message);
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



Console.ReadLine();
