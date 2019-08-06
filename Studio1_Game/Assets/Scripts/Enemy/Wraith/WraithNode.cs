using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WraithNode
{
    public List<WraithNode> MyChildren = new List<WraithNode>();

    public enum wraithState
    {
        RUNNING,
        SUCCESS,
        FAILLED
    }
    public wraithState myCurrentState;

    public virtual wraithState UpdateState(WraithBehaviourTree WBT)
    {
        return myCurrentState;
    }
}
