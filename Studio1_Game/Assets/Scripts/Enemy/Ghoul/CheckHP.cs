using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHP : GhoulNode
{
    public override State UpdateState(GhoulBehaviourTree GBT)
    {
        if (GBT.myCurrentHP <= 10f && GBT.myCurrentHP >= 5f && GBT.isEnraged == false)
        {
            return State.SUCCESS;
        }

        if (GBT.myCurrentHP <= 5f && GBT.isFleeing == false)
        {
            return State.SUCCESS; 
        }

        return State.FAILED;
    }
}
