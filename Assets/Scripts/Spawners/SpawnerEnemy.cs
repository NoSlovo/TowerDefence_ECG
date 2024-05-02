using System.Collections;
using Spawners.Factory;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private float _сreationDelay = 3;
    [SerializeField] private Transform  _endPoint;
    
    private bool _spawnerWork = false;

    private FactoryPool<Monster> FactoryPool =>
        ServiceLocator.Instance.GetService<FactoryPool<Monster>>();

    public void Init()
    {
        _spawnerWork = true;
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()//TODO : Можно заменить на UniTask для отвязывания от MonoBeheviour
    {
        while (_spawnerWork)
        {
            yield return new WaitForSeconds(_сreationDelay);
            InstanceMonster();
        }
    }

    private void InstanceMonster()
    {
        Monster monster = FactoryPool.GetElement();
        monster.transform.position = transform.position;
        monster.SetMoveTarget(_endPoint);
    }
}