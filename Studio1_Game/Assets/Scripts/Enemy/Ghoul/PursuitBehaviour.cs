using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuitBehaviour : GhoulNode
{ 
    public override void GhoulInitializeState(GhoulBehaviourTree GBT)
    {
        gManager = GBT;
    }

    public override void MyLogicUpdate()
    {
        if (gManager.checkDistance <= 10f && gManager.myCurrentHP >= 10)
        {
            Vector3 positionDiff = gManager.TargetPlayer.position - gManager.transform.position;
            Quaternion rotation = Quaternion.LookRotation(positionDiff);
            gManager.transform.rotation = Quaternion.Slerp(gManager.transform.rotation, rotation, gManager.mySpeed * Time.deltaTime);

            Vector3 vectVelocity = Vector3.Normalize(gManager.TargetPlayer.position - gManager.transform.position) * gManager.mySpeed;
            vectVelocity = new Vector3(vectVelocity.x, 0, vectVelocity.z);

            /*float T = 2f;
            Vector3 FuturePos = gManager.TargetPlayer.position + vectVelocity * T;*/

            Vector3 mySteering = vectVelocity - gManager.myRB.velocity;

            Vector3.ClampMagnitude(mySteering, gManager.maxForce);

            gManager.myRB.AddForce(mySteering);

            if (gManager.checkDistance <= 3f)
            {
                gManager.mySpeed = 0f;
            }
            else
            {
                gManager.mySpeed = 5f;
            }

            gManager.GhoulAnimator.SetBool("isPursuing", true);

            myCurrentState = State.SUCCESS;
        }
        else
        {
            gManager.GhoulAnimator.SetBool("isPursuing", false);
        }
        
        myCurrentState = State.FAILED;
    }
}