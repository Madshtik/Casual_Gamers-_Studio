using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequencer : Node
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

            if (MyChildren[i].myCurrentState == State.RUNNING)
            {
                myCurrentState = State.RUNNING;
            }
            else if (MyChildren[i].myCurrentState == State.FAILED)
            {
                myCurrentState = State.FAILED;
            }
        }
        myCurrentState = State.SUCCESS;
    }
}
