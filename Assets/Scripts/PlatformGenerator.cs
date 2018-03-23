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

    //public GameObject[] platformArray;
    private int platformSelector;
    private float[] platformArrayWidth;

    public ObjectPooler[] objectPool;


    private float minHeight;
    private float maxHeight;
    public Transform maxHeightPoint;
    public float maxHeightChange;
    private float heightChange;

    private CoinGenerator coinGenerator;
    public float randomCoinGeneration;


    // Use this for initialization
    void Start ()
    {
        //platformWidth = platform.GetComponent<BoxCollider2D>().size.x;

        platformArrayWidth = new float[objectPool.Length];

        for (int i = 0; i < objectPool.Length; i++)
        {
            platformArrayWidth[i] = objectPool[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;

        coinGenerator = FindObjectOfType<CoinGenerator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            distanceBetweenPlatforms = Random.Range(distanceMin, distanceMax);

            platformSelector = Random.Range(0, objectPool.Length);

            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

            if(heightChange > maxHeight)
            {
                heightChange = maxHeight;
            }
            else if (heightChange < minHeight)
            {
                heightChange = minHeight;
            }

            transform.position = new Vector3(transform.position.x + (platformArrayWidth[platformSelector] / 2) + distanceBetweenPlatforms, heightChange, transform.position.z);

            //Instantiate(/*platform*/platformArray[platformSelector], transform.position, transform.rotation);

            GameObject newPlatform = objectPool[platformSelector].GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            if(Random.Range(0f, 10f) < randomCoinGeneration)
            {
                coinGenerator.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));
            }

            transform.position = new Vector3(transform.position.x + (platformArrayWidth[platformSelector] / 2), transform.position.y, transform.position.z);


        }

    }
}
