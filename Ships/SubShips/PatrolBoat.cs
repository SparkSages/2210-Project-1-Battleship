using Ships;
namespace SubShips
{
    public class PatrolBoat : Ship
    {
        /// <summary>
        /// Creates a patrol boat with the given parameters
        /// </summary>
        /// <param name="position"></param>
        /// <param name="direction"></param>
        public PatrolBoat(Coord2D position, DirectionType direction) : base(position, direction, 2) { }
    }
}