﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderBehaviour : GhoulNode
{
    public override void GhoulInitializeState(GhoulBehaviourTree GBT)
    {
        myCurrentState = State.SUCCESS;
    }
}
