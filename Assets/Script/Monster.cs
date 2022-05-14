using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    public Slider FeedingBar;
    public GameObject Bouche;
    public GameObject SlapSprite;
    public float Timer = 0;
    public float Timer2 = 0;
    public bool BoucheOuverte = true;
    public bool Sleep = false;
    public bool Slap = false;
    public GameObject NoomText;

    public GameObject SpawnerManager;
    public GameObject SLAPText;


    void Start()
    {
        FeedingBar.value = 100;
        Timer = 10;
        Timer2 = 0;
    }

    void Update()
    {
        FeedingBar.value = FeedingBar.value - 5 * Time.deltaTime;




        if (Timer > -1)
        {
            Timer = Timer + 1 * Time.deltaTime;
            Bouche.SetActive(false);
        }
        if (Timer > 1)
        {
            Bouche.SetActive(true);
            NoomText.SetActive(false);
        }





        if (Input.GetKeyDown(KeyCode.F))
        {
            Slap = true;
            Debug.Log("STARTslap");
        }

        if (Slap == true)
        {
            MonkeySlap();
        }


        if (Input.GetKeyDown("space"))
        {
            if(Sleep == false)
            {
                Sleep = true;
                Debug.Log("GOsleep");
            }
        }

        if(Sleep == true)
        {
            SleepMode();
        }
    }

    public void FeedMonster()
    {
        FeedingBar.value = FeedingBar.value  + 5;
        Bouche.SetActive(false);
        NoomText.SetActive(true);
        Timer = 0;
        SpawnerManager.GetComponent<SpawnersManager>().fruitsC -= 1;
    }

    public void MonkeySlap()
    {
        if (Timer2 > -1)
        {
            Timer2 = Timer2 + 1 * Time.deltaTime;
            SLAPText.SetActive(true);
            SlapSprite.SetActive(true);
        }
        if (Timer2 > 0.5)
        {
            SLAPText.SetActive(false);
            SlapSprite.SetActive(false);
            Timer2 = 0;
            Debug.Log("ENDslap");
            Slap = false;
        }
        //retire une vie a chaque joueure
        ////remet le barre au max 
    }

    public void SleepMode()
    {
        Debug.Log("sleep");
        Bouche.SetActive(false);
        if (Timer2 > -1)
        {
            Timer2 = Timer2 + 1 * Time.deltaTime;
            Bouche.SetActive(false);
        }
        if (Timer2 > 4)
        {
            Bouche.SetActive(true);
        }
        if (Timer2 > 6)
        {
            Timer2 = 0;
        }
    }
}
