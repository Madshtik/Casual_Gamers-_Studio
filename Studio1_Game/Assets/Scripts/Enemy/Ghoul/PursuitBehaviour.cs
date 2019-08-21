using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuitBehaviour : Node
{ 
 

    public override void MyLogicUpdate()
    {
        //Debug.Log("HEYYYY");

        float slowingRadius = 5f;

        Vector3 positionDiff = bTManager.targetPlayer.position - (bTManager as GhoulBehaviourTree).transform.position;
        Quaternion rotation = Quaternion.LookRotation(positionDiff);
        (bTManager as GhoulBehaviourTree).transform.rotation = Quaternion.Slerp((bTManager as GhoulBehaviourTree).transform.rotation, rotation, (bTManager as GhoulBehaviourTree).rotationSlerp * Time.deltaTime); //rotation towards the target player

        if ((bTManager as GhoulBehaviourTree).checkDistance <= slowingRadius)
        {
            (bTManager as GhoulBehaviourTree).GhoulAnimator.SetBool("isCrawling", true);
            Vector3 vectVelocity = Vector3.Normalize(bTManager.targetPlayer.position - (bTManager as GhoulBehaviourTree).transform.position) * (bTManager as GhoulBehaviourTree).mySpeed * ((bTManager as GhoulBehaviourTree).checkDistance / slowingRadius);
            vectVelocity = new Vector3(vectVelocity.x, 0, vectVelocity.z);
            Vector3 mySteering = vectVelocity - (bTManager as GhoulBehaviourTree).myRB.velocity;

            Vector3.ClampMagnitude(mySteering, (bTManager as GhoulBehaviourTree).maxForce);
 
            (bTManager as GhoulBehaviourTree).myRB.AddForce(mySteering);

            if ((bTManager as GhoulBehaviourTree).checkDistance <= 3f)
            {
                 (bTManager as GhoulBehaviourTree).GhoulAnimator.SetBool("isCrawling", false);
            }
        }
        else
        {
             (bTManager as GhoulBehaviourTree).GhoulAnimator.SetBool("isCrawling", true);
            Vector3 vectVelocity = Vector3.Normalize(bTManager.targetPlayer.position -  (bTManager as GhoulBehaviourTree).transform.position) *  (bTManager as GhoulBehaviourTree).mySpeed;

            vectVelocity = new Vector3(vectVelocity.x, 0, vectVelocity.z);
            Vector3 mySteering = vectVelocity -  (bTManager as GhoulBehaviourTree).myRB.velocity;

            Vector3.ClampMagnitude(mySteering,  (bTManager as GhoulBehaviourTree).maxForce);

            (bTManager as GhoulBehaviourTree).myRB.AddForce(mySteering);

        }
        if ((bTManager as GhoulBehaviourTree).checkDistance <= 3f)
        {
            myCurrentState = State.SUCCESS;
        }
        else
        {
            myCurrentState = State.RUNNING;
        }
    }
}