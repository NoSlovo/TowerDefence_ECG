public interface IGameFSM
{
    public void EnterState<T>() where T : IGameState;
}