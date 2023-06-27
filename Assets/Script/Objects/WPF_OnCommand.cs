using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WPF_OnCommand : WaypointFollower
{
    private bool triggered = false;

    public bool Triggered { get => triggered; set => triggered = value; }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Waypoints[CurrentWaypointIndex].transform.position, Time.deltaTime * Speed);
        if (Triggered)
        {
            CurrentWaypointIndex++;
            if (CurrentWaypointIndex >= Waypoints.Length)
            {
                CurrentWaypointIndex = 0;
            }
            Triggered = false;
        }
    }
}
