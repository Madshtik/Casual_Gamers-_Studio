using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WraithEnragedAttack : Node
{
    
 
    public override void MyLogicUpdate()
    {
        (bTManager as WraithBehaviourTree).PlasmaShot();
    }
}
