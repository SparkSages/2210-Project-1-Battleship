using System.Net;
using System.Text.RegularExpressions;
using SubShips;
namespace Ships
{
    public class ShipFactory
    {
        /// <summary>
        /// This is used to make sure that the user is inputting a legal string for the ship.
        /// </summary>
        /// <param name="stringToVerify">Input the string that needs to be tested</param>
        /// <returns>True only if each condition is met.</returns>
        static bool VerifyShipString(string description)
        {
            var stringToVerify = description.Split(',');
            /// <summary>
            /// Checks if the string is a valid ship string where: the ship is one of the 5 ships, the length is 1-5, the direction is h or v, and the coordinate of the ship is less than 11 or greater than 0.
            /// </summary>
            /// <param name="stringToVerify"> String from the Stream reader separated by a comma.</param>
            /// <returns>True if condition are met, False if any one condition is not met</returns>
            if (Int32.Parse(stringToVerify[1].Trim()) < 6 && ((stringToVerify[2].Trim() == "h" && Int32.Parse(stringToVerify[1]) + Int32.Parse(stringToVerify[3]) < 11) || (stringToVerify[2].Trim() == "v" && Int32.Parse(stringToVerify[1]) + Int32.Parse(stringToVerify[4]) < 11)) && ((stringToVerify[2].Trim() == "h" && Int32.Parse(stringToVerify[1]) + Int32.Parse(stringToVerify[3]) >= 0) || (stringToVerify[2].Trim() == "v" && Int32.Parse(stringToVerify[1]) + Int32.Parse(stringToVerify[4]) >= 0)))
            {
                return true;
            }
            else
            {
                throw new Exception("Invalid ship string");
            }
        }
        /// <summary>
        /// This method is used to parse the ship string into a ship object after verifying that the string is valid.
        /// </summary>
        /// <param name="description">Ship description</param>
        /// <returns>A ship of the proper type</returns>
        /// <exception cref="Exception">Invalid ship string</exception>
        static Ship ParseShipString(string description)
        {
            if (!VerifyShipString(description))
            {
                throw new Exception("Invalid ship string");
            }
            else
            {
                string[] separatedDescription = description.Split(',');
                string name = separatedDescription[0].Trim();
                int length = Int32.Parse(separatedDescription[1].Trim());
                DirectionType direction = separatedDescription[2].Trim() == "h" ? DirectionType.Horizontal : DirectionType.Vertical;
                int x = Int32.Parse(separatedDescription[3].Trim());
                int y = Int32.Parse(separatedDescription[4].Trim());

                switch (name)
                {
                    case "Carrier":
                        return new Carrier(new Coord2D() { X = x, Y = y }, direction);
                    case "Battleship":
                        return new Battleship(new Coord2D() { X = x, Y = y }, direction);
                    case "Destroyer":
                        return new Destroyer(new Coord2D() { X = x, Y = y }, direction);
                    case "Submarine":
                        return new Submarine(new Coord2D() { X = x, Y = y }, direction);
                    case "Patrol Boat":
                        return new PatrolBoat(new Coord2D() { X = x, Y = y }, direction);
                    default:
                        throw new Exception("Invalid ship string");
                }
            }
        }
        /// <summary>
        /// This method is used to parse the file into an array of ships.
        /// </summary>
        /// <param name="filePath">File path to the ship data</param>
        /// <returns>An array of ships.</returns>
        public static Ship[] ParseStringFile(string filePath)
        {
            StreamReader sr = new StreamReader(filePath);
            List<Ship> ships = new();
            int i = 0;
            Regex regex = new Regex(@"(Carrier|Battleship|Destroyer|Submarine|Patrol Boat),\s*[0-9],\s*(h|v),\s*[0-9],\s*[0-9]");
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                if (!regex.IsMatch(line)) continue;
                else if (regex.IsMatch(line))
                {
                    ships.Add(ParseShipString(line));
                    i++;
                }
                else
                {
                    continue;
                }
            }
            return ships.ToArray();
        }
    }




}