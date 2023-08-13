using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHandler : MonoBehaviour
{
    private LinkedList<BattleEntity> entityRotation = new LinkedList<BattleEntity>();
    private LinkedListNode<BattleEntity> currEntity;
    private List<BattleEntity> aliveCharacters, aliveEnemies = new List<BattleEntity>();
    private bool wait;
    [SerializeField] private GameObject actionMenu;

    private void OnValidate()
    {
        
    }


    private void Start()
    {
        actionMenu.SetActive(false);
        entityRotation.Clear();
        foreach (BattleCharacter chara in BattleTeamComp.GetComp())
        {
            entityRotation.AddLast(chara);
            aliveCharacters.Add(chara);
        }
        foreach (BattleEnemy enemy in BattleEncounter.CurrEnemies)
        {
            entityRotation.AddLast(enemy);
            aliveEnemies.Add(enemy);
        }
        currEntity = entityRotation.First;
    }

    private void Update()
    {
        if (currEntity.Value.Moved)
        {
            actionMenu.SetActive(false);
            currEntity.Value.Moved = false;
            if(currEntity == entityRotation.Last)
            {
                currEntity = entityRotation.First;
            }
            else
            {
                currEntity = currEntity.Next;
            }
            wait = false;
        }

        if (!wait)
        {
            if(aliveCharacters.Count == 0)
            {
                BattleLose();
                wait = true;
                return;
            }
            if(aliveEnemies.Count == 0)
            {
                BattleWin();
                wait = true;
                return;
            }
            currEntity.Value.Move();
            if(currEntity.Value is BattleCharacter)
            {
                actionMenu.SetActive(true);
            }
            wait = true;
        }
    }

    public void CharacterMove(int buttonidx)
    {
        BattleCharacter chara = (BattleCharacter)currEntity.Value;
        switch (buttonidx)
        {
            case 1:
                chara.BasicAttack();
                break;
            case 2:
                chara.FirstSkill();
                break;
            case 3:
                chara.SecondSkill();
                break;
            case 4:
                chara.Ultimate();
                break;
            case 5:
                // inventory
                break;
            default:
                break;
        }
    }

    private void BattleWin()
    {

    }

    private void BattleLose()
    {

    }
}
