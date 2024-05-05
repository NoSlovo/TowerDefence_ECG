using UnityEngine;

namespace Services.FollowTarget
{
    public class FollowerService
    {
        private Transform _guidanceObject;
        private float _angle;
        private float _turnSpeed;

        public bool HasLocked { get; private set; } = false;
        private Rigidbody _rb; 
        
        public FollowerService(Transform guidanceObject, float angle, float turnSpeed)
        {
            _guidanceObject = guidanceObject;
            _angle = angle;
            _turnSpeed = turnSpeed;
        }

        public void SetTarget(Transform target)
        {
            _rb = target.GetComponent<Rigidbody>();
        }
        
        public void RotateTurret(Vector3 targetPosition)
        {
            Vector3 targetVelocity = _rb.velocity;
            Vector3 predictedTargetPosition = PredictPosition(targetPosition, targetVelocity);
            Aiming(predictedTargetPosition, _turnSpeed);
        }

        private Vector3 PredictPosition(Vector3 targetPosition, Vector3 targetVelocity) =>
            targetPosition + targetVelocity * Time.deltaTime;


        private void Aiming(Vector3 targetPosition, float turnSpeed)
        {
            var targetRotation = GetTargetRotation(targetPosition, out var angleToTarget);
            Rotate(targetRotation, turnSpeed * Time.deltaTime);
            HasLocked = angleToTarget < _angle;
        }

        private void Rotate(Quaternion targetRotation, float turnSpeed)
        {
            _guidanceObject.rotation = Quaternion.RotateTowards(_guidanceObject.rotation, targetRotation, turnSpeed);
        }

        private Quaternion GetTargetRotation(Vector3 targetPosition, out float angleToTarget)
        {
            Vector3 directionToPredictedPosition = targetPosition - _guidanceObject.position;
            Quaternion targetRotation = Quaternion.LookRotation(directionToPredictedPosition);
            angleToTarget = Vector3.Angle(_guidanceObject.forward, directionToPredictedPosition);
            return targetRotation;
        }
    }
}