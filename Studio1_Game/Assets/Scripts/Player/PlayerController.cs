using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Rigidbody Player;

    [SerializeField]
    float mySpeed;

    [SerializeField]
    float myJumpHeight;

    [SerializeField]
    float myTeleportDistance;

    [SerializeField]
    float myTeleportTimer;
    
    [SerializeField]
    float myTeleportTimerMax;

    bool myJump = false;

    [SerializeField]
    GameObject myCamera;

    [SerializeField]
    Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Plane levelPlane = new Plane(Vector3.up, transform.position);
        Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        float rayHitDist = 0.0f;

        if (levelPlane.Raycast(myRay, out rayHitDist))
        {
            Vector3 target = myRay.GetPoint(rayHitDist);
            Quaternion playerRotate = Quaternion.LookRotation(target - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, playerRotate, mySpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * mySpeed * Time.deltaTime);

            if (Input.GetKey(KeyCode.LeftControl) && myTeleportTimer >= myTeleportTimerMax)
            {
                transform.Translate(Vector3.forward * myTeleportDistance * mySpeed * Time.deltaTime);
                myTeleportTimer = 0;
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * mySpeed * Time.deltaTime);

            if (Input.GetKey(KeyCode.LeftControl) && myTeleportTimer >= myTeleportTimerMax)
            {
                transform.Translate(Vector3.back * myTeleportDistance * mySpeed * Time.deltaTime);
                myTeleportTimer = 0;
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * mySpeed * Time.deltaTime);

            if (Input.GetKey(KeyCode.LeftControl) && myTeleportTimer >= myTeleportTimerMax)
            {
                transform.Translate(Vector3.left * myTeleportDistance * mySpeed * Time.deltaTime);
                myTeleportTimer = 0;
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * mySpeed * Time.deltaTime);

            if (Input.GetKey(KeyCode.LeftControl) && myTeleportTimer >= myTeleportTimerMax)
            {
                transform.Translate(Vector3.right * myTeleportDistance * mySpeed * Time.deltaTime);
                myTeleportTimer = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && myJump == false)
        {
            Player.velocity = new Vector3(0, myJumpHeight, 0);
            myJump = true;
        }

        if (myTeleportTimer <= myTeleportTimerMax)
        {
            myTeleportTimer += Time.deltaTime;
        }
        else
        {
            if (myTeleportTimer == myTeleportTimerMax)
            {
                myTeleportTimer = myTeleportTimerMax;
            }
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            myAnimator.SetBool("IsAttacking", true);
        }
        else
        {
            myAnimator.SetBool("IsAttacking", false);
        }
    }

    private void OnCollisionEnter(Collision player)
    {
        if (player.gameObject.tag == "Floor")
        {
            myJump = false;
        }
    }
}
