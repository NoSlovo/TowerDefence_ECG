using Tower.Projectiles;
using UnityEngine;

namespace Tower
{
    public abstract class BaseTower : MonoBehaviour
    {
        [SerializeField] protected ShotComponent<BaseProjectile> ShotComponent;
        [SerializeField] protected float ShootInterval = 0.5f;

        protected Monster Target;
        protected bool IsShooting = false;


        public void SetTarget(Monster target)
        {
            Target = target;
            IsShooting = true;
        }

        public abstract void Shoot();
    }
}