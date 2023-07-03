using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlPanel : MonoBehaviour
{
    private GameObject buttonParent;
    private List<GameObject> buttons = new List<GameObject>();
    [SerializeField] private GameObject buttonTemplate;

    void OnValidate()
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
        }
        int j = 0;
        foreach (GameObject button in buttons)
        {
            button.name = j + "";
            button.GetComponent<Button>().onClick.AddListener(delegate { puzzle.MovePlatform(button.name); });
            j++;
        }
    }

    //public void SetupUI()

    public void StopUI()
    {
        gameObject.SetActive(false);
        foreach (GameObject button in buttons)
        {
            Destroy(button);
        }
        buttons.Clear();
    }
}
