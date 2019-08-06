﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhoulBehaviourTree : MonoBehaviour
{
    GhoulNode RootNode;
    public Transform TargetPlayer;
    public Rigidbody myRB;

    public float myMaxHP;
    public float myCurrentHP;
    public float mySpeed;
    public float checkDistance;
    public float fleeTimerMax;
    public float swordDamage;
    public float myDamage;
    public float maxForce;
    public bool isFleeing;
    public bool isEnraged;
    public bool normalAttack;
    public bool enragedAttack;
    public bool mouseClickBool;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        RootNode = new PrimarySelector();

        RootNode.MyChildren.Add(new FleeSequence());
        RootNode.MyChildren.Add(new FailClass());
        RootNode.MyChildren.Add(new RangeSequence());
        RootNode.MyChildren.Add(new WanderBehaviour());

        RootNode.MyChildren[0].MyChildren.Add(new CheckHP());
        RootNode.MyChildren[0].MyChildren.Add(new FleeBehaviour());
        RootNode.MyChildren[1].MyChildren.Add(new FailSequence());
        RootNode.MyChildren[2].MyChildren.Add(new CheckRange());
        RootNode.MyChildren[2].MyChildren.Add(new SequenceSelector());

        RootNode.MyChildren[1].MyChildren[0].MyChildren.Add(new CheckHP());
        RootNode.MyChildren[1].MyChildren[0].MyChildren.Add(new EnragedClass());
        RootNode.MyChildren[2].MyChildren[1].MyChildren.Add(new EnragedSequence());
        RootNode.MyChildren[2].MyChildren[1].MyChildren.Add(new CalmSequence());

        RootNode.MyChildren[2].MyChildren[1].MyChildren[0].MyChildren.Add(new CheckEnraged());
        RootNode.MyChildren[2].MyChildren[1].MyChildren[0].MyChildren.Add(new PursuitBehaviour());
        RootNode.MyChildren[2].MyChildren[1].MyChildren[0].MyChildren.Add(new EnragedAttack());
        RootNode.MyChildren[2].MyChildren[1].MyChildren[1].MyChildren.Add(new PursuitBehaviour());
        RootNode.MyChildren[2].MyChildren[1].MyChildren[1].MyChildren.Add(new Attack());
    }

    // Update is called once per frame
    void Update()
    {
        checkDistance = Vector3.Distance(transform.position, TargetPlayer.position);
        if (Input.GetMouseButtonDown(0))
        {
            mouseClickBool = true;
        }
        RootNode.UpdateState(this);
    }

    private void OnTriggerEnter(Collider MyTrigger)
    {
        if (MyTrigger.gameObject.tag.Equals("Sword") && mouseClickBool == true)
        {
            myCurrentHP -= swordDamage * (2 * Time.deltaTime);
            mouseClickBool = false;

            if (myCurrentHP <= 0f)
            {
                Destroy(gameObject);
            }
        }
    }
}