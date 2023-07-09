using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private float speed;
    private Transform maincamera;
    private Vector3 camerastart, start;
    void Start()
    {
        maincamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        camerastart = maincamera.position;
        start = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(start.x - (camerastart.x - maincamera.position.x) * speed, start.y - (camerastart.y - maincamera.position.y) * speed, 1);
    }
}
