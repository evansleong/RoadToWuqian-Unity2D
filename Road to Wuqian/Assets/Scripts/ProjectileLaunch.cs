using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLaunch : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform launchPoint;
    public Animator anim;
    [SerializeField] private AudioClip launchSound;

    public float shootCooldown = 170.0f; // Cooldown time in seconds
    private float cooldownTimer = 0.0f; // Timer for the cooldown
    private int remainingShots = 3;
    public float shootCounter;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Reduce the cooldown timer if it's greater than zero
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && remainingShots > 0 && cooldownTimer <= 0)
        {
            anim.SetTrigger("cast");
            SoundManager.instance.PlaySound(launchSound);
            Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);
            remainingShots--;

            cooldownTimer = shootCooldown;
        }
    }
}
