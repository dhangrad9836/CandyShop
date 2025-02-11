string title = "The Candy Shop";
string divide = "-------------------------------------";
DateTime datetime = DateTime.Now;
int daysSinceOpening = 1;
decimal todaysProfit = 5.5m;
bool targetAchieved = false;
string menu = "Choose one option: ";

Console.WriteLine(title);
Console.WriteLine(divide);
Console.WriteLine("Today's date: " + datetime);
Console.WriteLine("Days since opening: " + daysSinceOpening);
Console.WriteLine("Today's profit: " + todaysProfit + "$");
Console.WriteLine("Today's target achieved " + targetAchieved);
Console.WriteLine(divide);
Console.WriteLine("Choose one option: ");
Console.WriteLine('V' + " to view products");
Console.WriteLine('A' + " to Add products");
Console.WriteLine('D' + " to Delete products");
Console.WriteLine('U' + " to Update products");


Console.ReadLine();