using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public string ItemName;
    public Sprite Icon;

    public virtual void Use()
    {

    }
}
