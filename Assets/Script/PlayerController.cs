using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private LayerMask m_layerSol;

    [SerializeField]
    private LayerMask m_layerCoco;

    [SerializeField]
    private Rigidbody2D m_rb;

    [SerializeField]
    private GameObject m_cocoLaunch;

    [SerializeField]
    private SpriteRenderer m_sprite;
    
    [SerializeField]
    private Transform m_rightSlot;
    
    [SerializeField]
    private Transform m_leftSlot;

    [SerializeField]
    private Transform m_currentCoco;
    private Transform m_currentTargetMonster;

    [SerializeField]
    private List<Transform> m_listPointEatMonster;

    [SerializeField]
    private bool m_isPlayerOne;

    [SerializeField]
    private float m_SpeedMovement;

    [SerializeField]
    private Vector2 m_projectionSpeed;

    [SerializeField]
    private Vector2 m_jumpSpeed;

    [SerializeField]
    private float m_collideGravityValue;

    private float m_throwValue;

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

            if (Input.GetKeyDown(KeyCode.Space)) { m_throwValue = Time.time; };
            if (Input.GetKeyUp(KeyCode.Space)) { ThrowCoco(); };
            return;
        }

        if (Input.GetKey(KeyCode.RightArrow)) { MovePlayer(1); };
        if (Input.GetKeyUp(KeyCode.RightArrow)) { MovePlayer(0); };
        if (Input.GetKey(KeyCode.LeftArrow)) { MovePlayer(-1); };
        if (Input.GetKeyUp(KeyCode.LeftArrow)) { MovePlayer(0); };

        if (Input.GetKeyDown(KeyCode.UpArrow) && m_canJump) { JumpPlayer(); };

        if (Input.GetKeyDown(KeyCode.KeypadEnter)) { m_throwValue = Time.time; };
        if (Input.GetKeyUp(KeyCode.KeypadEnter)) { ThrowCoco(); };

    }

    private void ThrowCoco()
    {
        if (m_currentCoco == null) return;
        float timeValue = Time.time - m_throwValue;
        if (timeValue > 1)
        {
            ProjectForMonster();
            m_throwValue = 0;
            return;
        }
        Debug.Log("Donner a manger au monstre" + timeValue);

        ProjectForPlayer();

        m_throwValue = 0;
    }

    private void ProjectForMonster()
    {
        List<Transform> m_currentTargetMonsterList = new List<Transform>();
        Transform transformCoco = m_listPointEatMonster[Random.Range(0, m_listPointEatMonster.Count - 1)];
        
        m_currentCoco.parent = null;

        Vector3 dirCoco = (transformCoco.position - m_currentCoco.position).normalized;
        
        GameObject go = Instantiate(m_cocoLaunch);
        go.transform.position = m_currentCoco.position;

        Rigidbody2D rbCoco = go.GetComponent<Rigidbody2D>();

        rbCoco.simulated = true;

        rbCoco.gravityScale = 0;

        rbCoco.AddRelativeForce(dirCoco * 100);

    }

    private void ProjectForPlayer()
    {
        GameObject go = Instantiate(m_cocoLaunch);
        go.transform.position = m_currentCoco.position;

        m_currentCoco.gameObject.SetActive(false);
        m_currentCoco = null;

        go.GetComponent<Coco>().SetLayerThrowPlayer(gameObject.layer);

        Rigidbody2D rbCoco = go.GetComponent<Rigidbody2D>();
        rbCoco.simulated = true;
        rbCoco.AddRelativeForce(m_projectionSpeed);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        
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
            other.transform.localScale /= 2;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_canJump = true;
    }

    private void FixedUpdate()
    {
        m_rb.AddForce(m_speed * Time.fixedDeltaTime, ForceMode2D.Impulse);
    }

    private void MovePlayer(float p_dir)
    {
        m_speed.x = p_dir * m_SpeedMovement;

        
        if (p_dir == 0) return;

        m_projectionSpeed.x *= p_dir;

        if (p_dir > 0)
        {
            m_projectionSpeed.x = Mathf.Abs(m_projectionSpeed.x);

            m_sprite.flipX = false;
            SetPosCoco(m_rightSlot);
            return;
        }


        m_sprite.flipX = true;
        SetPosCoco(m_leftSlot);

        if (m_projectionSpeed.x < 0) return;
        m_projectionSpeed.x *= p_dir;
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
