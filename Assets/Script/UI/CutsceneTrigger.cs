using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneTrigger : MonoBehaviour
{
    //masih dummy

    [SerializeField] private CutsceneManager manager;
    [SerializeField] private Cutscene cutscene;
    private bool enter;

    private void Update()
    {
        //if(enter && Input.GetKeyDown(KeyCode.Q))
        //{
        //    manager.StartCutscene(cutscene);
        //}
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<Player>(out _))
        {
            enter = true;
            manager.StartCutscene(cutscene);
            Destroy(gameObject);
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.TryGetComponent<Player>(out _))
    //    {
    //        enter = false;
    //    }
    //}
}
