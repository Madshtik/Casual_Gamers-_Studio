using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WraithBehaviourTree : MonoBehaviour
{
    WraithNode RootNode;

    // Start is called before the first frame update
    void Start()
    {
        RootNode = new WraithPrimarySelector();
        
        RootNode.MyChildren.Add(new PatrolSequence());
        RootNode.MyChildren.Add(new WraithFailClass());
    }

    // Update is called once per frame
    void Update()
    {
        RootNode.UpdateState(this);
    }
}
