using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeBehaviour : GhoulNode
{
    public override void GhoulInitializeState(GhoulBehaviourTree GBT)
    {
        gManager = GBT;
    }

    public override void MyLogicUpdate()
    {
        if (gManager.myCurrentHP <= 10f && gManager.checkDistance <= 10f && gManager.fleeTimerMax >= 0f)
        {
            Vector3 vectVelocity = Vector3.Normalize(gManager.transform.position - gManager.TargetPlayer.position) * gManager.mySpeed;
            vectVelocity = new Vector3(vectVelocity.x, 0, vectVelocity.z);
            Vector3 mySteering = vectVelocity - gManager.myRB.velocity;

            Vector3.ClampMagnitude(mySteering, gManager.maxForce);

            gManager.myRB.AddForce(mySteering);
            gManager.GhoulAnimator.SetBool("isPursuing", true);
            gManager.fleeTimerMax -= 1f * Time.deltaTime;
        }

        if (gManager.fleeTimerMax <= 1f && gManager.isEnraged != true)
        {
            gManager.mySpeed = 0f;
            gManager.GhoulAnimator.SetBool("isPursuing", false);
            myCurrentState = State.FAILED;
        }

        gManager.isFleeing = true;
        gManager.isEnraged = false;
        myCurrentState = State.SUCCESS;
    }
}
