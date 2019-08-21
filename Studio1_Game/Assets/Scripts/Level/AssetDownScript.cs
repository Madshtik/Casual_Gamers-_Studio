using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetDownScript : MonoBehaviour
{
    public float smoothingSpeed = 0.05f;
    Vector3 myInitialPos;
    public bool playerNear;
    public bool arrived;
    public GameObject PlayerGO;
    public float dist;
    Vector3 desiredPos;
 
    // Start is called before the first frame update
    void Start()
    {


    }
    private void Awake()
    {
        myInitialPos = transform.position;
        playerNear = false;
        desiredPos = new Vector3(myInitialPos.x, myInitialPos.y - 20f, myInitialPos.z);

    }
    // Update is called once per frame
    void Update()
    {
        if (PlayerGO == null)
        {
            PlayerGO = GameObject.FindGameObjectWithTag("Player");
        }

        if (!playerNear && Vector3.Distance(transform.position, PlayerGO.transform.position) < dist)
        {
            playerNear = true;
        }

        if (playerNear && !arrived)
        {
            Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothingSpeed);
            transform.position = smoothedPos;

            if (Vector3.Distance(transform.position, PlayerGO.transform.position) <= 1)
            {
                arrived = true;
            }
        }

    }
}
