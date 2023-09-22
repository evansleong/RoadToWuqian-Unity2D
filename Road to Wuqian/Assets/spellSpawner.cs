using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spellSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] spellPrefabs;
    [SerializeField] private AudioClip spellSound;
    private float lifetime;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            spell();
        }

        lifetime += Time.deltaTime;
        if(lifetime > 3) {gameObject.SetActive(false);}
    }

    void spell()
    {
        lifetime = 0;

        int ranSpell = Random.Range(0, spellPrefabs.Length);
        int ranSpawPoint = Random.Range(0, spawnPoints.Length);
            
        Instantiate(spellPrefabs[ranSpell], spawnPoints[ranSpawPoint].position, transform.rotation);
        SoundManager.instance.PlaySound(spellSound);
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
