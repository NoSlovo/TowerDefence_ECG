using System.Collections.Generic;
using UnityEngine;

namespace Spawners.Factory
{
    public class MonsterFactoryPoolPoll : IEnemyFactoryPool
    {
        private Monster _monsterPrefab;
        private Transform _targetPoint;

        private List<Monster> _poolMonsters;


        public MonsterFactoryPoolPoll(Monster enemyPrefab, Transform targetPoint, int enemyCount)
        {
            _monsterPrefab = enemyPrefab;
            _targetPoint = targetPoint;
            _poolMonsters = new List<Monster>(enemyCount);
            InitPool(enemyCount);
        }

        private void InitPool(int countEnemyOnPool)
        {
            for (int i = 0; i < countEnemyOnPool; i++)
            {
               var enemy = CreateEnemy();
               _poolMonsters.Add(enemy);
            }
        }

        public Monster GetEnemy()
        {
            var enemy = SearchDeadEnemy();
            enemy.OnDead += EnemyRemove;
            enemy.SwitchActiveState(true);
            enemy.SetTarget(_targetPoint);
            return enemy;
        }

        private Monster SearchDeadEnemy()
        {
            for (int i = 0; i < _poolMonsters.Count; i++)
            {
                if (!_poolMonsters[i].IsAlive)
                    return _poolMonsters[i];
            }
            var newEnemy = CreateEnemy();
            _poolMonsters.Add(newEnemy);
            return newEnemy;
        }

        private Monster CreateEnemy()
        {
            var enemy = Object.Instantiate(_monsterPrefab);
            enemy.SwitchActiveState(false);
            return enemy;
        }

        private void EnemyRemove()
        {
            for (int i = 0; i < _poolMonsters.Count; i++)
            {
                if (!_poolMonsters[i].IsAlive)
                {
                    _poolMonsters[i].SwitchActiveState(false);
                    _poolMonsters[i].OnDead -= EnemyRemove;
                }
            }
        }
    }
}