using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text hiScoreText;
    public Text coinText;
    public float scoreCount;
    public float hiScoreCount;
    public float pointsPerSecond;
    public bool notDead=true;
    public float startMove;

    public float coinScoreCount;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("HighScore"))
        {
            hiScoreCount = PlayerPrefs.GetFloat("HighScore");
        }
        if (PlayerPrefs.HasKey("CoinScore"))
        {
            coinScoreCount = PlayerPrefs.GetFloat("CoinScore");
        }
        else
        {
            coinScoreCount = 0;
        }

    }

    // Update is called once per frame
    void Update()
    {
        startMove -= Time.deltaTime;
        if (startMove <= 3.4f)
        {
            if (notDead)
            {
                scoreCount += pointsPerSecond * Time.deltaTime;
            }
            if (scoreCount > hiScoreCount)
            {
                hiScoreCount = scoreCount;
                PlayerPrefs.SetFloat("HighScore", hiScoreCount);
            }
            scoreText.text = "Pontos: " + Mathf.Round(scoreCount);
            
        }
        hiScoreText.text = "Record: " + Mathf.Round(hiScoreCount);
        coinText.text = ""+coinScoreCount;
        //coinText.text = "Moedas:aaa " + coinScoreCount;


    }
}
