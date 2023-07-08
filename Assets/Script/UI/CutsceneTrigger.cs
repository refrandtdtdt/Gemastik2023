using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneTrigger : MonoBehaviour
{
    enum TriggerType
    {
        onStart,
        onEnter,
        onInteract
    }
    [SerializeField] private CutsceneManager manager;
    [SerializeField] private Cutscene cutscene;
    [SerializeField] private TriggerType type;
    private bool enter = false;

    private void Start()
    {
        if (type != TriggerType.onStart) return;
        manager.StartCutscene(cutscene);
        Destroy(gameObject);
    }
    private void Update()
    {
        if (enter && Input.GetKeyDown(KeyCode.F))
        {
            manager.StartCutscene(cutscene);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out _))
        {
            switch (type)
            {
                case TriggerType.onStart:
                    break;
                case TriggerType.onEnter:
                    manager.StartCutscene(cutscene);
                    Destroy(gameObject);
                    break;
                case TriggerType.onInteract:
                    enter = true;
                    break;
                default:
                    break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out _))
        {
            enter = false;
        }
    }
}
