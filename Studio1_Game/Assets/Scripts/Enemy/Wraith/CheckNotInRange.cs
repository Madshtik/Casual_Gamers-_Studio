using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckNotInRange : Node
{
   
    public override void MyLogicUpdate()
    {
       
        if (Vector3.Distance((bTManager as WraithBehaviourTree).playerGO.transform.position, (bTManager as WraithBehaviourTree).transform.position)> (bTManager as WraithBehaviourTree).range&& !(bTManager as WraithBehaviourTree).isDead)
        {
            myCurrentState = State.SUCCESS;
        }
        else
        {
            myCurrentState = State.FAILED;
        }
    }
}
