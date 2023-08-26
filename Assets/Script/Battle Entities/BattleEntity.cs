using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEntity
{
    private string name;
    private int maxhealth, health, atk, def, level;
    private float critRate, critDmg;
    private List<Effect> currentEffects;
    private bool moved, alive;
    private BattleEntity target;
    private Animator anim;

    public int Maxhealth { get => maxhealth; set => maxhealth = value; }
    public int Health { get => health; set => health = value; }
    public int Atk { get => atk; set => atk = value; }
    public int Def { get => def; set => def = value; }
    public bool Moved { get => moved; set => moved = value; }
    public bool Alive { get => alive; set => alive = value; }
    public int Level { get => level; set => level = value; }
    public BattleEntity Target { get => target; set => target = value; }
    public float CritRate { get => critRate; set => critRate = value; }
    public float CritDmg { get => critDmg; set => critDmg = value; }
    public string Name { get => name; set => name = value; }
    public Animator Anim { get => anim; set => anim = value; }

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
        if(health <= 0)
        {
            alive = false;
            EndMove();
        }
    }

    public void EndMove()
    {
        moved = true;
    }

    public int CalculateDamage(float dmgPercentage)
    {
        float crit = Random.value;
        int critHit = (crit <= critRate) ? 1 : 0;
        float dmg = dmgPercentage * (Atk - Target.Def / 2) * (1 + critHit * critDmg);
        return Mathf.RoundToInt(dmg);
    }
}
