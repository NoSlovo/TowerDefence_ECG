using Components;
using UnityEngine;

namespace Tower
{
    public class ElectricTower : BaseTower
    {
        [SerializeField] private ShotComponent<GuidedProjectile> _shotComponent;

        private Monster _target;
        private bool _isShooting = false;
        protected override void Init()
        {
            DetectionEnemy.OnDetected += SetTarget;
        }

        private void Update()
        {
            if (_isShooting)
            {
                Shoot();
            }
        }

        protected override void SetTarget(Monster target)
        {
            _target = target;
            _isShooting = true;
        }

        protected override void Shoot()
        {
            if (_shotComponent.CheckAttackDistance(transform, _target.transform, AttackRange))
                StopShooting();

            ShootInterval -= Time.deltaTime;

            if (ShootInterval <= 0 && _isShooting)
            {
                ShootInterval = 0.5f;
                _shotComponent.ShootToTarget(_target.transform);
            }
        }

        private void StopShooting()
        {
            _target = null;
            _isShooting = false;
        }

        private void OnDisable()
        {
            DetectionEnemy.OnDetected -= SetTarget;
        }
    }
}