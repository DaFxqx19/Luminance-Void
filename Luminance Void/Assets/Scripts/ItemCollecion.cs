using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollecion : MonoBehaviour
{
    /* private void OnTriggerEnter2D(Collider2D other)
     {
         if (other.CompareTag("Player"))
         {
             Inventory.AddCoins(50);
             Destroy(this);
         }
     }
   */

    private void Update()
    {
        if (Mathf.Abs(PlayerControls.FindFirstObjectByType<PlayerControls>().transform.position.x - transform.position.x) < 0.25 &&
            Mathf.Abs(PlayerControls.FindFirstObjectByType<PlayerControls>().transform.position.y - transform.position.y) < 0.25)
        {
            Inventory.AddCoins(50);
            Destroy(this.gameObject);
        }
    }
}