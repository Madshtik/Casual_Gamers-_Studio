using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailClass : GhoulNode
{
    public override void MyLogicUpdate()
    {
        for (int i = 0; i < MyChildren.Count; i++)
        {
            MyChildren[i].MyLogicUpdate();
        }
        myCurrentState = State.FAILED;
    }
}
