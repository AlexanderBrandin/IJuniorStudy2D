using UnityEngine;

public class HealthBarFollower : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private void LateUpdate()
    {
        FollowTarget();
    }

    public void Initialize(Transform target)
    {
        _target = target;
    }

    private void FollowTarget()
    {
        if (_target == null)
            return;

        transform.position = _target.position;
        transform.rotation = Quaternion.identity;
    }
}
