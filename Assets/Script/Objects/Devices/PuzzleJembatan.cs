using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class buttonJembatan
{
    [Tooltip("platform yang dipengaruhin button")]
    public GameObject[] platforms;
}
public class PuzzleJembatan : Device
{
    public List<buttonJembatan> buttonRules = new List<buttonJembatan>();
    [HideInInspector] public int buttonCount;

    private void Awake()
    {
        buttonCount = buttonRules.Capacity;
    }

    public void MovePlatform(GameObject platform)
    {
        platform.GetComponentInChildren<WPF_OnCommand>().Triggered = true;
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
