using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Collider2D))]
public abstract class Device : MonoBehaviour, Interactable
{
    protected ControlPanel UIpanel;
    protected Player player;
    private bool near;
    [SerializeField] private GameObject Popup;
    private Image image;
    private TextMeshProUGUI text;
    private float alpha;
    private bool change=false;

    private void OnValidate()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }
    private void Start()
    {
        UIpanel = GameObject.FindGameObjectWithTag("UI").GetComponentInChildren<ControlPanel>();
        image = Popup.GetComponentInChildren<Image>();
        text = Popup.GetComponentInChildren<TextMeshProUGUI>();
    }
    void Update()
    {
        if (near)
        {
            alpha += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.F))
            {
                Interact();
            }
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
        if(alpha != 0 || alpha != 1)
        {
            change = true;
        }
        else
        {
            change = false;
        }
    }

    public abstract void Interact();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            near = true;
            this.player = player;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            near = false;
        }
    }
}
