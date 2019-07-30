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

        if (GBT.checkDistance >= 10f && GBT.normalAttack == true)
        {
            GBT.normalAttack = false;
        }

        if (GBT.checkDistance <= 20f && GBT.isEnraged == true && GBT.normalAttack != true && GBT.myCurrentHP <= 5f)
        {
            GBT.enragedAttack = true;
            return State.SUCCESS;
        }

        if (GBT.checkDistance >= 20f && GBT.enragedAttack == true)
        {
            GBT.enragedAttack = false;
        }

        return State.FAILED;
    }
}