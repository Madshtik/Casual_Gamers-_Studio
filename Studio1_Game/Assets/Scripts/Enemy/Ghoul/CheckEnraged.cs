using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnraged : GhoulNode
{
    public override State UpdateState(GhoulBehaviourTree GBT)
    {
        if (GBT.isEnraged == true && GBT.enragedAttack == true)
        {
            return State.SUCCESS;
        }

        return State.FAILED;
    }
}
