using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private PlayerInputReader _inputReader;
    [SerializeField] private Attacker _attacker;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private float _attackRadius;

    private void OnEnable()
    {
        _inputReader.AttackPressed += Attack;
    }

    private void OnDisable()
    {
        _inputReader.AttackPressed -= Attack;
    }

    private void Attack()
    {
        Collider2D enemyCollider = Physics2D.OverlapCircle(
            transform.position,
            _attackRadius,
            _enemyLayer
        );

        if (enemyCollider == null)
            return;

        if (enemyCollider.TryGetComponent(out Health enemyHealth))
            _attacker.AttackOnce(enemyHealth);
    }
}
