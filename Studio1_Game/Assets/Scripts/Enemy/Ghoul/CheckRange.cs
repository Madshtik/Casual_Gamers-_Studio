using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRange : GhoulNode
{
    public override void GhoulInitializeState(GhoulBehaviourTree GBT)
    {
        gManager = GBT;
    }

    public override void MyLogicUpdate()
    {
        
        if (gManager.checkDistance <= 20f)
        {
            Debug.Log("Hbaahaug");
            myCurrentState = State.SUCCESS;
        }

        if (gManager.checkDistance >= 20f)
        {
            Debug.Log("No Hbaahaug");
            myCurrentState = State.FAILED;
        }
    }
}