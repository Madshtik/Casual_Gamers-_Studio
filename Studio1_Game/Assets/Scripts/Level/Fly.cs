﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public Rigidbody rB;
    public static bool triggered = false;
    // Use this for initialization
    void Awake()
    {
        rB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    void Update()
    {
        rB.constraints = RigidbodyConstraints.FreezePositionY;

        if (triggered == true)
        {
            rB.constraints = RigidbodyConstraints.None;
        }

    }
}