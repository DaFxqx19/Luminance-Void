using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Inventory
{
    //public static Inventory instance;
    public static int health = 100;

    public static int maxHealth = 200;
    public static int coinAmount = 100;
    private static int healthCost = 2;

    public static int GetHealth()
    { return health; }

    public static string GetHealth(bool wantString)
    { return health.ToString(); }

    public static int GetCoins()
    { return coinAmount; }

    public static string GetCoins(bool wantString)
    { return coinAmount.ToString(); }

    public static void SetCoins(int amount)
    {
        coinAmount = amount;
    }

    public static void BuyHealth()
    {
        BuyHealth(20, false);
    }

    public static void BuyHealth(int amount)
    {
        BuyHealth(amount, false);
    }

    public static void BuyHealth(int amount, bool revival)
    {
        Debug.Log("Bought health: " + amount);
        if (revival) { health = maxHealth; return; }
        if (coinAmount >= amount * healthCost)
        {
            if (health + amount >= maxHealth) { amount = maxHealth - health; }
            health += amount;
            SetCoins(GetCoins() - amount * healthCost);
        }
    }
}