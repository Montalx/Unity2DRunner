using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PickUpLoot : MonoBehaviour
{

    public Currency currentGold;
    public AudioSource coinFx;

    public int addAmount;

    void Start()
    {
        currentGold = GameObject.FindGameObjectWithTag("GameController").GetComponent<Currency>();

        coinFx = GameObject.Find("AudioSource").GetComponent<AudioSource>();

    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.gameObject.tag == "Player")
        {

            currentGold.scoreCount += addAmount;
            // Destroy(gameObject);
            //AudioSource.PlayClipAtPoint(coinFx, new Vector3(transform.position.x, transform.position.y, transform.position.z - 31.6f));
            if(coinFx.isPlaying)
            {
                coinFx.Stop();
                coinFx.Play();
            }
            else
            {
                coinFx.Play();
            }

            gameObject.SetActive(false);
        }
    }
}