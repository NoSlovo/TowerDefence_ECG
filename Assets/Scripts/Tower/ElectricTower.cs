using UnityEngine;

namespace Tower
{
    public class ElectricTower : BaseTower
    {
        
        private void Update()
        {
            if (IsShooting)
                Shoot();
        }

        public override void Shoot()
        {
            ShootInterval -= Time.deltaTime;
            if (ShootInterval <= 0)
            {
                ShootInterval = 0.5f;
                ShotComponent.ShootToTarget(Target.transform);
            }
        }
    }
}