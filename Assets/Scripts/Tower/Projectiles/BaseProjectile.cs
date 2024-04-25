using UnityEngine;

namespace Tower.Projectiles
{
    public abstract class BaseProjectile : MonoBehaviour
    {
        private Transform target;
        private const float projectileSpeed = 45f;

        public void LaunchToTarget(Transform targetTransform)
        {
            target = targetTransform;
        }

        private void Update()
        {
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            // Рассчитываем скорость движения врага
            float targetSpeed = CalculateTargetSpeed(target.position);
            transform.position += directionToTarget * ((projectileSpeed + targetSpeed) * Time.deltaTime);
        }
        
        private float CalculateTargetSpeed(Vector3 targetPosition)
        {
            // Если враг не двигается, возвращаем нулевую скорость
            if (target == null || targetPosition == target.position)
            {
                return 0f;
            }

            // Рассчитываем направление движения врага
            Vector3 directionToTarget = (targetPosition - target.position).normalized;

            // Оцениваем скорость движения врага как скалярное произведение скорости снаряда и направления движения врага
            float targetSpeed = Vector3.Dot(target.GetComponent<CharacterController>().velocity, directionToTarget);

            return targetSpeed;
        }
    }
}