using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    [SerializeField] private GameObject coinSpawner;

    private float health = 75;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(coinSpawner, transform.position, Quaternion.identity);
            Destroy(transform.parent.gameObject);
        }
        if (other.CompareTag("PlayerAttack"))
        {
            health -= 25;
            Debug.Log("Hurt enemy" + health);

            //Destroy(other.gameObject);
        }
    }

    private void Update()
    {
        if (health <= 0)
        {
            Instantiate(coinSpawner, transform.position, Quaternion.identity);
            Destroy(transform.parent.gameObject);
        }
    }
}