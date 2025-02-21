using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    [SerializeField] private GameObject coinSpawner;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(coinSpawner, transform.position, Quaternion.identity);
            Destroy(transform.parent.gameObject);
        }
    }
}