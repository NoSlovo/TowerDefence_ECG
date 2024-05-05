using Enemy;
using Services.FollowTarget;
using UnityEngine;

namespace Towers.CannonTower
{
    public class CannonTower : BaseTower
    {
        [SerializeField] private Transform _cannonTransform;
        [SerializeField] private float _turningSpeed = 150f;

        private FollowerService _followerService;

        private float _angle = 10f;

        public override void Initialize()
        {
            _followerService = new FollowerService(_cannonTransform, _angle, _turningSpeed);
            base.Initialize();
        }


        private void Update()
        {
            if (!HasTarget)
                return;

            FollowTarget();
        }

        private void FollowTarget() => _followerService.RotateTurret(Target.Transform.position);

        public override void SetTarget(IEnemy target)
        {
            _followerService.SetTarget(target.Transform);
            base.SetTarget(target);
        }
    }
}