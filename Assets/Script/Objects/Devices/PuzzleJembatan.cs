using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleJembatan : Device
{
    [SerializeField] private WPF_OnCommand[] platforms;
    [SerializeField] private List<int> buttonRules = new List<int>();
    [HideInInspector] public int buttonCount;

    private void Awake()
    {
        buttonCount = buttonRules.Capacity;
    }

    public void MovePlatform(string ruleidx)
    {
        //Debug.Log("rule ke-" + ruleidx);
        int rule = buttonRules[int.Parse(ruleidx)];
        while(rule > 0)
        {
            //Debug.Log("platform ke-"+(rule % 10));
            platforms[(rule % 10)-1].Triggered = true;
            rule = rule / 10;
        }
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
}
