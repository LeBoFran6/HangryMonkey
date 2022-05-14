using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> m_listCanvas;

    public void Display(int canvas)
    {
        m_listCanvas[canvas].SetActive(true);
    }
}
