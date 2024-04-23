using UnityEngine;

public class LevelIniter : MonoBehaviour
{
   [SerializeField] private Transform _endPointlevel;
   [SerializeField] private SpawnerEnemy _spawnerEnemy;
   public Transform endPointlevel => _endPointlevel;

   public void Init()
   {
      _spawnerEnemy.Init();
   }
}
