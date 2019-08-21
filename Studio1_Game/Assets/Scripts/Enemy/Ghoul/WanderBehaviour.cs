using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderBehaviour : Node
{


    public override void MyLogicUpdate()
    {
        //Debug.Log("ROAM");

        //float minAngle = 0f;
        //float maxAngle = 180f;
        //float angleChange = Random.Range(50f, 100f);
        //float wanderAngle = Mathf.LerpAngle(minAngle, maxAngle, angleChange * Time.deltaTime);

        //Vector3 CircleCentre = new Vector3(0, 0, gManager.transform.position.z + 10);

        //Vector3 wanderCircleRadius = new Vector3(gManager.CircleCentre.position.x + 5, 0, gManager.CircleCentre.position.z + 5); //setting the radius
        ////Vector3 circleVectVelocity = Vector3.Normalize(gManager.CircleCentre.position - gManager.transform.position) * gManager.mySpeed;     
        ////Vector3 circlePosition = gManager.transform.position + circleVectVelocity * gManager.circleDistance;
        ////Vector3 myTarget = circlePosition + wanderCircleRadius;
        //gManager.CircleCentre.transform.eulerAngles = new Vector3(0, wanderAngle, 0);

        //Vector3 vectVelocity = Vector3.Normalize(gManager.CircleCentre.position - gManager.transform.position) * gManager.mySpeed;
        //vectVelocity = new Vector3(vectVelocity.x, 0, vectVelocity.z);

        //Vector3 futurePos = gManager.CircleCentre.position + vectVelocity + wanderCircleRadius;

        //Vector3 mySteering = futurePos - gManager.myRB.velocity;

        //Vector3.ClampMagnitude(mySteering, gManager.maxForce);

        //gManager.myRB.AddForce(mySteering);

        myCurrentState = State.FAILED;
    }
}
