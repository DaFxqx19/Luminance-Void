using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public static class Inventory
{
    //public static Inventory instance;
    public static int health = 100;

    public static int maxHealth = 200;
    public static int coinAmount = 0;
    public static int healthBuyAmount = 100;
    public static int healthCost = 2;

    public static float laserSpeed = 10;

    public static float aimGrade = 0f;

    public static List<Ability> abilities = new List<Ability>();

    public static List<Ability> allAbilities = new List<Ability>()
    {
        new Ability("Double Jump", "Lets You Double Jump :)", 50, 0, 1),
        new Ability("Flamethrower", "Flame on!", 500, 0, 200),
        new Ability("Grappling Hook", "Just like in the movies", 200, 0, 1),
    };

    public static int GetHealth()
    { return health; }

    public static string GetHealth(bool wantString)
    { return health.ToString(); }

    public static int GetMaxHealth()
    { return maxHealth; }

    public static int GetCoins()
    { return coinAmount; }

    public static string GetCoins(bool wantString)
    { return coinAmount.ToString(); }

    public static void AddCoins(int amount)
    {
        coinAmount += amount;
    }

    public static void SetCoins(int amount)
    {
        coinAmount = amount;
    }

    public static void SetHealthBuyAmount(int amount)
    {
        healthBuyAmount = amount;
    }

    public static void BuyHealth()
    {
        BuyHealth(healthBuyAmount, false);
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

    public static void SetHealth(int amount)
    {
        health = amount;
    }

    public static void HurtPlayer(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            //KILl!!
            Debug.Log("DIED!");
            Spawn.FindFirstObjectByType<Spawn>().SpawnFunction();
        }
    }

    public static int GetJumpsAvailable()
    {
        if (abilities.Count != 0)
        {
            return abilities.Find(i => i.nameOfAbility == "Double Jump").maxAmount + 1;
        }
        return 1;
    }

    public static void AddAbility(string nameOfAbility)
    {
        if (abilities != null || abilities.Count != 0)
        {
            foreach (Ability ab in abilities)
            {
                if (ab.nameOfAbility.Equals(nameOfAbility))
                {
                    if (ab.nameOfAbility == "Double Jump" && coinAmount >= ab.cost * (ab.maxAmount + 1))
                    {
                        ab.maxAmount += 1;
                        ab.cost = ab.maxAmount * ab.cost;
                        allAbilities.Find(i => i.nameOfAbility.Equals(nameOfAbility)).cost = ab.cost;
                        coinAmount -= ab.cost;
                    }
                    return;
                }
            }
        }
        foreach (Ability ab in allAbilities)
        {
            if (ab.nameOfAbility.Equals(nameOfAbility))
            {
                if (coinAmount >= ab.cost * (ab.maxAmount + 1))
                {
                    abilities.Add(ab);
                    coinAmount -= ab.cost * (ab.maxAmount + 1);
                }
                return;
            }
        }
    }

    public static int GetCostOfAbility(string nameOfRelevantAbility)
    {
        foreach (Ability ab in allAbilities)
        {
            if (ab.nameOfAbility.Equals(nameOfRelevantAbility))
            {
                return ab.cost * (ab.maxAmount + 1);
            }
        }

        return -1;
    }
}