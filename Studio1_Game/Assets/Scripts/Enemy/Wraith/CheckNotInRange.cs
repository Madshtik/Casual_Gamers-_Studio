using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckNotInRange : WraithNode
{
    public override void WraithInitializeState(WraithBehaviourTree WBT)
    {
        wManager = WBT;

    
    }
    public override void MyLogicUpdate()
    {
      
        if (Vector3.Distance(wManager.playerGO.transform.position,wManager.transform.position)>wManager.range)
        {
            myCurrentState = State.SUCCESS;
        }
        else
        {
            myCurrentState = State.FAILED;
        }
    }
}
