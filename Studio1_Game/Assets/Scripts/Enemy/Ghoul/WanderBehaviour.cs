using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderBehaviour : Node
{
    Vector3 circleCentre;
    Vector3 circleRadius;

    public override void MyLogicUpdate()
    {
        circleCentre = new Vector3((bTManager as GhoulBehaviourTree).transform.position.x, 
            (bTManager as GhoulBehaviourTree).transform.position.y, (bTManager as GhoulBehaviourTree).transform.position.z + 5);

        circleRadius = new Vector3(circleCentre.x + 3, 0, circleCentre.z + 3);

        myCurrentState = State.FAILED;
    }
}