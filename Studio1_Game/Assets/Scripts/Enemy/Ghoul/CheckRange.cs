using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRange : Node
{


    public override void MyLogicUpdate()
    {
        
        if ((bTManager as GhoulBehaviourTree).checkDistance <= 20f && bTManager.myHealth >= 1f)
        {
            (bTManager as GhoulBehaviourTree).myRB.useGravity = true;
            myCurrentState = State.SUCCESS;
        }
        else
        {
            (bTManager as GhoulBehaviourTree).GhoulAnimator.SetBool("isCrawling", false);
            (bTManager as GhoulBehaviourTree).myRB.useGravity = false;
            myCurrentState = State.FAILED;
        }
    }
}