using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Consumable", menuName = "Items/Consumable")]
public class Consumable : Item
{
    public int Heal = 0;

    public override void Use()
    {
        Debug.Log("Consuming " + ItemName);
    }
}
