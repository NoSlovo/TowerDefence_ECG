using DI;
using LevelInitialaizer;
using Services.Factory;
using Towers.EnemyTracker;
using VContainer;

namespace Bootstrapper.Game.GameStates
{
    public class GamePlayState : IGameState
    {
        private EnemySpawner _enemySpawner;
        private EnemyTrackerService _enemyTrackerService;
        private ITickComponent _tickComponent;

        public GamePlayState(IObjectResolver resolver, PointsMovement pointsMovement,ILevelBuilder builder, ITickComponent component)
        {
            _enemySpawner = new EnemySpawner(resolver.Resolve<FactoryPool<Monster>>(), pointsMovement);
            _enemyTrackerService = new EnemyTrackerService(builder.GetActiveTower(),_enemySpawner.GetEnemies());
            _tickComponent = component;
        }

        public void EnterState()
        {
            _enemySpawner.Init();
            _enemyTrackerService.Init();
            _tickComponent.AddTickService(_enemyTrackerService);
        }
    }
}