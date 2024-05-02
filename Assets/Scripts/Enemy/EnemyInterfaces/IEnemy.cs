using System;
using UnityEngine;

namespace Enemy
{
    public interface IEnemy : IDamageProvaider
    {
        public void SetMoveTarget(Transform target);
    }
}