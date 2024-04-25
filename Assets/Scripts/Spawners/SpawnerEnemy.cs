using System.Collections;
using Spawners.Factory;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private float m_interval = 3;

    private bool _spawnerWork = false;

    private IEnemyFactoryPool EnemyFactoryPool => ServiceLocator.Instance.GetService<IEnemyFactoryPool>();

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
        var monster = EnemyFactoryPool.GetEnemy();
        monster.transform.position = transform.position;
    }
}