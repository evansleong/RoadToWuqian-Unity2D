using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject bulletPool;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(bulletPool);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
