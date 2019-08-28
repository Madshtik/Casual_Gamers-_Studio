using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWander : MonoBehaviour
{
    [SerializeField] float circleRadius = .3f;

    float wanderAngle;
    Vector3 SeekDirection;
    void Start()
    {
        StartCoroutine(ChangeSeek());
    }
     
    void Update()
    {
        GetComponent<Rigidbody>().velocity += SeekDirection;
        transform.forward = GetComponent<Rigidbody>().velocity;
        if (GetComponent<Rigidbody>().velocity.magnitude > 5)
        {
            GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * 5;
        }
    }

    //polar coordinate system


    IEnumerator ChangeSeek()
    {
        while (true)
        {

            wanderAngle = Random.Range(0, Mathf.PI * 2);
            print(wanderAngle);
            SeekDirection = (transform.forward * 4 + new Vector3(circleRadius * Mathf.Cos(wanderAngle), 0, circleRadius * Mathf.Sin(wanderAngle))).normalized;

            if (transform.position.z >= 20)
            {
                SeekDirection *= -1;
            }
            SeekDirection.y = 0;
            yield return new WaitForSeconds(.5f); ;

        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position+(transform.forward + new Vector3(circleRadius * Mathf.Cos(wanderAngle), 0, circleRadius * Mathf.Sin(wanderAngle))).normalized);
    }
    
}
