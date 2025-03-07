using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Rigidbody2D rb;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(Random.Range(-2f, 2f), 5);
    }
}