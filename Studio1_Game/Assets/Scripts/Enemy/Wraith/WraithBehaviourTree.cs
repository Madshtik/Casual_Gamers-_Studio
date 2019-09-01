using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WraithBehaviourTree : BaseBT
{
    PrimarySelector RootNode;
    public float range;
    public GameObject playerGO;
    public int patrolRange;
    public float enragedHP = 20;
    public GameObject fireShot;
    public GameObject plasmaShot;
    public GameObject[] patrolPoints;
    public Transform ballSpawnP;
    public Rigidbody rb;
    public Animator myAnim;
    public float attTime;
    public float attIntervalTime;
    public float seekForce;
    public bool canAttack;
    public int patrolIndex = 0;
    public bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {

        patrolPoints = new GameObject[4];

        //tree
        RootNode = new PrimarySelector();

        RootNode.MyChildren.Add(new Sequencer());
        RootNode.MyChildren.Add(new Sequencer());
        RootNode.MyChildren.Add(new Sequencer());

        RootNode.MyChildren[0].MyChildren.Add(new CheckNotInRange());
        RootNode.MyChildren[0].MyChildren.Add(new PatrolBehavior());

        RootNode.MyChildren[1].MyChildren.Add(new WraithCheckEnraged());
        RootNode.MyChildren[1].MyChildren.Add(new SeekBehaviour());
        RootNode.MyChildren[1].MyChildren.Add(new WraithEnragedAttack());

        RootNode.MyChildren[2].MyChildren.Add(new SeekBehaviour());
        RootNode.MyChildren[2].MyChildren.Add(new WraithAttack());

        //tree
        RootNode.InitializeState(this);
        myAnim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        RootNode.MyLogicUpdate();
        if (!canAttack && attTime < attIntervalTime)
        {
            attTime += Time.deltaTime;
            if (attTime >= attIntervalTime)
            {
                canAttack = true;
                attTime = 0;
            }
        }

        if (myHealth <= 0 && !isDead)
        {
            isDead = true;
            myAnim.SetBool("isDead", true);

        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sword" && DamageSingleton.instance.swordSwing) //detects the player's sword trigger and reduces the health of the ghoul
        {
            myHealth -= swordDamage;
        }

        if (other.gameObject.tag == "PlayerBullet" && DamageSingleton.instance.swordSwing)
        {
            myHealth -= swordDamage;
        }
    }
    public void FireShot()
    {
        if (canAttack)
        {
            myAnim.SetTrigger("Attack");

            canAttack = false;
        }
    }
    public void PlasmaShot()
    {
        if (canAttack)
        {
            myAnim.SetTrigger("Attack");

            canAttack = false;
        }
    }

    public void InstantiatePlasma()
    {
        Instantiate(plasmaShot, transform.position, transform.rotation);
    }
    public void InstantiateFire()
    {
        if (!isEnraged)
        {
            Instantiate(fireShot, ballSpawnP.position, transform.rotation);
        }
        else
        {
            Instantiate(plasmaShot, ballSpawnP.position, transform.rotation);
        }
    }
}
