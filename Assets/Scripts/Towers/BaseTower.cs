using Components;
using Enemy;
using UnityEngine;

namespace Towers
{
    public abstract class BaseTower : MonoBehaviour
    {
        [SerializeField] private float _reload = 0.5f;
        [SerializeField] private float _attackRange = 5f;
        [SerializeField] private ShootComponent _shooterComponent;

        public bool HasTarget => Target != null;
        public Vector3 Position => transform.position;
        public float AttackRange => _attackRange;

        protected IEnemy Target;

        private float _currentReloadTime;

        public virtual void Initialize() => _shooterComponent.Init();

        public void Shoot()
        {
            if (!HasTarget)
                return;

            if (_currentReloadTime > 0)
            {
                _currentReloadTime -= Time.deltaTime;
                return;
            }

            _currentReloadTime = _reload;
            _shooterComponent.ShootToTarget(Target.Transform);

            if (_shooterComponent.CheckAttackDistance(transform, Target.Transform, AttackRange))
                StopShooting();
        }

        public virtual void SetTarget(IEnemy target) => Target = target;

        private void StopShooting() => Target = null;
    }
}