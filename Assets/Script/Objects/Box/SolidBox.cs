using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SolidBox : Box
{

    // Update is called once per frame
    void Update()
    {
        if ((inside || beingPull) && Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            Interact();
        }
        if (beingPull)
        {
            Vector2 rightcorner = new Vector2(maincol.bounds.max.x, maincol.bounds.min.y);
            Vector2 leftcorner = new Vector2(maincol.bounds.min.x, maincol.bounds.min.y);
            Vector2 down = new Vector2(0, -0.3f);
            RaycastHit2D right = Physics2D.Linecast(rightcorner, rightcorner + down, boundaryLayer);
            RaycastHit2D left = Physics2D.Linecast(leftcorner, leftcorner + down, boundaryLayer);
            if(right.collider != null && left.collider != null) { return; }
            if((right.collider == null && rb.velocity.x > 0.1f) || (left.collider == null && rb.velocity.x < -0.1f))
            {
                rb.bodyType = RigidbodyType2D.Static;
            }
            else if ((right.collider == null && Input.GetKeyDown(KeyCode.A) && !Input.GetKey(KeyCode.D)) || (left.collider == null && Input.GetKeyDown(KeyCode.D) && !Input.GetKey(KeyCode.A)))
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
            }
        }
        if (startLanded) { return; }
        if (rb.velocity.y == 0)
        {
            startLanded = true;
            rb.bodyType = RigidbodyType2D.Static;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out _))
        {
            inside = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out _))
        {
            inside = false;
        }
    }

}
