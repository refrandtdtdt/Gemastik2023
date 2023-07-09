using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform camerapos;
    [SerializeField] private float followspeed;
    private Transform playerpos;
    private Transform custompos;
    private bool followPlayer = true;

    private void Awake()
    {
        playerpos = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void FixedUpdate()
    {
        if (followPlayer)
        {
            Vector3 targetpos = new Vector3(playerpos.position.x, playerpos.position.y + 0.9f, -10);
            camerapos.position = Vector3.Lerp(camerapos.position, targetpos, followspeed * Time.deltaTime);
        }
        else
        {
            Vector3 targetpos = new Vector3(custompos.position.x, custompos.position.y, -10);
            camerapos.position = Vector3.Lerp(camerapos.position, targetpos, followspeed * Time.deltaTime);
        }
    }

    public void CustomTargetPosition(Transform newpos)
    {
        followPlayer = false;
        custompos = newpos;
    }

    public void StopCustomTarget()
    {
        followPlayer = true;
    }
}
