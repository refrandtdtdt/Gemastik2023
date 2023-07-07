using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Image background;
    [SerializeField] private Image portrait;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI dialogueText;
    private Player player;
    private Cutscene currCutscene;
    private Dialogue currDialogue;
    private bool triggered, typing, skip;
    private int index;

    private void Awake()
    {
        panel.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void Update()
    {
        if (panel.activeSelf)
        {
            if (!triggered)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (!typing)
                    {
                        index++;
                        triggered = true;
                        if(index == currCutscene.Dialogues.Capacity)
                        {
                            panel.SetActive(false);
                            player.CanMove = true;
                            Time.timeScale = 1;
                        }
                    }
                    else
                    {
                        skip = true;
                    }
                }
            } 
            else
            {
                currDialogue = currCutscene.Dialogues[index];
                portrait.sprite = currDialogue.portrait;
                nameText.text = currDialogue.name;
                StartCoroutine(TypeSentence(currDialogue.dialog));
                triggered = false;
            }
        }
    }

    public void StartCutscene(Cutscene cutscene)
    {
        Time.timeScale = 0;
        currCutscene = cutscene;
        index = 0;
        triggered = true;
        player.CanMove = false;
        panel.SetActive(true);
        background.sprite = currCutscene.background;
    }

    IEnumerator TypeSentence(string sentence)
    {
        typing = true;
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            //yield return new WaitForSeconds(0.01f);
            yield return new WaitForSecondsRealtime(0.01f);
            if (skip)
            {
                dialogueText.text = sentence;
                break;
            }
        }
        skip = false;
        typing = false;
    }
}
