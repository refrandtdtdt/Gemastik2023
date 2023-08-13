using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCharacter : BattleEntity
{
    private int sp, maxSp, energy, maxEnergy, exp, nextLevel, spRegen, firstSkillCost, secondSkillCost, aggro;
    //private static List<string> inventory;
    public int Sp { get => sp; set => sp = value; }
    public int Energy { get => energy; set => energy = value; }
    public int FirstSkillCost { get => firstSkillCost; set => firstSkillCost = value; }
    public int SecondSkillCost { get => secondSkillCost; set => secondSkillCost = value; }
    public int Aggro { get => aggro; set => aggro = value; }
    public int MaxSp { get => maxSp; set => maxSp = value; }
    public int MaxEnergy { get => maxEnergy; set => maxEnergy = value; }
    public int SpRegen { get => spRegen; set => spRegen = value; }

    public virtual void BasicAttack()
    {
        sp += SpRegen;
    }
    public virtual void FirstSkill()
    {
        sp -= FirstSkillCost;
    }
    public virtual void SecondSkill()
    {
        sp -= SecondSkillCost;
    }
    public virtual void Ultimate()
    {
        energy = 0;
    }

    public void UseItem()
    {
        // ngepake item dari inventory
        
    }

    override public void Move()
    {
        base.Move();
        //try catch
        energy++;
    }

    public void AddExp(int exp)
    {
        this.exp += exp;
        if(this.exp >= nextLevel)
        {
            Level++;
            this.exp -= nextLevel;
            nextLevel *= 2; // scaling sementara
        }
    }
}
