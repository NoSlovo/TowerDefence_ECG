using System;
using System.Collections.Generic;
using UnityEngine;

public class GameFSM : MonoBehaviour, IGameFSM
{
    [SerializeField] private LevelInitializerComponent _levelPrefab;
    [SerializeField] private Monster _monster;

    private Dictionary<Type, IGameState> _gameStates;

    private IGameState _lastState;

    private void Awake()
    {
        _gameStates = new Dictionary<Type, IGameState>()
        {
            [typeof(BootstrapState)] = new BootstrapState(this, _monster, _levelPrefab),
            [typeof(LevelInitState)] = new LevelInitState(_levelPrefab),
        };
    }

    private void Start() => EnterState<BootstrapState>();
    
    
    public void EnterState<T>() where T : IEnterGameState
    {
        _lastState?.ExitState();
        var gameState = _gameStates[typeof(T)];
        gameState.EnterState();
        _lastState = gameState;
    }
}