using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Entity
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float speed;
    [SerializeField] private float jumpDistance;
    protected Rigidbody2D rb;

    // Player's Action

    public void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-speed, 0);
        }
        else if (Input.GetKey(KeyCode.D)){
            transform.position += new Vector3(speed, 0);
        }
    }
    /**
     * Jump action for player
     */
    public void Jump()
    {
        if (CheckGround() && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Kuduna Loncat euy");
            rb.AddForce(new Vector2(0, jumpDistance), ForceMode2D.Impulse);
        }
    }


    // getter and setter
    public float GetSpeed()
    {
        return speed;
    }
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
    
    public float GetJumpDistance()
    {
        return jumpDistance;
    }
    public void SetJumpDistance(float jumpDistance)
    {
        this.jumpDistance = jumpDistance;
    }

    private bool CheckGround()
    {
        Collider2D playerCollider = GetComponent<BoxCollider2D>();
        Vector2 raycastPos = playerCollider.bounds.center;
        float raycastDist = playerCollider.bounds.extents.y + 0.1f;

        RaycastHit2D hit = Physics2D.BoxCast(raycastPos, playerCollider.bounds.size, 0f, Vector2.down, raycastDist, layerMask);
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
        Debug.DrawRay(raycastPos - new Vector2(playerCollider.bounds.extents.x, raycastDist), Vector2.right * raycastDist*2, rayColor);
        return hit.collider != null;
    }
}
