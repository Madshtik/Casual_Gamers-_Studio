using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : GhoulNode
{
    public override void GhoulInitializeState(GhoulBehaviourTree GBT)
    {
        if (GBT.checkDistance <= 1f)
        {
            myCurrentState = State.SUCCESS;
        }
        myCurrentState = State.FAILED;
    }
}
