using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhoulBehaviourTree : BaseBT
{
    Node RootNode;

    public Rigidbody myRB;
    public Animator GhoulAnimator;

    public float checkDistance;
    public float maxForce;
    public float rotationSlerp;
    public float deathTimer;

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

        RootNode.InitializeState(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (targetPlayer == null)
        {
            targetPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        }
        checkDistance = Vector3.Distance(transform.position, targetPlayer.position);

        if (myHealth <= 0f)
        {
            GhoulAnimator.SetTrigger("Dead");

            deathTimer -= Time.deltaTime;

            if (deathTimer <= 0f)
            {
                gameObject.SetActive(false);
            }
        }

        RootNode.MyLogicUpdate();
    }

    private void OnTriggerEnter(Collider MyTrigger)
    {
        if (MyTrigger.gameObject.tag.Equals("Sword") && DamageSingleton.instance.swordSwing) //detects the player's sword trigger and reduces the health of the ghoul
        {
            myHealth -= swordDamage;
        }
    }
}
