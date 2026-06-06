using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private PlayerInputReader _inputReader;
    [SerializeField] private GroundChecker _groundChecker;
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
        _rigidbody.linearVelocity = new Vector2(
            _inputReader.HorizontalDirection * _moveSpeed,
            _rigidbody.linearVelocity.y
        );
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
}
