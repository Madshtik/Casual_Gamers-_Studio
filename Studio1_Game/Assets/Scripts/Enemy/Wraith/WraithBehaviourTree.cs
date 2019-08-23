using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WraithBehaviourTree : MonoBehaviour
{
    PrimarySelector RootNode;
    public float range;
    public GameObject playerGO;
    public int patrolRange;
    public float moveSpeed;
    public float health=100;
    public float enragedHP=20;
    public bool isEnraged;
    public GameObject fireShot;
    public GameObject[] patrolPoints;

    public float attTime;
    public float attIntervalTime;
    public bool canAttack;
    public int patrolIndex=0;
    // Start is called before the first frame update
    void Start()
    {
        
        patrolPoints = new GameObject[4];
  
        //tree
        RootNode = new PrimarySelector();
        
        RootNode.MyChildren.Add(new Sequencer());
        RootNode.MyChildren.Add(new Sequencer());     
        RootNode.MyChildren.Add(new Sequencer());

        RootNode.MyChildren[0].MyChildren.Add(new CheckNotInRange());
        RootNode.MyChildren[0].MyChildren.Add(new PatrolBehavior());

        RootNode.MyChildren[1].MyChildren.Add(new WraithCheckEnraged());
        RootNode.MyChildren[1].MyChildren.Add(new SeekBehaviour());
        RootNode.MyChildren[1].MyChildren.Add(new WraithEnragedAttack());

        RootNode.MyChildren[1].MyChildren.Add(new SeekBehaviour());
        RootNode.MyChildren[1].MyChildren.Add(new WraithAttack());

        //tree
        RootNode.WraithInitializeState(this);
       
    }

    // Update is called once per frame
    void Update()
    {
        RootNode.MyLogicUpdate();

        if (!canAttack&&attTime<attIntervalTime)
        {
            attTime += Time.deltaTime;
            if (attTime>=attIntervalTime)
            {
                canAttack = true;
                attTime = 0;
            }
        }
    }

    public void FireShot() {

        if (canAttack)
        {
            Instantiate(fireShot, transform.position, transform.rotation);
            canAttack = false;
        }
        


    }
    public void PlasmaShot()
    {

        if (canAttack)
        {
            Instantiate(fireShot, transform.position, transform.rotation);
            canAttack = false;
        }



    }
}
