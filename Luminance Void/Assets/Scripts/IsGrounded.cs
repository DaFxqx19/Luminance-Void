using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGrounded : MonoBehaviour
{
    [SerializeField] private GameObject playerControls;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground") || collision.CompareTag("Object") || collision.CompareTag("Enemy"))
        {
            playerControls.GetComponent<PlayerControls>().jumpsDone = 0;
        }
    }
}