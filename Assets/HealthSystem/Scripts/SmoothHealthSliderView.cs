using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthSliderView : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _slider;
    [SerializeField] private float _changeSpeed;

    private Coroutine _changingCoroutine;

    private void OnEnable()
    {
        _health.Changed += StartChanging;

        float healthRatio = GetHealthRatio();
        _slider.value = healthRatio;
    }

    private void OnDisable()
    {
        _health.Changed -= StartChanging;

        if (_changingCoroutine != null)
            StopCoroutine(_changingCoroutine);
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

    private float GetHealthRatio()
    {
        return (float)_health.CurrentValue / _health.MaxValue;
    }
}
