using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasDeBouche : MonoBehaviour
{
    [SerializeField]
    private LayerMask m_playerlayer;

    [SerializeField]
    private LayerMask m_playerlayer2;

    public GameObject MonsterScript;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if((m_playerlayer.value & (1 << other.gameObject.layer)) > 0 || (m_playerlayer2.value & (1 << other.gameObject.layer)) > 0) return;

        Debug.Log(other.name);
        Debug.Log("CocoNotIeaten");

        Destroy(other.transform.gameObject);

        MonsterScript.GetComponent<Monster>().CocoNotIeaten();
        MonsterScript.GetComponent<Monster>().rrrrDamage();
        
    }
}
