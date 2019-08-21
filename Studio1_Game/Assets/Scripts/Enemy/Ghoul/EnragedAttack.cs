using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnragedAttack : Node
{
    public override void MyLogicUpdate()
    {
        if ((bTManager as GhoulBehaviourTree).checkDistance <= 3f && !(bTManager as GhoulBehaviourTree).GhoulAnimator.GetCurrentAnimatorStateInfo(0).IsName("Crawl"))
        {
            Debug.Log("time to die");
            (bTManager as GhoulBehaviourTree).GhoulAnimator.SetTrigger("EAttack");
            myCurrentState = State.SUCCESS;
        }
        else
        {
            myCurrentState = State.FAILED;
        }      
    }
}
