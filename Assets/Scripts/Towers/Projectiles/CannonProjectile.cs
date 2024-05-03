using Tower.Projectiles;
using UnityEngine;

public class CannonProjectile : BaseProjectile
{
    void OnTriggerEnter(Collider other) => Destroy(gameObject);
}