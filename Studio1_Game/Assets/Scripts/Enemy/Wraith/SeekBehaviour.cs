using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekBehaviour : Node
{
    RaycastHit hit;
 
    public override void MyLogicUpdate()
    {

        Vector3 lookVector = (bTManager as WraithBehaviourTree).playerGO.transform.position - (bTManager as WraithBehaviourTree).transform.position;
        lookVector.y = 0;
        Quaternion rot = Quaternion.LookRotation(lookVector);
        (bTManager as WraithBehaviourTree).transform.rotation = Quaternion.Slerp((bTManager as WraithBehaviourTree).transform.rotation, rot, .02f);

       
        if (Physics.Raycast((bTManager as WraithBehaviourTree).transform.position, (bTManager as WraithBehaviourTree).transform.forward, out hit, 10))
        {
            if (hit.transform.gameObject.tag == "Player")
            {
               
                myCurrentState = State.SUCCESS;
            }
        }


    }

}
