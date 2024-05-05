using DI;
using LevelBuilder.InterfacesBuilding;
using Services.Pool;
using Spawners;
using Towers.EnemyTracker;
using VContainer;

namespace Bootstrapper.Game.GameStates
{
    public class GamePlayState : IGameState
    {
        private EnemySpawner _enemySpawner;
        private EnemyTrackerService _enemyTrackerService;
        private ITickedServices _tickedServices;

        public GamePlayState(IObjectResolver resolver,ILevelBuilder builder, ITickedServices component)
        {
            _enemySpawner = new EnemySpawner(resolver.Resolve<PoolService<Monster>>(), builder);
            _enemyTrackerService = new EnemyTrackerService(builder.GetActiveTower(),_enemySpawner.GetEnemies());
            _tickedServices = component;
        }

        public void EnterState()
        {
            _enemySpawner.Initialize();
            _enemyTrackerService.Init();
            _tickedServices.AddTickService(_enemyTrackerService);
        }
    }
}