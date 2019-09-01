using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updown : MonoBehaviour
{
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            transform.position += Vector3.down * Time.deltaTime *3f ;
            Destroy(gameObject, 5f);
        }
    }
}
