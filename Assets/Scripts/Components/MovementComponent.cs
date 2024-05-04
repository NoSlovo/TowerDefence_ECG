using System;
using UnityEngine;

namespace Components
{
    public class MovementComponent : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Rigidbody _rigidbody;
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
            _rigidbody = GetComponent<Rigidbody>();
        }

        private bool CheckTargetDistance()
        {
            if (Vector3.Distance(transform.position, _targetPoint) <= _reachDistance)
                return true;

            return false;
        }

        private void MoveToTargetPoint()
        {
            Vector3 direction = _targetPoint - transform.position;

            direction.Normalize();

            _rigidbody.MovePosition(_rigidbody.position + direction * (_speed * Time.fixedDeltaTime));
        }
    }
}