using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderBehaviour : Node
{
    public override void MyLogicUpdate()
    {
        Vector3 vectVelocity = Vector3.Normalize((bTManager as GhoulBehaviourTree).transform.forward);

        vectVelocity = new Vector3(vectVelocity.x, 0, vectVelocity.z);

        float circleDist = 5f;
        Vector3 circleCentre = vectVelocity; //Sets the circle centre as the vector velocity so they point in the same direction
        circleCentre *= circleDist;

        Vector3 wanderCircleRadius = new Vector3(circleCentre.x + 5f, 0f, circleCentre.z + 5f); //Setting the radius of the circle in the x and z axes


        Vector3 mySteering = vectVelocity - (bTManager as GhoulBehaviourTree).myRB.velocity;

        Vector3.ClampMagnitude(mySteering, (bTManager as GhoulBehaviourTree).maxForce);

        (bTManager as GhoulBehaviourTree).myRB.AddForce(mySteering);
        myCurrentState = State.FAILED;
    }
}