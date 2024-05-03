using System;
using System.Collections;
using Cysharp.Threading.Tasks;
using Spawners.Factory;
using UnityEngine;

public class SpawnerEnemy
{
    private float _spawnDelay = 3;
    private Transform _spawnPoint;
    private Transform _endPoint;

    private bool _spawnerWork = false;

    private FactoryPool<Monster> _factoryPool;

    public SpawnerEnemy(FactoryPool<Monster> factoryPool, PointsMovement configuration)
    {
        _factoryPool = factoryPool;
        _spawnPoint = configuration.SpawnPoint;
        _endPoint = configuration.TargetPoint;
    }

    public void Init()
    {
        _spawnerWork = true;
        SpawnEnemy();
    }

    private async void SpawnEnemy()
    {
        var delay = TimeSpan.FromSeconds(_spawnDelay);
        
        while (_spawnerWork)
        {
            await UniTask.Delay(delay);
            InstanceMonster();
        }
    }

    private void InstanceMonster()
    {
        Monster monster = _factoryPool.GetElement();
        monster.transform.position = _spawnPoint.position;
        monster.SetMoveTarget(_endPoint);
    }
}