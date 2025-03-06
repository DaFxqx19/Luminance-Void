using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BossAI : MonoBehaviour
{
    [SerializeField] private GameObject laserObject;
    [SerializeField] private GameObject laserShowObject;
    [SerializeField] private GameObject playerObject;

    // for future random timing
    private float minTimer = 3;

    private float maxTimer = 5;

    // Boss stats >:)

    public float bossMaxHP = 2000;

    private float bossHP;

    private float timer = 0;

    private bool isAttacking = false;

    private int timesAttacked = 0;

    private void Start()
    {
        bossHP = bossMaxHP;
    }

    private void Update()
    {
        if (isAttacking == false)
        {
            // awaiting attack
            Debug.Log("Cooldown!");

            timer += Time.deltaTime;
            // start attack
            if (timer >= 5)
            {
                isAttacking = true;
                timer = 0;

                StartCoroutine(StartCharge());
            }
        }
    }

    private IEnumerator StartCharge()
    {
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(.2f);
            ChargeUp();
        }
    }

    private void ChargeUp()
    {
        Vector3 playerPosition = playerObject.transform.position;

        float rotZ = Mathf.Atan2(playerPosition.x - transform.position.x, playerPosition.y - transform.position.y) * Mathf.Rad2Deg;

        // float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        Vector3 relativePos = playerPosition - transform.position;

        // the second argument, upwards, defaults to Vector3.up
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.right);

        Instantiate(laserShowObject, transform.position, rotation);

        timesAttacked++;
        while (timer <= 1)
        {
            Debug.Log("is charging up!: " + timesAttacked);
            timer += Time.deltaTime;
        }
        if (timer >= 1)
        {
            isAttacking = false;
            timer = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerAttack"))
        {
        }
    }

    /*
    private void Attack(Quaternion rotation)
    {
        Debug.Log("The Boss Attacked now!");
        isAttacking = false;

        timer = 0;

        // transform.rotation = rotation;

        Instantiate(laserObject, transform.position, rotation);
    }
    */
}