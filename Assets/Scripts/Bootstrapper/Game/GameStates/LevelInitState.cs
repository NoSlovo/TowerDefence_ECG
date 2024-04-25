using LevelInitialaizer;

public class LevelInitState : IGameState 
{
    private ILevelInitializer _levelInitializerComponent;

    public LevelInitState(ILevelInitializer levelInitializerComponent)
    {
        _levelInitializerComponent = levelInitializerComponent.LevelPrefab;
    }

    public void EnterState() => _levelInitializerComponent.InitLevel();

    public void ExitState(){}
}