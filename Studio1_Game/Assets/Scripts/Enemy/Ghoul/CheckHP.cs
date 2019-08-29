using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHP : Node
{
    public override void MyLogicUpdate()
    {
        //Debug.Log("checking");
        if (bTManager.myHealth <= 85f)
        {
            myCurrentState = State.SUCCESS;
            Debug.Log("HP Success");
        }
        else
        {
            myCurrentState = State.FAILED;
        }
    }
}
