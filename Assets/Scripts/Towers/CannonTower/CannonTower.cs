using Components;
using UnityEngine;

namespace Towers.CannonTower
{
    public class CannonTower : BaseTower
    {
        [SerializeField] private Transform _turretHead;
        [SerializeField] private float _turnSpeed = 5f;

        private GuidanceComponent _guidanceComponent;
        private float _angle = 10f;

        protected override void Init()
        {
            _guidanceComponent = new GuidanceComponent(_turretHead, _angle, _turnSpeed);
            DetectionEnemy.OnDetected += SetTarget;
        }
        
        private void Update()
        {
            if (IsShooting)
                Shoot();
        }

        protected override void Shoot()
        {
            ShootInterval -= Time.deltaTime;
            if (IsShooting)
            {
                if (ShotComponent.CheckAttackDistance(transform, Target.transform, AttackRange))
                {
                    StopShooting();
                    return;
                }
                
                _guidanceComponent.RotateTurret(Target.transform, Target.transform.position);
                
                if (ShootInterval <= 0)
                {
                    ShootInterval = 0.5f;
                    ShotComponent.ShootToTarget(Target.transform);
                }
            }
        }

        private void OnDisable()
        {
            DetectionEnemy.OnDetected -= SetTarget;
        }
    }
}