using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleJembatan : Device
{
    public GameObject[] platforms;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact()
    {
        platforms[0].GetComponentInChildren<WPF_OnCommand>().Triggered = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Interact();
            }
        }  
    }
}
