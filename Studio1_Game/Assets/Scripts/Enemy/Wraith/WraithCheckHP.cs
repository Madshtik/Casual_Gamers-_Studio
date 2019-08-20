using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WraithCheckHP : WraithNode
{
    public override void WraithInitializeState(WraithBehaviourTree WBT)
    {
        wManager = WBT;


    }
    public override void MyLogicUpdate()
    {
        if (wManager.health < wManager.enragedHP)
        {
            myCurrentState = State.SUCCESS;
        }
        else {
            myCurrentState = State.FAILED;

        }
    }
}
