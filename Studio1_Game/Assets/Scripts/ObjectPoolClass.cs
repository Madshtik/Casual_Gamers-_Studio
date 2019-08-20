using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolClass : MonoBehaviour
{
    public GameObject ghoul;
    //public GameObject Wraith;
    public GameObject playerBullets;
    //public GameObject WraithBullets;
    //public Transform Player;
    //public GameObject spawnPoint;

    public List<GameObject> pooledBullets;
    public List<GameObject> pooledGhouls;

    public float playerDist;

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

        for (int i = 0; i < poolMax; i++)
        {
            GameObject ghoulObj = Instantiate(ghoul);
            ghoulObj.SetActive(false);
            pooledGhouls.Add(ghoulObj);
        }
    }

    void Update()
    {
        //playerDist = Vector3.Distance(transform.position, Player.position);

        //if (playerDist <= 15f)
        //{
        //    SpawnGhoul();
        //}
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

    //public void SpawnGhoul()
    //{
    //    for (int i = 0; i < pooledGhouls.Count; i++)
    //    {
    //        if (!pooledGhouls[i].activeInHierarchy)
    //        {
    //            GameObject ghoul = pooledGhouls[i];
    //            if (ghoul == null)
    //            {
    //                return;
    //            }
    //            ghoul.transform.position = spawnPoint.transform.position;
    //            ghoul.transform.rotation = transform.rotation;
    //            ghoul.SetActive(true);
    //        }
    //    }
    //}
}