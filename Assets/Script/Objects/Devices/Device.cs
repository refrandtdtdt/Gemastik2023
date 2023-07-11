using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class Device : MonoBehaviour, Interactable
{
    protected ControlPanel UIpanel;
    protected Player player;
    private bool near;

    private void OnValidate()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }
    private void Start()
    {
        UIpanel = GameObject.FindGameObjectWithTag("UI").GetComponent<ControlPanel>();
    }
    void Update()
    {
        if (near)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Interact();
            }
        }
    }

    public abstract void Interact();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            near = true;
            this.player = player;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            near = false;
        }
    }
}
