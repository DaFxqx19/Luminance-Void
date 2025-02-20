using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePosition;

    [SerializeField] private PlayerInputActions playerControls;

    private InputAction look;

    // Start is called before the first frame update
    private void Start()
    {
        playerControls = new PlayerInputActions();

        mainCam = GameObject.FindFirstObjectByType<Camera>();
        look = playerControls.Player.Look;
        look.Enable();
    }

    private void OnDisable()
    {
        look.Disable();
    }

    // Update is called once per frame
    private void Update()
    {
        //mousePosition = mainCam.ScreenToWorldPoint(look.);

        Vector3 rotation = mousePosition - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}