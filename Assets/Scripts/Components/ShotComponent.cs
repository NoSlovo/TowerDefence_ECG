using System;
using Spawners.Factory;
using Towers.Projectiles;
using UnityEngine;

namespace Components
{
    [Serializable]
    public class ShotComponent
    {
        [SerializeField] private Projectile _projectilePrefab;
        [SerializeField] private Transform _shotPoint;

        private FactoryPool<Projectile> _pool;

        public Transform ShotPoint => _shotPoint;

        public void Init()
        {
            _pool = new FactoryPool<Projectile>(_projectilePrefab, 10);
        }

        public void ShootToTarget(Transform target)
        {
            if (target == null)
                return;

            var projectile = _pool.GetElement();
            projectile.transform.position = _shotPoint.position;
            projectile.LaunchToTarget(target.transform);
        }

        public bool CheckAttackDistance(Transform shotObject, Transform target, float AttackRange)
        {
            if (Vector3.Distance(shotObject.position, target.transform.position) > AttackRange)
                return true;

            return false;
        }
    }
}