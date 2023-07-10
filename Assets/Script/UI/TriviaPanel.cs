using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TriviaPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private GameObject TextPanel;

    private void Start()
    {
        TextPanel.SetActive(false);
    }
    public void ShowMessage(string title, string message)
    {
        TextPanel.SetActive(!TextPanel.activeSelf);
        titleText.text = title;
        messageText.text = message;
    }
}
