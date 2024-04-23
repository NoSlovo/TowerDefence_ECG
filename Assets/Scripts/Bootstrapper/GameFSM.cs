using System;
using System.Collections.Generic;

public class GameFSM
{
    private IGameState _
    private Dictionary<Type, IGameState> _gameStates = new Dictionary<Type, IGameState>()
    {
        
    };

    public void EnterState<T>( T gameState) where T : IGameState
    {
        
    }
}