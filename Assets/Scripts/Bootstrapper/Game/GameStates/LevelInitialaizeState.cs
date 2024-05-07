using LevelBuilder;

namespace Bootstrapper.Game.GameStates
{
    public class LevelInitialaizeState : IGameState
    {
        private IGameFSM _game;
        private LevelInitialaizer _levelInitialaizer;

        public LevelInitialaizeState(LevelInitialaizer levelInitialaizer, IGameFSM game)
        {
            _levelInitialaizer = levelInitialaizer;
            _game = game;
        }

        public void EnterState()
        {
            _levelInitialaizer.InstacnePlayfield();
            _levelInitialaizer.InstacneTowers();
            _game.EnterState<GamePlayState>();
        }
    }
}