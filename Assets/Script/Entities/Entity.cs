using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    //attribute
    private int id;
    private string description;
    private int health;
    private int maxHealth;

    // getter and setter
    public int GetId()
    {
        return id;
    }
    public string GetDescription()
    {
        return description;
    }
    public int GetHealth()
    {
        return health;
    }
    public int GetMaxHealth()
    {
        return maxHealth;
    }
    public void SetId(int id)
    {
        this.id = id;
    }
    public void SetDescription(string description)
    {
        this.description = description;
    }
    public void SetHealth(int health)
    {
        this.health = health;
        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }
    public void SetMaxHealth(int maxHealth)
    {
        this.maxHealth = maxHealth;
        if(maxHealth < health)
        {
            health = maxHealth;
        }
    }
}
