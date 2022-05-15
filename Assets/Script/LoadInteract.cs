using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadInteract : MonoBehaviour
{

    [SerializeField]
    private KeyCode m_letter;

    [SerializeField]
    private Sprite m_newSprite;

    [SerializeField]
    private LoadInteractifManager m_managerLoad;

    private bool m_done;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(m_letter) && !m_done && gameObject.activeSelf)
        {
            m_managerLoad.AddKeyPress();
            GetComponent<Image>().sprite = m_newSprite;
        }
    }
}
