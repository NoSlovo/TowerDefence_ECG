

public class BootstraperState : IGameState
{
    private IGameFSM _gameFsm;
    
    private static ServiceLocator _serviceLocator;

    public BootstraperState(IGameFSM gameFsm)
    {
        _gameFsm = gameFsm;
    }
    
    public void EnterState()
    {
        ServiceLocator.Init();
        _serviceLocator = ServiceLocator.Instance;
       _gameFsm.EnterState<LevelInitState>();
    }

    public void ExitState()
    {
        throw new System.NotImplementedException();
    }
}