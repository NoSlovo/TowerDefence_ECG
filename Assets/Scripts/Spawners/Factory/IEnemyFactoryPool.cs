namespace Spawners.Factory
{
    public interface IEnemyFactoryPool : IService
    {
        public Monster GetEnemy();
    }
}