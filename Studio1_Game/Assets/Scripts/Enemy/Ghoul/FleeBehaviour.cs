using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeBehaviour : GhoulNode
{
    public override void GhoulInitializeState(GhoulBehaviourTree GBT)
    {
        if (GBT.checkDistance <= 10f && GBT.fleeTimerMax >= 0f)
        {
            Vector3 vectVelocity = Vector3.Normalize(GBT.transform.position - GBT.TargetPlayer.position) * GBT.mySpeed;
            vectVelocity = new Vector3(vectVelocity.x, 0, vectVelocity.z);
            Vector3 mySteering = vectVelocity - GBT.myRB.velocity;

            Vector3.ClampMagnitude(mySteering, GBT.maxForce);

            GBT.myRB.AddForce(mySteering);

            GBT.fleeTimerMax -= 1f * Time.deltaTime;
        }

        if (GBT.fleeTimerMax <= 1f && GBT.isEnraged != true)
        {
            GBT.mySpeed = 0f;
            myCurrentState = State.FAILED;
        }
  
        GBT.isFleeing = true;
        GBT.isEnraged = false;
        myCurrentState = State.SUCCESS;
    }
}
