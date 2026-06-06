using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnDelay;

    private Coroutine _spawnCoroutine;

    private void OnEnable()
    {
        _spawnCoroutine = StartCoroutine(SpawnCoins());
    }

    private void OnDisable()
    {
        if (_spawnCoroutine != null)
            StopCoroutine(_spawnCoroutine);
    }

    private IEnumerator SpawnCoins()
    {
        WaitForSeconds wait = new WaitForSeconds(_spawnDelay);

        while (enabled)
        {
            SpawnCoin();

            yield return wait;
        }
    }

    private void SpawnCoin()
    {
        Transform spawnPoint = GetRandomSpawnPoint();
        Coin coin = Instantiate(_coinPrefab, spawnPoint.position, Quaternion.identity);

        coin.Collected += RemoveCoin;
    }

    private void RemoveCoin(Coin coin)
    {
        coin.Collected -= RemoveCoin;

        Destroy(coin.gameObject);
    }

    private Transform GetRandomSpawnPoint()
    {
        int index = Random.Range(0, _spawnPoints.Length);

        return _spawnPoints[index];
    }
}
