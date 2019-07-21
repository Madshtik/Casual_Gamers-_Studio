using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeBehaviour : GhoulNode
{
    public override State UpdateState(GhoulBehaviourTree GBT)
    {
        if (GBT.checkDistance <= 10f && GBT.fleeTimerMax >= 0f)
        {
            GBT.MyEnemy.transform.position += GBT.TargetPlayer.position * GBT.mySpeed * Time.deltaTime; //script will be changed after learningevade behaviour found under pursuit
            GBT.fleeTimerMax -= 1f * Time.deltaTime; //1f is to normalize the timer to decrease by 1 second
        }

        if (GBT.fleeTimerMax <= 0f)
        {
            return State.FAILED;
        }
  
        GBT.isFleeing = true;
        return State.SUCCESS;
    }
}
