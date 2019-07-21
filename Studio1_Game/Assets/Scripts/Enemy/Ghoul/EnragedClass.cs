using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnragedClass : GhoulNode
{
    public override State UpdateState(GhoulBehaviourTree GBT)
    {
        GBT.isEnraged = true;
        return State.SUCCESS;
    }
}
