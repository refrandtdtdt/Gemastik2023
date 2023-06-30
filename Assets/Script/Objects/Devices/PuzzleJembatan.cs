using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleJembatan : Device
{
    public ControlPanel UIpanel;
    public WPF_OnCommand[] platforms;
    public List<int> buttonRules = new List<int>();
    private bool near;
    private Player player;
    [HideInInspector] public int buttonCount;

    private void Awake()
    {
        buttonCount = buttonRules.Capacity;
    }

    public override void Interact()
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

    public void MovePlatform(int ruleidx)
    {
        float rulefloat = buttonRules[ruleidx];
        while(rulefloat > 0)
        {
            platforms[(int)(rulefloat % 10)-1].Triggered = true;
            rulefloat = Mathf.Floor(rulefloat / 10);
        }
    }

    private void Update()
    {
        if (near)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Interact();
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
