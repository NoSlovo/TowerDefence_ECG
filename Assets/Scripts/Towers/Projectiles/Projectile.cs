using Enemy;
using Enemy.EnemyInterfaces;
using UnityEngine;

namespace Towers.Projectiles
{
    public class Projectile : MonoBehaviour, IPoolElement
    {
        [SerializeField] private float _speed = 45f;
        public bool IsActive { get; set; }

        private Transform _target;

        public void LaunchToTarget(Transform targetTransform) => _target = targetTransform;

        private void Update()
        {
            Vector3 directionToTarget = (_target.position - transform.position).normalized;
            float targetSpeed = CalculateTargetSpeed(_target.position);
            transform.position += directionToTarget * ((_speed + targetSpeed) * Time.deltaTime);
        }

        private float CalculateTargetSpeed(Vector3 targetPosition)
        {
            if (_target == null || targetPosition == _target.position)
                return 0f;

            Vector3 directionToTarget = (targetPosition - _target.position).normalized;
            float targetSpeed = Vector3.Dot(_target.GetComponent<CharacterController>().velocity, directionToTarget);

            return targetSpeed;
        }

        private void OnTriggerEnter(Collider other) => SwitchActiveState(false);


        public void SwitchActiveState(bool value)
        {
            IsActive = value;
            gameObject.SetActive(value);
        }
    }
}