using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 4f;
    private float vertical;
    private bool isClimbing;
    private bool isLadder;

    [SerializeField] private Rigidbody2D rb;

    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        if (isLadder && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
        }
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
        }
        else
        {
            rb.gravityScale = 2.5f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Climbable"))
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Climbable"))
        {
            isLadder = false;
            isClimbing = false;
        }
    }
}
