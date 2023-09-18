using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Vector3 lastCkptPos;
    [SerializeField] private AudioClip bonfireSound;

    public void setCkptPos(Vector3 position)
    {
        lastCkptPos = position;
        SoundManager.instance.PlaySound(bonfireSound);
        Debug.Log("Checkpoint position has been set to: " + lastCkptPos);
    }

    public Vector3 getLastCkptPos()
    {
        return lastCkptPos;
    }

}
