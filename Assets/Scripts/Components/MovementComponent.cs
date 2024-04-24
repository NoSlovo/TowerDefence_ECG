using UnityEngine;

namespace Components
{
    public class MovementComponent : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private bool _iDestroyOnReach;

        private Vector3 _targetPoint;
        public float Speed => _speed;
        private float _reachDistance = 0.3f;

        private void Update()
        {
            if (CheckTargetDistance() && _iDestroyOnReach) Destroy(gameObject);
            MoveToTargetPoint();
        }

        public void SetMovePoint(Vector3 target) => _targetPoint = target;

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