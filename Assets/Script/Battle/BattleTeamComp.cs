using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BattleTeamComp
{
    private static List<BattleCharacter> currComp, currCollectedChars = new List<BattleCharacter>();

    public static List<BattleCharacter> GetComp()
    {
        return currComp;
    }
    public static void CollectCharacter(BattleCharacter chara)
    {
        currCollectedChars.Add(chara);
    }
    public static void SelectCharacter(BattleCharacter chara)
    {
        currComp.Add(chara);
    }
    public static void RemoveCharacter(BattleCharacter chara)
    {
        currComp.Remove(chara);
    }
}
