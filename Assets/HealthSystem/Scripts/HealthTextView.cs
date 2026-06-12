using TMPro;
using UnityEngine;

public class HealthTextView : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private TMP_Text _text;

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
        _text.text = $"{_health.CurrentValue}/{_health.MaxValue}";
    }
}
