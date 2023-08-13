using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class BattleEncounterData : ScriptableObject
{
    [SerializeField] private List<BattleEnemy> enemyComp = new List<BattleEnemy>();
    [SerializeField] private Sprite background, floor;
}
