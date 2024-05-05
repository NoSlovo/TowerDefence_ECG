using System.Collections.Generic;
using Towers;

namespace LevelInitialaizer
{
    public interface ILevelBuilder
    {
        public void Build();

        public List<BaseTower> GetActiveTower();

    }
}