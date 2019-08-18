using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnragedAttack : GhoulNode
{
    public override void GhoulInitializeState(GhoulBehaviourTree GBT)
    {
        gManager = GBT;
    }

    public override void MyLogicUpdate()
    {
        Debug.Log("time to die");
        if (gManager.isEnraged && gManager.enragedAttack && gManager.checkDistance <= 2f)
        {
            myCurrentState = State.SUCCESS;
        }

        myCurrentState = State.FAILED;
    }
}
