using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEntityAnimations : ScriptableObject
{
    [SerializeField] private List<RuntimeAnimatorController> anims;

    public RuntimeAnimatorController GetAnimController(string name)
    {
        return anims.Where(anim => anim.name == name).Single();
    }
}
