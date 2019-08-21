using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehavior : Node
{
    int pRange;
   

    public override void InitializeState(BaseBT BTM)
    {
        base.InitializeState(BTM);
        for (int i = 0; i < (bTManager as WraithBehaviourTree).patrolPoints.Length; i++)
        {
            (bTManager as WraithBehaviourTree).patrolPoints[i] = new GameObject();
            pRange = Random.Range(-(bTManager as WraithBehaviourTree).patrolRange, (bTManager as WraithBehaviourTree).patrolRange);
            (bTManager as WraithBehaviourTree).patrolPoints[i].gameObject.transform.position = new Vector3((bTManager as WraithBehaviourTree).transform.position.x + pRange, (bTManager as WraithBehaviourTree).transform.position.y, (bTManager as WraithBehaviourTree).transform.position.z);

            pRange = Random.Range(-(bTManager as WraithBehaviourTree).patrolRange, (bTManager as WraithBehaviourTree).patrolRange);
            (bTManager as WraithBehaviourTree).patrolPoints[i].gameObject.transform.position = new Vector3((bTManager as WraithBehaviourTree).patrolPoints[i].gameObject.transform.position.x, (bTManager as WraithBehaviourTree).transform.position.y, (bTManager as WraithBehaviourTree).transform.position.z + pRange);


        }
    }
    public override void MyLogicUpdate()
    {
      
       // (bTManager as WraithBehaviourTree).transform.LookAt((bTManager as WraithBehaviourTree).patrolPoints[(bTManager as WraithBehaviourTree).patrolIndex].gameObject.transform.position);
        Quaternion lookOnLook = Quaternion.LookRotation((bTManager as WraithBehaviourTree).patrolPoints[(bTManager as WraithBehaviourTree).patrolIndex].gameObject.transform.position - (bTManager as WraithBehaviourTree).transform.position);
        (bTManager as WraithBehaviourTree).transform.rotation = Quaternion.Slerp((bTManager as WraithBehaviourTree).transform.rotation, lookOnLook, .05f);
       // (bTManager as WraithBehaviourTree).transform.Translate((bTManager as WraithBehaviourTree).transform.forward * (bTManager as WraithBehaviourTree).moveSpeed * Time.deltaTime);
        (bTManager as WraithBehaviourTree).transform.Translate(0,0,1 * bTManager.mySpeed * Time.deltaTime);

        myCurrentState = State.RUNNING;
        if (Vector3.Distance((bTManager as WraithBehaviourTree).transform.position, (bTManager as WraithBehaviourTree).patrolPoints[(bTManager as WraithBehaviourTree).patrolIndex].gameObject.transform.position) <= 2)
        {
            (bTManager as WraithBehaviourTree).patrolIndex++;
            myCurrentState = State.SUCCESS;
            if ((bTManager as WraithBehaviourTree).patrolIndex > 3)
            {
                (bTManager as WraithBehaviourTree).patrolIndex = 0;
            }
        }
    }
    public void InitializePatrolPoints() {

       
    }
}
