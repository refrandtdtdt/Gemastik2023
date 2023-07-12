using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Trivia : MonoBehaviour, Interactable
{
    [SerializeField] private string title;
    [TextArea(2,40)]
    [SerializeField] private string message;
    
    private TriviaPanel panel;
    private Player player;
    private bool insideYourMom = false;
    [SerializeField] private GameObject Popup;
    private Image image;
    private TextMeshProUGUI text;
    private float alpha;
    private bool change = false;
    public void Interact()
    {
        player.CanMove = !player.CanMove;
        panel.ShowMessage(title, message);
    }

    void Start()
    {
        panel = GameObject.FindGameObjectWithTag("UI").GetComponentInChildren<TriviaPanel>();
        image = Popup.GetComponentInChildren<Image>();
        text = Popup.GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update()
    {
        //cek apakah dia dapet input
        if (insideYourMom && Input.GetKeyDown(KeyCode.F))
        {
            Interact();
        }

        if (insideYourMom)
        {
            alpha += Time.deltaTime;
        }
        else
        {
            alpha -= Time.deltaTime;
        }
        alpha = Mathf.Clamp(alpha, 0, 1);
        if (change)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
            text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
        }
        if (alpha != 0 || alpha != 1)
        {
            change = true;
        }
        else
        {
            change = false;
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
