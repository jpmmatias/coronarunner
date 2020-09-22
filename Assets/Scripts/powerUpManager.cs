using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpManager : MonoBehaviour
{
    private bool healthPoints;
    private bool safeMode;

    private bool powerupActive;
    private float powerupTimeCounter;
    private ScoreManager theScoreManager;
    private ObjectSpawner theObjectSpawner;
    private float normalPointsPerSecond;
    private float enemyRate;
    public AudioSource powerUpSound;
    private bool powerUpSoundPlaying=false;
    private PlayerCol playerCol;
    // Start is called before the first frame update
    void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
        theObjectSpawner = FindObjectOfType<ObjectSpawner>();
        playerCol = FindObjectOfType<PlayerCol>();


    }

    // Update is called once per frame
    void Update()
    {
        if (powerupActive)
        {
            powerupTimeCounter -= Time.deltaTime;

            if (healthPoints)
            {
                if (powerUpSoundPlaying == false)
                {
                    powerUpSound.Play();
                    powerUpSoundPlaying = true;

                }
               
                playerCol.increaseHealth();
                Debug.Log("aaaaajdksjdksjd");
                
            }

            if (safeMode)
            {
                if (powerUpSoundPlaying == false)
                {
                    powerUpSound.Play();
                    powerUpSoundPlaying = true;

                }

                theObjectSpawner.enemy.SetActive(false);
                theObjectSpawner.enemySpawnTimer = 20f;
            }

            if (powerupTimeCounter <= 0)
            {
                theObjectSpawner.enemy.SetActive(true);
                theScoreManager.pointsPerSecond = normalPointsPerSecond;
                theObjectSpawner.enemySpawnTimer = enemyRate;
                powerupActive = false;
                powerUpSoundPlaying = false;
            }
        }
        
    }

    public void ActivatePowerUp(bool health,bool safe,float time)
    {
        healthPoints = health;
        safeMode = safe;
        powerupTimeCounter = time;

        normalPointsPerSecond = theScoreManager.pointsPerSecond;
        enemyRate = theObjectSpawner.enemySpawnTimer;

        powerupActive = true;


    }
}
