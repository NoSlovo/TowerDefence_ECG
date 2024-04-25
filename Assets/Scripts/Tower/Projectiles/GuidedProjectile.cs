using UnityEngine;
using Tower.Projectiles;

public class GuidedProjectile : BaseProjectile
{
	private void OnTriggerEnter(Collider other)  =>Destroy(gameObject);
}
