using UnityEngine;

namespace Tower
{
    public class CannonTower : BaseTower
    {
        [SerializeField] private Transform _turretHead;
        [SerializeField] private float _turnSpeed = 5f;

        void Update()
        {
            if (IsShooting)
                RotateTurret(Target.transform.position);
        }

        private void RotateTurret(Vector3 targetPosition)
        {
            Vector3 targetVelocity = Target.GetComponent<Rigidbody>().velocity;
            Vector3 predictedTargetPosition = PredictPosition(targetPosition, targetVelocity);
            RotationTower(predictedTargetPosition);
        }

        private Vector3 PredictPosition(Vector3 targetPosition, Vector3 targetVelocity)
        {
            return targetPosition + targetVelocity * Time.deltaTime;
        }

        private void RotationTower(Vector3 targetPosition)
        {
            Vector3 directionToPredictedPosition = targetPosition - _turretHead.position;
            Quaternion targetRotation = Quaternion.LookRotation(directionToPredictedPosition);
            _turretHead.rotation =
                Quaternion.RotateTowards(_turretHead.rotation, targetRotation, _turnSpeed * Time.deltaTime);
            Shoot();
        }

        public override void Shoot()
        {
            ShootInterval -= Time.deltaTime;
           if (ShootInterval <= 0)
           {
               ShootInterval = 0.5f;
               ShotComponent.ShootToTarget(Target.transform);
           }
        }
    }
}