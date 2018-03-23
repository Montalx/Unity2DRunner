using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinFx : MonoBehaviour
{

    public Transform Fx;

    // Use this for initialization
    void Start ()
    {
        //Fx = GameObject.FindObjectOfType<Coin>
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {

            var effect = Instantiate(Fx, transform.position, transform.rotation);

            Destroy(effect.gameObject, 2);
            //Destroy(gameObject);
            gameObject.SetActive(false);

        }
    }

}
