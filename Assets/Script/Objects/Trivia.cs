using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Trivia : MonoBehaviour, Interactable
{
    [SerializeField] private string title;
    [SerializeField] private string message;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI messageText;
    public void Interact()
    {
        titleText.enabled = !titleText.enabled;
        messageText.enabled = !messageText.enabled;
        ShowMessage();
    }

    // Start is called before the first frame update
    void Start()
    {
        titleText.enabled = false;
        messageText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //cek apakah dia dapet input
        if (Input.GetKeyDown(KeyCode.F))
        {
            Interact();
        }
    }

    public void ShowMessage()
    {
        titleText.text = title;
        messageText.text = message;
    }
}
