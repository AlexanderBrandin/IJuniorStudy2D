using UnityEngine;
using UnityEngine.UI;

public class HealthSliderView : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _slider;

    private void OnEnable()
    {
        _health.Changed += UpdateView;
        UpdateView();
    }

    private void OnDisable()
    {
        _health.Changed -= UpdateView;
    }

    private void UpdateView()
    {
        _slider.value = GetHealthRatio();
    }

    private float GetHealthRatio()
    {
        return (float)_health.CurrentValue / _health.MaxValue;
    }
}
