using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class DeadTrigger : MonoBehaviour
{
    public GameObject scoreText;

    public GameObject hiScoreText;

    public AudioSource deathFx;


    void Start()
    {
        scoreText = GameObject.Find("SCORE");
        hiScoreText = GameObject.Find("Hi-Score:");

        deathFx = GameObject.Find("AudioSource2").GetComponent<AudioSource>();

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            deathFx.Play();

            SceneManager.LoadScene("EndingScene");

            //scoreText.gameObject.SetActive(false);

           // hiScoreText.gameObject.SetActive(false);



        }
    }
}
