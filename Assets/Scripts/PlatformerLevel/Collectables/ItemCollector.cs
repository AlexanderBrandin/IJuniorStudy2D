using System;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public event Action<int> CoinCollected;
    public event Action<int> MedkitCollected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out CollectableItem item) == false)
            return;

        Collect(item);
    }

    private void Collect(CollectableItem item)
    {
        if (item is Coin)
            CoinCollected?.Invoke(item.Value);
        else if (item is Medkit)
            MedkitCollected?.Invoke(item.Value);

        item.Collect();
    }
}
