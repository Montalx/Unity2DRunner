using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSave : MonoBehaviour
{

    public Currency score;


    // Use this for initialization
    void Start ()
    {
        score = GameObject.FindGameObjectWithTag("GameController").GetComponent<Currency>();

        if(PlayerPrefs.HasKey("HighScore"))
        {
            score.scoreCount = PlayerPrefs.GetFloat("HighScore");
        }


    }

    // Update is called once per frame
    void Update ()
    {


      // PlayerPrefs.GetFloat("Score", score.scoreCount);

    }
}
