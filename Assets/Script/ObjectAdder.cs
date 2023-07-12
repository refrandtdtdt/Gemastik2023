using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAdder : MonoBehaviour
{
    // Start is called before the first frame update
    public CutsceneTrigger trigger;
    public GameObject[] enemyObjects;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (GameObject gameObject in enemyObjects)
        {
            gameObject.SetActive(true);
            Vector3 scale = gameObject.transform.localScale;
            gameObject.transform.localScale = scale;
        }
    }
}
