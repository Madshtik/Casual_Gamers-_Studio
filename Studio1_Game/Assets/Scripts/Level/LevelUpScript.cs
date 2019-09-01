using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpScript : MonoBehaviour
{
    public float smoothingSpeed = 0.05f;
    Vector3 myInitialPos;
    public bool playerNear;
    public GameObject PlayerGO;
    public float dist;
    Color fader;
    Material myMat;
    // Start is called before the first frame update
    void Start()
    {


    }
    private void Awake()
    {
        myInitialPos = transform.position;
        playerNear = false;
        myMat = GetComponent<MeshRenderer>().material;
        fader = myMat.color;
        fader.a = 0;
        myMat.color = fader;
    }
    // Update is called once per frame
    void Update()
    {
        if (!playerNear && Vector3.Distance(transform.position, PlayerGO.transform.position) < dist)
        {
            playerNear = true;
        }
        if (playerNear)
        {
            if (fader.a <= 1)
            {
                fader.a += .05f;
            }
            
            myMat.color = fader;
            Vector3 desiredPos = new Vector3(myInitialPos.x, myInitialPos.y + 20f, myInitialPos.z);
            Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothingSpeed);
            transform.position = smoothedPos;
        }

    }
}
