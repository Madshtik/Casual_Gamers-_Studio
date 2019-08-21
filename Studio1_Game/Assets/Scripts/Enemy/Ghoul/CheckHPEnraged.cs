using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHPEnraged : Node
{
   

    public override void MyLogicUpdate()
    {
        //Debug.Log("checkingE");
        if (bTManager.myHealth <= 45f)
        {
            //Debug.Log("HP SuccessE");
            myCurrentState = State.SUCCESS;
        }
        else
        {
            myCurrentState = State.FAILED;
            //Debug.Log("HP FailE");
        }
    }
}
