using System;
using UnityEngine;

namespace Components
{
    public class MovementComponent : MonoBehaviour
    {
        [SerializeField] private float _speed;
        
        private Vector3 _targetPoint;
        public float Speed => _speed;
        private float _reachDistance = 0.3f;

        private void Update()
        {
            if (CheckTargetDistance()) Destroy(gameObject);
            MoveToTargetPoint();
        }

        public void SetMovePoint(Transform target) => _targetPoint = target.position;


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