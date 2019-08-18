using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnraged : GhoulNode
{
    public override void GhoulInitializeState(GhoulBehaviourTree GBT)
    {
        gManager = GBT;
    }

    public override void MyLogicUpdate()
    {
        if (gManager.isEnraged && gManager.enragedAttack)
        {
            Debug.Log("Check Enraged");
            myCurrentState = State.SUCCESS;
        }

        myCurrentState = State.FAILED;
    }
}
