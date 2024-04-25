using Spawners.Factory;

public class BootstraperState : IGameState
{
    private IGameFSM _gameFsm;
    private Monster _enemyPrefab;
    private LevelIniter _levelIniter;

    private static ServiceLocator _serviceLocator;

    public BootstraperState(IGameFSM gameFsm, Monster enemyPrefab, LevelIniter levelIniter)
    {
        _gameFsm = gameFsm;
        _enemyPrefab = enemyPrefab;
        _levelIniter = levelIniter;
    }

    public void EnterState()
    {
        ServiceLocator.Init();
        _serviceLocator = ServiceLocator.Instance;
        RegisterServices();
        _gameFsm.EnterState<LevelInitState>();
    }

    private void RegisterServices()
    {
        var enemyFactory = new MonsterFactoryPoolPoll(_enemyPrefab, _levelIniter.endPointlevel,20);
        _serviceLocator.RegisterService<IEnemyFactoryPool>(enemyFactory);
    }

    public void ExitState()
    {
    }
}