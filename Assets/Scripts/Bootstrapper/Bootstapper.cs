using UnityEngine;
using UnityEngine.UI;

public class Bootstapper : MonoBehaviour
{
    private GameFSM _gameStateMashine;
}

public interface IGameState
{
    public void EnterState();
}
