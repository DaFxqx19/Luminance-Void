using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject colliderObject;

    private Rigidbody2D rb;
    private SpriteRenderer rend;
    private Animator anim;

    private bool insideObject = false;
    private float insideTimer = 0f;
    private float moveDirection = 1;
    [SerializeField] private int moveSpeed = 1;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, 0);
        anim.SetBool("isWalking", true);
        if (insideObject == true && insideTimer < 1)
        {
            insideTimer += Time.deltaTime;
        }
        else
        {
            insideObject = false;
            insideTimer = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Object") && insideObject == false || other.CompareTag("Enemy") && insideObject == false)
        {
            moveDirection *= -1;
            insideObject = true;
            transform.localScale = new Vector3(moveDirection, 1, 1);
        }
        else if (other.CompareTag("Player"))
        {
            //Hurt player
            Inventory.HurtPlayer(10);
        }
    }

    /*
    private void OnTriggerStay2D(Collider2D collision)
    {
        shootUpTimer += Time.deltaTime;
        if (shootUpTimer > 2)
        {
            rb.velocity = new Vector2(0, 10);
        }
    }
    */
}