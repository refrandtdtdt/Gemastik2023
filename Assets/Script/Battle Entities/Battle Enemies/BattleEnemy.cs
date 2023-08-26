using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BattleEnemy : BattleEntity
{
    //mungkin gold ato exp
    private int expDrop, goldDrop;

    public int ExpDrop { get => expDrop; set => expDrop = value; }
    public int GoldDrop { get => goldDrop; set => goldDrop = value; }
}
