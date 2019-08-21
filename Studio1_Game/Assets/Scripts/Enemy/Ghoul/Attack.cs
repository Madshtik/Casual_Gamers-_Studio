using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Node
{
    public override void MyLogicUpdate()
    {
        (bTManager as GhoulBehaviourTree).GhoulAnimator.SetTrigger("Attack");
        (bTManager as GhoulBehaviourTree).GhoulAnimator.SetBool("isCrawling", false);
        myCurrentState = State.SUCCESS;
    }
}
