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
        if (gManager.myCurrentHP <= 50f && gManager.checkDistance <= 10f && gManager.fleeTimerMax >= 0f)
        {
            Debug.Log("RUN");
            gManager.GhoulAnimator.SetBool("isCrawling", true);
            Vector3 positionDiff = gManager.transform.position - gManager.TargetPlayer.position;
            Quaternion rotation = Quaternion.LookRotation(positionDiff);
            gManager.transform.rotation = Quaternion.Slerp(gManager.transform.rotation, rotation, gManager.rotationSlerp * Time.deltaTime); //rotation

            Vector3 vectVelocity = Vector3.Normalize(gManager.transform.position - gManager.TargetPlayer.position) * gManager.mySpeed;
            vectVelocity = new Vector3(vectVelocity.x, 0, vectVelocity.z);
            Vector3 mySteering = vectVelocity - gManager.myRB.velocity;

            Vector3.ClampMagnitude(mySteering, gManager.maxForce);

            gManager.myRB.AddForce(mySteering);
            gManager.fleeTimerMax -= 1f * Time.deltaTime;
           
            myCurrentState = State.SUCCESS;
        }

        if (gManager.fleeTimerMax <= 1f)
        {
            myCurrentState = State.FAILED;
        }
    }
}
