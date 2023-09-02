using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool bullet;
    private List<GameObject> pooledBullets = new List<GameObject>();
    private int poolNo = 30;

    [SerializeField] private GameObject projectilePrefab;

    // Start is called before the first frame update
    //void Awake()
    //{
    //    if(bullet == null)
    //    {
    //        bullet = this;
    //    }
    //}

    void Start()
    {
        for(int i = 0; i < poolNo; i++)
        {
            GameObject obj = Instantiate(projectilePrefab);
            obj.SetActive(false);
            pooledBullets.Add(obj);
        }
    }

    public GameObject GetBulletFromPool()
    {
        for (int i = 0; i < pooledBullets.Count; i++)
        {
            if (!pooledBullets[i].activeInHierarchy)
            {
                return pooledBullets[i];
            }
        }

        return null;
    }
}
