using System;
using Enemy.EnemyInterfaces;
using UnityEngine;

namespace Enemy
{
    public interface IEnemy :IPoolElement, IDamageProvider
    {
        public void SetMoveTarget(Transform target);
        public Transform Transform { get; }
    }
}