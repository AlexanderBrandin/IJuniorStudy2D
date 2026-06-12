using UnityEngine;
using UnityEngine.UI;

public class HealthTester : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Button _damageButton;
    [SerializeField] private Button _healButton;
    [SerializeField] private int _damage;
    [SerializeField] private int _healValue;

    private void OnEnable()
    {
        _damageButton.onClick.AddListener(ApplyDamage);
        _healButton.onClick.AddListener(ApplyHeal);
    }

    private void OnDisable()
    {
        _damageButton.onClick.RemoveListener(ApplyDamage);
        _healButton.onClick.RemoveListener(ApplyHeal);
    }

    private void ApplyDamage()
    {
        _health.TakeDamage(_damage);
    }

    private void ApplyHeal()
    {
        _health.Heal(_healValue);
    }
}
