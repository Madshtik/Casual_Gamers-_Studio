using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnraged : Node
{
 

    public override void MyLogicUpdate()
    {
        if (bTManager.isEnraged && (bTManager as GhoulBehaviourTree).enragedAttack)
        {
            myCurrentState = State.SUCCESS;
        }
        else
        {
            myCurrentState = State.FAILED;
        }
    }
}
