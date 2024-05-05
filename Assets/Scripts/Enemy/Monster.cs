using System;
using Components;
using Enemy;
using Enemy.EnemyInterfaces;
using UnityEngine;

public class Monster : MonoBehaviour, IEnemy, IPoolElement
{
    [SerializeField] private MovementComponent _movementComponent;

    private HealthComponent _healthComponent = new HealthComponent();

    public Action OnUsed { get; set; }
    public bool IsActive { get; set; }
    public Transform Transform => transform;

    public void SwitchActiveState(bool value)
    {
        IsActive = value;
        gameObject.SetActive(value);

        if (value)
            Subscribes();
        else
            Unsubscribe();
    }

    public void SetMoveTarget(Transform target) =>
        _movementComponent.SetMovePoint(target.position);

    public void TakeDamage(int damage) => _healthComponent.GetDamage(damage);

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
}