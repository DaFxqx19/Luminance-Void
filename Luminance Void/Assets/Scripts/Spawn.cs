using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject playerReference;

    private void Awake()
    {
        SpawnFunction();
        Inventory.SetCoins(100);
        Inventory.SetHealth(200);
    }

    public void SpawnFunction()
    {
        Inventory.BuyHealth(0, true);
        if (Inventory.GetCoins() != 0)
        {
            Inventory.SetCoins(Mathf.CeilToInt(2 * Inventory.coinAmount / 3));
        }
        playerReference.transform.position = transform.position;
        playerReference.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }
}