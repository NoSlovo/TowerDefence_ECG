using System;
using System.Collections;
using Bootstrapper.Game.GameStates;
using Spawners.Factory;
using UnityEngine;

public class SpawnerEnemy
{
    private float _spawnDelay = 3;
    private Transform _spawnPoint;
    private Transform _endPoint;

    private bool _spawnerWork = false;
    private ICoroutineRunner _coroutineRunner;

    private FactoryPool<Monster> FactoryPool =>
        ServiceLocator.Instance.GetService<FactoryPool<Monster>>();

    public SpawnerEnemy(ICoroutineRunner coroutineRunner, Transform spawnPoint, Transform endPoint)
    {
        _coroutineRunner = coroutineRunner;
        _spawnPoint = spawnPoint;
        _endPoint = endPoint;
    }

    public void Init()
    {
        _spawnerWork = true;
        _coroutineRunner.Run(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy() 
    {
        while (_spawnerWork)
        {
            yield return new WaitForSeconds(_spawnDelay);
            InstanceMonster();
        }
    }

    private void InstanceMonster()
    {
        Monster monster = FactoryPool.GetElement();
        monster.transform.position = _spawnPoint.position;
        monster.SetMoveTarget(_endPoint);
    }
}