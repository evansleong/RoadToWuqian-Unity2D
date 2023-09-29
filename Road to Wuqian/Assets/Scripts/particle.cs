using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle : MonoBehaviour
{
    public ParticleSystem ps;
    public bool once = true;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && once)
        {
            var em = ps.emission;
            var dur = ps.duration;

            em.enabled = true;
            ps.Play();

            once = false;

        }
    }
}
