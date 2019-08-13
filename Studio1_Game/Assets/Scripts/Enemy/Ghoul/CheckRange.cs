using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRange : GhoulNode
{
    public override void GhoulInitializeState(GhoulBehaviourTree GBT)
    {
        gManager = GBT;
        if (GBT.checkDistance <= 10f && GBT.isEnraged != true)
        {
            GBT.normalAttack = true;
            myCurrentState = State.SUCCESS;
        }

        if (GBT.checkDistance >= 10f && GBT.normalAttack == true)
        {
            GBT.normalAttack = false;
        }

        if (GBT.checkDistance <= 20f && GBT.isEnraged == true && GBT.normalAttack != true && GBT.myCurrentHP <= 5f)
        {
            GBT.enragedAttack = true;
            myCurrentState = State.SUCCESS;
        }

        if (GBT.checkDistance >= 20f && GBT.enragedAttack == true)
        {
            GBT.enragedAttack = false;
        }

        myCurrentState = State.FAILED;
    }

    /*public Transform TargetPlayer;

    public float myCurrentHP;
    public float checkDistance;
    public float swordDamage;   

    public bool isEnraged;
    public bool normalAttack;
    public bool enragedAttack;

    void Update()
    {
        checkDistance = Vector3.Distance(transform.position, TargetPlayer.position);

        Debug.Log("Running Range Check");
        if (checkDistance <= 10f && isEnraged != true)
        {
            normalAttack = true;
        }

        if (checkDistance >= 10f && normalAttack == true)
        {
            normalAttack = false;
        }

        if (checkDistance <= 20f && isEnraged == true && normalAttack != true && myCurrentHP <= 5f)
        {
            enragedAttack = true;
        }

        if (checkDistance >= 20f && enragedAttack == true)
        {
            enragedAttack = false;
        }
    }

    private void OnTriggerEnter(Collider MyTrigger)
    {
        if (MyTrigger.gameObject.tag.Equals("Sword"))
        {
            myCurrentHP -= swordDamage * (2 * Time.deltaTime);

            if (myCurrentHP <= 0f)
            {
                Destroy(gameObject);
            }
        }
    }*/
}