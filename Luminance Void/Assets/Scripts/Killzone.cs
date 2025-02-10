using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour
{
    [SerializeField] private GameObject playerSpawner;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerSpawner.GetComponent<Spawn>().SpawnFunction();
        }
    }
}