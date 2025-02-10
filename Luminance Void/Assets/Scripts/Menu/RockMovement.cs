using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RockMovement : MonoBehaviour
{
    [SerializeField] private int moveSpeed = 1;
    private float timer = 5f;

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            float random = Random.Range(0f, 260f);
            timer = Random.Range(0f, 20f); ;
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(Mathf.Cos(random), Mathf.Sin(random)), moveSpeed * Time.deltaTime);
        }
    }
}