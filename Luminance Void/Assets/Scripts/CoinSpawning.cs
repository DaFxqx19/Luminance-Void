using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawning : MonoBehaviour
{
    private int coinsToSpawn = 10;

    [SerializeField] private GameObject coinObject;

    public void SetCoinsToSpawnAmount(int amount)
    {
        coinsToSpawn = amount;
    }

    private void Awake()
    {
        SpawnCoin();
    }

    private void SpawnCoin()
    {
        for (int i = 0; i < coinsToSpawn; i++)
        {
            Vector3 change = new Vector3(Random.Range(-.5f, .5f), Random.Range(0.5f, 2f));
            //Vector3 change = new Vector3(0, .5f);

            Instantiate(coinObject, transform.position + change, Quaternion.identity);
        }
    }
}