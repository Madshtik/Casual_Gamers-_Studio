using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WraithCheckEnraged : Node
{

    public override void MyLogicUpdate()
    {
        if (bTManager.myHealth < (bTManager as WraithBehaviourTree).enragedHP && !(bTManager as WraithBehaviourTree).isDead)
        {
            bTManager.isEnraged = true;
            myCurrentState = State.SUCCESS;
        }
        else
        {
            bTManager.isEnraged = false;
            myCurrentState = State.FAILED;

        }

    }
}
