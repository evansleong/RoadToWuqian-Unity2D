using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomSpawnerSpells : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] spells;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            int randSpell = Random.Range(0, spells.Length);
            int randSpawPoint = Random.Range(0, spawnPoints.Length);

            Instantiate(spells[0], spawnPoints[randSpawPoint].position, transform.rotation); 
        }
    }
}
