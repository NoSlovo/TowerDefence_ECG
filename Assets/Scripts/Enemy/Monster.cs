using System;
using Components;
using UnityEngine;

public class Monster : MonoBehaviour, IDamageProvaider
{
    [SerializeField] private int _maxHP = 30;
    [SerializeField] private MovementComponent _movementComponent;
    public int HP => _maxHP;
    public float Speed => _movementComponent.Speed;
    public bool IsAlive { get; private set; }
    public event Action OnDead;

    public void SwitchActiveState(bool velue)
    {
        IsAlive = velue;
        gameObject.SetActive(velue);
    }

    public void SetTarget(Transform target) => _movementComponent.SetMovePoint(target.position);

    public void TakeDamage(int damage)
    {
        if (damage > 0)
            _maxHP -= damage;
        if (CheckDead(damage))
        {
            SwitchActiveState(false);
            OnDead?.Invoke();
        }
    }

    private bool CheckDead(int damage)
    {
        if (_maxHP < damage)
        {
            _maxHP = 0;
            return true;
        }

        return false;
    }
}