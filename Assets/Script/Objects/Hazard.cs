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

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player p))
        {
            // pindah ke scene lain
        }
    }
}
