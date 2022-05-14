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
    private LayerMask m_layerTeleport;
    [SerializeField]
    private LayerMask m_layerPlayer1;

    [SerializeField]
    private LayerMask m_layerPlayer2;
    private LayerMask m_layerOtherPlayer;
    private Transform m_otherPlayer;
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
        if((m_layerOtherPlayer.value != collision.transform.gameObject.layer) && m_throw && (m_layerTeleport.value & (1 << collision.transform.gameObject.layer)) <= 0)
        {
            Explosion();
        }

        if (m_otherPlayer != null && m_otherPlayer != collision.transform)
        {
            
            PlayerController pc = collision.transform.GetComponent<PlayerController>();
            if (pc == null) return;
            pc.m_score.RemovePoint();
            StartCoroutine(pc.Stun());
        }
    }

    public void SetLayerThrowPlayer(LayerMask p_layer, Transform p_trans)
    {
        m_throw = true;
        m_layerOtherPlayer.value = p_layer.value;
        m_otherPlayer = p_trans;
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
