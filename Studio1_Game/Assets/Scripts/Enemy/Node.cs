using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node
{
    public BaseBT bTManager;


    public List<Node> MyChildren = new List<Node>();

    public enum State
    {
        RUNNING,
        SUCCESS,
        FAILED
    }
    public State myCurrentState;

    public virtual void InitializeState(BaseBT BTM)
    {
       
        bTManager = BTM;
        for (int i = 0; i < MyChildren.Count; i++)
        {
             MyChildren[i].InitializeState(bTManager);          
        }

    }

    public abstract void MyLogicUpdate();
}
