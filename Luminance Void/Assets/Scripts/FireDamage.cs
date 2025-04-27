using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDamage : MonoBehaviour
{
    private bool isInside = false;
    private float timer = 0;

    // Update is called once per frame
    private void Update()
    {
        if (isInside)
        {
            timer += Time.deltaTime;
            if (timer > 0.2f)
            {
                timer = 0;
                Inventory.HurtPlayer(20);
                // deal damage
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInside = true;
            timer = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInside = false;
            timer = 0;
        }
    }
}