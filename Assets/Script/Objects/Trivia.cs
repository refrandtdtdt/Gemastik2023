using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trivia : MonoBehaviour, Interactable
{
    [SerializeField] private string title;
    [TextArea(2,40)]
    [SerializeField] private string message;
    
    private TriviaPanel panel;
    private Player player;
    private bool insideYourMom = false;
    public void Interact()
    {
        player.CanMove = !player.CanMove;
        panel.ShowMessage(title, message);
    }

    void Start()
    {
        panel = GameObject.FindGameObjectWithTag("UI").GetComponentInChildren<TriviaPanel>();
    }

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
}
