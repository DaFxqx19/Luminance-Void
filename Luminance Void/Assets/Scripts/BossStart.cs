using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStart : MonoBehaviour
{
    [SerializeField] private GameObject bossObject;
    [SerializeField] private GameObject bosshHealthObject;

    private void Start()
    {
        bossObject.SetActive(false);
        bosshHealthObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //bossObject.GetComponent<BossAI>().StartBossUI();
            bossObject.SetActive(true);
            bosshHealthObject.SetActive(true);
        }
    }
}