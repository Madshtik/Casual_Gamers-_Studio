using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekBehaviour : WraithNode
{
    RaycastHit hit;
    public override void WraithInitializeState(WraithBehaviourTree WBT)
    {
        wManager = WBT;


    }
    public override void MyLogicUpdate()
    {

        Vector3 lookVector = wManager.playerGO.transform.position - wManager.transform.position;
        lookVector.y = 0;
        Quaternion rot = Quaternion.LookRotation(lookVector);
        wManager.transform.rotation = Quaternion.Slerp(wManager.transform.rotation, rot, .02f);
        

        if (Physics.Raycast(wManager.transform.position, wManager.transform.forward, out hit, 10))
        {
            if (hit.transform.gameObject.tag == "Player")
            {
                myCurrentState = State.SUCCESS;
            }
        }


    }

}
