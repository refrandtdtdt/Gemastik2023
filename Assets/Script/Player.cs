using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
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
            transform.position += new Vector3(speed, 0); ;
        }
    }
    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
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
}
