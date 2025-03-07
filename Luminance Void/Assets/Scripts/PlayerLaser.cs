using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaser : MonoBehaviour
{
    private Rigidbody2D rb;

    private float delay = 0;

    private bool alreadyHit = false;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        rb.velocity = transform.right * 50;
        if (alreadyHit)
        {
            delay += Time.deltaTime;
        }
        if (delay >= .25)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            alreadyHit = true;
        }
    }
}