using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : GhoulNode
{
    public override void GhoulInitializeState(GhoulBehaviourTree GBT)
    {
        gManager = GBT;
    }

    public override void MyLogicUpdate()
    {
        Debug.Log("fight!");
        if (gManager.checkDistance <= 3f && !gManager.GhoulAnimator.GetCurrentAnimatorStateInfo(0).IsName("Crawl"))
        {
            gManager.GhoulAnimator.SetTrigger("Attack");
            myCurrentState = State.SUCCESS;
        }
        else
        {
            myCurrentState = State.FAILED;
        }
    }
}
