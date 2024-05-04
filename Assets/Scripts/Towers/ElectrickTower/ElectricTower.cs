using UnityEngine;

namespace Towers.ElectrickTower
{
    public class ElectricTower : BaseTower
    {
        protected override void Init() => DetectionEnemy.OnDetected += SetTarget;
        
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
                    StopShooting();

                if (ShootInterval <= 0)
                {
                    ShootInterval = 0.5f;
                    ShotComponent.ShootToTarget(Target.transform);
                }
            }
        }

        private void OnDisable() => DetectionEnemy.OnDetected -= SetTarget;
    }
}