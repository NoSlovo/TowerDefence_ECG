using System.Collections.Generic;
using LevelInitialaizer;
using Tower;
using UnityEngine;

public class LevelBuilderComponent : MonoBehaviour, ILevelBuilder
{
    [SerializeField] private List<BaseTower> _towers;
    [SerializeField] private LevelConfig _levelConfig;
    [SerializeField] private GameObject _groundPrefab;
    [SerializeField] private Transform _groundInstancePoint;

    public void Build()
    {
        BuildTowers();
        BuildGround();
    }

    private void BuildTowers()
    {
        for (int i = 0; i < _towers.Count; i++)
        {
            var instanceTower = Instantiate(_towers[i]);
            instanceTower.transform.position = _levelConfig.GetTowerPoint(i);
            instanceTower.InitTowers();
        }
    }

    private void BuildGround()
    {
        var instanceGround = Instantiate(_groundPrefab);
        instanceGround.transform.position = _groundInstancePoint.position;
    }
}