using System;
using Services.Pool;
using Towers.Projectiles;
using UnityEngine;

namespace Components
{
    [Serializable]
    public class ShootComponent
    {
        [SerializeField] private Projectile _projectilePrefab;
        [SerializeField] private Transform _shootPoint;

        private PoolService<Projectile> _poolService;

        public void Init()
        {
            _poolService = new PoolService<Projectile>(_projectilePrefab, 10);
        }

        public void ShootToTarget(Transform target)
        {
            if (target == null)
                return;

            var projectile = _poolService.GetElement();
            projectile.transform.position = _shootPoint.position;
            projectile.LaunchToTarget(target.transform);
        }

        public bool CheckAttackDistance(Transform shotObject, Transform target, float AttackRange)
        {
            return Vector3.Distance(shotObject.position, target.transform.position) > AttackRange;
        }
    }
}