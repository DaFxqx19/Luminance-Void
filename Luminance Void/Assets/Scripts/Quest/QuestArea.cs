using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestArea : MonoBehaviour
{
    public bool questActive = false;

    [SerializeField] private GameObject questText;

    private void Awake()
    {
        questText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            questActive = true;
            questText.gameObject.SetActive(true);
            //questText.GetComponent<TMPro.TextMeshProUGUI>().
            // Reveal UI thingy
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            questText.gameObject.SetActive(false);

            // hide that shiii
        }
    }
}