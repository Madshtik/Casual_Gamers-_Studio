using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderBehaviour : Node
{
    float circleRadius = 5;
    float wanderAngle = Random.Range(0f, Mathf.PI * 2);
    Vector3 SeekDirection;
    public override void MyLogicUpdate()
    {
        


        myCurrentState = State.FAILED;
    }
}