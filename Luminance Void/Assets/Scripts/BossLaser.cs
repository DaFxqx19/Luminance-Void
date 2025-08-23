using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaser : MonoBehaviour
{
    [SerializeField] private AudioClip[] laserSounds;

    public float laserSpeed = 10;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SoundFXManager.instance.PlayRandomSoundFXClip(laserSounds, this.gameObject, 1);
    }

    private void Update()
    {
        rb.velocity = transform.forward * laserSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory.HurtPlayer(35);
        }
    }
}