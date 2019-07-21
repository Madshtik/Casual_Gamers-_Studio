using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRange : GhoulNode
{
    public override State UpdateState(GhoulBehaviourTree GBT)
    {
        if (GBT.checkDistance <= 10f && GBT.isEnraged != true)
        {
            GBT.normalAttack = true;
            return State.SUCCESS;
        }

        if (GBT.checkDistance <= 20f && GBT.isEnraged == true)
        {
            GBT.enragedAttack = true;
            return State.SUCCESS;
        }

        return State.FAILED;
    }
}