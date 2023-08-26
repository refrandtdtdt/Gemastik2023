using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Collectibles : ScriptableObject, Collectable
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
}
