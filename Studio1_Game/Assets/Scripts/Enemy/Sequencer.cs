using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequencer : Node
{
  

 
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

                return;
            }
        }
        myCurrentState = State.SUCCESS;
    }
}
