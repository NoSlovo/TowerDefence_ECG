namespace Enemy
{
    public interface IPolElement : IEnemy,IEnemyMove
    {
        public void SwitchActiveState(bool value);
        
    }
}