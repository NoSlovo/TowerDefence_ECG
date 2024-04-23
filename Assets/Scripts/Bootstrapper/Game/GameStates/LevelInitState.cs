using System;
using Spawners.Factory;
using Object = UnityEngine.Object;

public class LevelInitState : IGameState
{
    private LevelIniter _levelPrefab;
    private Monster _enemyPrefab;

    public LevelInitState(LevelIniter levelPrefab, Monster enemyPrefab)
    {
        _levelPrefab = levelPrefab;
        _enemyPrefab = enemyPrefab;
    }

    public void EnterState()
    {
        var level = Object.Instantiate(_levelPrefab);
        var enemyFactory = new MonsterFactory(_enemyPrefab, level.endPointlevel);
        ServiceLocator.Instance.RegisterService<IEnemyFactory>(enemyFactory);
    }

    public void ExitState()
    {
        throw new NotImplementedException();
    }
}