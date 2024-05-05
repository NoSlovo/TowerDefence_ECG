using Components;
using Enemy;
using UnityEngine;

namespace Towers
{
    public abstract class BaseTower : MonoBehaviour
    {
        [SerializeField] private float reload = 0.5f;
        [SerializeField] private float attackRange = 5f;
        [SerializeField] private ShootComponent shooterComponent;

        public bool HasTarget => Target != null;
        public Vector3 Position => transform.position;
        public float AttackRange => attackRange;

        protected IEnemy Target;

        private float _currentReloadTime;

        public virtual void Initialize()
        {
            shooterComponent.Init();
        }

        public void Shoot()
        {
            if (!HasTarget)
                return;

            if (_currentReloadTime > 0)
            {
                _currentReloadTime -= Time.deltaTime;
                return;
            }

            _currentReloadTime = reload;
            shooterComponent.ShootToTarget(Target.Transform);

            if (shooterComponent.CheckAttackDistance(transform, Target.Transform, AttackRange))
                StopShooting();
        }

        public virtual void SetTarget(IEnemy target)
        {
            Target = target;
        }

        protected void StopShooting()
        {
            Target = null;
        }
    }
}