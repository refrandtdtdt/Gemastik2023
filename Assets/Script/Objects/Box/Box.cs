using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Box : MonoBehaviour,IMoveable
{
    protected bool beingPull = false;
    protected bool inside = false;
    protected Player player;
    protected Rigidbody2D rb;
    protected LayerMask boundaryLayer;
    protected Vector3 deltaPlayerBox;
    
    public void Interact()
    {
        transform.position = player.transform.position - deltaPlayerBox;

    }

    public void hitBoundary()
    {
        Vector2 origin = rb.position;
        //float rayCastDist = rb.position
        //RaycastHit2D hit = Physics2D.BoxCast() 
    }
}
