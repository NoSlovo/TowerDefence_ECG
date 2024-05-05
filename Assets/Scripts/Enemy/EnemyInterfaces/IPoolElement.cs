namespace Enemy.EnemyInterfaces
{
    public interface IPoolElement
    {
        public bool IsActive { get; set; }
        public void SwitchActiveState(bool value);
    }
}