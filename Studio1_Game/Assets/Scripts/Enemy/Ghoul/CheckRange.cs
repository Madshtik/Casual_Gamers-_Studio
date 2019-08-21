using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRange : Node
{


    public override void MyLogicUpdate()
    {
        
        if ((bTManager as GhoulBehaviourTree).checkDistance <= 20f && bTManager.myHealth >= 1f)
        {
            //Debug.Log("Hbaahaug");
            myCurrentState = State.SUCCESS;
        }
        else
        {
            (bTManager as GhoulBehaviourTree).GhoulAnimator.SetBool("isCrawling", false);
            myCurrentState = State.FAILED;
        }
    }
}