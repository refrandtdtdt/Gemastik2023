using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleJembatan : Device
{
    public ControlPanel UIpanel;
    public GameObject[] platforms;
    private bool near;
    private Player player;
    
    public override void Interact()
    {
        //UIpanel.SetupUI(this);
        //platforms[0].GetComponentInChildren<WPF_OnCommand>().Triggered = true;
    }

    private void Update()
    {
        if (near)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (UIpanel.gameObject.activeSelf)
                {
                    player.CanMove = true;
                    UIpanel.StopUI();
                }
                else
                {
                    player.CanMove = false;
                    UIpanel.SetupUI(this);
                }
            }
        }
    }

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
