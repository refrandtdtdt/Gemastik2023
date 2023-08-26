using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleGameObject : MonoBehaviour
{
    private BattleEntity stats;
    private Animator anim;
    public bool playerTeam;
    public int index;

    public BattleEntity Stats { get => stats; set => stats = value; }

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Setup(BattleEntity ent, RuntimeAnimatorController controller, int index)
    {
        Stats = ent;
        anim.runtimeAnimatorController = controller;
        Stats.Anim = anim;
        this.index = index;
    }
}
