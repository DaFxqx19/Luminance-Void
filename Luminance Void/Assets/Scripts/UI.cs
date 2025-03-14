using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject hpObject;
    [SerializeField] private GameObject coinObject;
    [SerializeField] private GameObject doubleJumpObject;

    [SerializeField] private GameObject settingsObject;
    [SerializeField] private GameObject hudObject;
    [SerializeField] private GameObject shopObject;

    [SerializeField] private GameObject hpCostObject;
    [SerializeField] private GameObject hpBuyAmountObject;

    [SerializeField] private GameObject doubleJumpCostObject;

    [SerializeField] private GameObject healthSlider;

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

        // Normal GUI Stats stuff
        hpObject.GetComponent<TMPro.TextMeshProUGUI>().text = "hp: " + Inventory.GetHealth(true);
        coinObject.GetComponent<TMPro.TextMeshProUGUI>().text = "$: " + Inventory.GetCoins(true);
        doubleJumpObject.GetComponent<TMPro.TextMeshProUGUI>().text = "Double Jumps: " + (Inventory.GetJumpsAvailable() - 1).ToString();

        // Health Slider
        hpCostObject.GetComponent<TMPro.TextMeshProUGUI>().text = ("Cost: " + (Inventory.healthBuyAmount * Inventory.healthCost).ToString());
        hpBuyAmountObject.GetComponent<TMPro.TextMeshProUGUI>().text = ("Amount: " + Inventory.healthBuyAmount.ToString());
        float amount = healthSlider.GetComponent<Slider>().value;
        Inventory.SetHealthBuyAmount((int)amount);

        // Double Jump Cost
        doubleJumpCostObject.GetComponent<TMPro.TextMeshProUGUI>().text = ("Cost: " + Inventory.GetCostOfAbility("Double Jump"));
    }

    public void ExitGame()
    {
        ToggleSettings();
        SceneManager.LoadScene(0);
    }

    public void PurchaseJumps()
    {
        Inventory.AddAbility("Double Jump");
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

    public void ToggleShop()
    {
        if (!UIStatus.Equals("settings"))
        {
            if (UIStatus.Equals("hud"))
            {
                // Open Shop
                hudObject.gameObject.SetActive(true);
                shopObject.gameObject.SetActive(true);
                UIStatus = "shop";
                Debug.Log("Opens shop");
            }
            else
            {
                // Close shop
                hudObject.gameObject.SetActive(true);
                shopObject.gameObject.SetActive(false);
                UIStatus = "hud";
                Debug.Log("Closes shop");
            }
        }
        // if in setting then do nothing >:)
    }
}