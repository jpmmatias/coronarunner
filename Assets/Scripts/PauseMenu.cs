using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public AudioSource btnSound;
    public Button pauseBtn;
    public AudioSource Running;
    public void PauseGame()
    {
        btnSound.Play();
        Time.timeScale=0f;
        Running.volume = 0;
        pauseMenu.SetActive(true);
        pauseBtn.gameObject.SetActive(false);
    }
    public void ResumeGame()
    {
        btnSound.Play();
        pauseMenu.SetActive(false);
        Running.volume = 1;
        Time.timeScale = 1f;
        pauseBtn.gameObject.SetActive(true);
    }
    public void PlayGame()
    {
        Time.timeScale = 1f;
        btnSound.Play();
        SceneManager.LoadScene("Main");

    }

    // Update is called once per frame
    public void QuitGame()
    {
        Time.timeScale = 1f;
        btnSound.Play();
        SceneManager.LoadScene("Menu");
    }
}
