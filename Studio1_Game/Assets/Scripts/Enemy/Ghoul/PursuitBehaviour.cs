using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuitBehaviour : GhoulNode
{
    public override State UpdateState(GhoulBehaviourTree GBT)
    {      
        if (GBT.checkDistance <= 10f && GBT.myCurrentHP >= 10)
        {   
            Vector3 vectVelocity = Vector3.Normalize(GBT.TargetPlayer.position - GBT.transform.position) * GBT.mySpeed;
            vectVelocity = new Vector3(vectVelocity.x, 0, vectVelocity.z);

            /*float T = 2f;
            Vector3 FuturePos = GBT.TargetPlayer.position + vectVelocity;*/

            Vector3 mySteering = vectVelocity - GBT.myRB.velocity;

            Vector3.ClampMagnitude(mySteering, GBT.maxForce);

            GBT.myRB.AddForce(mySteering);

            return State.SUCCESS;
        }

        return State.FAILED;
    }
}
