using System;
using Services.Factory;
using Towers.Projectiles;
using UnityEngine;

namespace Components
{
    [Serializable]
    public class ShootComponent
    {
        [SerializeField] private Projectile _projectilePrefab;
        [SerializeField] private Transform shootPoint;

        private FactoryPool<Projectile> _pool;

        public Transform ShootPoint => shootPoint;

        public void Init()
        {
            _pool = new FactoryPool<Projectile>(_projectilePrefab, 10);
        }

        public void ShootToTarget(Transform target)
        {
            if (target == null)
                return;

            var projectile = _pool.GetElement();
            projectile.transform.position = shootPoint.position;
            projectile.LaunchToTarget(target.transform);
        }

        public bool CheckAttackDistance(Transform shotObject, Transform target, float AttackRange)
        {
            return Vector3.Distance(shotObject.position, target.transform.position) > AttackRange;
        }
    }
}