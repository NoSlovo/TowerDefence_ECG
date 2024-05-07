using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using LevelBuilder;
using Services.Pool;
using UnityEngine;

namespace Spawners
{
    public class EnemySpawner
    {
        private float _spawnDelay = 3;
        private Transform _showPoint;
        private Transform _endPoint;

        private bool _isActive = false;

        private PoolService<Monster> _poolService;

        public EnemySpawner(PoolService<Monster> poolService, LevelInitialaizer levelCreator)
        {
            _poolService = poolService;
            _showPoint = levelCreator.ShowPoint;
            _endPoint = levelCreator.EndPoint;
        }

        public void Initialize()
        {
            ShowEnemy();
        }

        private async void ShowEnemy()
        {
            var delay = TimeSpan.FromSeconds(_spawnDelay);
            _isActive = true;

            while (_isActive)
            {
                await UniTask.Delay(delay);
                CreateEnemy();
            }
        }

        private void CreateEnemy()
        {
            Monster enemy = _poolService.GetElement();
            enemy.transform.position = _showPoint.position;
            enemy.SetMoveTarget(_endPoint);
        }

        public Stack<Monster> GetEnemies()
        {
            Stack<Monster> copy = _poolService.GetPoolElements();
            return copy;
        }
    }
}