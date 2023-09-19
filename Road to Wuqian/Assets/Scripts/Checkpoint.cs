using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Vector3 lastCkptPos;
    [SerializeField] private AudioClip bonfireSound;

    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vector3 playerPosition = other.transform.position;
            setCkptPos(playerPosition);
        }
    }

    public void setCkptPos(Vector3 playerPosition)
    {
            lastCkptPos = playerPosition;
            SoundManager.instance.PlaySound(bonfireSound);
            Debug.Log("Checkpoint position has been set to: " + lastCkptPos);
    }

    public Vector3 getLastCkptPos()
    {
        return lastCkptPos;
    }

   

}
