using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEntity : MonoBehaviour
{
    private int health, atk, def;
    private List<Effect> currentEffects;

    public int Health { get => health; set => health = value; }
    public int Atk { get => atk; set => atk = value; }
    public int Def { get => def; set => def = value; }

    private void applyEffects()
    {
        foreach (Effect effect in currentEffects)
        {
            if(effect.Duration == 0)
            {
                currentEffects.Remove(effect);
            }
            else
            {
                effect.Apply();
                effect.Duration--;
            }
        }
    }

    public virtual void Move()
    {
        applyEffects();
    }

    public void EndMove()
    {
        // kelar
    }
}
