using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEngine.Rendering.VolumeComponent;

public class ShowBehindBlock : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    private int situation = 0;
    private float transparancy = 1;

    private void Update()
    {
        if (situation == 1)
        {
            if (transparancy > 0)
            {
                transparancy -= Time.deltaTime * speed;
                gameObject.GetComponent<Tilemap>().color = new Color(1, 1, 1, transparancy);
            }
            else
            {
                transparancy = 0;
            }
        }
        if (situation == 2)
        {
            if (transparancy < 1)
            {
                transparancy += Time.deltaTime * speed;
                //gameObject.GetComponent<Tilemap>().color = Color.white;
                gameObject.GetComponent<Tilemap>().color = new Color(1, 1, 1, transparancy);
            }
            else
            {
                transparancy = 1;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // transparacy 100%

        if (collision.CompareTag("Player"))
        {
            situation = 2;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            situation = 1;
        }
        // transparacy 0%
    }
}