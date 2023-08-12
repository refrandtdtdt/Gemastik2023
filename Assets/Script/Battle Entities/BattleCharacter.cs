using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCharacter : BattleEntity
{
    private int sp, energy;
    [SerializeField] private int spRegen, firstSkillCost, secondSkillCost;
    //private static List<string> inventory;
    public int Sp { get => sp; set => sp = value; }
    public int Energy { get => energy; set => energy = value; }
    public int FirstSkillCost { get => firstSkillCost; set => firstSkillCost = value; }
    public int SecondSkillCost { get => secondSkillCost; set => secondSkillCost = value; }

    public virtual void BasicAttack()
    {
        sp += spRegen;
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
        EndMove();
    }

    override public void Move()
    {
        base.Move();
        //try catch
        energy++;
    }
}
