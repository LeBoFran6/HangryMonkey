using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> m_listCanvas;

    [SerializeField]
    private PlayerController m_p1;

    [SerializeField]
    private PlayerController m_p2;

    [SerializeField]
    private GameObject m_P1Win;
    [SerializeField]
    private GameObject m_P2Win;
    [SerializeField]
    private GameObject m_Draw;

    [SerializeField]
    private AudioSource m_win;

    [SerializeField]
    private AudioSource m_draw;

    public void Display(int canvas)
    {
        m_listCanvas[canvas].SetActive(true);

        if(canvas == 1)
        {
            if(m_p1.m_score.m_currentPoint > m_p2.m_score.m_currentPoint)
            {
                m_win.Play();
                m_P1Win.SetActive(true);
                return;
            }

            if(m_p1.m_score.m_currentPoint < m_p2.m_score.m_currentPoint)
            {
                m_win.Play();
                m_P2Win.SetActive(true);
                return;
            }
            m_draw.Play();
            m_Draw.SetActive(true);
        }
    }
}
