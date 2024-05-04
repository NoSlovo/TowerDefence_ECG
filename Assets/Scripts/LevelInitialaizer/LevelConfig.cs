using System;
using System.Collections.Generic;
using UnityEngine;

namespace LevelInitialaizer
{
    public class LevelConfig : MonoBehaviour
    {
        [SerializeField] private List<Transform> _towersSpawnPoints;

        public Vector3 GetTowerPoint(int pointIndex)
        {
            if (pointIndex <= _towersSpawnPoints.Count)
                return _towersSpawnPoints[pointIndex].position;
            throw new NullReferenceException();
        }
    }
}