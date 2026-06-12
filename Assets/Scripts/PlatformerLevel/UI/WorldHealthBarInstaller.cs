using UnityEngine;

[RequireComponent(typeof(Health))]
public class WorldHealthBarInstaller : MonoBehaviour
{
    [SerializeField] private SmoothHealthSliderView _healthBarPrefab;
    [SerializeField] private Transform _healthBarPoint;

    private Health _health;
    private SmoothHealthSliderView _healthBar;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void Start()
    {
        _healthBar = Instantiate(
            _healthBarPrefab,
            _healthBarPoint.position,
            Quaternion.identity
        );

        _healthBar.Initialize(_health);

        if (_healthBar.TryGetComponent(out HealthBarFollower follower))
            follower.Initialize(_healthBarPoint);
    }

    private void OnDisable()
    {
        if (_healthBar != null)
            Destroy(_healthBar.gameObject);
    }
}
