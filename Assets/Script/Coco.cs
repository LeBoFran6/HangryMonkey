using System.Collections;
using UnityEngine;

public class Coco : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D m_rb;
    [SerializeField]
    private SpriteRenderer m_spriteRenderer;

    [SerializeField]
    private Sprite m_sprite;

    [SerializeField]
    private LayerMask m_layerCoco;
    [SerializeField]
    private LayerMask m_layerPlayer1;

    [SerializeField]
    private LayerMask m_layerPlayer2;
    private LayerMask m_layerOtherPlayer;
    [SerializeField]
    private float m_waitHideValue;

    bool m_throw;

    private WaitForSeconds m_waitHide;

    private void Awake()
    {
        m_waitHide = new WaitForSeconds(m_waitHideValue);
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((m_layerOtherPlayer.value != collision.transform.gameObject.layer) && m_throw)
        {
            Debug.Log(m_layerOtherPlayer.value + " " + collision.transform.gameObject.layer);
            Explosion();
        }
    }

    public void SetLayerThrowPlayer(int p_layer)
    {
        m_throw = true;
        m_layerOtherPlayer = p_layer;
    }

    private void Explosion()
    {
        m_spriteRenderer.sprite = m_sprite;
        m_rb.simulated = false;

        StartCoroutine(WaitHide());
    }

    IEnumerator WaitHide()
    {
        yield return m_waitHide;

        Destroy(gameObject);
    }
}
