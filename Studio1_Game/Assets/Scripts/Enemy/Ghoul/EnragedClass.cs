using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnragedClass : Node
{
  

    public override void MyLogicUpdate()
    {
        if (!(bTManager as GhoulBehaviourTree).isEnraged && !(bTManager as GhoulBehaviourTree).enragedAttack)
        {
            Debug.Log("RAGEEEEE");
            bTManager.isEnraged = true;
            (bTManager as GhoulBehaviourTree).enragedAttack = true;
            myCurrentState = State.SUCCESS;
        }
        else
        {
            myCurrentState = State.FAILED;
            //Debug.Log("failed");
        }
    }
}
