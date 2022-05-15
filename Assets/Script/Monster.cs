using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Monster : MonoBehaviour
{
    public PlayerController Player1;
    public PlayerController Player2;
    public Slider FeedingBar;
    public GameObject Bouche;
    public GameObject PasDeBouche;
    public GameObject SlapSprite;
    public float Timer = 0;
    public float Timer2 = 0;
    public float Timer3 = 0;
    public bool BoucheOuverte = true;
    public bool Rage = false;
    public bool Slap = false;
    public bool RRRR = false;
    public bool canEat = true;
    public GameObject NoomText;

    public AudioSource RageAudio;
    public AudioSource SlapAudio;
    public AudioSource RRRRAudio;
    public AudioSource GrumyAudio;

    public List<Transform> listVignettePoint;

    public GameObject SpawnerManager;
    public GameObject SLAPText;
    public GameObject RRRRText;
    public GameObject m_camera;


    void Start()
    {
        FeedingBar.value = 100;
        Timer = 10;
        Timer2 = 0;
    }

    void Update()
    {

        if (!canEat) return;

        FeedingBar.value = FeedingBar.value - 5 * Time.deltaTime;

        if (FeedingBar.value <= 0)
        {
            Slap = true;


            //retire une vie a chaque joueure
            Player1.GetDamage(1);
            Player2.GetDamage(1);

        }

        if (Timer > -1)
        {
            Timer = Timer + 1 * Time.deltaTime;
            Bouche.SetActive(false);
        }

        if (Timer > 1)
        {
            Bouche.SetActive(true);
            PasDeBouche.SetActive(false);
            NoomText.SetActive(false);
        }

        if (Rage == true)
        {
            RageMode();
        }

        if (Slap == true)
        {
            MonkeySlap();
        }

        if (RRRR == true)
        {
            CocoNotIeaten();
        }
    }

    public void FeedMonster()
    {
        
        FeedingBar.value = FeedingBar.value  + 5;
        Bouche.SetActive(false);
        PasDeBouche.SetActive(true);
        GrumyAudio.Play();
        Transform trans = listVignettePoint[Random.Range(0, listVignettePoint.Count - 1)];
        NoomText.transform.position = trans.position;
        NoomText.transform.rotation = trans.rotation;
        NoomText.transform.DOShakeRotation(0.5f,15,30);
        NoomText.SetActive(true);
        Timer = 0;
        SpawnerManager.GetComponent<SpawnersManager>().fruitsC -= 1;
    }

    public void MonkeySlap()
    {
        if (Timer2 > -1 )
        {
            Debug.Log("StartSlap");
            Timer2 = Timer2 + 1 * Time.deltaTime;
            
            if (!SLAPText.activeSelf)
            {
                SlapAudio.Play();
                Transform trans = listVignettePoint[Random.Range(0, listVignettePoint.Count - 1)];
                SLAPText.transform.position = trans.position;
                SLAPText.transform.rotation = trans.rotation;
                m_camera.transform.DOShakeRotation(0.2f, 10, 40);
                SLAPText.transform.DOShakeRotation(0.5f, 15, 30);
                SLAPText.SetActive(true);
                SlapSprite.SetActive(true);
            }
        }
        if (Timer2 > 0.5)
        {
            SLAPText.SetActive(false);
            SlapSprite.SetActive(false);
            Timer2 = 0;
            Debug.Log("ENDslap");
            Slap = false;
        }

        FeedingBar.value = 100;

    }

    public void RageMode()
    {
        Bouche.SetActive(false);
        if (Timer2 > -1)
        {
            Timer2 = Timer2 + 1 * Time.deltaTime;
            Bouche.SetActive(false);
            PasDeBouche.SetActive(true);
        }
        if (Timer2 > 1)
        {
            PasDeBouche.SetActive(false);
            Bouche.SetActive(true);
            
        }
        if (Timer2 > 2.5)
        {
            Timer2 = 0;
        }
    }

    public void CocoNotIeaten()
    {
        
        PasDeBouche.SetActive(false);
        RRRR = true;
        
        if (Timer3 > -1)
        {
            Timer3 = Timer3 + 1 * Time.deltaTime;

            if (!RRRRText.activeSelf)
            {
                RRRRAudio.Play();
                Transform trans = listVignettePoint[Random.Range(0, listVignettePoint.Count - 1)];
                RRRRText.transform.position = trans.position;
                RRRRText.transform.rotation = trans.rotation;
                RRRRText.transform.DOShakeRotation(0.5f, 15, 30);
                RRRRText.SetActive(true);
            }
        }

        if (Timer3 > 2)
        {
            RRRRText.SetActive(false);
            Timer3 = 0;
            RRRR = false;
        }
        
    }

    public void rrrrDamage()
    {
        FeedingBar.value = FeedingBar.value - 5;
    }
}
