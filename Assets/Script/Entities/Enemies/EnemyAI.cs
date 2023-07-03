using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using Unity.VisualScripting;

public class EnemyAI : MonoBehaviour
{

    public Transform target;
    public float speed;
    public float nextWaypointDistance = 2f;
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

        InvokeRepeating("UpdatePath", 0f, .5f);
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

        Vector2 direction = ((Vector2) path.vectorPath[currentWaypoint] - (Vector2) transform.position).normalized;
        if (direction.x < 0)
        {
            enemyObject.movingDirection = "Left";
            enemyObject.Move();
        } else if (direction.x > 0)
        {
            enemyObject.movingDirection = "Right";
            enemyObject.Move();
        }
        else
        {
            enemyObject.movingDirection = "Idle";
            enemyObject.Move();
        }
        
        if (direction.y > 0)
        {
            enemyObject.isJumping = true;
            enemyObject.Jump();
            enemyObject.isJumping = false;
        }
        float distance = Vector2.Distance(transform.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }
}
