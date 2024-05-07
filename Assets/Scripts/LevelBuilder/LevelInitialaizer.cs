using System;
using System.Collections.Generic;
using LevelBuilder.Configs;
using LevelBuilder.InterfacesBuilding;
using Towers;
using UnityEngine;
using Object = UnityEngine.Object;

namespace LevelBuilder
{
    [Serializable]
    public class LevelInitialaizer : ILevelBuilder
    {
        [SerializeField] private List<BaseTower> _towersPrefabs;
        [SerializeField] private TowerSpawnConfig _towerSpawnConfig;
        [SerializeField] private GameObject _groundPrefab;
        [SerializeField] private Transform _groundPointInstance;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Transform _targetPoint;

        public Transform EndPoint => _targetPoint;
        public Transform ShowPoint => _spawnPoint;


        private int itemIndex = 0;

        private List<BaseTower> _activeTowers = new List<BaseTower>();


        public void Build()
        {
            BuildTowers();
            BuildPlayfield();
        }


        private void BuildTowers()
        {
            foreach (var tower in _towersPrefabs)
            {
                var instanceTower = Object.Instantiate(tower);
                instanceTower.transform.position = _towerSpawnConfig.GetPointInstance(itemIndex);
                instanceTower.Initialize();
                _activeTowers.Add(instanceTower);
                itemIndex++;
            }
        }

        private void BuildPlayfield()
        {
            var playfield = Object.Instantiate(_groundPrefab);
            playfield.transform.position = _groundPointInstance.position;
        }

        public List<BaseTower> GetActiveTower()
        {
            var clone = _activeTowers;
            return clone;
        }
    }
}