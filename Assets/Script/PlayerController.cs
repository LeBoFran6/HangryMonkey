using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private LayerMask m_layerSol;

    [SerializeField]
    private LayerMask m_layerCoco;

    [SerializeField]
    private Rigidbody2D m_rb;

    [SerializeField]
    private SpriteRenderer m_sprite;
    
    [SerializeField]
    private Transform m_rightSlot;
    
    [SerializeField]
    private Transform m_leftSlot;

    [SerializeField]
    private Transform m_currentCoco;

    [SerializeField]
    private bool m_isPlayerOne;

    [SerializeField]
    private float m_SpeedMovement;

    [SerializeField]
    private Vector2 m_jumpSpeed;

    [SerializeField]
    private float m_collideGravityValue;

    private Vector3 m_collideGravity;


    private bool m_canJump = true;

    private Vector2 m_speed = new Vector2(0,0);

    private void Awake()
    {
        m_collideGravity.y = m_collideGravityValue;
    }

    private void Update()
    {
        //m_speed.x = Input.GetAxisRaw("Horizontal");
        
        if (m_isPlayerOne)
        {
            if (Input.GetKey(KeyCode.Q)) { MovePlayer(-1); };
            if (Input.GetKeyUp(KeyCode.Q)) { MovePlayer(0); };
            if (Input.GetKey(KeyCode.D)) { MovePlayer(1); };
            if (Input.GetKeyUp(KeyCode.D)) { MovePlayer(0); };

            if (Input.GetKeyDown(KeyCode.Z) && m_canJump) { JumpPlayer(); };
            return;
        }

        if (Input.GetKey(KeyCode.RightArrow)) { MovePlayer(1); };
        if (Input.GetKeyUp(KeyCode.RightArrow)) { MovePlayer(0); };
        if (Input.GetKey(KeyCode.LeftArrow)) { MovePlayer(-1); };
        if (Input.GetKeyUp(KeyCode.LeftArrow)) { MovePlayer(0); };

        if (Input.GetKeyDown(KeyCode.UpArrow) && m_canJump) { JumpPlayer(); };


        if (!m_canJump)
        {
            transform.position -= m_collideGravity * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if((m_layerSol.value & ( 1 << other.transform.gameObject.layer )) > 0)
        {
            m_canJump = true;
        }
        if((m_layerCoco.value & ( 1 << other.transform.gameObject.layer )) > 0 && m_currentCoco == null)
        {
            m_currentCoco = other.transform;

            other.transform.GetComponent<CircleCollider2D>().enabled = false;

            other.transform.SetParent(transform);

            if (m_sprite.flipX)
            {
                other.transform.position = m_leftSlot.position;
            }

            other.transform.position = m_rightSlot.position;
        }
    }

    private void FixedUpdate()
    {
        m_rb.AddForce(m_speed * Time.fixedDeltaTime, ForceMode2D.Impulse);
    }

    private void MovePlayer(float p_dir)
    {
        m_speed.x = p_dir * m_SpeedMovement;
        if (p_dir == 0) return;

        if (p_dir > 0)
        {
            m_sprite.flipX = false;
            SetPosCoco(m_rightSlot);
            return;
        }

        m_sprite.flipX = true;
        SetPosCoco(m_leftSlot);

    }

    private void SetPosCoco(Transform p_trans)
    {
        if (m_currentCoco == null) return;
        m_currentCoco.position = p_trans.position;
    }

    private void JumpPlayer()
    {
        m_canJump = false;
        m_rb.velocity = m_jumpSpeed;
    }
}
