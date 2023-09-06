using Ships;
namespace SubShips
{


    public class Submarine : Ship
    {
        public Submarine(Coord2D position, DirectionType direction) : base(position, direction, 3) { }
    }
}