using DI;
using LevelBuilder;
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

        public GamePlayState(IObjectResolver resolver,LevelInitialaizer levelInitialaize, ITickedServices component)
        {
            _enemySpawner = new EnemySpawner(resolver.Resolve<PoolService<Monster>>(), levelInitialaize);
            _enemyTrackerService = new EnemyTrackerService(levelInitialaize.GetActiveTower(),_enemySpawner.GetEnemies());
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