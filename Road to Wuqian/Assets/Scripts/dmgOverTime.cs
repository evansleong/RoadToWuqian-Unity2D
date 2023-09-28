using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dmgOverTime : MonoBehaviour
{
    private TrapsScript trapS;
    private playerMovement ply;
    public float slowDrag = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        trapS = GetComponent<TrapsScript>();
        ply = GetComponent<playerMovement>();

        if (trapS != null)
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
                // Slow down the player by increasing linear drag
                if (ply != null)
                {
                    ply.SetLinearDrag(slowDrag);
                }
            }
        }
    } 
}
