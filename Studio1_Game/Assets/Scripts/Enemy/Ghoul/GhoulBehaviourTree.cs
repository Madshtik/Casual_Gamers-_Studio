using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhoulBehaviourTree : MonoBehaviour
{
    Node RootNode;
    public Transform TargetPlayer;
    public Transform CircleCentre;
    public Rigidbody myRB;
    public Animator GhoulAnimator;

    public float myMaxHP;
    public float myCurrentHP;
    public float mySpeed;
    public float checkDistance;
    public float fleeTimerMax;
    public float swordDamage;
    public float myDamage;
    public float maxForce;
    public float rotationSlerp;

    public bool isEnraged;
    public bool enragedAttack;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        RootNode = new PrimarySelector(); //sets the PrimarySelector as the root node of the behavior tree

        //------first generation children------
        RootNode.MyChildren.Add(new Sequencer());
        RootNode.MyChildren.Add(new FailClass());
        RootNode.MyChildren.Add(new Sequencer());
        RootNode.MyChildren.Add(new WanderBehaviour());

        //------second generation children------
        RootNode.MyChildren[0].MyChildren.Add(new CheckHP());
        RootNode.MyChildren[0].MyChildren.Add(new FleeBehaviour());

        RootNode.MyChildren[1].MyChildren.Add(new Sequencer());

        RootNode.MyChildren[2].MyChildren.Add(new CheckRange());
        RootNode.MyChildren[2].MyChildren.Add(new PrimarySelector());

        //------third generation children------
        RootNode.MyChildren[1].MyChildren[0].MyChildren.Add(new CheckHPEnraged());
        RootNode.MyChildren[1].MyChildren[0].MyChildren.Add(new EnragedClass());

        RootNode.MyChildren[2].MyChildren[1].MyChildren.Add(new Sequencer());
        RootNode.MyChildren[2].MyChildren[1].MyChildren.Add(new Sequencer());

        //------fourth generation children------
        RootNode.MyChildren[2].MyChildren[1].MyChildren[0].MyChildren.Add(new CheckEnraged());
        RootNode.MyChildren[2].MyChildren[1].MyChildren[0].MyChildren.Add(new PursuitBehaviour());
        RootNode.MyChildren[2].MyChildren[1].MyChildren[0].MyChildren.Add(new EnragedAttack());

        RootNode.MyChildren[2].MyChildren[1].MyChildren[1].MyChildren.Add(new PursuitBehaviour());
        RootNode.MyChildren[2].MyChildren[1].MyChildren[1].MyChildren.Add(new Attack());

        RootNode.GhoulInitializeState(this);
    }

    // Update is called once per frame
    void Update()
    {
        checkDistance = Vector3.Distance(transform.position, TargetPlayer.position);
        RootNode.MyLogicUpdate();
    }

    private void OnTriggerEnter(Collider MyTrigger)
    {
        if (MyTrigger.gameObject.tag.Equals("Sword")) //detects the player's sword trigger and reduces the health of the ghoul
        {
            GhoulAnimator.SetBool("isHit", true);
            myCurrentHP -= swordDamage;

            if (myCurrentHP <= 0f)
            {
                Destroy(gameObject);
            }
        }
    }
}
