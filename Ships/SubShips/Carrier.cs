using Ships;
namespace SubShips
{

    public class Carrier : Ship
    {
        /// <summary>
        /// Creates a carrier with the given parameters
        /// </summary>
        /// <param name="position"></param>
        /// <param name="direction"></param>
        public Carrier(Coord2D position, DirectionType direction) : base(position, direction, 5) { }
    }
}