using Components;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private float _speed  = 0.1f;
    [SerializeField] private int _maxHP  = 30;
    [SerializeField] private MovementComponent _movementComponent;
    public MovementComponent MovementComponent => _movementComponent;
    public int HP => _maxHP;
}