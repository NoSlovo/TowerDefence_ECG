using DI;
using Spawners.Factory;
using VContainer;

namespace Bootstrapper.Game.GameStates
{
    public class SpawnEnemyState : IGameState
    {
        private SpawnerEnemy _spawnerEnemy;

        public SpawnEnemyState(ProjectContext context)
        {
            _spawnerEnemy = new SpawnerEnemy
            (
                context.Container.Resolve<FactoryPool<Monster>>(),
                context.Container.Resolve<PointsMovement>()
            );
        }

        public void EnterState() => _spawnerEnemy.Init();
    }
}