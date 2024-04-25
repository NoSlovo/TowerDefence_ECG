using System.Collections.Generic;
using Enemy;
using UnityEngine;

namespace Spawners.Factory
{
    public class EnemyFactoryPool<T> : IService where T : MonoBehaviour, IPolElement
    {
        private T _enemyPrefab;
        private Transform _targetPoint;
        private Stack<T> _poolMonsters;


        public EnemyFactoryPool(T enemyPrefab, Transform targetPoint, int enemyCount)
        {
            _enemyPrefab = enemyPrefab;
            _targetPoint = targetPoint;
            _poolMonsters = new Stack<T>(enemyCount);
            InitPool(enemyCount);
        }

        public T GetEnemy()
        {
            var enemy = GetMonster();
            enemy.OnDead += EnemyRemove;
            enemy.SwitchActiveState(true);
            enemy.SetTarget(_targetPoint);
            return enemy;
        }

        private void InitPool(int countEnemyOnPool)
        {
            for (int i = 0; i < countEnemyOnPool; i++)
            {
                var enemy = CreateEnemy();
                _poolMonsters.Push(enemy);
            }
        }


        private T CreateEnemy()
        {
            var enemy = Object.Instantiate(_enemyPrefab);
            enemy.SwitchActiveState(false);
            return enemy;
        }

        private T GetMonster()
        {
            foreach (var monster in _poolMonsters)
            {
                if (!monster.IsAlive)
                    return monster;
            }

            var newEnemy = CreateEnemy();
            _poolMonsters.Push(newEnemy);
            return newEnemy;
        }


        private void EnemyRemove()
        {
            foreach (var monster in _poolMonsters)
            {
                if (!monster.IsAlive)
                {
                    monster.SwitchActiveState(false);
                    monster.OnDead -= EnemyRemove;
                }
            }
        }
    }
}