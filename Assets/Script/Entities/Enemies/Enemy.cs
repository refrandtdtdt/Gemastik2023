using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public override void Move()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        SetId(1);
        SetDescription("musuh");
        Speed = 0.05f;
        JumpDistance = 10;
        SetMaxHealth(100);
        SetHealth(100);
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
