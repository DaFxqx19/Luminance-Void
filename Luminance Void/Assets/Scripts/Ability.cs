using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public string nameOfAbility;
    public string description;
    public int cost;
    public float coolDown;
    public int maxAmount;
    public bool isAbility;

    public Ability(string name, string description, int cost, float coolDown, int maxAmount)
    {
        this.nameOfAbility = name;
        this.description = description;
        this.cost = cost;
        this.coolDown = coolDown;
        this.maxAmount = maxAmount;
    }

    public bool AbilityWithName(string name)
    {
        return nameOfAbility.Equals(name);
    }
}