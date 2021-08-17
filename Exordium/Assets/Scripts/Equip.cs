using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Equip", menuName = "Items/Equip")]
public class Equip : Item
{
    public EquipType EquipType;

    public int Armor = 0;
    public int Damage = 0;

    public override void Use()
    {
        base.Use();
        Debug.Log("Equipping " + this.ItemName);
    }
}

public enum EquipType { Head_Armor, Primary_Arm, Torso, Secondary_Arm }