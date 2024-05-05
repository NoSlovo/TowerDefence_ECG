using DI;
using UnityEngine;

namespace Bootstrapper.Game
{
    public class Bootstrapper : MonoBehaviour 
    {
        [SerializeField] private ProjectContext _projectContext;
        [SerializeField] private LevelBuilder.LevelCreator levelCreator;

        private GameStateMashine _game;
        

        private void Start()
        {
            _game = new GameStateMashine(_projectContext,  levelCreator,_projectContext);
            _game.EnterState<BuildLevelState>();
            DontDestroyOnLoad(this);
        }
        
    }
    

}