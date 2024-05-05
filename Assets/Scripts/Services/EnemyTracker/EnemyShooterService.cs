using System.Collections.Generic;

namespace Towers.EnemyTracker
{
    public class EnemyShooterService 
    {
        private List<BaseTower> _towers;
        
        public EnemyShooterService(List<BaseTower> towers)
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