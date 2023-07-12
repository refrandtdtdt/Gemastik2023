using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlPanel : MonoBehaviour
{
    public GameObject Panel;
    [SerializeField] private GameObject buttonParent;
    private List<GameObject> buttons = new List<GameObject>();
    [SerializeField] private GameObject buttonTemplate;

    void Start()
    {
        Panel.SetActive(false);
    }

    public void SetupUI(PuzzleJembatan puzzle)
    {
        Panel.SetActive(true);
        for (int i = 0; i < puzzle.buttonCount; i++)
        {
            buttons.Add(Instantiate(buttonTemplate, buttonParent.transform));
            foreach (GameObject platform in puzzle.buttonRules[i].platforms)
            {
                buttons[i].GetComponent<Button>().onClick.AddListener(delegate { puzzle.MovePlatform(platform); });
            }
        }
        //int j = 0;
        //foreach (GameObject button in buttons)
        //{
        //    j++;
        //}
    }

    //public void SetupUI()

    public void StopUI()
    {
        Panel.SetActive(false);
        foreach (GameObject button in buttons)
        {
            Destroy(button);
        }
        buttons.Clear();
    }
}
