using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnragedClass : GhoulNode
{
    public override State UpdateState(GhoulBehaviourTree GBT)
    {
        if (GBT.myCurrentHP <= 5f)
        {
            GBT.isEnraged = true;
            GBT.isFleeing = false;
            GBT.normalAttack = false;
            return State.SUCCESS;
        }

        return State.FAILED;
    }
}
