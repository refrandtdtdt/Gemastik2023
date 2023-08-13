using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stun : Debuff
{
    public Stun(BattleEntity entity, int duration)
    {
        Ent = entity;
        Duration = duration;
    }
    override public void Apply()
    {
        Ent.EndMove();
    }
}
