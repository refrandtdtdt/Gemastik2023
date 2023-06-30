using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        for (int i = 0; i < puzzle.buttonCount; i++)
        {
            buttons.Add(Instantiate(buttonTemplate, buttonParent.transform));
            buttons[i].GetComponent<Button>().onClick.AddListener(delegate { puzzle.MovePlatform(i); });
        }
    }

    public void StopUI()
    {
        gameObject.SetActive(false);
        foreach (GameObject button in buttons)
        {
            buttons.Clear();
            Destroy(button);
        }
    }
}
