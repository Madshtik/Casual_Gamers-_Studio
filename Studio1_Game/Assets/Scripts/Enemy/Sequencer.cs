using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequencer : Node
{
    public override void GhoulInitializeState(GhoulBehaviourTree GBT)
    {
        gManager = GBT;

        for (int i = 0; i < MyChildren.Count; i++)
        {
            MyChildren[i].GhoulInitializeState(gManager);
        }
    }

    public override void WraithInitializeState(WraithBehaviourTree WBT)
    {
        wManager = WBT;

        for (int i = 0; i < MyChildren.Count; i++)
        {
            MyChildren[i].WraithInitializeState(wManager);
        }
    }

    public override void MyLogicUpdate()
    {
        for (int i = 0; i < MyChildren.Count; i++) //the sequencer will update its state by asking it's children to update theirs
        {
            MyChildren[i].MyLogicUpdate();

            if (MyChildren[i].myCurrentState == State.RUNNING)
            {
                myCurrentState = State.RUNNING;
                return;
            }
            else if (MyChildren[i].myCurrentState == State.FAILED)
            {
                myCurrentState = State.FAILED;
                Debug.Log("Failed child");
                return;
            }
        }
        myCurrentState = State.SUCCESS;
    }
}
