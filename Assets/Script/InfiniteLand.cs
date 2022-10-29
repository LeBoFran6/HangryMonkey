using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteLand : MonoBehaviour
{

    [SerializeField] private InfiniteLand m_otherTeleporter;

    public Transform newPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D rb = collision.transform.GetComponent<Rigidbody2D>();
        if (rb == null) return;
        rb.simulated = false;
        collision.transform.position = new Vector3(newPosition.position.x, rb.transform.position.y , newPosition.position.z);
        rb.simulated = true;
    }
}