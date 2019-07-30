using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnragedAttack : GhoulNode
{
    public override State UpdateState(GhoulBehaviourTree GBT)
    {
        return State.SUCCESS;
    }
}
