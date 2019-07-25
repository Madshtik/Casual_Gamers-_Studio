using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuitBehaviour : GhoulNode
{
    public override State UpdateState(GhoulBehaviourTree GBT)
    {      
        if (GBT.checkDistance <= 10f && GBT.checkDistance >= 1f)
        {   
            Vector3 vectVelocity = Vector3.Normalize(GBT.TargetPlayer.position - GBT.transform.position) * GBT.mySpeed;

            float T = 5f;
            Vector3 FuturePos = GBT.TargetPlayer.position + vectVelocity * T;

            Vector3 mySteering = FuturePos - GBT.myRB.velocity;

            Vector3.ClampMagnitude(mySteering, GBT.maxForce);

            GBT.myRB.AddForce(mySteering);

            return State.SUCCESS;
        }

        return State.FAILED;
    }
}
