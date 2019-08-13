using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHP : GhoulNode
{
    public override void GhoulInitializeState(GhoulBehaviourTree GBT)
    {
        gManager = GBT;
    }

    public override void MyLogicUpdate()
    {
        if (gManager.myCurrentHP <= 10f && gManager.myCurrentHP >= 5f && !gManager.isEnraged)
        {
            myCurrentState = State.SUCCESS;
        }

        if (gManager.myCurrentHP <= 5f && !gManager.isFleeing)
        {
            myCurrentState = State.SUCCESS;
        }

        myCurrentState = State.FAILED;
    }
}
