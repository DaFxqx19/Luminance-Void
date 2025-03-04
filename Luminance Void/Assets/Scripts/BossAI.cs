using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BossAI : MonoBehaviour
{
    [SerializeField] private GameObject laserObject;
    [SerializeField] private GameObject playerObject;

    private float minTimer = 3;
    private float maxTimer = 5;

    private float timer = 0;

    private bool isAttacking = false;

    private int timesAttacked = 0;

    // Update is called once per frame
    private void Update()
    {
        if (isAttacking == false)
        {
            // awaiting attack
            Debug.Log("Cooldown!");

            timer += Time.deltaTime;
            // start attack
            if (timer >= 3)
            {
                isAttacking = true;
                timer = 0;
                ChargeUp();
            }
        }
    }

    private void ChargeUp()
    {
        timesAttacked++;
        while (timer <= 1)
        {
            Debug.Log("is charging up!: " + timesAttacked);
            timer += Time.deltaTime;
        }
        Attack();
    }

    private void Attack()
    {
        Debug.Log("The Boss Attacked now!");
        isAttacking = false;

        Vector3 playerPosition = playerObject.transform.position;

        float rotZ = Mathf.Atan2(playerPosition.x - transform.position.x, playerPosition.y - transform.position.y) * Mathf.Rad2Deg;

        // float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        Vector3 relativePos = playerPosition - transform.position;

        // the second argument, upwards, defaults to Vector3.up
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.right);
        // transform.rotation = rotation;

        Instantiate(laserObject, transform.position, rotation);
    }
}