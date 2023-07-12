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
        SetMaxHealth(1000);
        SetHealth(1000);
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        Scale = transform.localScale;
        AttackPower = 20;
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
        Collider2D[] players = Physics2D.OverlapBoxAll(attackPoint.transform.position, new Vector2(AttackRadius / 2, AttackRadius), 0f, playerMask);
        foreach (Collider2D playerCollider in players)
        {
            Debug.Log("Hit Player");
            if (playerCollider.TryGetComponent<Player>(out Player player))
            {
                player.SetHealth(player.GetHealth() - AttackPower);
            }
        }
    }

    public void SkillAttack()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(attackPoint.transform.position, new Vector3(AttackRadius/2, AttackRadius, 1));
    }
}
