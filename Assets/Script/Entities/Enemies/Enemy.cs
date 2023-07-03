using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public string movingDirection = "Idle";
    public bool isJumping = false;
    public override void Move()
    {
        if (movingDirection.Equals("Left"))
        {
            transform.position += new Vector3(-Speed, 0);
            transform.localScale = new Vector3(-Scale.x, Scale.y, Scale.z);
        }
        else if (movingDirection.Equals("Right"))
        {
            transform.position += new Vector3(Speed, 0);
            transform.localScale = new Vector3(Scale.x, Scale.y, Scale.z);
        }
    }

    public void Jump()
    {
        if (CheckGround() && (JumpCount > 0) && isJumping)
        {
            //Debug.Log("Kuduna Loncat euy");
            rb.AddForce(new Vector2(0, JumpDistance), ForceMode2D.Impulse);
            JumpCount--;
            isJumping = false;
        }
        if (CheckGround()) {
            JumpCount = 1;
            isJumping = false;
         }
    }


    private bool CheckGround()
    {
        Collider2D playerCollider = GetComponent<BoxCollider2D>();
        Vector2 raycastPos = playerCollider.bounds.center;
        float raycastDist = playerCollider.bounds.extents.y + 0.1f;

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
        return hit.collider != null;
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
        Scale = new Vector3(0.8f, 1.8f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
