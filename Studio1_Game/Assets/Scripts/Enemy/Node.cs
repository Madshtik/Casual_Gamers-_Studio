using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node 
{
    public GhoulBehaviourTree gManager;
    public WraithBehaviourTree wManager;

    public List<Node> MyChildren = new List<Node>();

    public enum State
    {
        RUNNING,
        SUCCESS,
        FAILED
    }
    public State myCurrentState;

    public abstract void GhoulInitializeState(GhoulBehaviourTree GBT);
    public abstract void WraithInitializeState(WraithBehaviourTree WBT);

    public virtual void MyLogicUpdate()
    {
        
    }
}
