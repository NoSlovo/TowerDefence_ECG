using UnityEngine;

namespace Tower.Projectiles
{
    public abstract class BaseProjectile : MonoBehaviour
    {
        private Transform target;
        private const float projectileSpeed = 45f;

        public void LaunchToTarget(Transform targetTransform) => target = targetTransform;

        private void Update()
        {
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            float targetSpeed = CalculateTargetSpeed(target.position);
            transform.position += directionToTarget * ((projectileSpeed + targetSpeed) * Time.deltaTime);
        }

        private float CalculateTargetSpeed(Vector3 targetPosition)
        {
            if (target == null || targetPosition == target.position)
                return 0f;
            
            Vector3 directionToTarget = (targetPosition - target.position).normalized;
            float targetSpeed = Vector3.Dot(target.GetComponent<CharacterController>().velocity, directionToTarget);

            return targetSpeed;
        }
    }
}