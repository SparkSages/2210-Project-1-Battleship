using Ships;
namespace SubShips
{
    public class Battleship : Ship
    {
        public Battleship(Coord2D position, DirectionType direction) : base(position, direction, 4) { }
    }
}