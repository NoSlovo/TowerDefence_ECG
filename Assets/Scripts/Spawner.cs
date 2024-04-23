using UnityEngine;

public class Spawner : MonoBehaviour
{
    [field: SerializeField] private Monster _enemyPrefab;
    [field: SerializeField] public float m_interval { get; private set; } = 3;
    [field: SerializeField] public Transform m_moveTarget;

    private float m_lastSpawn = -1;

    public void FixedUpdate()
    {
        
        // Todo : Создать фабрику инстанца моделей,
        // IWaveConfig.GetEnemyCongif();
        if (Time.time > m_lastSpawn + m_interval)
        {
            CreateMonster();
            m_lastSpawn = Time.time;
        }
    }

    private void CreateMonster()
    {
        Monster newMonster = Instantiate(_enemyPrefab);
        newMonster.transform.position = transform.position;
        newMonster.SetTargetPoint(m_moveTarget.transform);
    }
}