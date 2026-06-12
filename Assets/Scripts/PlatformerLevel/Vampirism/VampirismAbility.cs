using System.Collections;
using UnityEngine;

public class VampirismAbility : MonoBehaviour
{
    [SerializeField] private PlayerInputReader _inputReader;
    [SerializeField] private Health _playerHealth;
    [SerializeField] private EnemyFinder _enemyFinder;
    [SerializeField] private VampirismAreaView _areaView;
    [SerializeField] private VampirismProgressView _progressView;
    [SerializeField] private Transform _areaPoint;

    [SerializeField] private float _radius;
    [SerializeField] private float _duration;
    [SerializeField] private float _cooldown;
    [SerializeField] private float _tickDelay;
    [SerializeField] private int _damagePerTick;
    [SerializeField] private int _healPerTick;

    private bool _isActive;
    private bool _isOnCooldown;
    private Coroutine _abilityCoroutine;

    private void Start()
    {
        _areaView.Initialize(_areaPoint, _radius);
    }

    private void OnEnable()
    {
        _inputReader.VampirismPressed += TryActivate;
    }

    private void OnDisable()
    {
        _inputReader.VampirismPressed -= TryActivate;

        if (_abilityCoroutine != null)
            StopCoroutine(_abilityCoroutine);
    }

    private void TryActivate()
    {
        if (_isActive || _isOnCooldown)
            return;

        _abilityCoroutine = StartCoroutine(UsingAbility());
    }

    private IEnumerator UsingAbility()
    {
        _isActive = true;
        _areaView.Show();

        float elapsedTime = 0f;
        float tickTimer = 0f;

        while (elapsedTime < _duration)
        {
            elapsedTime += Time.deltaTime;
            tickTimer += Time.deltaTime;

            if (tickTimer >= _tickDelay)
            {
                ApplyVampirism();
                tickTimer = 0f;
            }

            float progress = 1f - elapsedTime / _duration;
            _progressView.SetProgress(progress);

            yield return null;
        }

        _areaView.Hide();
        _isActive = false;

        yield return StartCoroutine(Cooldown());

        _abilityCoroutine = null;
    }

    private IEnumerator Cooldown()
    {
        _isOnCooldown = true;

        float elapsedTime = 0f;

        while (elapsedTime < _cooldown)
        {
            elapsedTime += Time.deltaTime;

            float progress = elapsedTime / _cooldown;
            _progressView.SetProgress(progress);

            yield return null;
        }

        _progressView.SetReady();
        _isOnCooldown = false;
    }

    private void ApplyVampirism()
    {
        if (_enemyFinder.TryGetNearestEnemy(_areaPoint.position, _radius, out Health enemyHealth) == false)
            return;

        enemyHealth.TakeDamage(_damagePerTick);
        _playerHealth.Heal(_healPerTick);
    }
}
