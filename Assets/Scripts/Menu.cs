using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public AudioSource Start;
    public AudioSource audioBtn;
    public GameObject ComoJogar;
    public Button VoltarBTN; 


    // Start is called before the first frame update
    public void PlayGame()
    {
        Start.Play();
        SceneManager.LoadScene("Main");
    }

    // Update is called once per frame
    public void QuitGame()
    {
        audioBtn.Play();
        ComoJogar.SetActive(true);
    }

    public void Voltar()
    {
        audioBtn.Play();
        ComoJogar.SetActive(false);
    }

}
