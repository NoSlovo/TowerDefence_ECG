using Tower.Projectiles;
using UnityEngine;

namespace Tower
{
    public abstract class BaseTower : MonoBehaviour
    {
        [SerializeField] protected float ShootInterval = 0.5f;
        [SerializeField] private float _attackRange = 5f;
        [SerializeField] private DetectionEnemy _detectionEnemy;

        protected Monster Target;
        protected bool IsShooting = false;
        
        public float AttackRange => _attackRange;

        public void Init()
        {
            gameObject.SetActive(true);
            _detectionEnemy.Init();
        }

        public void SetTarget(Monster target)
        {
            Target = target;
            IsShooting = true;
        }

        public void StopShooting()
        {
            Target = null;
            IsShooting = false;
        }

        public abstract void Shoot();
    }
}