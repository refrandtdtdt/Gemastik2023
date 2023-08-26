using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Inventory
{
    private static Dictionary<Consumables,int> consumableInventory;
    private static List<Collectibles> collectibleInventory;

    public static Dictionary<Consumables,int> GetConsumables()
    {
        return consumableInventory;
    }

    public static List<Collectibles> GetCollectibles()
    {
        return collectibleInventory;
    }

    public static void UseConsumable(Consumables consumable)
    {
        consumableInventory[consumable]--;
        if(consumableInventory[consumable] == 0)
        {
            consumableInventory.Remove(consumable);
        }
    }

    public static void Collect(Consumables consumable)
    {
        if (!consumableInventory.TryAdd(consumable, 1))
        {
            consumableInventory[consumable]++;
        }
    }

    public static void Collect(Collectibles collectible)
    {
        collectibleInventory.Add(collectible);
    }

    public static void Reset()
    {
        consumableInventory.Clear();
        collectibleInventory.Clear();
    }
}
