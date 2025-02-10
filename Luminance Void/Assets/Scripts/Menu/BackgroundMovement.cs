using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    private bool movingLeft = true;

    [SerializeField] private int moveSpeed = 1;

    private Vector3 startPosition = new Vector3(5.4f, 5f, -0.1432623f);
    private Vector3 endPosition = new Vector3(64.4f, 5f, -0.1432623f);

    // Start is called before the first frame update
    private void Start()
    {
        transform.position.Set(startPosition.x, startPosition.y, startPosition.z);
    }

    // Update is called once per frame
    private void Update()
    {
        if (movingLeft)
        {
            if (transform.position.x >= endPosition.x) { movingLeft = false; }
            transform.position = Vector2.MoveTowards(transform.position, endPosition, moveSpeed * Time.deltaTime);
        }
        else
        {
            if (!movingLeft)
            {
                if (transform.position.x <= startPosition.x) { movingLeft = true; }
                transform.position = Vector2.MoveTowards(transform.position, startPosition, moveSpeed * Time.deltaTime);
            }
        }
    }
}