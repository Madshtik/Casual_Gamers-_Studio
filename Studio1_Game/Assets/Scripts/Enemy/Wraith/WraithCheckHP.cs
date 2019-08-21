using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WraithCheckHP : Node
{
   
    public override void MyLogicUpdate()
    {
        if (bTManager.myHealth < (bTManager as WraithBehaviourTree).enragedHP)
        {
            myCurrentState = State.SUCCESS;
        }
        else {
            myCurrentState = State.FAILED;

        }
    }
}
