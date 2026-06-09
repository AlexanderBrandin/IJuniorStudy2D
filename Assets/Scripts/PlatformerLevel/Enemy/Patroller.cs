using UnityEngine;

public class Patroller : MonoBehaviour
{
    [SerializeField] private ObjectFlipper _flipper;
    [SerializeField] private Transform _leftPoint;
    [SerializeField] private Transform _rightPoint;
    [SerializeField] private float _speed;

    private Transform _targetPoint;
    private bool _isActive = true;

    private void Start()
    {
        _targetPoint = _rightPoint;
        _flipper.LookRight();
    }

    private void Update()
    {
        if (_isActive)
            Move();
    }

    public void Activate()
    {
        _isActive = true;
    }

    public void Deactivate()
    {
        _isActive = false;
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            _targetPoint.position,
            _speed * Time.deltaTime
        );

        if ((Vector2)transform.position == (Vector2)_targetPoint.position)
            SwitchTargetPoint();
    }

    private void SwitchTargetPoint()
    {
        if (_targetPoint == _rightPoint)
        {
            _targetPoint = _leftPoint;
            _flipper.LookLeft();
        }
        else
        {
            _targetPoint = _rightPoint;
            _flipper.LookRight();
        }
    }
}
