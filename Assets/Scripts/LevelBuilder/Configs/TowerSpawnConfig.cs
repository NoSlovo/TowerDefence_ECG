using System;
using System.Collections.Generic;
using UnityEngine;

namespace LevelBuilder
{
    [Serializable]
    public struct TowerSpawnConfig
    {
        
        [SerializeField] private List<Transform> _towersSpawnPoints;

        public Vector3 GetPointInstance(int indexPoint)
        {
            if (indexPoint <= _towersSpawnPoints.Count)
                return _towersSpawnPoints[indexPoint].position;
            throw new NullReferenceException();
        }
    }
}