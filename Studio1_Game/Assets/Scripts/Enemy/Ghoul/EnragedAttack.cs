using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnragedAttack : GhoulNode
{
    public override void GhoulInitializeState(GhoulBehaviourTree GBT)
    {
        gManager = GBT;
        if (GBT.isEnraged && GBT.enragedAttack && GBT.checkDistance <= 2f)
        {
            myCurrentState = State.SUCCESS;
        }

        myCurrentState = State.FAILED;
    }
}
