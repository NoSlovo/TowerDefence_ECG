using Components;
using UnityEngine;

namespace Tower.Projectiles
{
    public abstract class BaseProjectile : MonoBehaviour
    {
        [SerializeField] protected MovementComponent _movementComponent;
        [SerializeField] protected int Damage = 10;

        public MovementComponent MovementComponent => _movementComponent;

        public void SetTarget(Transform target) => _movementComponent.SetMovePoint(target.position);
    }
}