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
    float myDashSpeed;

    [SerializeField]
    float dashTimer;
    
    [SerializeField]
    GameObject myCamera;

    float dashTimerMax = 3.0f;

    bool myJump = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Plane levelPlane = new Plane(Vector3.up, transform.position);
        Ray myRay = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);

        float rayHitPoint = 0.0f;

        if (levelPlane.Raycast(myRay, out rayHitPoint))
        {
            Vector3 target = myRay.GetPoint(rayHitPoint);
            Quaternion playerRotate = Quaternion.LookRotation(target - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, playerRotate, mySpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * mySpeed * Time.deltaTime);

            if (Input.GetKey(KeyCode.LeftControl) && dashTimer >= dashTimerMax)
            {
                Player.velocity = Vector3.forward * myDashSpeed;
                dashTimer = 0;
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * mySpeed * Time.deltaTime);

            if (Input.GetKey(KeyCode.LeftControl) && dashTimer >= dashTimerMax)
            {
                Player.velocity = Vector3.back * myDashSpeed;
                dashTimer = 0;
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * mySpeed * Time.deltaTime);

            if (Input.GetKey(KeyCode.LeftControl) && dashTimer >= dashTimerMax)
            {
                Player.velocity = Vector3.left * myDashSpeed;
                dashTimer = 0;
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * mySpeed * Time.deltaTime);

            if (Input.GetKey(KeyCode.LeftControl) && dashTimer >= dashTimerMax)
            {
                Player.velocity = Vector3.right * myDashSpeed;
                dashTimer = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && myJump == false)
        {
            Player.velocity = new Vector3(0, myJumpHeight, 0);
            myJump = true;
        }

        if (dashTimer <= dashTimerMax)
        {
            dashTimer += Time.deltaTime;
        }
        else
        {
            if (dashTimer == dashTimerMax)
            {
                dashTimer = dashTimerMax;
            }
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
