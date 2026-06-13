using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _detectionDistance;

    public bool CanSeePlayer()
    {
        Vector2 currentPosition = transform.position;
        Vector2 playerPosition = _player.position;

        return currentPosition.IsEnoughClose(playerPosition, _detectionDistance);
    }
}
