using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeBehaviour : Node
{
    float fleeTimer = 3f;
    public override void MyLogicUpdate()
    {
       
        if ((bTManager as GhoulBehaviourTree).checkDistance <= 10f && fleeTimer >= 0f)
        {
           
            //Debug.Log("RUN");
            (bTManager as GhoulBehaviourTree).GhoulAnimator.SetBool("isCrawling", true);
            Vector3 positionDiff = bTManager.transform.position - bTManager.targetPlayer.position;
            Quaternion rotation = Quaternion.LookRotation(positionDiff);
            bTManager.transform.rotation = Quaternion.Slerp(bTManager.transform.rotation, rotation, (bTManager as GhoulBehaviourTree).rotationSlerp * Time.deltaTime); //rotation

            Vector3 vectVelocity = Vector3.Normalize(bTManager.transform.position - bTManager.targetPlayer.position) * bTManager.mySpeed;
            vectVelocity = new Vector3(vectVelocity.x, 0, vectVelocity.z);
            Vector3 mySteering = vectVelocity - (bTManager as GhoulBehaviourTree).myRB.velocity;

            Vector3.ClampMagnitude(mySteering, (bTManager as GhoulBehaviourTree).maxForce);

            (bTManager as GhoulBehaviourTree).myRB.AddForce(mySteering);
            fleeTimer -= 1f * Time.deltaTime;
           
            myCurrentState = State.SUCCESS;
        }
        else
        {
            (bTManager as GhoulBehaviourTree).GhoulAnimator.SetBool("isCrawling", false);
            fleeTimer -= 1f * Time.deltaTime;
        }

        if (fleeTimer <= 1f)
        {
            myCurrentState = State.FAILED;
        }
    }
}
