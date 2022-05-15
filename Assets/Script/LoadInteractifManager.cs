using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LoadInteractifManager : MonoBehaviour
{
    [SerializeField]
    private Timer m_timer;

    [SerializeField]
    private PlayerController m_playerController;

    [SerializeField]
    private PlayerController m_playerController2;

    [SerializeField]
    private Monster m_monster;

    [SerializeField]
    private SpawnersManager m_spawnManager;
    [SerializeField]
    private SpawnersManager m_spawnManager2;

    [SerializeField]
    private Transform m_uiMonster;

    private int m_index;

    public void AddKeyPress()
    {
        m_index++;

        if (m_index == 8)
        {
            //Changement de scene
            transform.DOLocalMove(new Vector3(-820, 18, 10), 1);
            m_uiMonster.DOLocalMove(new Vector3(0, 0, 0), 1);
            StartCoroutine(LaunchGame());
        }
    }

    IEnumerator LaunchGame()
    {
        m_playerController.m_pause = false;
        m_playerController.m_rb.simulated = true;
        m_playerController2.m_pause = false;
        m_playerController2.m_rb.simulated = true;

        yield return new WaitForSeconds(2f);
        m_timer.timerIsRunning = true;
        m_spawnManager.Pause = false;
        m_spawnManager2.Pause = false;
        m_monster.canEat = true;
        
    }
}   