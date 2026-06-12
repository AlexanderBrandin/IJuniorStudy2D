using UnityEngine;

public class EnemyFinder : MonoBehaviour
{
    [SerializeField] private LayerMask _enemyLayer;

    public bool TryGetNearestEnemy(Vector2 center, float radius, out Health enemyHealth)
    {
        enemyHealth = null;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(center, radius, _enemyLayer);

        if (colliders.Length == 0)
            return false;

        float nearestDistance = float.MaxValue;

        foreach (Collider2D collider in colliders)
        {
            if (collider.TryGetComponent(out Health health) == false)
                continue;

            if (health.IsAlive == false)
                continue;

            float distance = Vector2.Distance(center, collider.transform.position);

            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                enemyHealth = health;
            }
        }

        return enemyHealth != null;
    }
}
