using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class PlayerControls : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer rend;
    private Animator anim;
    private AudioSource audioSource;

    [SerializeField] private float moveHorizontalSpeed = 1.0f;

    //[SerializeField] private float moveVerticalSpeed = 1.0f;
    [SerializeField] private float jumpSpeed = 1.0f;

    [SerializeField] private float laserSpeed = 10f;

    [SerializeField] private PlayerInputActions playerControls;

    [SerializeField] private GameObject aimObject;

    [SerializeField] private Camera mainCamera;

    [SerializeField] private GameObject referenceToUI;

    [SerializeField] private GameObject laserObject;

    [SerializeField] private AudioClip[] laserSounds;
    [SerializeField] private AudioClip[] jumpSounds;
    [SerializeField] private AudioClip[] stepSounds;

    private Vector3 musPosition = Vector3.zero;

    private Vector2 moveDirection = Vector2.zero;

    public int jumpsDone = 0;

    private InputAction move;
    private InputAction fire;
    private InputAction jump;
    private InputAction buySmallHealth;
    private InputAction look;
    private InputAction settingsToggle;
    private InputAction shopToggle;

    private Camera cam;

    //private Quaternion m_MyQuaternion;

    private void Start()
    {
        //m_MyQuaternion = new Quaternion();

        cam = Camera.main;

        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        //musPosition = new Vector3(-Screen.width / 2, -Screen.height / 2, 0f);
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

        look = playerControls.Player.Look;
        look.Enable();
        look.performed += Look;

        settingsToggle = playerControls.Player.SettingsToggle;
        settingsToggle.Enable();
        settingsToggle.performed += SettingsToggle;

        shopToggle = playerControls.Player.ShopToggle;
        shopToggle.Enable();
        shopToggle.performed += ShopToggle;
    }

    private void OnDisable()
    {
        move.Disable();
        fire.Disable();
        jump.Disable();
        buySmallHealth.Disable();
        look.Disable();
    }

    private void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
        anim.SetBool("Running", rb.velocity.x != 0);
        anim.SetBool("Jumping", rb.velocity.y > 0.25);
        anim.SetBool("Falling", rb.velocity.y < -0.25);
        //look.performed += Look;
        Inventory.laserSpeed = laserSpeed;
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
        Instantiate(laserObject, aimObject.transform.position, aimObject.transform.rotation);

        SoundFXManager.instance.PlayRandomSoundFXClip(laserSounds, transform.position, 1);
        //Inventory.BuyHealth();
        Debug.Log("We Fired");
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (CanJump())
        {
            // -1 jump available
            SoundFXManager.instance.PlayRandomSoundFXClip(jumpSounds, transform.position, 1);
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed * rb.gravityScale);
            Debug.Log("We Jumped");
            jumpsDone++;
        }
    }

    private void Look(InputAction.CallbackContext context)
    {
        Vector3 mousePosition = look.ReadValue<Vector2>();

        Vector3 screenSize = new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight);

        //Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        //musPosition += mousePosition;
        //Debug.Log("mouse position: " + mousePosition);
        //Debug.Log("aimObject: " + aimObject.transform.position);

        bool isFollowing = true;

        if (context.performed)
        {
            if (!isFollowing)
            {
                //Vector2 rotation = new Vector2(mousePosition.x - aimObject.transform.position.x, mousePosition.y - aimObject.transform.position.y);
                /*

                Vector3 rotation = mousePosition - new Vector3(Screen.width / 2, Screen.height / 2);

                rotation -= new Vector3(aimObject.transform.position.x * 100, aimObject.transform.position.y * 100);
                */
                /*
                mousePosition -= new Vector3(Screen.width / 2, Screen.height / 2);
                //mousePosition -= aimObject.transform.position;
                //Vector3 rotation = new Vector3(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y, 0f);

                //Debug.Log("rotation: " + rotation);

                //Vector3 newRotation = rotation;

                //Vector3 newRotation = new Vector3(Mathf.Cos(aimObject.transform.rotation.x) + mousePosition.x / Screen.width, Mathf.Sin(aimObject.transform.rotation.y) + mousePosition.y / Screen.height);

                //float rotZ = Mathf.Atan2(newRotation.y, newRotation.x) * Mathf.Rad2Deg;

                //float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

                //Debug.Log("rotZ in degrees: " + rotZ);

                //Vector3 playerPosition = aimObject.transform.position;
                Vector3 playerPosition = mousePosition;

                float rotZ = Mathf.Atan2(playerPosition.x - aimObject.transform.position.x, playerPosition.y - aimObject.transform.position.y) * Mathf.Rad2Deg;

                // float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

                Vector3 relativePos = playerPosition - aimObject.transform.position;

                // the second argument, upwards, defaults to Vector3.up
                Quaternion rotation = Quaternion.LookRotation(playerPosition, Vector3.right);

                aimObject.transform.rotation = rotation;

                //aimObject.transform.rotation = Quaternion.Euler(0, 0, rotZ);
            */
            }
            else
            {
                //Vector3 rotation = mousePosition - new Vector3(mainCamera.pixelWidth / 2, mainCamera.pixelHeight / 2);

                Vector3 rotation = mousePosition - new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);

                float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

                //rotZ = Mathf.Atan2(rotation.y, rotation.x);
                //
                //aimObject.transform.rotation = Quaternion.FromToRotation(aimObject.transform.position, rotation);
                aimObject.transform.rotation = Quaternion.Euler(0, 0, rotZ);
            }
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

        if (Inventory.GetJumpsAvailable() - jumpsDone > 0)
        {
            return true;
        }
        return false;
    }

    private void BuySmallHealth(InputAction.CallbackContext context)
    {
        Inventory.BuyHealth();
    }

    /*
    public float SetAimGrade()
    {
        return aimObject.transform.rotation.z;
    }
    */

    private void SettingsToggle(InputAction.CallbackContext context)
    {
        referenceToUI.GetComponent<UI>().ToggleSettings();
    }

    private void ShopToggle(InputAction.CallbackContext context)
    {
        referenceToUI.GetComponent<UI>().ToggleShop();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.CompareTag("Fire"))
        {
            audioSource.clip = fireSound;
            audioSource.loop = true;
            audioSource.Play();
        }*/
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        /*if (collision.CompareTag("Fire"))
        {
            audioSource.Stop();
        }
        */
    }

    public void PlayStepSound()
    {
        SoundFXManager.instance.PlayRandomSoundFXClip(stepSounds, transform.position, 1);
    }
}