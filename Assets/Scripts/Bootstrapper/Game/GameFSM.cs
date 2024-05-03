using System;
using System.Collections;
using System.Collections.Generic;
using Bootstrapper.Game.GameStates;
using DI;
using VContainer;

public class GameFSM : IGameFSM, ICoroutineRunner
{
    private Dictionary<Type, IGameState> _gameStates;

    public GameFSM(ProjectContext projectContext)
    {
        _gameStates = new Dictionary<Type, IGameState>()
        {
            [typeof(BuildLevelState)] = new BuildLevelState(projectContext.Container.Resolve<LevelBuilderComponent>(), this),
            [typeof(SpawnEnemyState)] = new SpawnEnemyState(projectContext),
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