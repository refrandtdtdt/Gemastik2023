using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleKroco : BattleEnemy
{
    public override void Move()
    {
        base.Move();
        basicAttack();
        EndMove();
    }

    private void basicAttack()
    {
        // ngambil character secara random
        // BattleEntity character
        // character.Health -= 10;
    }
}
