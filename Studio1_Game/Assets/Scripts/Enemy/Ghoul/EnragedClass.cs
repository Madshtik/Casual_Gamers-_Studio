using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnragedClass : GhoulNode
{
    public override void GhoulInitializeState(GhoulBehaviourTree GBT)
    {
        gManager = GBT;
    }

    public override void MyLogicUpdate()
    {
        if (!gManager.isEnraged && !gManager.enragedAttack)
        {
            Debug.Log("RAGEEEEE");
            gManager.isEnraged = true;
            gManager.enragedAttack = true;
            myCurrentState = State.SUCCESS;
        }
        else
        {
            myCurrentState = State.FAILED;
            Debug.Log("failed");
        }
    }
}
