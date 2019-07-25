using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderBehaviour : GhoulNode
{
    public override State UpdateState(GhoulBehaviourTree GBT)
    {
        return State.SUCCESS;
    }
}
