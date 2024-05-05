using System;
using System.Collections.Generic;
using Bootstrapper.Game.GameStates;
using DI;

namespace Bootstrapper.Game
{
    public class GameStateMashine : IGameFSM
    {
        private Dictionary<Type, IGameState> _gameStates;

        public GameStateMashine(ProjectContext projectContext, LevelBuilder.LevelCreator levelCreator,
            ITickedServices tickedServices)
        {
            _gameStates = new Dictionary<Type, IGameState>()
            {
                [typeof(BuildLevelState)] = new BuildLevelState(levelCreator, this),
                [typeof(GamePlayState)] = new GamePlayState(projectContext.Container, levelCreator, tickedServices),
            };
        }

        public void EnterState<T>() where T : IEnterGameState
        {
            var gameState = _gameStates[typeof(T)];
            gameState.EnterState();
        }
    }
}