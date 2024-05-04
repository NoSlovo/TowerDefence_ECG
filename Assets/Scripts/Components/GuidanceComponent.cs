using UnityEngine;


namespace Components
{
    public class GuidanceComponent
    {
        private Transform _guidanceObject;
        private float _angle;
        private float _turnSpeed;

        public bool LookTarget { get; private set; } = false;

        public GuidanceComponent(Transform guidanceObject, float angle,float turnSpeed)
        {
            _guidanceObject = guidanceObject;
            _angle = angle;
            _turnSpeed = turnSpeed;
        }

        public void RotateTurret(Transform target, Vector3 targetPosition)
        {
            if (target != null)
            {
                Vector3 targetVelocity = target.GetComponent<Rigidbody>().velocity;
                Vector3 predictedTargetPosition = PredictPosition(targetPosition, targetVelocity);
                Aiming(predictedTargetPosition,_turnSpeed);
            }
        }

        private Vector3 PredictPosition(Vector3 targetPosition, Vector3 targetVelocity)
            => targetPosition + targetVelocity * Time.deltaTime;


        private void Aiming(Vector3 targetPosition, float turnSpeed)
        {
            var targetRotation = GetTargetRotation(targetPosition, out var angleToTarget);

            if (angleToTarget < _angle)
            {
                _guidanceObject.rotation =
                    Quaternion.RotateTowards(_guidanceObject.rotation, targetRotation, turnSpeed * Time.deltaTime);
                LookTarget = true;
            }
            else
            {
                _guidanceObject.rotation =
                    Quaternion.RotateTowards(_guidanceObject.rotation, targetRotation, turnSpeed * Time.deltaTime);
                LookTarget = false;
            }
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