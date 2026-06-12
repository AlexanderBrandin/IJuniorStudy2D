using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthSliderView : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _changeSpeed;

    private Health _health;
    private Coroutine _changingCoroutine;

    private void OnDisable()
    {
        Unsubscribe();

        if (_changingCoroutine != null)
            StopCoroutine(_changingCoroutine);
    }

    public void Initialize(Health health)
    {
        Unsubscribe();

        _health = health;
        _health.Changed += StartChanging;

        float healthRatio = GetHealthRatio();
        _slider.value = healthRatio;
    }

    private void StartChanging()
    {
        if (_changingCoroutine != null)
            StopCoroutine(_changingCoroutine);

        _changingCoroutine = StartCoroutine(Changing());
    }

    private IEnumerator Changing()
    {
        float targetValue = GetHealthRatio();

        while (_slider.value != targetValue)
        {
            _slider.value = Mathf.MoveTowards(
                _slider.value,
                targetValue,
                _changeSpeed * Time.deltaTime
            );

            yield return null;
        }

        _changingCoroutine = null;
    }

    private void Unsubscribe()
    {
        if (_health == null)
            return;

        _health.Changed -= StartChanging;
    }

    private float GetHealthRatio()
    {
        return (float)_health.CurrentValue / _health.MaxValue;
    }
}
