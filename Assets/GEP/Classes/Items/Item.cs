using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemClass
    {
        Bottle,
        Torch,
        MedKit,
        Radio,
    }

    public ItemClass itemType;
    public int amount;

    public Sprite itemIcon;
    public int maxStack;
}
