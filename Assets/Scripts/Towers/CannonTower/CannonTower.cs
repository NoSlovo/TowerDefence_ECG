using Components;
using UnityEngine;

namespace Tower
{
    public class CannonTower : BaseTower
    {
        [SerializeField] private ShotComponent<CannonProjectile> _shotComponent;
        [SerializeField] private Transform _turretHead;
        [SerializeField] private float _turnSpeed = 5f;

        private Monster _target;
        private GuidanceComponent _guidanceComponent;
        
        private float _angle = 10f;
        private bool _isShooting = false;

        protected override void Init()
        {
            _guidanceComponent = new GuidanceComponent(_turretHead, _angle, _turnSpeed);
            DetectionEnemy.OnDetected += SetTarget;
        }

        protected override void SetTarget(Monster target)
        {
            _target = target;
            _isShooting = true;
        }

        private void StopShooting()
        {
            _target = null;
            _isShooting = false;
        }

        public void Update()
        {
            if (_isShooting)
                _guidanceComponent.RotateTurret(_target.transform, _target.transform.position);

            if (_guidanceComponent.LookTarget)
                Shoot();
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

        private void OnDisable()
        {
            DetectionEnemy.OnDetected -= SetTarget;
        }
    }
}