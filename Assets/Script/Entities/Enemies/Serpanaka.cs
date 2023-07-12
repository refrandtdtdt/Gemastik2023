using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Serpanaka : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        SetId(3);
        SetDescription("Serpanakan, raksasa kuat adik dari rahwana");
        Speed = 6f;
        JumpDistance = 8;
        SetMaxHealth(100);
        SetHealth(100);
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        Scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Multiplier *= -1;
    }

    public void BasicAttack()
    {

    }
}
