using System;
using System.Collections.Generic;
using Bootstrapper.Game.GameStates;
using DI;

public class GameFSM : IGameFSM
{
    private Dictionary<Type, IGameState> _gameStates;

    public GameFSM(ProjectContext projectContext, PointsMovement pointsMovement, LevelBuilder levelBuilder, ITickComponent tickComponent)
    {
        _gameStates = new Dictionary<Type, IGameState>()
        {
            [typeof(BuildLevelState)] = new BuildLevelState(levelBuilder, this),
            [typeof(GamePlayState)] = new GamePlayState(projectContext.Container, pointsMovement,levelBuilder,tickComponent),
        };
    }

    public void EnterState<T>() where T : IEnterGameState
    {
        var gameState = _gameStates[typeof(T)];
        gameState.EnterState();
    }
}