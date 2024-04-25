using Enemy;
using Spawners.Factory;

public class BootstrapState : IGameState
{
    private IGameFSM _gameFsm;
    private Monster _enemyPrefab;
    private LevelInitializerComponent _levelInitializerComponent;

    private static ServiceLocator _serviceLocator; //TODO: можно заменить на DIConteiner для разрешения вопроса прокидывания зависимостей в конструкторы

    public BootstrapState(IGameFSM gameFsm, Monster enemyPrefab, LevelInitializerComponent levelInitializerComponent)
    {
        _gameFsm = gameFsm;
        _enemyPrefab = enemyPrefab;
        _levelInitializerComponent = levelInitializerComponent;
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
        var enemyFactory = new EnemyFactoryPool<Monster>(_enemyPrefab, _levelInitializerComponent.EndPoint,20);
        _serviceLocator.RegisterService<EnemyFactoryPool<Monster>>(enemyFactory);
    }

    public void ExitState()
    {
    }
}