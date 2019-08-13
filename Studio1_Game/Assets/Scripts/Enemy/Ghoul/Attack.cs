using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : GhoulNode
{
    public override void GhoulInitializeState(GhoulBehaviourTree GBT)
    {
        gManager = GBT;
        if (GBT.normalAttack && !GBT.isFleeing && GBT.checkDistance <= 1f)
        {
            GBT.GhoulAnimator.SetTrigger("Attack");
            myCurrentState = State.SUCCESS;
        }
        myCurrentState = State.FAILED;
    }
}
