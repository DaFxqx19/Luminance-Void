using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject playerReference;

    private void Awake()
    {
        SpawnFunction();
    }

    public void SpawnFunction()
    {
        playerReference.transform.position = transform.position;
        playerReference.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }
}