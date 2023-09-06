using Ships;
namespace SubShips
{
    public class Destroyer : Ship
    {
        public Destroyer(Coord2D position, DirectionType direction) : base(position, direction, 3) { }
    }
}