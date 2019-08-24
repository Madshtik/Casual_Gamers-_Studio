using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimarySelector : Node
{
    public override void MyLogicUpdate()
    {
       
        for (int i = 0; i < MyChildren.Count; i++) //the selector will update its state by asking it's children to update theirs
        {
            MyChildren[i].MyLogicUpdate();

            if (MyChildren[i].myCurrentState == State.SUCCESS)
            {
                myCurrentState = State.SUCCESS; //if the child returns a state SUCCESS, the Primary Selector will update itself to SUCCESS
                return;
            }

            if (MyChildren[i].myCurrentState == State.RUNNING)
            {
                myCurrentState = State.RUNNING; //if the child returns a state RUNNING, the Primary Selector will update itself to RUNNING
                return;
            }
        }
        myCurrentState = State.FAILED; //the Primary Selector will update itself to FAILED only if none of the above conditions are met
    }
}
