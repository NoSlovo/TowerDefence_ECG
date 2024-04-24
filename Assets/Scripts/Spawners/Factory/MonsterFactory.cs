using UnityEngine;

namespace Spawners.Factory
{
    public class MonsterFactory : IEnemyFactory
    {
        private Monster _monsterPrefab;
        private Transform _targetPoint;

        public MonsterFactory(Monster enemyPrefab,Transform targetPoint)
        {
            _monsterPrefab = enemyPrefab;
            _targetPoint = targetPoint;
        }
        
        public Monster Create()
        {
            var enemy =  Object.Instantiate(_monsterPrefab);
            enemy.MovementComponent.SetMovePoint(_targetPoint.position);
            return enemy;
        }
    }
}