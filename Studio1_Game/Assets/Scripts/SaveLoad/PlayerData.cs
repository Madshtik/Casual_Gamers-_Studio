﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float[] playerPos;
   
    public float playerHealth;


    public PlayerData(PlayerController player) {

        playerPos[0] = player.transform.position.x; 
        playerPos[1] = player.transform.position.y;
        playerPos[2] = player.transform.position.z;

        playerHealth = player.myHealth;
   

    }
}
