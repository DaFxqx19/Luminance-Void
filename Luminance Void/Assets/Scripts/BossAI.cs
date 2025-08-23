using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class BossAI : MonoBehaviour
{
    [SerializeField] private GameObject coinSpawner;
    [SerializeField] private GameObject switchSceneObject;

    [SerializeField] private GameObject laserObject;
    [SerializeField] private GameObject laserShowObject;
    [SerializeField] private GameObject playerObject;

    //[SerializeField] private GameObject healthUIObject;
    [SerializeField] private GameObject healthTextObject;

    [SerializeField] private GameObject healthSliderObject;

    [SerializeField] private AudioClip[] chargingUpSounds;
    [SerializeField] private AudioClip deathSound;

    public bool isActive = false;

    // for future random timing
    /*
    private float minTimer = 3;

    private float maxTimer = 5;
    */

    // Boss stats >:)

    public float bossMaxHP = 2000;

    private float bossHP;

    private float timer = 0;

    private bool isAttacking = false;

    private int timesAttacked = 0;

    private void Start()
    {
        bossHP = bossMaxHP;
        healthSliderObject.GetComponent<Slider>().maxValue = bossMaxHP;

        //healthUIObject.gameObject.SetActive(false);
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
        healthSliderObject.GetComponent<Slider>().value = bossHP;
        healthTextObject.GetComponent<TMPro.TextMeshProUGUI>().text = ("Super Dangerrous quantum AI: " + bossHP).ToString();

        if (bossHP <= 0)
        {
            KillBoss();
        }
    }

    private void KillBoss()
    {
        for (int i = 0; i < 5; i++)
        {
            Vector3 change = new Vector3(Random.Range(-1f, 1f), Random.Range(0.5f, 2f));

            Instantiate(coinSpawner, transform.position + change, Quaternion.identity);
        }
        Debug.Log("You Killed Me! ARGH");
        Instantiate(switchSceneObject);
        Destroy(gameObject);
    }

    private IEnumerator StartCharge()
    {
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(.2f);
            ChargeUp();
        }
        yield return new WaitForSeconds(1.2f);

        SoundFXManager.instance.PlayRandomSoundFXClip(chargingUpSounds, transform.position, 1);
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
        if (collision.CompareTag("PlayerAttack") && isActive)
        {
            bossHP -= 25;
        }
    }

    /*
    public void StartBossUI()
    {
        isActive = true;
        healthUIObject.gameObject.SetActive(true);
    }\
    */

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