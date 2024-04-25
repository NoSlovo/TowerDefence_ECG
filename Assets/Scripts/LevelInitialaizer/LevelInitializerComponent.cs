using System;
using System.Collections.Generic;
using LevelInitialaizer;
using Tower;
using UnityEngine;

[Serializable]
public class LevelInitializerComponent : MonoBehaviour , ILevelInitializer
{
    [SerializeField] private Transform _endPoint;
    [SerializeField] private SpawnerEnemy _spawnerEnemy;
    [SerializeField] private List<BaseTower> _towers;
    public Transform EndPoint => _endPoint;

    public ILevelInitializer LevelPrefab
    {
        get => Instantiate(this);
        set
        {
        }
    }

    public void InitLevel()
    {
        _spawnerEnemy.Init();
        InitTowers();
    }

    private void InitTowers()
    {
        foreach (var tower in _towers)
        {
            tower.Init();
        }
    }
}