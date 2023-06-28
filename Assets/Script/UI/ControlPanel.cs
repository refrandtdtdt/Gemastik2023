using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanel : MonoBehaviour
{
    private GameObject buttonParent;
    private List<GameObject> buttons = new List<GameObject>();
    [SerializeField] private GameObject buttonTemplate;

    void Start()
    {
        gameObject.SetActive(false);
        buttonParent = gameObject.transform.GetChild(0).gameObject;
    }

    public void SetupUI(PuzzleJembatan puzzle)
    {
        gameObject.SetActive(true);
        foreach (GameObject platform in puzzle.platforms)
        {
            buttons.Add(Instantiate(buttonTemplate, buttonParent.transform));
        }
    }

    public void StopUI()
    {
        gameObject.SetActive(false);
        foreach (GameObject button in buttons)
        {
            Destroy(button);
        }
    }
}
