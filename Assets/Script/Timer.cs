using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 180;
    public bool timerIsRunning = false;
    public GameManager gameManager;
    public TextMeshProUGUI timeText;
    public Monster m_monster;

    public AudioSource m_globalMusic;
    public AudioSource m_speedMusic;


    private void Start()
    {
        //timerIsRunning = true;
        m_globalMusic.Play();
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= UnityEngine.Time.deltaTime;
                DisplayTime(timeRemaining);
            }

            if (timeRemaining > 29.5f && timeRemaining < 30.5f)
            {
                if (!m_speedMusic.isPlaying)
                {
                    m_speedMusic.Play();
                }
                m_monster.Rage = true;
            }

            if (timeRemaining < 0)
            {
                Debug.Log("Time has run out!");
                timeText.text = "Le Singe est rassasié!";
                gameManager.Display(1);
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

