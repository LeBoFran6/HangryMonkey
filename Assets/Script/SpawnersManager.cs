using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnersManager : MonoBehaviour
{
    public float randomNumber;
    public float randomSpawner;
    public float randomS;
    public float fruitsC ;

    public GameObject myPrefab;

    void Start()
    {
        fruitsC = 1;
        randomNumber = Random.Range(2f, 6f);
        randomSpawner = Random.Range(0f, 3f);
    }
    
    void Update()
    {
        if(fruitsC < 7 && randomNumber > 0)
        {
            randomNumber = randomNumber - 1 *Time.deltaTime;
        }
        if(randomNumber < 0)
        {
            if (randomNumber < 0)
            {
                randomS = Random.Range(0f, 1f);
                Instantiate(myPrefab, new Vector3(8f + randomS, 8f , 0f), Quaternion.identity);
                fruitsC++;
                randomNumber = Random.Range(2f, 6f);
                randomSpawner = Random.Range(0f, 3f);
                Debug.Log("0");
            }
            if (randomNumber < 1)
            {
                randomS = Random.Range(0f, 1f);
                Instantiate(myPrefab,  new Vector3(10f + randomS, 8f , 0f), Quaternion.identity);
                fruitsC++;
                randomNumber = Random.Range(2f, 6f);
                randomSpawner = Random.Range(0f, 3f);
                Debug.Log("1");
            }
            if ( randomNumber < 2)
            {
                randomS = Random.Range(0f, 1f);
                Instantiate(myPrefab,  new Vector3(12f + randomS, 8f, 0f), Quaternion.identity);
                fruitsC++;
                randomNumber = Random.Range(2f, 6f);
                randomSpawner = Random.Range(0f, 3f);
                Debug.Log("2");
            }
        }
    }
}
