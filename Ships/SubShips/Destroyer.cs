using Ships;
namespace SubShips
{
    public class Destroyer : Ship
    {
        /// <summary>
        /// Creates a destroyer with the given parameters
        /// </summary>
        /// <param name="position"></param>
        /// <param name="direction"></param>
        public Destroyer(Coord2D position, DirectionType direction) : base(position, direction, 3) { }
    }
}