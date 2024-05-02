using System;
using Components;
using Enemy;
using UnityEngine;

public class Monster : MonoBehaviour, IEnemy, IPolElement
{
    [SerializeField] private MovementComponent _movementComponent;

    private HealthComponent _healthComponent;
    public int HP => _healthComponent.Value;
    public float Speed => _movementComponent.Speed;

    public event Action OnTurnedOff;
    public bool IsActive { get; set; }

    public void SwitchActiveState(bool value)
    {
        IsActive = value;
        gameObject.SetActive(value);
    }

    public void TakeDamage(int damage) => _healthComponent.GetDamage(damage);

    public void SetMoveTarget(Transform target) => _movementComponent.SetMovePoint(target.position);
}