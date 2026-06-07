using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private PlayerInputReader _inputReader;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private PlayerAnimator _animator;
    [SerializeField] private ObjectFlipper _flipper;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _inputReader.JumpPressed += Jump;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnDisable()
    {
        _inputReader.JumpPressed -= Jump;
    }

    private void Move()
    {
        float horizontalDirection = _inputReader.HorizontalDirection;

        _rigidbody.linearVelocity = new Vector2(
            horizontalDirection * _moveSpeed,
            _rigidbody.linearVelocity.y
        );

        UpdateLookDirection(horizontalDirection);
        _animator.SetRunning(horizontalDirection != 0f);
    }

    private void Jump()
    {
        if (_groundChecker.IsGrounded == false)
            return;

        _rigidbody.linearVelocity = new Vector2(
            _rigidbody.linearVelocity.x,
            _jumpForce
        );
    }

    private void UpdateLookDirection(float horizontalDirection)
    {
        if (horizontalDirection > 0f)
            _flipper.LookRight();
        else if (horizontalDirection < 0f)
            _flipper.LookLeft();
    }
}
