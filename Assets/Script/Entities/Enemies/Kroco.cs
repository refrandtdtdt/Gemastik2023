using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kroco : Enemy
{
    private EnemyAI enemyAI;
    private Player player;
    private bool attack = false;
    private bool attackhit = false;
    [SerializeField] private float attackcd;
    float cd;
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
        animator = GetComponent<Animator>();
        enemyAI = GetComponent<EnemyAI>();
        player = enemyAI.target.GetComponent<Player>();
        AttackPower = 10;
        cd = attackcd;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Multiplier *= -1;
        if (attack)
        {
            if (attackPoint.activeSelf)
            {
                attackPoint.SetActive(false);
                Attack();
            }
            attackcd = 0;
        }
        else
        {
            if(attackcd < cd)
            {
                attackcd += Time.deltaTime;
                return;
            }
            RaycastHit2D[] hitrange = Physics2D.LinecastAll(new Vector2((boxCollider.bounds.min.x -2f), 0), new Vector2((2f + boxCollider.bounds.max.x), 0));
            foreach (RaycastHit2D hit in hitrange)
            {
                if(hit.collider.tag == "Player" && !attack)
                {
                    animator.Play("Kroco_Attack");
                    enemyAI.canMove = false;
                    attack = true;
                    attackhit = false;
                    return;
                }
            }
        }
        
    }

    public override void Attack()
    {
        if (attackhit)
        {
            return;
        }
        RaycastHit2D[] hitrange = Physics2D.LinecastAll(new Vector2((boxCollider.bounds.min.x - 2f), 0), new Vector2((2f + boxCollider.bounds.max.x), 0));
        foreach (RaycastHit2D hit in hitrange)
        {
            if (hit.collider.tag == "Player" && attack)
            {
                attackhit = true;
                break;
            }
        }
        attack = false;
        if (attackhit)
        {
            player.SetHealth(player.GetHealth() - AttackPower);
            Debug.Log("duar");
            Rigidbody2D playerrb = player.GetComponent<Rigidbody2D>();
            Vector2 knockback = new Vector2(400f, 200f);
            knockback.x = knockback.x * transform.localScale.x;
            playerrb.AddForce(knockback);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, AttackRadius);
    }

}
