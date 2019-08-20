using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WraithAttack : WraithNode
{
    public override void WraithInitializeState(WraithBehaviourTree WBT)
    {
        wManager = WBT;


    }
    public override void MyLogicUpdate()
    {

        wManager.FireShot();
    }
}
