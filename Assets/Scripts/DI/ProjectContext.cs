using System;
using System.Collections.Generic;
using Services.Pool;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace DI
{
    public class ProjectContext : LifetimeScope , ITickedServices
    {
        [SerializeField] private Monster _enemyPrefab;

        private const int _defaultValue = 10;

        private List<ITickService> _tickServices = new List<ITickService>();
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<PoolService<Monster>>(Lifetime.Singleton)
                .WithParameter(_enemyPrefab)
                .WithParameter(_defaultValue);
        }

        public void Update()
        {

            foreach (var service in _tickServices)
            {
                service.Tick();
            }
            
        }

        public void AddTickService(ITickService service)
        {
            _tickServices.Add(service);
        }
    }
}