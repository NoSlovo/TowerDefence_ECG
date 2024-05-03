using System;
using System.Collections;
using System.Collections.Generic;
using Bootstrapper.Game.GameStates;
using UnityEngine;

public class GameFSM :  IGameFSM, ICoroutineRunner
{
     private LevelBuilderComponent _levelPrefab;
     private EnemyMovementConfiguration _enemyMovementConfiguration;
     private Monster _monster;

     private Dictionary<Type, IGameState> _gameStates;

    public GameFSM(LevelBuilderComponent levelPrefab, EnemyMovementConfiguration enemyMovementConfiguration,
        Monster monster)
    {
        _gameStates = new Dictionary<Type, IGameState>()
        {
            [typeof(BootstrapState)] = new BootstrapState(this, _monster),
            [typeof(BuildLevelState)] = new BuildLevelState(_levelPrefab,this),
            [typeof(SpawnEnemyState)] = new SpawnEnemyState
            (this,
                _enemyMovementConfiguration.SpawnPoint,
                _enemyMovementConfiguration.TargetPoint
            ),
        };
    }

    public void EnterState<T>() where T : IEnterGameState
    {
        var gameState = _gameStates[typeof(T)];
        gameState.EnterState();
    }

    public void Run(IEnumerator coroutine)
    {
        throw new NotImplementedException();
    }
}