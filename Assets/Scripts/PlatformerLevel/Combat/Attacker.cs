using System.Collections;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _attackDistance;
    [SerializeField] private float _attackDelay;

    private Coroutine _attackCoroutine;

    private void OnDisable()
    {
        StopAttacking();
    }

    public void StartAttacking(Health target)
    {
        if (_attackCoroutine != null)
            return;

        _attackCoroutine = StartCoroutine(Attacking(target));
    }

    public void StopAttacking()
    {
        if (_attackCoroutine == null)
            return;

        StopCoroutine(_attackCoroutine);
        _attackCoroutine = null;
    }

    public void AttackOnce(Health target)
    {
        if (target == null || target.IsAlive == false)
            return;

        target.TakeDamage(_damage);
    }

    public bool IsTargetClose(Transform target)
    {
        Vector2 currentPosition = transform.position;
        Vector2 targetPosition = target.position;

        return currentPosition.IsEnoughClose(targetPosition, _attackDistance);
    }

    private IEnumerator Attacking(Health target)
    {
        WaitForSeconds wait = new WaitForSeconds(_attackDelay);

        while (target != null && target.IsAlive)
        {
            target.TakeDamage(_damage);

            yield return wait;
        }

        _attackCoroutine = null;
    }
}
