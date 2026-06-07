using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action Died;
    public event Action<int> Changed;

    [SerializeField] private int _maxValue;
    [SerializeField] private int _currentValue;

    public bool IsAlive => _currentValue > 0;

    private void Awake()
    {
        _currentValue = _maxValue;
    }

    public void TakeDamage(int damage)
    {
        if (damage <= 0 || IsAlive == false)
            return;

        _currentValue = Mathf.Max(_currentValue - damage, 0);
        Changed?.Invoke(_currentValue);

        if (_currentValue == 0)
            Died?.Invoke();
    }

    public void Heal(int value)
    {
        if (value <= 0 || IsAlive == false)
            return;

        _currentValue = Mathf.Min(_currentValue + value, _maxValue);
        Changed?.Invoke(_currentValue);
    }
}
