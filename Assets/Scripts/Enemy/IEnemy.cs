using System;

namespace Enemy
{
    public interface IEnemy : IDamageProvaider
    {
        public bool IsAlive { get; set; }
        public event Action OnDead;
    }
}