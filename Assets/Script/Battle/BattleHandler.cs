using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handler for battle scene
/// </summary>
public class BattleHandler : MonoBehaviour
{
    private LinkedList<BattleGameObject> entityRotation = new LinkedList<BattleGameObject>();
    private LinkedListNode<BattleGameObject> currEntity;
    private List<BattleEntity> aliveCharacters, aliveEnemies = new List<BattleEntity>();
    private bool wait;
    private delegate void CharMove();
    private CharMove charMove;
    [SerializeField] private GameObject actionMenu;
    [SerializeField] private List<BattleGameObject> charaObj, enemyObj;
    [SerializeField] private BattleEntityAnimations battleAnimations;

    public List<BattleEntity> AliveCharacters { get => aliveCharacters; }
    public List<BattleEntity> AliveEnemies { get => aliveEnemies; }

    private void OnValidate()
    {
        
    }


    private void Start()
    {
        actionMenu.SetActive(false);
        entityRotation.Clear();
        aliveCharacters.Clear();
        aliveEnemies.Clear();
        int i = 0;
        foreach (BattleCharacter chara in BattleTeamComp.GetComp())
        {
            //aliveCharacters.Add(chara);
            charaObj[i].Setup(chara, battleAnimations.GetAnimController(chara.Name), i);
            AliveCharacters.Add(charaObj[i].Stats);
            entityRotation.AddLast(charaObj[i]);
            i++;
        }
        i = 0;
        foreach (BattleEnemy enemy in BattleEncounter.CurrEnemies)
        {
            enemyObj[i].Setup(enemy, battleAnimations.GetAnimController(enemy.Name), i);
            AliveEnemies.Add(enemyObj[i].Stats);
            entityRotation.AddLast(enemyObj[i]);
            i++;
        }
        currEntity = entityRotation.First;
        TargetingSystem.UpdateAvailableEntities();
    }

    private void Update()
    {
        if (currEntity.Value.Stats.Moved)
        {
            actionMenu.SetActive(false);
            currEntity.Value.Stats.Moved = false;
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
            if(AliveCharacters.Count == 0)
            {
                BattleLose();
                wait = true;
                return;
            }
            if(AliveEnemies.Count == 0)
            {
                BattleWin();
                wait = true;
                return;
            }
            if(currEntity.Value.Stats is BattleCharacter)
            {
                actionMenu.SetActive(true);
            }
            else
            {
                //currEntity.Value.Stats.Target = ChooseEnemyTarget();
            }
            currEntity.Value.Stats.Move();
            wait = true;
        }
    }

    public void CharacterMove(int buttonidx)
    {
        BattleCharacter chara = (BattleCharacter)currEntity.Value.Stats;
        switch (buttonidx)
        {
            case 1:
                charMove = chara.BasicAttack;
                break;
            case 2:
                charMove = chara.FirstSkill;
                break;
            case 3:
                charMove = chara.SecondSkill;
                break;
            case 4:
                charMove = chara.Ultimate;
                break;
            case 5:
                // inventory
                break;
            default:
                break;
        }
    }

    public void CancelMove()
    {

    }

    public void ChangeTarget(int idx, bool enemy)
    {
        
    }

    //public BattleCharacter ChooseEnemyTarget()
    //{
    //    int totalAggro = 0;
    //    Dictionary<int, BattleCharacter> availableTargets = new Dictionary<int, BattleCharacter>();
    //    foreach (BattleCharacter character in aliveCharacters)
    //    {
    //        totalAggro += character.Aggro;
    //        availableTargets.Add(totalAggro, character);
    //    }
    //    int aggroHit = Random.Range(1,totalAggro+1);
    //    BattleCharacter target = null;
    //    foreach (KeyValuePair<int, BattleCharacter> character in availableTargets)
    //    {
    //        if(character.Key <= aggroHit)
    //        {
    //            target = character.Value;
    //            break;
    //        }
    //    }
    //    return target;
    //}

    private void BattleWin()
    {

    }

    private void BattleLose()
    {

    }
}
