using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour
{
    [SerializeField] private GameObject playerSpawner;
    [SerializeField] private GameObject bossObject;

    public bool isBossArenaKZ = false;

    private float timer = 0;

    private void Update()
    {
        timer += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isBossArenaKZ)
            {
                if (timer > 1)
                {
                    playerSpawner.GetComponent<Spawn>().SpawnFunction();
                }
            }
            else
            {
                bossObject.GetComponent<BossAI>().StartBossUI();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Sometthing left");
        if (other.CompareTag("PlayerAttack"))
        {
            Destroy(other.gameObject);
        }
        if (other.CompareTag("BossAttack") && isBossArenaKZ)
        {
            Destroy(other.gameObject);
        }
    }
}