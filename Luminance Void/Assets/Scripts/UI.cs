using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject hpObject;
    [SerializeField] private GameObject coinObject;

    // Update is called once per frame
    private void Update()
    {
        //hpObject.GetComponent<TMPro.TextMeshProUGUI>().text = "Hello World!";

        hpObject.GetComponent<TMPro.TextMeshProUGUI>().text = "hp: " + Inventory.GetHealth(true);
        coinObject.GetComponent<TMPro.TextMeshProUGUI>().text = "$: " + Inventory.GetCoins(true);
    }
}