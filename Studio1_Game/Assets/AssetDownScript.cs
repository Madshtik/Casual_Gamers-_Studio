﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetDownScript : MonoBehaviour
{
    public float smoothingSpeed = 0.05f;
    Vector3 myInitialPos;
    public bool playerNear;
    public GameObject PlayerGO;
    public float dist;
   
 
    // Start is called before the first frame update
    void Start()
    {


    }
    private void Awake()
    {
        myInitialPos = transform.position;
        playerNear = false;
     
        
    }
    // Update is called once per frame
    void Update()
    {
        //if (!playerNear)
        //{
        //    Debug.Log(Vector3.Distance(transform.position, PlayerGO.transform.position));
        //}

        if (!playerNear && Vector3.Distance(transform.position, PlayerGO.transform.position) < dist)
        {
            playerNear = true;
        }
        if (playerNear)
        {
          
            Vector3 desiredPos = new Vector3(myInitialPos.x, myInitialPos.y - 20f, myInitialPos.z);
            Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothingSpeed);
            transform.position = smoothedPos;
        }

    }
}