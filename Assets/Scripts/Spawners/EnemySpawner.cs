using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Enemy;
using Services.Factory;
using UnityEngine;

public class EnemySpawner
{
    private float _spawnDelay = 3;
    private Transform _spawnPoint;
    private Transform _endPoint;

    private bool _isActive = false;

    private FactoryPool<Monster> _factoryPool;

    public EnemySpawner(FactoryPool<Monster> factoryPool, PointsMovement configuration)
    {
        _factoryPool = factoryPool;
        _spawnPoint = configuration.SpawnPoint;
        _endPoint = configuration.TargetPoint;
    }

    public void Init()
    {
        SpawnEnemy();
    }

    private async void SpawnEnemy()
    {
        var delay = TimeSpan.FromSeconds(_spawnDelay);
        _isActive = true;

        while (_isActive)
        {
            await UniTask.Delay(delay);
            InstantiateEnemy();
        }
    }

    private void InstantiateEnemy()
    {
        Monster enemy = _factoryPool.GetElement();
        enemy.transform.position = _spawnPoint.position;
        enemy.SetMoveTarget(_endPoint);
    }

    public Stack<Monster> GetEnemies()
    {
        Stack<Monster> copy = _factoryPool.GetPoolElements();
        return copy;
    }
}