using Ships;
namespace SubShips
{
    public class Submarine : Ship
    {
        /// <summary>
        /// Creates a submarine with the given parameters
        /// </summary>
        /// <param name="position"></param>
        /// <param name="direction"></param>
        public Submarine(Coord2D position, DirectionType direction) : base(position, direction, 3) { }
    }
}