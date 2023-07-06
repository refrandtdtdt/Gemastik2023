using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using Unity.VisualScripting;
using System;

public class EnemyAI : MonoBehaviour
{

    public Transform target;
    public float speed;
    public float nextWaypointDistance = 25f;
    public Enemy enemyObject;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        enemyObject = gameObject.GetComponent<Enemy>();
        speed = enemyObject.Speed;
        target = GameObject.FindGameObjectWithTag("Player").transform;

        InvokeRepeating("UpdatePath", 0f, .1f);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(transform.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Recalculate Graph");
            AstarPath.active.Scan();
        }

        if (path == null)
        {
            return;
        }
        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        reachedEndOfPath = false;

        if (Vector2.Distance(transform.position, target.position) <= 20f)
        {
            Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - (Vector2)transform.position).normalized;
            if (direction.x < 0)
            {
                enemyObject.movingDirection = "Left";
                enemyObject.Move();
            }
            else if (direction.x > 0)
            {
                enemyObject.movingDirection = "Right";
                enemyObject.Move();
            }
            else
            {
                enemyObject.movingDirection = "Idle";
                enemyObject.Move();
            }

            if ((-transform.position + target.position).y > 0.5f)
            {
                enemyObject.isJumping = true;
                enemyObject.Jump();
                enemyObject.isJumping = false;
            }
        }
        float distance = Vector2.Distance(transform.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }
}
