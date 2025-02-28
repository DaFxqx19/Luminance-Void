using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public void BuyJump()
    {
        Inventory.AddAbility("Double Jump");
    }

    public void BuyGrapple()
    {
        //Inventory.AddAbility("Grappling Hook");
    }

    public void BuyFlameThrower()
    {
        //Inventory.AddAbility("Flamethrower");
    }
}