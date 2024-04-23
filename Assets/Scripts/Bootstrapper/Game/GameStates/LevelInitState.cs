using Spawners.Factory;
using UnityEngine;

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
        var level = GameObject.Instantiate(_levelPrefab);
        var enemyFactory = new MonsterFactory(_enemyPrefab, level.endPointlevel);
        ServiceLocator.Instance.RegisterService<IEnemyFactory>(enemyFactory);
        level.Init();
    }

    public void ExitState(){}
}