using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderBehaviour : Node
{
    Vector3 circleCentre;
    float circleRadius = 5;
    float wanderAngle = Random.Range(0f, Mathf.PI * 2);
    Vector3 SeekDirection;
    public override void MyLogicUpdate()
    {
        circleCentre = new Vector3((bTManager as GhoulBehaviourTree).transform.position.x, 
            (bTManager as GhoulBehaviourTree).transform.position.y, (bTManager as GhoulBehaviourTree).transform.position.z + 5);


        myCurrentState = State.FAILED;
    }
}