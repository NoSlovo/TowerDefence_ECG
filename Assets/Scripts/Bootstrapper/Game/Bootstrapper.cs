using DI;
using UnityEngine;

namespace Bootstrapper.Game
{
    public class Bootstrapper : MonoBehaviour 
    {
        [SerializeField] private ProjectContext _projectContext;
        [SerializeField] private PointsMovement pointsMovement;
        [SerializeField] private LevelBuilder levelBuilder;

        private GameFSM _game;
        

        private void Start()
        {
            _game = new GameFSM(_projectContext, pointsMovement, levelBuilder,_projectContext);
            _game.EnterState<BuildLevelState>();
            DontDestroyOnLoad(this);
        }
        
    }
    

}