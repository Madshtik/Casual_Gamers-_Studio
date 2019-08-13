using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnraged : GhoulNode
{
    public override void GhoulInitializeState(GhoulBehaviourTree GBT)
    {
        gManager = GBT;
        if (GBT.isEnraged == true && GBT.enragedAttack == true)
        {
            myCurrentState = State.SUCCESS;
        }

        myCurrentState = State.FAILED;
    }
}
