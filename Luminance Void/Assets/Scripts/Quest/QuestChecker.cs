using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestChecker : MonoBehaviour
{
    [SerializeField] private GameObject coin;

    private float timer = 5f;

    private void Update()
    {
        if (coin == null && this.gameObject.GetComponent<QuestArea>().questActive && Inventory.GetHealth() == Inventory.GetMaxHealth())
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}