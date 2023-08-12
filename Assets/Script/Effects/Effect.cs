using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect
{
    private BattleEntity entity;
    private int duration;
    public BattleEntity Ent { get => entity; set => entity = value; }
    public int Duration { get => duration; set => duration = value; }
    public abstract void Apply();
}
