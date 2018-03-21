using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{

    public GameObject platform;
    public Transform generationPoint;
    public float distanceBetweenPlatforms;

    private float platformWidth;

    public float distanceMin;
    public float distanceMax;



    // Use this for initialization
    void Start ()
    {
        platformWidth = platform.GetComponent<BoxCollider2D>().size.x;

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            distanceBetweenPlatforms = Random.Range(distanceMin, distanceMax);

            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetweenPlatforms, transform.position.y, transform.position.z);

            Instantiate(platform, transform.position, transform.rotation);
        }
		
	}
}
