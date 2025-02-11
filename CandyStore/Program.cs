var isMenuRunning = true;
var menuMessage = "Press Any Key To Go Back to Menu";

while (isMenuRunning)
{
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
        case "Q":
            menuMessage = "Goodbye"; //will be displayed at bottom of program
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

Console.ReadLine();

