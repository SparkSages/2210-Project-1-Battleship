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
      /// Creates a ship with the given parameters
      /// </summary>
      /// <param name="position"></param>
      /// <param name="direction"></param>
      /// <param name="length"></param>
      public Ship(Coord2D position, DirectionType direction, byte length)
      {
         this.Position = position;
         this.Direction = direction;
         this.Length = length;
         this.Points = new Coord2D[length];
         this.DamagedPoints = new List<Coord2D>();
      }
      /// <summary>
      /// Checks if the given point is a part of the ship
      /// </summary>
      /// <param name="point"></param>
      /// <returns></returns>
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
      /// Checks if the given point is a part of the ship
      /// if it is, it will add the point that got hit to the
      /// ships damaged points
      /// </summary>
      /// <param name="point"></param>
      public void TakeDamage(Coord2D point)
      {
         if (this.DamagedPoints.Contains(point))
         {
            return;
         }
         else
         {
            DamagedPoints.Add(point);
         }
      }
      /// <summary>
      ///  Get the name of the ship 
      /// </summary>
      /// <returns>String: name of ship</returns>
      /// <returns></returns>
      public string GetName()
      {
         return this.GetType().Name;
      }
      /// <summary>
      /// Get information of the ship, including max health, current health, 
      /// indicate if it is dead, position, length, and direction
      /// </summary>
      /// <returns></returns>
      public string GetInfo()
      {
         return
         $@"Max Health:    {this.Length}
         CurrentHealth: {this.GetCurrentHealth()}
         IsDead:        {this.IsDead()}
         Position:      {this.Position}
         Length:        {this.Length}
         Direction:     {this.Direction}
         ";
      }
      #region IHealth Stuff
      /// <summary>
      /// Get the current health of the ship
      /// </summary>
      /// <returns>int: Current Health</returns>
      public int GetCurrentHealth()
      {
         return this.Length - this.DamagedPoints.Count;
      }
      /// <summary>
      /// Get the max health of the ship
      /// </summary>
      /// <returns>Int: Length of ship</returns>
      public int GetMaxHealth()
      {
         return this.Length;
      }
      /// <summary>
      /// Checks if the ship is dead
      /// </summary>
      /// <returns>if dead returns true, if alive returns false</returns>
      public bool IsDead()
      {
         return this.Length == this.DamagedPoints.Count;
      }
      /// <summary>
      /// Unimplemented method the ships should not be damaged in this way
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