using System;
using UnityEngine;

namespace Components
{
    public class MovementComponent : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Vector3 _targetPoint;

        public Action<bool> OnReachTarget;

        public float Speed => _speed;
        private float _reachDistance = 0.3f;

        private void Update()
        {
            bool reach = CheckTargetDistance();
            
            if (reach)
                OnReachTarget?.Invoke(false);
            MoveToTargetPoint();
        }

        public void SetMovePoint(Vector3 target)
        {
            if (target == Vector3.zero)
                throw new Exception("Move point cannot be null");

            _targetPoint = target;
        }

        private bool CheckTargetDistance()
        {
            if (Vector3.Distance(transform.position, _targetPoint) <= _reachDistance)
                return true;

            return false;
        }

        private void MoveToTargetPoint()
        {
            var directionMove = _targetPoint - transform.position;

            if (directionMove.magnitude > _speed)
                directionMove = directionMove.normalized * _speed;

            transform.Translate(directionMove);
        }
    }
}