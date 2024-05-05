using System;
using Components;
using Enemy;
using UnityEngine;

namespace Towers.CannonTower
{
    public class CannonTower : BaseTower
    {
        [SerializeField] private Transform _turretHead;
        [SerializeField] private float _turnSpeed = 5f;

        private Follower _follower;

        private void Start() => _follower = new Follower(_turretHead, _angle, _turnSpeed);


        private float _angle = 10f;

        private void Update()
        {
            if (!HasTarget)
                return;

            FollowTarget();
        }

        private void FollowTarget() => _follower.RotateTurret(Target.Transform.position);

        public override void SetTarget(IEnemy target)
        {
            _follower.SetTarget(target.Transform);
            base.SetTarget(target);
        }
    }
}