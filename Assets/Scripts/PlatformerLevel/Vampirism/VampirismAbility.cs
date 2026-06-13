using System;
using System.Collections;
using UnityEngine;

public class VampirismAbility : MonoBehaviour
{
    public event Action Started;
    public event Action Finished;
    public event Action<float> ProgressChanged;

    [SerializeField] private PlayerInputReader _inputReader;
    [SerializeField] private Health _playerHealth;
    [SerializeField] private EnemyFinder _enemyFinder;
    [SerializeField] private VampirismAreaView _areaView;
    [SerializeField] private Cooldown _cooldown;
    [SerializeField] private Transform _areaPoint;

    [SerializeField] private float _radius;
    [SerializeField] private float _duration;
    [SerializeField] private float _tickDelay;
    [SerializeField] private int _damagePerTick;
    [SerializeField] private int _healPerTick;

    private bool _isActive;
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
        if (_isActive)
            return;

        if (_cooldown.IsReady == false)
            return;

        _abilityCoroutine = StartCoroutine(UsingAbility());
    }

    private IEnumerator UsingAbility()
    {
        _isActive = true;

        _areaView.Show();
        Started?.Invoke();

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
            ProgressChanged?.Invoke(progress);

            yield return null;
        }

        _areaView.Hide();

        _isActive = false;
        Finished?.Invoke();

        _cooldown.StartCooldown();
        _abilityCoroutine = null;
    }

    private void ApplyVampirism()
    {
        if (_enemyFinder.TryGetNearestEnemy(_areaPoint.position, _radius, out Health enemyHealth) == false)
            return;

        enemyHealth.TakeDamage(_damagePerTick);
        _playerHealth.Heal(_healPerTick);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        if (_areaPoint != null)
            Gizmos.DrawWireSphere(_areaPoint.position, _radius);
        else
            Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
