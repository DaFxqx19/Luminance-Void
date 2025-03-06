using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaserShow : MonoBehaviour
{
    [SerializeField] private GameObject laser;
    private float timer = 0;

    private float maxTime = 1;

    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        sr.size = new Vector2(1, timer / 2);
        sr.color = new Color(1, 0, 0, timer);
        if (timer >= maxTime)
        {
            SpawnLaser();
            Destroy(gameObject);
        }
    }

    private void SpawnLaser()
    {
        Instantiate(laser, transform.position, transform.rotation);
    }
}