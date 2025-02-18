using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer rend;
    private Animator anim;

    [SerializeField] private float moveHorizontalSpeed = 1.0f;

    //[SerializeField] private float moveVerticalSpeed = 1.0f;
    [SerializeField] private float jumpSpeed = 1.0f;

    [SerializeField] private PlayerInputActions playerControls;

    [SerializeField] private GameObject aimObject;

    private Vector2 moveDirection = Vector2.zero;

    private InputAction move;
    private InputAction fire;
    private InputAction jump;
    private InputAction buySmallHealth;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();

        fire = playerControls.Player.Fire;
        fire.Enable();
        fire.performed += Fire;

        jump = playerControls.Player.Jump;
        jump.Enable();
        jump.performed += Jump;

        buySmallHealth = playerControls.Player.SmallHeal;
        buySmallHealth.Enable();
        buySmallHealth.performed += BuySmallHealth;
    }

    private void OnDisable()
    {
        move.Disable();
        fire.Disable();
        jump.Disable();
        buySmallHealth.Disable();
    }

    private void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
        anim.SetBool("Running", rb.velocity.x != 0);
        anim.SetBool("Jumping", rb.velocity.y > 0.25);
        anim.SetBool("Falling", rb.velocity.y < -0.25);
    }

    private void FixedUpdate()
    {
        MoveCharacter();
        FlipSprite();
    }

    private void MoveCharacter()
    {
        rb.velocity = new Vector2(moveDirection.x * moveHorizontalSpeed, rb.velocity.y);
    }

    private void Fire(InputAction.CallbackContext context)
    {
        //Inventory.BuyHealth();
        Debug.Log("We Fired");
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (CanJump())
        {
            // -1 jump available
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed * rb.gravityScale);
            Debug.Log("We Jumped");
        }
    }

    private void FlipSprite()
    {
        if (moveDirection.x > 0)
        {
            rend.flipX = false;
        }
        if (moveDirection.x < 0)
        {
            rend.flipX = true;
        }
    }

    private bool CanJump()
    {
        // x>0 amount of jumps available

        return true;
    }

    private void JumpRenewal()
    {
    }

    private void BuySmallHealth(InputAction.CallbackContext context)
    {
        Inventory.BuyHealth();
    }

    public float SetAimGrade()
    {
        return aimObject.transform.rotation.z;
    }
}