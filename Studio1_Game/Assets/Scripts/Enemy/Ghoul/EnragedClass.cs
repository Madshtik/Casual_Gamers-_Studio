using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnragedClass : GhoulNode
{
    public override void GhoulInitializeState(GhoulBehaviourTree GBT)
    {
        if (GBT.myCurrentHP <= 5f)
        {
            GBT.isEnraged = true;
            GBT.isFleeing = false;
            GBT.normalAttack = false;
            myCurrentState = State.SUCCESS;
        }

        myCurrentState = State.FAILED;
    }
}
