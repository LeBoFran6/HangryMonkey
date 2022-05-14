using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnersManager : MonoBehaviour
{
    // Start is called before the first frame update
    //public bool Timer;
    public float randomNumber;
    public float randomSpawner;
    public float fruitsC ;

    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject myPrefab;

    public Transform Spawn0;
    public Transform Spawn1;
    public Transform Spawn2;

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        //Timer = true;
        //Instantiate(myPrefab, Spawn0.transform.position, Quaternion.identity);
        fruitsC = 1;
        // Instantiatet position (0, 0, 0) and ero rotation.
        randomNumber = Random.Range(2f, 7f);
        randomSpawner = Random.Range(0f, 3f);
    }


    
    void Update()
    {
        if( randomNumber > 0)
        {
            randomNumber = randomNumber - 1 *Time.deltaTime;
        }
        if(randomNumber < 0)
        {
            if(randomNumber < 1)
            {
                Instantiate(myPrefab, Spawn0.transform.position, Quaternion.identity);
                randomNumber = Random.Range(0f, 7f);
                randomSpawner = Random.Range(0f, 3f);
            }
            if (randomNumber < 2)
            {
                Instantiate(myPrefab, Spawn1.transform.position, Quaternion.identity);
                randomNumber = Random.Range(0f, 7f);
                randomSpawner = Random.Range(0f, 3f);
            }
            if (randomNumber < 3)
            {
                Instantiate(myPrefab, Spawn2.transform.position, Quaternion.identity);
                randomNumber = Random.Range(0f, 7f);
                randomSpawner = Random.Range(0f, 3f);
            }
        }
        
    }

   
}
