using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimarySelector : Node
{
    public override void GhoulInitializeState(GhoulBehaviourTree GBT)
    {

    }

    public override void WraithInitializeState(WraithBehaviourTree WBT)
    {
        
    }

    public override void MyLogicUpdate()
    {
        for (int i = 0; i < MyChildren.Count; i++)
        {
            MyChildren[i].MyLogicUpdate();
            if (MyChildren[i].myCurrentState == State.SUCCESS)
            {
                myCurrentState = State.SUCCESS;
            }

            if (MyChildren[i].myCurrentState == State.RUNNING)
            {
                myCurrentState = State.RUNNING;
            }
        }
        myCurrentState = State.FAILED;
    }
}
