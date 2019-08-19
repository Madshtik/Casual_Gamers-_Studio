using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolClass : MonoBehaviour
{
    public GameObject ghoul;
    //public GameObject Wraith;
    public GameObject playerBullets;
    //public GameObject WraithBullets;

    public List<GameObject> pooledBullets;

    int poolMax = 10;
    int newPoolMax = 35;

    //Singleton
    public static ObjectPoolClass instance;

    void Awake()
    {
        instance = this;

        for (int i = 0; i < poolMax; i++)
        {
            GameObject pBulletObj = Instantiate(playerBullets);
            pBulletObj.SetActive(false);
            pooledBullets.Add(pBulletObj);
        }
    }

    public GameObject PlayerBulletToSpawn()
    {
        for (int i = 0; i < pooledBullets.Count; i++)
        {
            if (!pooledBullets[i].activeInHierarchy)
            {
                return pooledBullets[i];
            }
        }
        if (pooledBullets.Count >= 10 && !(pooledBullets.Count >= newPoolMax))
        {
            GameObject pBulletObj = Instantiate(playerBullets);
            pBulletObj.SetActive(false);
            pooledBullets.Add(pBulletObj);
            return pBulletObj;
        }
        return null;
    }
}