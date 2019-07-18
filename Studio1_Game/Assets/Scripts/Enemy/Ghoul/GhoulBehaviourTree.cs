using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhoulBehaviourTree : MonoBehaviour
{
    public GhoulNode RootNode;
    public GameObject MyEnemy;

    // Start is called before the first frame update
    void Start()
    {

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
        RootNode.UpdateState(this);
    }
}
