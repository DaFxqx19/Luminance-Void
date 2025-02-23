using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject hpObject;
    [SerializeField] private GameObject coinObject;

    [SerializeField] private GameObject settingsObject;
    [SerializeField] private GameObject hudObject;
    [SerializeField] private GameObject shopObject;

    public string UIStatus;
    private string lastStatus;

    private void Start()
    {
        UIStatus = "hud";
        hudObject.gameObject.SetActive(true);
        shopObject.gameObject.SetActive(false);
        settingsObject.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        //hpObject.GetComponent<TMPro.TextMeshProUGUI>().text = "Hello World!";

        hpObject.GetComponent<TMPro.TextMeshProUGUI>().text = "hp: " + Inventory.GetHealth(true);
        coinObject.GetComponent<TMPro.TextMeshProUGUI>().text = "$: " + Inventory.GetCoins(true);
    }

    public void ToggleSettings()
    {
        if (UIStatus != "settings")
        {
            lastStatus = UIStatus;
            UIStatus = "settings";
            hudObject.gameObject.SetActive(false);
            shopObject.gameObject.SetActive(false);
            settingsObject.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            if (lastStatus.Equals("hud"))
            {
                hudObject.gameObject.SetActive(true);
                shopObject.gameObject.SetActive(false);
                settingsObject.gameObject.SetActive(false);
            }
            if (lastStatus.Equals("shop"))
            {
                hudObject.gameObject.SetActive(false);
                shopObject.gameObject.SetActive(true);
                settingsObject.gameObject.SetActive(false);
            }
            UIStatus = lastStatus;
            lastStatus = "settings";
            Time.timeScale = 1f;
        }
    }
}