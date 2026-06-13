using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class CollectableItem : MonoBehaviour
{
    [SerializeField] private int _value;

    public event Action<CollectableItem> Collected;

    public int Value => _value;

    public void Collect()
    {
        Collected?.Invoke(this);
    }
}
