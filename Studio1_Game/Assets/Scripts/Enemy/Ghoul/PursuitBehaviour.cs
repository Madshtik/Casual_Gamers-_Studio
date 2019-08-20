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
        Debug.Log("HEYYYY");
        gManager.GhoulAnimator.SetBool("isCrawling", true);

        float slowingRadius = 5f;

        Vector3 positionDiff = gManager.TargetPlayer.position - gManager.transform.position;
        Quaternion rotation = Quaternion.LookRotation(positionDiff);
        gManager.transform.rotation = Quaternion.Slerp(gManager.transform.rotation, rotation, gManager.rotationSlerp * Time.deltaTime); //rotation towards the target player

        if (gManager.checkDistance <= slowingRadius)
        {
            Vector3 vectVelocity = Vector3.Normalize(gManager.TargetPlayer.position - gManager.transform.position) * gManager.mySpeed * (gManager.checkDistance / slowingRadius);
            vectVelocity = new Vector3(vectVelocity.x, 0, vectVelocity.z);
            Vector3 mySteering = vectVelocity - gManager.myRB.velocity;

            Vector3.ClampMagnitude(mySteering, gManager.maxForce);

            gManager.myRB.AddForce(mySteering);

            Debug.Log(mySteering);

            if (gManager.checkDistance <= 3f)
            {
                gManager.GhoulAnimator.SetBool("isCrawling", false);
            }
        }
        else
        {
            Vector3 vectVelocity = Vector3.Normalize(gManager.TargetPlayer.position - gManager.transform.position) * gManager.mySpeed;

            vectVelocity = new Vector3(vectVelocity.x, 0, vectVelocity.z);
            Vector3 mySteering = vectVelocity - gManager.myRB.velocity;

            Vector3.ClampMagnitude(mySteering, gManager.maxForce);

            gManager.myRB.AddForce(mySteering);
        }

        myCurrentState = State.SUCCESS;
    }
}