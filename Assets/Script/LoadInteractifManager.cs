using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LoadInteractifManager : MonoBehaviour
{
    [SerializeField]
    private PlayerController m_playerController;

    [SerializeField]
    private Monster m_monster;

    [SerializeField]
    private SpawnersManager m_spawnManager;

    private int m_index;

    public void AddKeyPress()
    {
        m_index++;

        if(m_index == 8)
        {
            //Changement de scene
            m_spawnManager.Pause = false;
            m_monster.canEat = true;
            m_playerController.m_pause = false;
            transform.DOLocalMove(new Vector3(-820, 18, 10), 1);
        }
    }
}
