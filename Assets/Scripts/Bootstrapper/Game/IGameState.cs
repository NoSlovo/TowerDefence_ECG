public interface IGameState : IEnterGameState, IExitGameState
{
   
}

public interface IEnterGameState
{
    public void EnterState();
}

public interface IExitGameState
{
    public void ExitState();
}