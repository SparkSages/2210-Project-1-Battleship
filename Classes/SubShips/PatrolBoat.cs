using Ships;
namespace SubShips
{
    public class PatrolBoat : Ship
    {
        public PatrolBoat(Coord2D position, DirectionType direction) : base(position, direction, 2) { }
    }
}