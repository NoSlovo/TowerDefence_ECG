using Bootstrapper.Game.GameStates;
using DI;
using UnityEngine;

namespace Bootstrapper.Game
{
    public class Bootstrapper : MonoBehaviour 
    {
        [SerializeField] private ProjectContext _projectContext;
        [SerializeField] private LevelBuilder.LevelInitialaizer levelInitialaizer;

        private GameStateMashine _game;
        

        private void Start()
        {
            _game = new GameStateMashine(_projectContext,  levelInitialaizer,_projectContext);
            _game.EnterState<LevelInitialaizeState>();
            DontDestroyOnLoad(this);
        }
        
    }
    

}