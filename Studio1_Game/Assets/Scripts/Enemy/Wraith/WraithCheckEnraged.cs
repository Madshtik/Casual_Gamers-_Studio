using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WraithCheckEnraged : Node
{
   
    public override void MyLogicUpdate()
    {
        if (bTManager.isEnraged)
        {
            myCurrentState = State.SUCCESS;
        }
        else
        {
            myCurrentState = State.FAILED;
        }
        
    }
}
