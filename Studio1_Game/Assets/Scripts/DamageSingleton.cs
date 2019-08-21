using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSingleton : MonoBehaviour
{
    public static DamageSingleton instance;

    public bool swordSwing;

    void Awake()
    {
        instance = this;
    }
}
