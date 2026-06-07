using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Medkit : MonoBehaviour
{
    public event Action<Medkit> Collected;

    [SerializeField] private int _healValue;

    public void Collect(Health targetHealth)
    {
        targetHealth.Heal(_healValue);
        Collected?.Invoke(this);
    }
}
