using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private int currentWaypointIndex;
    [SerializeField] private float speed;

    public GameObject[] Waypoints { get => waypoints; set => waypoints = value; }
    public float Speed { get => speed; set => speed = value; }
    public int CurrentWaypointIndex { get => currentWaypointIndex; set => currentWaypointIndex = value; }
}
