using Ships;
namespace SubShips
{

    public class Carrier : Ship
    {
        public Carrier(Coord2D position, DirectionType direction) : base(position, direction, 5) { }
    }
}