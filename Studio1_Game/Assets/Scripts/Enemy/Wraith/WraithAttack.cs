using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WraithAttack : Node
{

    public override void MyLogicUpdate()
    {

        (bTManager as WraithBehaviourTree).FireShot();
    }
}
