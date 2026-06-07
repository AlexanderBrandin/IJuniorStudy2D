using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _detectionDistance;

    public bool CanSeePlayer()
    {
        return Vector2.Distance(transform.position, _player.position) <= _detectionDistance;
    }
}
