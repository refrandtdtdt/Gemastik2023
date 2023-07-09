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
    private Player player;
    private bool insideYourMom = false;
    public void Interact()
    {
        titleText.enabled = !titleText.enabled;
        messageText.enabled = !messageText.enabled;
        player.CanMove = !player.CanMove;
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
        if (insideYourMom && Input.GetKeyDown(KeyCode.F))
        {
            Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            player = collision.gameObject.GetComponent<Player>();
            insideYourMom = true;
        }   
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            player = null;
            insideYourMom = false;
        }
    }

    public void ShowMessage()
    {
        titleText.text = title;
        messageText.text = message;
    }
}
