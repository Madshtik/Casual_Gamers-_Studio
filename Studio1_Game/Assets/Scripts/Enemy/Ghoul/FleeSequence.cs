using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeSequence : GhoulNode
{
    public override State UpdateState(GhoulBehaviourTree GBT)
    {
        for (int i = 0; i < MyChildren.Count; i++)
        {
            State childState = MyChildren[i].UpdateState(GBT);

            if (childState == State.FAILED)
            {
                return State.FAILED;
            }

            if (childState == State.RUNNING)
            {
                return State.RUNNING;
            }
        }

        return State.SUCCESS;
    }
}
