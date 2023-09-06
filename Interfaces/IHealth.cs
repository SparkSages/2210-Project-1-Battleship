namespace Interfaces
{
    public interface IHealth
    {
        public int GetCurrentHealth();
        public int GetMaxHealth();
        public bool IsDead();
        public void TakeDamage(int amount);
    }
}