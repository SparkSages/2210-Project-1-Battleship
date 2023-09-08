using Interfaces;
namespace Ships
{
   public abstract class Ship : IHealth, IInfomatic
   {
      private Coord2D Position;
      private byte Length;
      private DirectionType Direction;
      private Coord2D[] Points;
      private List<Coord2D> DamagedPoints;
      /// <summary>
      /// Creates a ship with the given parameters.
      /// </summary>
      /// <param name="position">coordinates of the ship.</param>
      /// <param name="direction">direction ship is facing.</param>
      /// <param name="length">How long is the ship?</param>
      public Ship(Coord2D position, DirectionType direction, byte length)
      {
         this.Position = position;
         this.Direction = direction;
         this.Length = length;
         this.Points = new Coord2D[length];
         this.DamagedPoints = new List<Coord2D>();

         if (direction == DirectionType.Horizontal)
         {
            for (int i = 0; i < length; i++)
            {
               Points[i] = new Coord2D() { X = position.X + i, Y = position.Y };
            }
         }
         else if (direction == DirectionType.Vertical)
         {
            for (int i = 0; i < length; i++)
            {
               Points[i] = new Coord2D() { X = position.X, Y = position.Y + i };
            }
         }
         else
         {
            throw new Exception("Invalid direction");
         }

      }
      /// <summary>
      /// The user can damage a ship, this method will check if the given point will do so
      /// </summary>
      /// <param name="point">Point to check</param>
      /// <returns>True if the ship is hit.</returns>
      public bool CheckIfHit(Coord2D point)
      {
         if (Points.Contains(point))
         {
            return true;
         }
         else
         {
            return false;
         }

      }
      /// <summary>
      /// Checks if the given point is already a part of the ships damaged points
      /// if it is not, it will add it to the list, if it is, it will do nothing.
      /// </summary>
      /// <param name="point">coordinate to check.</param>
      public void TakeDamage(Coord2D point)
      {
         if (this.DamagedPoints.Contains(point))
         {
            return;
         }
         else
         {
            this.DamagedPoints.Add(point);
            System.Console.WriteLine($"You hit a ship at {point.X},{point.Y}!");
         }
      }
      /// <summary>
      ///  This method is used to get the name of the ship.
      /// </summary>
      /// <returns>Name of the ship.</returns>
      public string GetName()
      {
         return this.GetType().Name;
      }
      /// <summary>
      /// This is used to get information on ship, including max health, current health, 
      /// indicate if it is dead, position, length, and direction
      /// </summary>
      /// <returns>A displayable string containing important information</returns>
      public string GetInfo()
      {
         return
         $"\nMax Health: {this.Length}\nCurrentHealth: {this.GetCurrentHealth()}\nIsDead: {this.IsDead()}\nPosition: ({this.Position.X},{this.Position.Y})\nLength: {this.Length}\nDirection: {this.Direction}";
      }
      #region IHealth Stuff
      /// <summary>
      /// This is used to check the current health of a ship.
      /// </summary>
      /// <returns>The ships current health</returns>
      public int GetCurrentHealth()
      {
         return this.Length - this.DamagedPoints.Count;
      }
      /// <summary>
      /// This is used to obtain the max health of the ship.
      /// </summary>
      /// <returns>Length of ship</returns>
      public int GetMaxHealth()
      {
         return this.Length;
      }
      /// <summary>
      /// This is used to check if a ship is dead.
      /// </summary>
      /// <returns>If the ship is dead this method returns true, if it is alive alive it returns false</returns>
      public bool IsDead()
      {
         return this.Length == this.DamagedPoints.Count;
      }
      /// <summary>
      /// This is an unimplemented method, the ships should not be damaged in this way.
      /// If this method gets used it will throw an exception.
      /// </summary>
      /// <param name="amount"></param>
      /// <exception cref="Exception"></exception>
      public void TakeDamage(int amount)
      {
         throw new Exception("Ship is not damaged in this way.");
      }
      #endregion
   }
}