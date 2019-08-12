using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHP : GhoulNode
{
    public override void GhoulInitializeState(GhoulBehaviourTree GBT)
    {
        Debug.Log("Checking HP");
        if (GBT.myCurrentHP <= 10f && GBT.myCurrentHP >= 5f && GBT.isEnraged == false)
        {
            myCurrentState = State.SUCCESS;
        }

        if (GBT.myCurrentHP <= 5f && GBT.isFleeing == false)
        {
            myCurrentState = State.SUCCESS; 
        }

        myCurrentState = State.FAILED;
    }
}
