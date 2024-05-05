using Bootstrapper.Game.GameStates;
using LevelInitialaizer;

public class BuildLevelState : IGameState
{
    private IGameFSM _game;
    private ILevelBuilder _levelBuilder;

    public BuildLevelState(ILevelBuilder levelBuilder, IGameFSM game)
    {
        _levelBuilder = levelBuilder;
        _game = game;
    }

    public void EnterState()
    {
        _levelBuilder.Build();
        _game.EnterState<GamePlayState>();
    }
}