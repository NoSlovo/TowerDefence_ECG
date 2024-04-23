using UnityEngine;

namespace Tower
{
    public class BaseTower : MonoBehaviour
    {
        [SerializeField] ShotComponent _shotComponent;

        private float m_lastShotTime = -0.5f;
	
        private Monster  _target;
    }
}