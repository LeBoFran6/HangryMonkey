using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasDeBouche : MonoBehaviour
{
    public GameObject MonsterScript;

    private void OnTriggerEnter2D(Collider2D other)
    {
        MonsterScript.GetComponent<Monster>().CocoNotIeaten();
        MonsterScript.GetComponent<Monster>().rrrrDamage();
        Debug.Log("CocoNotIeaten");
    }
}
