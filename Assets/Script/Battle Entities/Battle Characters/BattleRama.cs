using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleRama : BattleCharacter
{
    public BattleRama()
    {
        Alive = true;
        Maxhealth = 1000;
        Atk = 100;
        Def = 30;
        MaxSp = 100;
        MaxEnergy = 3;
        SpRegen = 30;
        FirstSkillCost = 30;
        SecondSkillCost = 20;
        Health = Maxhealth;
        Sp = MaxSp;
        Energy = MaxEnergy;
        Name = GetType().Name;
    }

    override public void BasicAttack()
    {
        base.BasicAttack();
        Target.Health -= CalculateDamage(1f);
        EndMove();
    }
    override public void FirstSkill()
    {
        base.FirstSkill();
        Target.Health -= CalculateDamage(1.5f);
    }
    override public void SecondSkill()
    {
        base.SecondSkill();
        
    }
    override public void Ultimate()
    {
        base.Ultimate();
    }

}
