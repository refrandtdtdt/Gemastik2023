using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;
    public Sprite portrait;
    [TextArea(2,10)]
    public string dialog;
}
[CreateAssetMenu]
public class Cutscene : ScriptableObject
{
    public Sprite background;
    public List<Dialogue> Dialogues = new List<Dialogue>();
}
