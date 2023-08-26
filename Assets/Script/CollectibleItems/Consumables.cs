using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Consumables : Collectable
{
    private string itemName, description;
    private Sprite image;

    public string GetName()
    {
        return itemName;
    }

    public string GetDescription()
    {
        return description;
    }

    public Sprite GetImage()
    {
        return image;
    }

    public void Collect()
    {
        Inventory.Collect(this);
    }

    public abstract void Use();
}
