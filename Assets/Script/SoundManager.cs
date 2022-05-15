using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    List<AudioSource> m_listAudio;

    private void Awake()
    {
        if (m_listAudio.Count != 0) m_listAudio[0].Play();
    }
}
