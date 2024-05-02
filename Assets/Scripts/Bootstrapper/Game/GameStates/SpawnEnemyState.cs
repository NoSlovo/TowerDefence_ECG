using UnityEngine;

namespace Bootstrapper.Game.GameStates
{
    public class SpawnEnemyState : IGameState
    {
        private ICoroutineRunner _runner;
        private Transform _spawnPoint;
        private Transform _targetPoint;
        private SpawnerEnemy _spawnerEnemy;
        public  SpawnEnemyState(ICoroutineRunner runner,Transform spawnPoint,Transform targetPoint)
        {
            _runner = runner;
            _spawnPoint = spawnPoint;
            _targetPoint = targetPoint;
        }
        public void EnterState()
        {
            _spawnerEnemy = new SpawnerEnemy(_runner, _spawnPoint, _targetPoint);
            _spawnerEnemy.Init();
        }
    }
}