using System.Collections;
using Spawners.Factory;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private float m_interval = 3;
    [SerializeField] private Transform m_moveTarget;

    private float m_lastSpawn = -1;
    private bool _spawnerWork = false;

    private IEnemyFactory _enemyFactory => ServiceLocator.Instance.GetService<IEnemyFactory>();

    public void Init()
    {
        _spawnerWork = true;
        StartCoroutine(SpawnEnemy()); 
    }

    private IEnumerator SpawnEnemy()
    {
        while (_spawnerWork)
        {
            yield return new WaitForSeconds(m_interval);
            CreateMonster();
        }
    }

    private void CreateMonster()
    {
        var Enemy = _enemyFactory.Create();
        Enemy.MovementComponent.SetMovePoint(m_moveTarget);
    }
}