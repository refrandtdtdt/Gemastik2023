using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : Object
{
    [SerializeField] int damage;
    [SerializeField] float cd;
    float currCd = 0;
    bool hit = false;
    Player player;

    private void Update()
    {
        if (hit)
        {
            if(currCd <= 0)
            {
                player.SetHealth(player.GetHealth() - damage);
                currCd = cd;
            }
            else
            {
                currCd -= Time.deltaTime;
            }
        }
        else
        {
            if(currCd > 0)
            {
                currCd -= Time.deltaTime;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player p))
        {
            player = p;
            hit = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player p))
        {
            player = p;
            hit = false;
        }
    }
}
