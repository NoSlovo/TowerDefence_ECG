using System;

namespace Enemy
{
    public class HealthComponent
    {
        public int Value { get; private set; } = 30;

        public event Action<bool> OnDied;

        public void GetDamage(int damage)
        {
            if (damage > 0)
                Value -= damage;

            bool checkResult = CheckDead(damage);
            OnDied?.Invoke(!checkResult);
        }

        public bool CheckDead(int damage)
        {
            if (Value < damage)
            {
                Value = 0;
                return true;
            }

            return false;
        }
    }
}