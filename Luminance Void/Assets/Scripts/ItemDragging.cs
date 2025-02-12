using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDragging : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            other.GetComponent<Rigidbody2D>().transform.position = Vector2.MoveTowards(other.transform.position, transform.position, 5 * Time.deltaTime);
        }
    }
}