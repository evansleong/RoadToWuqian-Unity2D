using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProjectileLaunch : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform launchPoint;
    public Animator anim;
    [SerializeField] private AudioClip launchSound;

    public float shootCooldown = 5.0f; // Cooldown time in seconds
    private float cooldownTimer = 0.0f; // Timer for the cooldown
    private bool isCooldown = false;
    private int remainingShots = 3;
    public float shootCounter;

    [SerializeField] private Image imageCooldown;
    [SerializeField] private TMP_Text textCooldown;
    [SerializeField] private TMP_Text remainingFireball;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        textCooldown.gameObject.SetActive(false);
        imageCooldown.fillAmount = 0.0f;

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && remainingShots > 0 && cooldownTimer <= 0)
        {
            useFireball();
        }
        if(isCooldown)
        {
            ApplyCoolDown();
        }
    }

    void ApplyCoolDown()
    {
        cooldownTimer -= Time.deltaTime;

        if(remainingShots == 0)
        {
            isCooldown = false;
            textCooldown.gameObject.SetActive(false);
            imageCooldown.fillAmount = 0.0f;
        }

        if(cooldownTimer < 0.0f)
        {
            isCooldown = false;
            textCooldown.gameObject.SetActive(false);
            imageCooldown.fillAmount = 0.0f;
        }
        else
        {
            textCooldown.text = Mathf.RoundToInt(cooldownTimer).ToString();
            imageCooldown.fillAmount = cooldownTimer / shootCooldown;
        }
    }

    public bool useFireball()
    {
        if(isCooldown)
        {
            return false;
        }
        else
        {
            anim.SetTrigger("cast");
            SoundManager.instance.PlaySound(launchSound);
            Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);
            remainingShots--;
            remainingFireball.text = Mathf.RoundToInt(remainingShots).ToString();

            isCooldown = true;
            textCooldown.gameObject.SetActive(true);
            cooldownTimer = shootCooldown;
            return true;   
        }
    }

    
    // // Update is called once per frame
    // void Update()
    // {
    //     // Reduce the cooldown timer if it's greater than zero
    //     if (cooldownTimer > 0)
    //     {
    //         cooldownTimer -= Time.deltaTime;
    //         isCooldown = true;
    //     }

    //     if (Input.GetKeyDown(KeyCode.Space) && remainingShots > 0 && cooldownTimer <= 0)
    //     {
    //         anim.SetTrigger("cast");
    //         SoundManager.instance.PlaySound(launchSound);
    //         Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);
    //         remainingShots--;

    //         isCooldown = false;
    //         textCooldown.gameObject.SetActive(true);
    //         cooldownTimer = shootCooldown;            
    //     }
    // }
}
