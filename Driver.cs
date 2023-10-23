using System.Text.RegularExpressions;
using Ships;

string userInput;
Regex coordRegex = new Regex(@"\s*[0-9],\s*[0-9]\s*");
List<Ship> ships = new();


if (args.Length > 0)
{
    userInput = args[0];
}
else
{
    System.Console.Write("Please enter your filepath: ");
    userInput = Console.ReadLine().Trim();
}
if (File.Exists(userInput))
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Green;
    System.Console.WriteLine("File found!");
    ships = ShipFactory.ParseStringFile(userInput).ToList();
    Console.Clear();
    System.Console.WriteLine("File loaded!");
    Console.ResetColor();
}
else
{
    throw new Exception("invalid file path, or file does not exist");
}
Console.ForegroundColor = ConsoleColor.DarkCyan;
System.Console.WriteLine("Welcome to Battleship!");
userInput = ConsoleMessage();

while (userInput.ToLower().Trim() != "exit")
{

    if (userInput.ToUpper() == "EXIT")
    {
        System.Console.WriteLine("Goodbye!");
        userInput = "exit";
    }
    else if (userInput.ToUpper() == "INFO")
    {
        int count = 0;
        foreach (Ship ship in ships)
        {
            if (ship.IsDead())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                count++;
                System.Console.WriteLine(count);
                System.Console.WriteLine(ship.GetInfo());
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                count++;
                System.Console.WriteLine(count);
                System.Console.WriteLine(ship.GetInfo());
            }
        }
        userInput = ConsoleMessage();
    }
    else if (coordRegex.IsMatch(userInput))
    {
        Coord2D coord = new()
        {
            X = Int32.Parse(userInput.Split(',')[0]),
            Y = Int32.Parse(userInput.Split(',')[1])
        };
        foreach (Ship ship in ships)
        {
            if (ship.CheckIfHit(coord))
            {
                System.Console.WriteLine("Hit!");
                ship.TakeDamage(coord);
                if (ship.IsDead())
                {
                    System.Console.WriteLine($"You sunk a {ship.GetName()}!");
                }
            }
        }
        if (ships.All(x => x.IsDead()))
        {
            System.Console.WriteLine("You Win!");
            userInput = "exit";
        }
        else
        {
            userInput = ConsoleMessage();
        }
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        System.Console.WriteLine("Command Not Recognized");
        userInput = ConsoleMessage();
    }
}


/// <summary>
/// The user can input into the console, this displays their options
/// </summary>
/// <returns>the user's input</returns>
static string ConsoleMessage()
{
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    System.Console.WriteLine("\n\n\nPlease select between EXIT, INFO or a Coordinate x, y");
    string input = Console.ReadLine().Trim().ToUpper();
    Console.ResetColor();
    Console.Clear();
    return input;
}