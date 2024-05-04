using Components;
using Towers.TowerDetection;
using UnityEngine;

namespace Towers
{
    public abstract class BaseTower : MonoBehaviour 
    {
        [SerializeField] protected float ShootInterval = 0.5f;
        [SerializeField] protected DetectionEnemy DetectionEnemy;
        [SerializeField] protected float AttackRange = 5f;
        [SerializeField] protected ShotComponent ShotComponent;

        protected Monster Target;
        protected bool IsShooting = false;

        public virtual void InitTower()
        {
            ShotComponent.Init();
            Init();
        }

        protected abstract void Init();
        
        protected abstract void Shoot();


        protected void SetTarget(Monster monster)
        {
            if (Target != null)
                return;

            Target = monster;
            IsShooting = true;
        }

        protected void StopShooting()
        {
            IsShooting = false;
            Target = null;
        }
    }
}