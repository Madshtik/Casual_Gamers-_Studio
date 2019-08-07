using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhoulNode : Node
{
    public override void GhoulInitializeState(GhoulBehaviourTree GBT)
    {
        gManager = GBT;

        for (int i = 0; i < MyChildren.Count; i++)
        {
            MyChildren[i].GhoulInitializeState(gManager);
        }
    }
    public override void WraithInitializeState(WraithBehaviourTree WBT)
    {
        wManager = WBT;

        for (int i = 0; i < MyChildren.Count; i++)
        {
            MyChildren[i].WraithInitializeState(wManager);
        }
    }
}