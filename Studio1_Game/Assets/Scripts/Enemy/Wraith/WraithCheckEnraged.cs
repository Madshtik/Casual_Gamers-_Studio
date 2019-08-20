using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WraithCheckEnraged : WraithNode
{
    public override void WraithInitializeState(WraithBehaviourTree WBT)
    {
        wManager = WBT;


    }
    public override void MyLogicUpdate()
    {
        if (wManager.isEnraged)
        {
            myCurrentState = State.SUCCESS;
        }
        else
        {
            myCurrentState = State.FAILED;
        }
        
    }
}
