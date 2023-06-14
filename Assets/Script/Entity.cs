using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    //attribute
    [SerializeField] private int id;

    [SerializeField] private string description;

    // Update is called once per frame
    void Update()
    {
        
    }

    // getter and setter
    public int GetId()
    {
        return id;
    }
    public string GetDescription()
    {
        return description;
    }
    public void SetId(int id)
    {
        this.id = id;
    }
    public void SetDescription(string description)
    {
        this.description = description;
    }
}
