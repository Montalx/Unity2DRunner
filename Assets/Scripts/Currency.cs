using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Currency : MonoBehaviour
{

    //public int gold;
    GameObject HUD;

    public Text scoreText;

    public Text hiScoreText;

    public float scoreCount;
    public float hiScoreCount;

    public float pointsPerSecond;

    public bool scoreIncreasing;

    void Start()
    {
        HUD = GameObject.Find("Currency");

        if(PlayerPrefs.HasKey("HighScore"))
        {
            hiScoreCount = PlayerPrefs.GetFloat("HighScore");
        }
        
    }
    void Update()
    {

        scoreCount += pointsPerSecond * Time.deltaTime;

        if(scoreIncreasing)
        {
            if(Application.loadedLevel == 1)
            {
                scoreCount += pointsPerSecond * Time.deltaTime;

            }
        }

        if(scoreCount > hiScoreCount)
        {
            hiScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", hiScoreCount);
        }

        HUD.GetComponent<Text>().text = scoreCount.ToString();

        if(scoreCount < 0)
        {
            scoreCount = 0;
        }

        scoreText.text = "Score:  " + Mathf.Round (scoreCount);
        hiScoreText.text = "High Score:  " + Mathf.Round(hiScoreCount);
       // PlayerPrefs.SetFloat(hiScoreCount)

    }

}