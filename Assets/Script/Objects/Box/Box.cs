using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Box : MonoBehaviour,IMoveable
{
    //method override
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (collider.gameObject.TryGetComponent<Player>(out _))
            {
                Debug.Log("Whoops!");
                Interact();
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {

        }
    }
    public void Interact()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
