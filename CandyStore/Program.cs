PrintHeader();

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


int GetDaysSinceOpening()
{
    var openingDate = new DateTime(2023, 1, 1);
    TimeSpan timeDifference = DateTime.Now - openingDate;

    return timeDifference.Days;
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