using UnityEngine;

public class MedkitSpawner : MonoBehaviour
{
    [SerializeField] private Medkit _medkitPrefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private int _medkitsAmount;

    private void Start()
    {
        SpawnMedkits();
    }

    private void SpawnMedkits()
    {
        for (int i = 0; i < _medkitsAmount; i++)
        {
            Transform spawnPoint = GetRandomSpawnPoint();
            Medkit medkit = Instantiate(_medkitPrefab, spawnPoint.position, Quaternion.identity);

            medkit.Collected += RemoveItem;
        }
    }

    private void RemoveItem(CollectableItem item)
    {
        item.Collected -= RemoveItem;

        Destroy(item.gameObject);
    }

    private Transform GetRandomSpawnPoint()
    {
        int index = Random.Range(0, _spawnPoints.Length);

        return _spawnPoints[index];
    }
}
