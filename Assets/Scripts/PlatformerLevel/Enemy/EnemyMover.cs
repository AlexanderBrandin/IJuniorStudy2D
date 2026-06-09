using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Health _playerHealth;
    [SerializeField] private PlayerDetector _detector;
    [SerializeField] private Patroller _patroller;
    [SerializeField] private Attacker _attacker;
    [SerializeField] private ObjectFlipper _flipper;
    [SerializeField] private float _chaseSpeed;

    private void Update()
    {
        UpdateBehaviour();
    }

    private void UpdateBehaviour()
    {
        if (_detector.CanSeePlayer())
            ChaseOrAttackPlayer();
        else
            Patrol();
    }

    private void ChaseOrAttackPlayer()
    {
        _patroller.Deactivate();

        if (_attacker.IsTargetClose(_player))
        {
            _attacker.StartAttacking(_playerHealth);
            return;
        }

        _attacker.StopAttacking();
        MoveToPlayer();
    }

    private void Patrol()
    {
        _attacker.StopAttacking();
        _patroller.Activate();
    }

    private void MoveToPlayer()
    {
        Vector3 direction = (_player.position - transform.position).normalized;

        transform.position = Vector2.MoveTowards(
            transform.position,
            _player.position,
            _chaseSpeed * Time.deltaTime
        );

        if (direction.x > 0f)
            _flipper.LookRight();
        else if (direction.x < 0f)
            _flipper.LookLeft();
    }
}
