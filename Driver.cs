using System.Text.RegularExpressions;
using Ships;


string filePath = null;
ShipFactory shipFactory = new ShipFactory();
bool allShipsSunk = false;
Regex coordRegex = new Regex(@"\s*[0-9]\s*,\s*[0-9]\s*");
if (args.Length > 0)
{
    filePath = args[0];
}
else
{
    Console.WriteLine("Please enter a file path");
    filePath = Console.ReadLine().Trim();
}
if (!File.Exists(filePath))
{
    throw new Exception("File does not exist");
}

Ship[] ships = shipFactory.ParseStringFile(filePath);
System.Console.WriteLine("Welcome to Battleship! Enter coordinates to fire at a ship, type 'info' to get info on all ships, or 'exit' to exit the game.");

while (!allShipsSunk)
{
    string input = Console.ReadLine().Trim().ToUpper();
    Options(input, coordRegex, ships);
}



static void Options(string input, Regex coordRegex, Ship[] ships)
{
    input = input.ToUpper().Trim();
    bool[] allShipsSunk = new bool[ships.Length];
    if (input == "EXIT")
    {
        Environment.Exit(0);
    }
    else if (input == "INFO")
    {
        foreach (Ship ship in ships)
        {
            Console.WriteLine(ship.GetInfo() + "\n");
        }
    }
    else if (coordRegex.IsMatch(input))
    {
        string[] splitInput = input.Split(',');
        Coord2D coord = new Coord2D() { X = Int32.Parse(splitInput[0].Trim()), Y = Int32.Parse(splitInput[1].Trim()) };
        foreach (Ship ship in ships)
        {
            ship.CheckIfHit(coord);
            ship.TakeDamage(coord);
        }
    }
    else
    {
        Console.WriteLine("Invalid input");
    }
    int index = 0;
    foreach (Ship ship in ships)
    {
        if (ship.IsDead())
        {
            allShipsSunk[index] = true;
            index++;
        }
        if (allShipsSunk.All(x => x == true))
        {
            Console.WriteLine("All ships sunk, you win!");
            Environment.Exit(0);
        }
    }
}