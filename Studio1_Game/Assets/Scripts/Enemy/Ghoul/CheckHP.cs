using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHP : GhoulNode
{
    public override void GhoulInitializeState(GhoulBehaviourTree GBT)
    {
        gManager = GBT;
    }

    public override void MyLogicUpdate()
    {
        Debug.Log("checking");
        if (gManager.myCurrentHP <= 50f && gManager.myCurrentHP >= 15f)
        {
            myCurrentState = State.SUCCESS;
            Debug.Log("HP Success");
        }
        else
        {
            myCurrentState = State.FAILED;
        }
    }
}
