using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
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
    }
}