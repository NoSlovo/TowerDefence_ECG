﻿using Bootstrapper.Game.GameStates;
using LevelInitialaizer;
using VContainer;

public class BuildLevelState : IGameState
{
    private IGameFSM _game;
    private ILevelBuilder _levelBuilder;
    
    [Inject]
    public BuildLevelState(ILevelBuilder levelBuilder, IGameFSM game)
    {
       this._levelBuilder = levelBuilder;
        _game = game;
    }

    public void EnterState()
    {
        _levelBuilder.Build();
        _game.EnterState<SpawnEnemyState>();
    }
}