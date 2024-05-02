using System;
using Components;
using Enemy;
using UnityEngine;

public class Monster : MonoBehaviour, IEnemy, IPolElement
{
    [SerializeField] private int _maxHP = 30;
    [SerializeField] private MovementComponent _movementComponent;
    public int HP => _maxHP;
    public float Speed => _movementComponent.Speed;

    public event Action TurnedOff;
    public bool IsActive { get; set; }

    public void SwitchActiveState(bool value)
    {
        IsActive = value;
        gameObject.SetActive(value);
    }

    public void TakeDamage(int damage)
    {
        if (damage > 0)
            _maxHP -= damage;
        
        if (CheckDead(damage))
        {
            SwitchActiveState(false);
            TurnedOff?.Invoke();
        }
    }

    public void SetMoveTarget(Transform target)
    {
        _movementComponent.SetMovePoint(target.position);
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