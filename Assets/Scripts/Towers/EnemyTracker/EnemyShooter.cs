using System.Collections.Generic;

namespace Towers.EnemyTracker
{
    public class EnemyShooter 
    {
        private List<BaseTower> _towers;
        
        public EnemyShooter(List<BaseTower> towers)
        {
            _towers = towers;
        }

        public void Tick()
        {
            foreach (var tower in _towers)
            {
                if(!tower.HasTarget)
                    continue;
                
                tower.Shoot();
            }
        }
    }
}