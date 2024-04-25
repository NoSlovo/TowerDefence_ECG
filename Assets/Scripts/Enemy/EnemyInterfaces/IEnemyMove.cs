using UnityEngine;

namespace Enemy
{
    public interface IEnemyMove
    {
        public void SetTarget(Transform target);
    }
}