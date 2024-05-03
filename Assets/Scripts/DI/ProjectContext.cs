using Bootstrapper.Game;
using Spawners.Factory;
using UnityEngine;
using UnityEngine.Serialization;
using VContainer;
using VContainer.Unity;

namespace DI
{
    public class ProjectContext : LifetimeScope
    {
        [SerializeField] private Monster _enemyPrefab;
        [SerializeField] private PointsMovement pointsMovement;
        [SerializeField] private LevelBuilderComponent _levelBuilderComponent;

        private int _enemyCount = 20;

        protected override void Configure(IContainerBuilder builder)
        {
            RegisterEntryPoint(builder);
            RegisterComponents(builder);
            RegisterServices(builder);
        }

        private static void RegisterEntryPoint(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<EntryPoint>();
            builder.Register<GameFSM>(Lifetime.Singleton);
        }

        private void RegisterServices(IContainerBuilder builder)
        {
            builder.Register<FactoryPool<Monster>>(Lifetime.Singleton)
                .WithParameter(_enemyPrefab)
                .WithParameter(_enemyCount);
        }

        private void RegisterComponents(IContainerBuilder builder)
        {
            builder.RegisterComponent(pointsMovement);
            builder.RegisterComponent(_levelBuilderComponent);
        }
    }
}