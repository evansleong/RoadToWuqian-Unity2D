using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{

    [SerializeField] private AudioClip buttonSound;
    public void Pause()
    {
        SoundManager.instance.PlaySound(buttonSound);
        Time.timeScale = 0;
    }

    public void Continue()
    {
        SoundManager.instance.PlaySound(buttonSound);
        Time.timeScale = 1;
    }
    public void quitGame()
    {
        SoundManager.instance.PlaySound(buttonSound);
        Application.Quit();
    }

    public void Restart()
    {
        SoundManager.instance.PlaySound(buttonSound);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
