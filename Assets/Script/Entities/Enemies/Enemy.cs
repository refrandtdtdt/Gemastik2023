using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public string movingDirection = "Idle";
    public bool isJumping = false;
    private float startTime;
    private float multiplier = 1f;
    protected Animator animator;
    [SerializeField] protected LayerMask playerMask;
    protected float Multiplier { get => multiplier; set => multiplier = value; }

    public override void Move()
    {
        if (movingDirection.Equals("Left") && MadepMana == Hadap.Kiri)
        {
            //transform.position += new Vector3(-Speed*Time.deltaTime, 0);
            animator.SetBool("Moving", true);
            rb.velocity = new Vector2(-Speed, rb.velocity.y+multiplier*0.2f);
            transform.localScale = new Vector3(-Scale.x, Scale.y, Scale.z);
        }
        else if (movingDirection.Equals("Right") && MadepMana == Hadap.Kanan)
        {
            rb.velocity = new Vector2(Speed, rb.velocity.y+multiplier*0.2f);
            animator.SetBool("Moving", true);
            //transform.position += new Vector3(Speed * Time.deltaTime, 0);
            transform.localScale = new Vector3(Scale.x, Scale.y, Scale.z);
        }
        else
        {
            animator.SetBool("Moving", false);
            rb.velocity = new Vector2(0, rb.velocity.y+ multiplier * 0.2f);
        }
    }

    public void Jump()
    {
        if (Time.time >= startTime + .5f)
        {
            if (CheckGround() && (JumpCount > 0) && isJumping)
            {
                //Debug.Log("Kuduna Loncat euy");
                //rb.AddForce(new Vector2(0, JumpDistance), ForceMode2D.Impulse);
                rb.velocity = new Vector2(rb.velocity.x, JumpDistance);
                JumpCount--;
                //isJumping = true;
                animator.SetBool("Jumping", true);
            }
            if (CheckGround())
            {
                JumpCount = 1;
                isJumping = false;
                animator.SetBool("Jumping", false);
            }
            //isJumping = false;
            startTime = Time.time;
        }

    }

    private bool CheckGround()
    {
        Collider2D playerCollider = GetComponent<BoxCollider2D>();
        Vector2 raycastPos = playerCollider.bounds.center;
        float raycastDist = playerCollider.bounds.extents.y + 0.2f;

        RaycastHit2D hit = Physics2D.BoxCast(raycastPos, playerCollider.bounds.size, 0f, Vector2.down, raycastDist, this.LayerMask);
        Color rayColor;
        if (hit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;

        }
        Debug.DrawRay(raycastPos + new Vector2(playerCollider.bounds.extents.x, 0), Vector2.down * raycastDist, rayColor);
        Debug.DrawRay(raycastPos - new Vector2(playerCollider.bounds.extents.x, 0), Vector2.down * raycastDist, rayColor);
        Debug.DrawRay(raycastPos - new Vector2(playerCollider.bounds.extents.x, raycastDist), 2 * raycastDist * Vector2.right, rayColor);
        return hit.collider != null && rb.velocity.y >= -0.1f && rb.velocity.y <= 0.1f;
    }

    public virtual void Attack()
    {

    }
}
