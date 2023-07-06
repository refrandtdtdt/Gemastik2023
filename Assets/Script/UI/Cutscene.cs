using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;
    public Sprite portrait;
    public string dialog;
}
[CreateAssetMenu]
public class Cutscene : ScriptableObject
{
    public List<Dialogue> Dialogues = new List<Dialogue>();
}
