using System;
using Components;
using Enemy;
using UnityEngine;

public class Monster : MonoBehaviour, IEnemy, IPolElement
{
    [SerializeField] private MovementComponent _movementComponent;

    private HealthComponent _healthComponent = new HealthComponent();
    public int HP => _healthComponent.Value;
    public float Speed => _movementComponent.Speed;

    public event Action OnTurnedOff;
    public bool IsActive { get; set; }

    public void SwitchActiveState(bool value)
    {
        IsActive = value;
        gameObject.SetActive(value);
        Unsubscribe();
    }

    public void SetMoveTarget(Transform target)
    {
        _movementComponent.SetMovePoint(target.position);
        Subscribes();
    }


    private void Subscribes()
    {
        _movementComponent.OnReachTarget += SwitchActiveState;
        _healthComponent.OnDied += SwitchActiveState;
    }

    private void Unsubscribe()
    {
        _movementComponent.OnReachTarget -= SwitchActiveState;
        _healthComponent.OnDied -= SwitchActiveState;
    }

    public void TakeDamage(int damage) => _healthComponent.GetDamage(damage);
}