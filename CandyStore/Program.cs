string title = "The Candy Shop";
string divide = "-------------------------------------";
DateTime datetime = DateTime.Now;
int daysSinceOpening = 1;
decimal todaysProfit = 5.5m;
bool targetAchieved = false;
string menu = "Choose one option:\n"
    + 'V' + " to view products\n"
    + 'A' + " to Add products:\n"
    + 'D' + " to Delete products:\n"
    + 'U' + " to Update products:\n";

Console.WriteLine(title);
Console.WriteLine(divide);
Console.WriteLine("Today's date: " + datetime);
Console.WriteLine("Days since opening: " + daysSinceOpening);
Console.WriteLine("Today's profit: " + todaysProfit + "$");
Console.WriteLine("Today's target achieved " + targetAchieved);
Console.WriteLine(divide);
Console.WriteLine(menu);


Console.ReadLine();