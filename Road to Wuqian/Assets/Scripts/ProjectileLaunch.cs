using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLaunch : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform launchPoint;
    public Animator anim;
    [SerializeField] private AudioClip launchSound;

    public float shootTime;
    public float shootCounter;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        shootCounter = shootTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && shootCounter <= 0)
        {
            anim.SetTrigger("cast");
            SoundManager.instance.PlaySound(launchSound);
            Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);
            shootCounter = shootTime;
        }
        shootCounter -= Time.deltaTime; 
    }
}
