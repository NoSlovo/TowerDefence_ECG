using System.Collections.Generic;
using DI;
using Enemy;
using UnityEngine;

namespace Towers.EnemyTracker
{
    public class EnemyTrackerService : ITickService
    {
        private Stack<Monster> _enemies;
        private List<BaseTower> _towers;

        private EnemyShooterService _enemyShooterService;

        private bool _heWorks = false;

        public EnemyTrackerService(List<BaseTower> activeTowers, Stack<Monster> enemies)
        {
            _towers = activeTowers;
            _enemies = enemies;
        }

        public void Init()
        {
            _heWorks = true;
            _enemyShooterService = new EnemyShooterService(_towers);
        }

        public void Tick()
        {
            if (!_heWorks)
                return;

            SetTowerTarget();
            _enemyShooterService.Tick();
        }

        private void SetTowerTarget()
        {
            foreach (var tower in _towers)
            {
                if (tower.HasTarget)
                    continue;

                var newTarget = GetClosetTarget(tower);

                if (newTarget != null && newTarget.IsActive)
                    tower.SetTarget(newTarget);
            }
        }

        private IEnemy GetClosetTarget(BaseTower tower)
        {
            var minDistance = float.MaxValue;

            foreach (var enemy in _enemies)
            {
                var dist = Vector3.Distance(tower.Position, enemy.Transform.position);

                if (dist > tower.AttackRange)
                    continue;

                if (dist > minDistance)
                    continue;

                minDistance = dist;
                return enemy;
            }

            return null;
        }
    }
}