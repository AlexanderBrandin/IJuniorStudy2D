using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private Transform _checkPoint;
    [SerializeField] private float _checkRadius;
    [SerializeField] private LayerMask _groundLayer;

    public bool IsGrounded { get; private set; }

    private void Update()
    {
        UpdateGroundedState();
    }

    private void UpdateGroundedState()
    {
        IsGrounded = Physics2D.OverlapCircle(
            _checkPoint.position,
            _checkRadius,
            _groundLayer
        );
    }
}
