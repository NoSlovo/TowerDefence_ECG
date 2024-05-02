using Bootstrapper.Game.GameStates;
using LevelInitialaizer;

public class BuildLevelState : IGameState
{
    private IGameFSM _game;
    private ILevelBuilder _levelBuilder;

    public BuildLevelState(ILevelBuilder levelInitializerComponent, IGameFSM game)
    {
        _levelBuilder = levelInitializerComponent;
        _game = game;
    }

    public void EnterState()
    {
        _levelBuilder.Build();
        _game.EnterState<SpawnEnemyState>();
    }
}