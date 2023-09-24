using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMove_ref : MonoBehaviour
{

    public int sceneBuildIndex;

    [SerializeField] private AudioClip portalSound;

    IEnumerator wait()
    {
        Debug.Log("sdsd");
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Trigger Entered");

        if(other.tag == "Player")
        {
            print("Switching Scene to " + sceneBuildIndex);
            SoundManager.instance.PlaySound(portalSound);
            StartCoroutine(wait());
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }
}
