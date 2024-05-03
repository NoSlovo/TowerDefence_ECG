using UnityEngine;

namespace Tower
{
    public abstract class BaseTower : MonoBehaviour
    {
        [SerializeField] protected float ShootInterval = 0.5f;
        [SerializeField] protected DetectionEnemy DetectionEnemy;
        [SerializeField] protected float AttackRange = 5f;

        public void InitTowers() => Init();
        
        protected abstract void Init();

        protected abstract void Shoot();
        protected abstract void SetTarget(Monster monster);
    }
}