using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailClass : Node //this class will update itself as fail no matter what state the children return
{
   

    public override void MyLogicUpdate()
    {
       
        //Debug.Log("Fail class");
        for (int i = 0; i < MyChildren.Count; i++)
        {
            MyChildren[i].MyLogicUpdate();
        }
        myCurrentState = State.FAILED; //set's it state to FAILED whatever it'c children return
    }
}
