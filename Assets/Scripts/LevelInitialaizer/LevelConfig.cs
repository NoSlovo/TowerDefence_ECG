using System;
using System.Collections.Generic;
using UnityEngine;

namespace LevelInitialaizer
{
    public class LevelConfig : MonoBehaviour
    {
        [SerializeField] private List<Transform> _towersSpawnPoints;

        public Vector3 GetTowerPoint(int _pointIndex)
        {
            if (_pointIndex <= _towersSpawnPoints.Count)
                return _towersSpawnPoints[_pointIndex].position;
            throw new NullReferenceException();
        }
    }
}