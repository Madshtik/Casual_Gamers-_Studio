using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHPEnraged : GhoulNode
{
    public override void GhoulInitializeState(GhoulBehaviourTree GBT)
    {
        gManager = GBT;
    }

    public override void MyLogicUpdate()
    {
        Debug.Log("checkingE");
        if (gManager.myCurrentHP <= 15f)
        {
            Debug.Log("HP SuccessE");
            myCurrentState = State.SUCCESS;
        }
        else
        {
            myCurrentState = State.FAILED;
            Debug.Log("HP FailE");
        }
    }
}
