using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SolidBox : Box
{
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inside && Input.GetKey(KeyCode.LeftShift)) 
        {
            beingPull = true;
            deltaPlayerBox = player.transform.position - transform.position;
        }
        else
        {
            beingPull = false;
            deltaPlayerBox = Vector3.zero;
        }
        if (beingPull)
        {
            Interact();
        }
        else
        {
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            inside = true;
            this.player = player;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out _))
        {
            inside = false;
            this.player = null;
        }

    }

}
