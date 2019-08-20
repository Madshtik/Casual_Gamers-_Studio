using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehavior : WraithNode
{
    int pRange;
   
    public override void WraithInitializeState(WraithBehaviourTree WBT)
    {
        wManager = WBT;

        for (int i = 0; i < wManager.patrolPoints.Length; i++)
        {
            wManager.patrolPoints[i] = new GameObject();
            pRange = Random.Range(-wManager.patrolRange, wManager.patrolRange);
            wManager.patrolPoints[i].gameObject.transform.position = new Vector3(wManager.transform.position.x + pRange, wManager.transform.position.y, wManager.transform.position.z);

            pRange = Random.Range(-wManager.patrolRange, wManager.patrolRange);
            wManager.patrolPoints[i].gameObject.transform.position = new Vector3(wManager.patrolPoints[i].gameObject.transform.position.x, wManager.transform.position.y, wManager.transform.position.z + pRange);


        }
    }
    public override void MyLogicUpdate()
    {
      
       // wManager.transform.LookAt(wManager.patrolPoints[wManager.patrolIndex].gameObject.transform.position);
        Quaternion lookOnLook = Quaternion.LookRotation(wManager.patrolPoints[wManager.patrolIndex].gameObject.transform.position - wManager.transform.position);
        wManager.transform.rotation = Quaternion.Slerp(wManager.transform.rotation, lookOnLook, .05f);
       // wManager.transform.Translate(wManager.transform.forward * wManager.moveSpeed * Time.deltaTime);
        wManager.transform.Translate(0,0,1 * wManager.moveSpeed * Time.deltaTime);

        myCurrentState = State.RUNNING;
        if (Vector3.Distance(wManager.transform.position, wManager.patrolPoints[wManager.patrolIndex].gameObject.transform.position) <= 2)
        {
            wManager.patrolIndex++;
            myCurrentState = State.SUCCESS;
            if (wManager.patrolIndex > 3)
            {
                wManager.patrolIndex = 0;
            }
        }
    }
    public void InitializePatrolPoints() {

       
    }
}
