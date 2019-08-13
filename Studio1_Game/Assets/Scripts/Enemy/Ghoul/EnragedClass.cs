using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnragedClass : GhoulNode
{
    public override void GhoulInitializeState(GhoulBehaviourTree GBT)
    {
        gManager = GBT;
        GBT.isEnraged = true;
        GBT.isFleeing = false;
        myCurrentState = State.SUCCESS;
    }
}
