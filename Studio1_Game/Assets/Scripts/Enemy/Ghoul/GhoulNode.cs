using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhoulNode : MonoBehaviour
{
    public List<GhoulNode> MyChildren = new List<GhoulNode>();

    public enum State
    {
        RUNNING,
        SUCCESS,
        FAILED
    }
    public State myCurrentState;

    public virtual State UpdateState(GhoulBehaviourTree GBT)
    {
        return myCurrentState;
    }
}
