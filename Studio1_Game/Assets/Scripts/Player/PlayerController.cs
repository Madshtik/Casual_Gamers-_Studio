using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody Player;

    public Transform ShootPoint;

    public float mySpeed;
    public float myJumpHeight;
    public float myTeleportDistance;
    public float myTeleportTimer;
    public float myTeleportTimerMax;
    public float myHealth;
    public float clawDamage;
    public float damageMod;
    public float fireBallDamage;
    public float plasmaBallDamage;

    bool isJumping = false;

    public Animator myAnimator;

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

        float rayHitDist;

        if (levelPlane.Raycast(myRay, out rayHitDist))
        {
            Vector3 target = myRay.GetPoint(rayHitDist);
            Quaternion playerRotate = Quaternion.LookRotation(target - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, playerRotate, mySpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S)
            && !myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack 1") && !myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack 2"))
        {
            transform.Translate(Vector3.forward * mySpeed * Time.deltaTime);
            myAnimator.SetBool("isWalkingF", true);

            if (Input.GetKey(KeyCode.LeftControl) && myTeleportTimer >= myTeleportTimerMax)
            {
                transform.Translate(Vector3.forward * myTeleportDistance * mySpeed * Time.deltaTime);
                myTeleportTimer = 0;
            }
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            myAnimator.SetBool("isWalkingF", false);
        }

        if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)
            && !myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack 1") && !myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack 2"))
        {
            transform.Translate(Vector3.back * (mySpeed/1.5f) * Time.deltaTime);
            myAnimator.SetBool("isWalkingB", true);

            if (Input.GetKey(KeyCode.LeftControl) && myTeleportTimer >= myTeleportTimerMax)
            {
                transform.Translate(Vector3.back * myTeleportDistance * mySpeed * Time.deltaTime);
                myTeleportTimer = 0;
            }
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            myAnimator.SetBool("isWalkingB", false);
        }

        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S)
            && !myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack 1") && !myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack 2"))
        {
            transform.Translate(Vector3.left * (mySpeed / 1.5f) * Time.deltaTime);
            myAnimator.SetBool("isStrafingL", true);

            if (Input.GetKey(KeyCode.LeftControl) && myTeleportTimer >= myTeleportTimerMax)
            {
                transform.Translate(Vector3.left * myTeleportDistance * mySpeed * Time.deltaTime);
                myTeleportTimer = 0;
            }
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            myAnimator.SetBool("isStrafingL", false);
        }

        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S)
            && !myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack 1") && !myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack 2"))
        {
            transform.Translate(Vector3.right * (mySpeed / 1.5f) * Time.deltaTime);
            myAnimator.SetBool("isStrafingR", true);

            if (Input.GetKey(KeyCode.LeftControl) && myTeleportTimer >= myTeleportTimerMax)
            {
                transform.Translate(Vector3.right * myTeleportDistance * mySpeed * Time.deltaTime);
                myTeleportTimer = 0;
            }
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            myAnimator.SetBool("isStrafingR", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
        {
            Player.velocity = new Vector3(0f, myJumpHeight, 0f);
            isJumping = true;
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

        if (Input.GetMouseButtonDown(0) && !myAnimator.GetCurrentAnimatorStateInfo(0).IsName("WalkF") && !myAnimator.GetCurrentAnimatorStateInfo(0).IsName("WalkB")
            && !myAnimator.GetCurrentAnimatorStateInfo(0).IsName("StrafeR") && !myAnimator.GetCurrentAnimatorStateInfo(0).IsName("StrafeL"))
        {
            myAnimator.SetTrigger("Attack");
        }

        if (Input.GetMouseButtonDown(1) && !myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack 1") && !myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack 2") 
            && !myAnimator.GetCurrentAnimatorStateInfo(0).IsName("WalkF") && !myAnimator.GetCurrentAnimatorStateInfo(0).IsName("WalkB")
            && !myAnimator.GetCurrentAnimatorStateInfo(0).IsName("StrafeR") && !myAnimator.GetCurrentAnimatorStateInfo(0).IsName("StrafeL"))
        {
            myAnimator.SetTrigger("FireBolt");
            Shoot();
        }

        if (myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack 1") || myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack 2"))
        {
            DamageSingleton.instance.swordSwing = true;
            Debug.Log("attacking");
        }
        else
        {
            DamageSingleton.instance.swordSwing = false;
            Debug.Log("not attacking");
        }
    }

    private void OnCollisionEnter(Collision Player)
    {
        if (Player.gameObject.tag == "Floor")
        {
            isJumping = false;
        }

        if (Player.gameObject.tag == "Trap")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Claw")
        {
            if (col.transform.parent.transform.parent.transform.parent.transform.parent.transform.parent.
                transform.parent.transform.parent.transform.parent.transform.parent.gameObject.GetComponent<GhoulBehaviourTree>().isEnraged)
            {
                myHealth -= clawDamage + damageMod;
            }
            else
            {
                myHealth -= clawDamage;
            }

            if (myHealth <= 0)
            {
                Destroy(gameObject);
            }
        }

        if (col.gameObject.tag=="FireBall")
        {
            myHealth -= fireBallDamage;
            //other set inactive
        }
        if (col.gameObject.tag == "PlasmaBall")
        {
            myHealth -= plasmaBallDamage;
            //other set inactive
        }
    }

    void Shoot()
    {
        GameObject bullet = ObjectPoolClass.instance.PlayerBulletToSpawn(); //taking method from ObjectPoolClass
        if (bullet == null)
        {
            return;
        }
        bullet.transform.position = ShootPoint.position;
        bullet.transform.rotation = transform.rotation;
        bullet.SetActive(true);
    }
}