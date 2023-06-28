using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class GameUI : MonoBehaviour
{
    private GameObject obj;

    public GameObject Object { get => obj; set => obj = value; }

    private void Awake()
    {
        obj = gameObject;
    }

}
