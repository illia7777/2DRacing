using UnityEngine;
using System.Collections;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] Transform[] TransformCoinSpawner;
    [SerializeField] GameObject PrefabCoin;
    [SerializeField] float SpawnInterval = 2f;
    private void Start()
    {
        StartCoroutine(SpawnCoin());
    }

    public void AddCoin()
    {
        var random = Random.Range(0, TransformCoinSpawner.Length);
        GameObject coin = Instantiate((GameObject)PrefabCoin, TransformCoinSpawner[random].position, Quaternion.identity);
      
    }
    IEnumerator SpawnCoin()
    {
        while (true)
        {
            AddCoin();
            yield return new WaitForSeconds(SpawnInterval);
        }
    }
}
