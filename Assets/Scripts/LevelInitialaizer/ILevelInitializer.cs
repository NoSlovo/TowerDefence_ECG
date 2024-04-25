using UnityEngine;

namespace LevelInitialaizer
{
    public interface ILevelInitializer
    {
        public ILevelInitializer LevelPrefab{get;set;}
        public void InitLevel();
    }
}