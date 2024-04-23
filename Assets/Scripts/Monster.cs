using UnityEngine;

public class Monster : MonoBehaviour
{
    [field: SerializeField] public float Speed { get; private set; } = 0.1f;
    [field: SerializeField] public int MaxHP { get; private set; } = 30;

    private Transform _targetPoint;

    private const float m_reachDistance = 0.3f;

    public int m_hp;

    public void Start()
    {
        m_hp = MaxHP;
    }

    void Update()
    {
        if (CheckTargetDistance()) Destroy(gameObject);

        MoveToTargetPoint();
    }

    private void MoveToTargetPoint()
    {
        var directionMove = _targetPoint.position - transform.position;

        if (directionMove.magnitude > Speed)
            directionMove = directionMove.normalized * Speed;


        transform.Translate(directionMove);
    }

    public void SetTargetPoint(Transform targetPoint)
    {
        if (targetPoint != null)
            _targetPoint = targetPoint;
    }

    private bool CheckTargetDistance()
    {
        if (Vector3.Distance(transform.position, _targetPoint.position) <= m_reachDistance)
            return true;

        return false;
    }
}