using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public abstract class Box : MonoBehaviour,IMoveable
{
    protected bool beingPull = false;
    protected bool inside = false;
    protected Player player;
    protected Rigidbody2D rb;
    [SerializeField] protected Collider2D maincol, triggercol;
    [SerializeField] protected LayerMask boundaryLayer;
    [SerializeField] protected float speedminus;
    protected Vector3 deltaPlayerBox;
    protected FixedJoint2D joint;
    protected Collider2D playercol;
    protected bool startLanded = false;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playercol = player.GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        joint = GetComponent<FixedJoint2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.velocity = new Vector2(0f, -1f);
    }
    //private void Update()
    //{
    //    if (inside)
    //    {
    //        if (Input.GetKeyDown(KeyCode.F))
    //        {
    //            Interact();
    //        }
    //    }
    //}
    public void Interact()
    {
        if (beingPull)
        {
            LetItGo();
        } 
        else
        {
            PullBox();
        }
    }

    private void PullBox()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        Vector3 currPlayerPos = player.transform.position;
        if (player.gameObject.transform.position.x < gameObject.transform.position.x)
        {
            player.transform.localScale = new Vector3(player.Scale.x, player.Scale.y, player.Scale.z);
            player.transform.position = new Vector3(gameObject.transform.position.x - maincol.bounds.extents.x - playercol.bounds.extents.x, currPlayerPos.y, currPlayerPos.z);
        }
        else
        {
            player.transform.localScale = new Vector3(-player.Scale.x, player.Scale.y, player.Scale.z);
            player.transform.position = new Vector3(gameObject.transform.position.x + maincol.bounds.extents.x + playercol.bounds.extents.x, currPlayerPos.y, currPlayerPos.z);
        }
        player.IsPulling = true;
        //player.Speed -= speedminus;

        joint.enabled = true;
        joint.connectedBody = player.GetComponent<Rigidbody2D>();
        beingPull = true;
    }
    
    private void LetItGo()
    {
        rb.bodyType = RigidbodyType2D.Static;
        beingPull = false;
        joint.enabled = false;
        joint.connectedBody = null;
        player.IsPulling = false;
        /*        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Ground");
                foreach(GameObject obstacle in obstacles)
                {
                    AstarPath.active.UpdateGraphs(obstacle.GetComponent<Collider2D>().bounds);
                }*/
        //player.Speed += speedminus;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.TryGetComponent<Player>(out Player player))
    //    {
    //        inside = true;
    //    }
    //}
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.TryGetComponent<Player>(out Player player))
    //    {
    //        inside = false;
    //    }
    //}


    //public void hitBoundary()
    //{
    //    Vector2 origin = rb.position;
    //    //float rayCastDist = rb.position
    //    //RaycastHit2D hit = Physics2D.BoxCast() 
    //}
}
