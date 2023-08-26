using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Static class for controlling entity targeting in a turn-based game setting
/// </summary>
public static class TargetingSystem
{
    private static List<BattleCharacter> availableAlly;
    private static List<BattleEnemy> availableEnemies;
    private static List<BattleEntity> availableEntities;

    public static void UpdateAvailableEntities()
    {
        availableAlly = BattleTeamComp.GetComp();
        availableEnemies = BattleEncounter.CurrEnemies;
        availableEntities = new List<BattleEntity>();
        availableEntities.AddRange(availableAlly);
        availableEntities.AddRange(availableEnemies);
    }

    public static BattleCharacter TargetAllyEntity(bool AggroOn)
    {
        BattleCharacter target = null;
        if (AggroOn)
        {
            int totalAggro = 0;
            Dictionary<int, BattleCharacter> availableTargets = new Dictionary<int, BattleCharacter>();
            foreach (BattleCharacter character in availableAlly)
            {
                if (character.Alive)
                {
                    totalAggro += character.Aggro;
                    availableTargets.Add(totalAggro, character);
                }
            }
            int aggroHit = Random.Range(1, totalAggro + 1);
            foreach (KeyValuePair<int, BattleCharacter> character in availableTargets)
            {
                if (character.Key <= aggroHit)
                {
                    target = character.Value;
                    break;
                }
            }
        }
        else
        {
            do
            {
                int i = Random.Range(1, availableAlly.Capacity);
                target = availableAlly[i];
            } while (!target.Alive);
        }
        return target;
    }

    public static BattleCharacter TargetAllyEntity(int targetIndex)
    {
        return availableAlly[targetIndex];
    }

    public static BattleEnemy TargetEnemyEntity()
    {
        int i = Random.Range(1, availableEnemies.Capacity);
        return availableEnemies[i];
    }

    public static BattleEnemy TargetEnemyEntity(int targetIndex)
    {
        return availableEnemies[targetIndex];
    }

    public static List<BattleCharacter> TargetEveryAlly()
    {
        return availableAlly;
    }

    public static List<BattleEnemy> TargetEveryEnemy()
    {
        return availableEnemies;
    }

    public static List<BattleEntity> TargetEveryEntity()
    {
        return availableEntities;
    }
}