using System;
using UnityEngine;
using Tower.Projectiles;

public class GuidedProjectile : BaseProjectile
{
	public void Update()
	{
		
	}

	private void OnTriggerEnter(Collider other) 
	{
		Destroy(gameObject);
	}
}
