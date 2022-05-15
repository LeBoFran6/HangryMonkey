using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class Score : MonoBehaviour
{
    [SerializeField, Tooltip("")]
    public float m_upPoint;

    [SerializeField, Tooltip("le nombre de point que le joueur gagne avec les ")]
    public float m_downPoint;

    [SerializeField]
    private TextMeshProUGUI m_textMeshPro;

    public float m_currentPoint = 0;

    private void Awake()
    {
        UpdateText();
    }

    public void RemovePoint()
    {
        m_currentPoint -= m_downPoint;

        if(m_currentPoint < 0)
        {
            m_currentPoint = 0;
        }
        UpdateText();
    }

    public void AddScore()
    {
        m_currentPoint += m_upPoint;
        UpdateText();
    }

    public void ResetScore()
    {
        m_currentPoint = 0;
        UpdateText();
    }

    private void UpdateText()
    {
        //m_textMeshPro.text = m_currentPoint.ToString();

        m_textMeshPro.transform.localScale = Vector3.one;
        m_textMeshPro.transform.DOPunchScale(Vector3.one * 1.5f, 0.2f);
        //m_textMeshPro.text.DOText(m_currentPoint.ToString(), 0.2f);
        
    }
}
