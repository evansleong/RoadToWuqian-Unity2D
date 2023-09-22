using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField]private AudioClip buttonSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("SampleScene");
    }

    public void playGame()
    {
        SoundManager.instance.PlaySound(buttonSound);
        StartCoroutine(wait());
    }

    public void setting()
    {
        SoundManager.instance.PlaySound(buttonSound);
    }
    public void quitGame()
    {
        SoundManager.instance.PlaySound(buttonSound);
        Application.Quit();
    }
}
