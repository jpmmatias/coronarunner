using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine.SceneManagement;
using UnityEngine;
using Debug = UnityEngine.Debug;
using UnityEngine.UI;
using System;

public class PlayerCol : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource coinAudio;
    public AudioSource deathAudio;
    public ScoreManager theScoreManager;
    public GameOver deathScreean;
    public Button pauseBTN;
    public Text textVida;
    public Text moedasText;


    public int health = 100;
    public GameObject Player;
    public Slider healthBar;
    public AudioSource onstacleAudio;

 



    void start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
        InvokeRepeating("reduceHealth", 1f, 1f);


        //coinAudio=GameObject.Find

    }
    public void reduceHealth()
    {
        health -= 20;
        healthBar.value = health;

        if (health <= 0)
        {
            PlayerDies();
        }
    }

    public void increaseHealth()
    {
        health += 40;
        healthBar.value = health;
      

    }


    void OnCollisionEnter(Collision col)
    {
      



        if (col.gameObject.tag == "PoweUp1")
        {
           
        }
    }
    void OnTriggerEnter(Collider trig)
    {
        trig.gameObject.SetActive(false);
        //Destroy(trig.gameObject);

        if (trig.gameObject.tag=="Coin")
        {
           
            
            theScoreManager.coinScoreCount = theScoreManager.coinScoreCount + 1;
            PlayerPrefs.SetFloat("CoinScore", theScoreManager.coinScoreCount);
            //coinText.text = "Moedas: " + coinScoreCount;

            if (coinAudio.isPlaying)
            {
                coinAudio.Stop();
                coinAudio.Play();
            }
            else
            {
                coinAudio.Play();
            }
            
        }
        if (trig.gameObject.tag == "enemy")
        {
           reduceHealth();
           reduceHealth();


        }

        if (trig.gameObject.tag == "obstacle")
        {

            onstacleAudio.Play();
            reduceHealth();
      

        }






    }

    private void MakeSubclip(AudioSource onstacleAudio, float v1, float v2)
    {
        throw new NotImplementedException();
    }

   

    void PlayerDies()
    {
        //SceneManager.LoadScene("Main");
        pauseBTN.gameObject.SetActive(false);
        moedasText.gameObject.SetActive(false);
        healthBar.gameObject.SetActive(false);
        textVida.gameObject.SetActive(false);
        deathScreean.gameObject.SetActive(true);
        theScoreManager.notDead = false;
        gameObject.SetActive(false);
        deathAudio.Play();


    }
}
