using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteLand : MonoBehaviour
{

    [SerializeField] private InfiniteLand m_otherTeleporter;

    public Transform newPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.GetComponent<Rigidbody2D>().simulated = false;
        collision.transform.position = newPosition.position;
        collision.transform.GetComponent<Rigidbody2D>().simulated = true;
    }
}
