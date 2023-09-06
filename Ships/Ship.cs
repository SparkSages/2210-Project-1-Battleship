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
      public Ship(Coord2D position, DirectionType direction, byte length)
      {
         this.Position = position;
         this.Direction = direction;
         this.Length = length;
         this.Points = new Coord2D[length];
         this.DamagedPoints = new List<Coord2D>();
      }

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
      public string GetName()
      {
         return this.GetType().Name;
      }
      public string GetInfo()
      {
         // Should include the max health, current health, indicate if it is dead, position, length, and direction
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
      public int GetCurrentHealth()
      {
         return this.Length - this.DamagedPoints.Count;
      }
      public int GetMaxHealth()
      {
         return this.Length;
      }
      public bool IsDead()
      {
         return this.Length == this.DamagedPoints.Count;
      }
      public void TakeDamage(int amount)
      {
         throw new Exception("Ship is not damaged in this way.");
      }
      #endregion
   }
}

