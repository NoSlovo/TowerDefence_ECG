using UnityEngine;

namespace Bootstrapper.Game
{
    public class EntryPoint : MonoBehaviour
    {
        private GameFSM _game;

        private void Start()
        {
           // _game = new GameFSM();
            _game.EnterState<BootstrapState>();
            DontDestroyOnLoad(this);
        }
    }
}