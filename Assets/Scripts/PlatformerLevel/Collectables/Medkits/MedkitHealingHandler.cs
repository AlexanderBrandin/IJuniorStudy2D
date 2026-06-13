using UnityEngine;

[RequireComponent(typeof(ItemCollector))]
[RequireComponent(typeof(Health))]
public class MedkitHealingHandler : MonoBehaviour
{
    private ItemCollector _itemCollector;
    private Health _health;

    private void Awake()
    {
        _itemCollector = GetComponent<ItemCollector>();
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _itemCollector.MedkitCollected += Heal;
    }

    private void OnDisable()
    {
        _itemCollector.MedkitCollected -= Heal;
    }

    private void Heal(int value)
    {
        _health.Heal(value);
    }
}
