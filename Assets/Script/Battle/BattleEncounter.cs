using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BattleEncounter
{
    private static List<BattleEnemy> currEnemies = new List<BattleEnemy>();
    private static Sprite currBackground, currFloor;

    public static List<BattleEnemy> CurrEnemies { get => currEnemies; set => currEnemies = value; }
    public static Sprite CurrBackground { get => currBackground; set => currBackground = value; }
    public static Sprite CurrFloor { get => currFloor; set => currFloor = value; }
}
