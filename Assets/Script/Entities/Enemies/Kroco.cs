using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kroco : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        SetId(1);
        SetDescription("musuh");
        Speed = 7f;
        JumpDistance = 11;
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

    public override void Attack()
    {
        Collider2D players = Physics2D.OverlapCircle(attackPoint.transform.position, AttackRadius, playerMask);
        Player player = players.GetComponent<Player>();
        if (player != null )
        {
            player.SetHealth(player.GetHealth() - AttackPower);
        }
    }
}
