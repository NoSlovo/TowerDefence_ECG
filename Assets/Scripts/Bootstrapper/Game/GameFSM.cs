using System;
using System.Collections;
using System.Collections.Generic;
using Bootstrapper.Game.GameStates;
using UnityEngine;

public class GameFSM : MonoBehaviour, IGameFSM, ICoroutineRunner
{
    [SerializeField] private LevelBuilderComponent _levelPrefab;
    [SerializeField] private EnemyMovementConfiguration _enemyMovementConfiguration;
    [SerializeField] private Monster _monster;

    private Dictionary<Type, IGameState> _gameStates;

    private void Awake()
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

    private void Start() => EnterState<BootstrapState>();


    public void EnterState<T>() where T : IEnterGameState
    {
        var gameState = _gameStates[typeof(T)];
        gameState.EnterState();
    }

    public void Run(IEnumerator coroutine) => StartCoroutine(coroutine);
}