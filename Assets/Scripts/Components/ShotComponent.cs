using System;
using Tower.Projectiles;
using UnityEngine;

namespace Components
{
    [Serializable]
    public class ShotComponent<T> where T : BaseProjectile
    {
        [SerializeField] private T _projectilePrefab;
        [SerializeField] private Transform _shotPoint;
        
        public Transform ShotPoint => _shotPoint;

        public void ShootToTarget(Transform monster)
        {
            if (monster == null)
                return;

            var projectile = GameObject.Instantiate(_projectilePrefab, _shotPoint.position, Quaternion.identity);
            projectile.LaunchToTarget(monster.transform);
        }

        public bool CheckAttackDistance(Transform shotObject, Transform target, float AttackRange)
        {
            if (Vector3.Distance(shotObject.position, target.transform.position) > AttackRange)
                return true;

            return false;
        }
    }
}