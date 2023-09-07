using Ships;
namespace SubShips
{
    public class Battleship : Ship
    {
        /// <summary>
        /// Creates a battleship with the given parameters
        /// </summary>
        /// <param name="position"></param>
        /// <param name="direction"></param>
        public Battleship(Coord2D position, DirectionType direction) : base(position, direction, 4) { }
    }
}