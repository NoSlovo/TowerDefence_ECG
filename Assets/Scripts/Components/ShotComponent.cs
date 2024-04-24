using System;
using Components;
using Tower.Projectiles;
using UnityEngine;

namespace Tower
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
            projectile.SetTarget(monster.transform);
        }
    }
}