using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleKroco : BattleEnemy
{
    [SerializeField] private GameObject prefab;
    
    public override void Move()
    {
        base.Move();
        basicAttack();
        EndMove();
    }

    private void basicAttack()
    {
        Target = TargetingSystem.TargetAllyEntity(true);
        
    }
}
