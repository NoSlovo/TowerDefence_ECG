using UnityEngine;

namespace Tower
{
    public class CannonTower : BaseTower
    {
        [SerializeField] private Transform _turretHead;
        [SerializeField] private float _turnSpeed = 5f;

        private float _angle = 10f;

        public void Update()
        {
            if (IsShooting)
                RotateTurret(Target.transform.position);
        }

        private void RotateTurret(Vector3 targetPosition)
        {
            Vector3 targetVelocity = Target.GetComponent<Rigidbody>().velocity;
            Vector3 predictedTargetPosition = PredictPosition(targetPosition, targetVelocity);
            RotationTurrentHead(predictedTargetPosition);
        }

        private Vector3 PredictPosition(Vector3 targetPosition, Vector3 targetVelocity)
            => targetPosition + targetVelocity * Time.deltaTime;


        private void RotationTurrentHead(Vector3 targetPosition)
        {
            var targetRotation = GetTargetRotation(targetPosition, out var angleToTarget);

            if (angleToTarget < _angle)
            {
                _turretHead.rotation =
                    Quaternion.RotateTowards(_turretHead.rotation, targetRotation, _turnSpeed * Time.deltaTime);
                Shoot();
            }
            else
                _turretHead.rotation =
                    Quaternion.RotateTowards(_turretHead.rotation, targetRotation, _turnSpeed * Time.deltaTime);
        }

        private Quaternion GetTargetRotation(Vector3 targetPosition, out float angleToTarget)
        {
            Vector3 directionToPredictedPosition = targetPosition - _turretHead.position;
            Quaternion targetRotation = Quaternion.LookRotation(directionToPredictedPosition);
            angleToTarget = Vector3.Angle(_turretHead.forward, directionToPredictedPosition);
            return targetRotation;
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