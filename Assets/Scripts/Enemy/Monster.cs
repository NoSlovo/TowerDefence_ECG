using Components;
using UnityEngine;

public class Monster : MonoBehaviour , IDamageProvaider
{
    [SerializeField] private float _speed  = 0.1f;
    [SerializeField] private int _maxHP  = 30;
    [SerializeField] private MovementComponent _movementComponent;
    public MovementComponent MovementComponent => _movementComponent;
    public int HP => _maxHP;
    public void TakeDamage(int damage)
    {
        if (damage > 0)
            _maxHP -= damage;
        if (CheckDead(damage))
            Destroy(gameObject);
    }

    private bool CheckDead(int damage)
    {
        if (_maxHP < damage)
        {
            _maxHP = 0;
            Dead();
            return true;
        }
        return false;
    }

    private void Dead()
    {
        gameObject.SetActive(false);
    }
}

public interface IDamageProvaider
{
    public void TakeDamage(int damage);
}