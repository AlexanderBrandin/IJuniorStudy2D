using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Transform _leftPoint;
    [SerializeField] private Transform _rightPoint;
    [SerializeField] private float _speed;
    [SerializeField] private float _minDistanceToPoint;

    private Transform _targetPoint;

    private void Start()
    {
        _targetPoint = _rightPoint;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            _targetPoint.position,
            _speed * Time.deltaTime
        );

        if (Vector2.Distance(transform.position, _targetPoint.position) <= _minDistanceToPoint)
            SwitchTargetPoint();
    }

    private void SwitchTargetPoint()
    {
        if (_targetPoint == _rightPoint)
            _targetPoint = _leftPoint;
        else
            _targetPoint = _rightPoint;

        Flip();
    }

    private void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1f;
        transform.localScale = scale;
    }
}
