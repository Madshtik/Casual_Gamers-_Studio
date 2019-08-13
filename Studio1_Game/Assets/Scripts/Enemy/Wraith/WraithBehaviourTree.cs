using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WraithBehaviourTree : MonoBehaviour
{
    PrimarySelector RootNode;

    // Start is called before the first frame update
    void Start()
    {
        RootNode = new PrimarySelector();
        
        RootNode.MyChildren.Add(new Sequencer());
        RootNode.MyChildren.Add(new FailClass());
        RootNode.MyChildren.Add(new PrimarySelector());

        RootNode.MyChildren[0].MyChildren.Add(new CheckNotInRange());
        RootNode.MyChildren[0].MyChildren.Add(new PatrolBehavior());

        RootNode.MyChildren[1].MyChildren.Add(new Sequencer());

        RootNode.MyChildren[1].MyChildren[0].MyChildren.Add(new WraithCheckHP());
        RootNode.MyChildren[1].MyChildren[0].MyChildren.Add(new WraithEnragedClass());

        RootNode.MyChildren[2].MyChildren.Add(new Sequencer());
        RootNode.MyChildren[2].MyChildren.Add(new Sequencer());

        RootNode.MyChildren[2].MyChildren[0].MyChildren.Add(new WraithCheckEnraged());
        RootNode.MyChildren[2].MyChildren[0].MyChildren.Add(new SeekBehaviour());
        RootNode.MyChildren[2].MyChildren[0].MyChildren.Add(new WraithEnragedAttack());

        RootNode.MyChildren[2].MyChildren[1].MyChildren.Add(new SeekBehaviour());
        RootNode.MyChildren[2].MyChildren[1].MyChildren.Add(new WraithAttack());

        RootNode.WraithInitializeState(this);

    }

    // Update is called once per frame
    void Update()
    {
        RootNode.MyLogicUpdate();
    }
}
