using System.Collections.Generic;
using Towers;
using UnityEngine;

namespace LevelBuilder.InterfacesBuilding
{
    public interface ILevelBuilder
    {
        public Transform ShowPoint { get; }
        public Transform EndPoint { get; }

        public void Build();

        public List<BaseTower> GetActiveTower();
    }
}