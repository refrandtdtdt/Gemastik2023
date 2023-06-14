using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : Object
{
    [SerializeField] int damage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Entity ent))
        {
            ent.SetHealth(ent.GetHealth() - damage);
        }
    }
}
