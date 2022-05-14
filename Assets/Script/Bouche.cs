using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouche : MonoBehaviour
{

    public GameObject MonsterScript;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other);
        MonsterScript.GetComponent<Monster>().FeedMonster();
        Debug.Log("NOOOM");
    }
}
