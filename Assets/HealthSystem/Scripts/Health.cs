using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action Changed;
    public event Action Died;

    [SerializeField] private int _maxValue;
    [SerializeField] private int _currentValue;

    public int CurrentValue => _currentValue;
    public int MaxValue => _maxValue;
    public bool IsAlive => _currentValue > 0;

    private void Awake()
    {
        _currentValue = _maxValue;
        Changed?.Invoke();
    }

    public void TakeDamage(int damage)
    {
        if (damage <= 0 || IsAlive == false)
            return;

        _currentValue = Mathf.Max(_currentValue - damage, 0);
        Changed?.Invoke();

        if (_currentValue == 0)
            Died?.Invoke();
    }

    public void Heal(int value)
    {
        if (value <= 0 || IsAlive == false)
            return;

        _currentValue = Mathf.Min(_currentValue + value, _maxValue);
        Changed?.Invoke();
    }
}
