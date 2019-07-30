using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : GhoulNode
{
    public override State UpdateState(GhoulBehaviourTree GBT)
    {
        if (GBT.checkDistance <= 1f)
        {
            return State.SUCCESS;
        }
        return State.FAILED;
    }
}
