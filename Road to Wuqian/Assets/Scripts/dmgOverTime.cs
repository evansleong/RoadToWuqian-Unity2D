using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dmgOverTime : MonoBehaviour
{
    private TrapsScript trapS;
    // Start is called before the first frame update
    void Start()
    {
        trapS = GetComponent<TrapsScript>();

        if(trapS != null)
        {
            InvokeRepeating("CallTrap", 0f, 2f);
        }
    }
    
    public void CallTrap()
    {
        if (trapS != null)
        {
            playerLife playerLifeComponent = GetComponent<playerLife>();

            if (playerLifeComponent != null)
            {
                trapS.TrapTrigger(playerLifeComponent);
            }
        }
    } 
}
