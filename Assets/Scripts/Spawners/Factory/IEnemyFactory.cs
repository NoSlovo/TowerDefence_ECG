namespace Spawners.Factory
{
    public interface IEnemyFactory : IService
    {
        public Monster Create();
    }
}