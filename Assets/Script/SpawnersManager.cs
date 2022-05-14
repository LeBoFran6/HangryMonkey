using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnersManager : MonoBehaviour
{
    public float randomNumber;
    public float randomSpawner;
    public float randomS;
    public float fruitsC ;

    public Transform Spawner0;
    public Transform Spawner1;
    public Transform Spawner2;

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
            if (randomSpawner < 0)
            {
                randomS = Random.Range(0f, 1f);
                Instantiate(myPrefab, new Vector3( randomS + Spawner0.position.x, 8f , 0f), Quaternion.identity);
                fruitsC++;
                randomNumber = Random.Range(2f, 6f);
                randomSpawner = Random.Range(0f, 3f);
                Debug.Log("0");
            }
            if (randomSpawner < 1)
            {
                randomS = Random.Range(0f, 1f);
                Instantiate(myPrefab,  new Vector3(randomS + Spawner1.position.x, 8f , 0f), Quaternion.identity);
                fruitsC++;
                randomNumber = Random.Range(2f, 6f);
                randomSpawner = Random.Range(0f, 3f);
                Debug.Log("1");
            }
            if (randomSpawner < 2)
            {
                randomS = Random.Range(0f, 1f);
                Instantiate(myPrefab,  new Vector3(randomS + Spawner2.position.x, 8f, 0f), Quaternion.identity);
                fruitsC++;
                randomNumber = Random.Range(2f, 6f);
                randomSpawner = Random.Range(0f, 3f);
                Debug.Log("2");
            }
        }
    }
}
