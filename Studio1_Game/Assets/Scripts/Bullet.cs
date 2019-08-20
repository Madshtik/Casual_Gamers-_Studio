using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float myBulletSpeed;
    public float myBulletTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isActiveAndEnabled)
        {
            transform.Translate(0, 0, myBulletSpeed * Time.deltaTime);

            myBulletTimer -= Time.deltaTime;

            if (myBulletTimer <= 0f)
            {
                gameObject.SetActive(false);
                myBulletTimer = 5f;
            }
        }
    }
}
