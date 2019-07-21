using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHP : GhoulNode
{
    public override State UpdateState(GhoulBehaviourTree GBT)
    {
        if (GBT.myCurrentHP <= 20f && GBT.myCurrentHP >= 11 && GBT.isEnraged == false)
        {
            return State.SUCCESS;
        }

        if (GBT.myCurrentHP <= 10f && GBT.myCurrentHP >= 0 && GBT.isFleeing == false)
        {
            return State.SUCCESS; 
        }

        return State.FAILED;
    }
}
