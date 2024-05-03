using DI;
using UnityEngine;
using UnityEngine.Serialization;

namespace Bootstrapper.Game
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private ProjectContext _projectContext;

        private GameFSM _game;

        private void Start()
        {
            _game = new GameFSM(_projectContext);
            _game.EnterState<BuildLevelState>();
            DontDestroyOnLoad(this);
        }
    }
}