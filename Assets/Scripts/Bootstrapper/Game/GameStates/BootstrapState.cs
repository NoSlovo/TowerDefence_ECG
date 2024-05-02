using Spawners.Factory;

public class BootstrapState : IGameState
{
    private IGameFSM _gameFsm;
    private Monster _enemyPrefab;

    private static ServiceLocator _serviceLocator; //TODO: можно заменить на DIConteiner для разрешения вопроса прокидывания зависимостей в конструкторы

    public BootstrapState(IGameFSM gameFsm, Monster enemyPrefab)
    {
        _gameFsm = gameFsm;
        _enemyPrefab = enemyPrefab;
    }

    public void EnterState()
    {
        ServiceLocator.Init();
        _serviceLocator = ServiceLocator.Instance;
        RegisterServices();
        _gameFsm.EnterState<BuildLevelState>();
    }

    private void RegisterServices()
    {
        var enemyFactory = new FactoryPool<Monster>(_enemyPrefab,20);
        _serviceLocator.RegisterService<FactoryPool<Monster>>(enemyFactory);
    }
}