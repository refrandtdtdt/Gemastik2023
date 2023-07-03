using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public abstract class Collectible : MonoBehaviour
{
    private void OnValidate()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {
            CollectItem(player);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<Collider2D>().enabled = false;
            // destroy called in child
        }
    }

    protected abstract void CollectItem(Player player);
}
