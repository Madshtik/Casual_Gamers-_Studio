using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeBehaviour : GhoulNode
{
    public override State UpdateState(GhoulBehaviourTree GBT)
    {
        if (GBT.checkDistance <= 10f && GBT.fleeTimerMax >= 0f)
        {
            Vector3 vectVelocity = Vector3.Normalize(GBT.transform.position - GBT.TargetPlayer.position) * GBT.mySpeed;
            Vector3 mySteering = vectVelocity - GBT.myRB.velocity;

            Vector3.ClampMagnitude(mySteering, GBT.maxForce);

            GBT.myRB.AddForce(mySteering);

            GBT.fleeTimerMax -= 1f * Time.deltaTime;
        }

        if (GBT.fleeTimerMax <= 1f && GBT.isEnraged != true)
        {
            GBT.mySpeed = 0f;
            return State.FAILED;
        }
  
        GBT.isFleeing = true;
        GBT.isEnraged = false;
        return State.SUCCESS;
    }
}
