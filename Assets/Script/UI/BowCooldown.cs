using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BowCooldown : MonoBehaviour
{
    private Bow bow;
    private Slider slider;
    [SerializeField] private GameObject child;
    void Start()
    {
        slider = GetComponent<Slider>();
        bow = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Bow>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = bow.cooldownTimer / 3f;
        if (bow.cooldownTimer >= 3f)
        {
            child.SetActive(false);
        }
        else
        {
            child.SetActive(true);
        }
    }
}
