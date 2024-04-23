using UnityEngine;

namespace Tower
{
    public class ShotComponent : MonoBehaviour
    {
        [SerializeField] private float m_shootInterval = 0.5f;
        [SerializeField] private float m_range = 4f;
        [SerializeField] private CannonProjectile _projectilePrefab;
        [SerializeField] private Transform _shotPoint;
        
        public void Shoot(Monster monster)
        {
            var projectile = Instantiate(_projectilePrefab,_shotPoint.position, Quaternion.identity);
            var projectileBeh = projectile.GetComponent<GuidedProjectile> ();
            projectileBeh.m_target = monster.gameObject;
        }
        
        private bool CheckShootDistance(Monster monster)
        {
            if (Vector3.Distance(transform.position, monster.transform.position) > m_range)
                return false;
		
            return true;
        }
    }
}