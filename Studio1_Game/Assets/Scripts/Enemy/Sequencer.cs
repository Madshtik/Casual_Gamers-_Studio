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
        Debug.Log("checking children");
        for (int i = 0; i < MyChildren.Count; i++)
        {
            MyChildren[i].MyLogicUpdate();

            if (MyChildren[i].myCurrentState == State.RUNNING)
            {
                Debug.Log("Running");
                myCurrentState = State.RUNNING;
            }
            else if (MyChildren[i].myCurrentState == State.FAILED)
            {
                Debug.Log("Fail");
                myCurrentState = State.FAILED;
            }
        }
        Debug.Log("Success");
        myCurrentState = State.SUCCESS;
    }
}
