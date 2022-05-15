using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Collections;

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
    private Transform m_stunPicture;
    
    [SerializeField]
    private Transform m_leftSlot;

    [SerializeField]
    private Transform m_currentCoco;

    private Transform m_currentTargetMonster;

    [SerializeField]
    public Score m_score;

    [SerializeField]
    private SpawnersManager m_spawnerManager;

    [SerializeField]
    private Monster m_monster;

    [SerializeField]
    private GameManager m_gameManager;

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
    private float m_speedMultiplier = 1;

    private Vector3 m_collideGravity;

    private int m_HP = 3;

    public bool m_pause;
    private bool m_rotateStun;

    private bool m_canJump = true;

    private Vector2 m_speed = new Vector2(0,0);

    private void Awake()
    {
        m_collideGravity.y = m_collideGravityValue;
        m_stunPicture.gameObject.SetActive(false);
    }

    private void Update()
    {
        //m_speed.x = Input.GetAxisRaw("Horizontal");

        if (m_pause) return;

        if (m_rotateStun) m_stunPicture.Rotate(Vector3.forward);
        

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

        if (Input.GetKey(KeyCode.Keypad6)) { MovePlayer(1); };
        if (Input.GetKeyUp(KeyCode.Keypad6)) { MovePlayer(0); };
        if (Input.GetKey(KeyCode.Keypad4)) { MovePlayer(-1); };
        if (Input.GetKeyUp(KeyCode.Keypad4)) { MovePlayer(0); };

        if (Input.GetKeyDown(KeyCode.Keypad8) && m_canJump) { JumpPlayer(); };

        if (Input.GetKeyDown(KeyCode.KeypadEnter)) { m_throwValue = Time.time; };
        if (Input.GetKeyUp(KeyCode.KeypadEnter)) { ThrowCoco(); };

        

    }

    private void ThrowCoco()
    {
        if (m_currentCoco == null) return;
        float timeValue = Time.time - m_throwValue;
        if (timeValue > 0.5f)
        {
            ProjectForMonster();
            m_throwValue = 0;
            return;
        }
        Debug.Log("Donner a manger au monstre" + timeValue);
        m_spawnerManager.GetComponent<SpawnersManager>().fruitsC -= 1;
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

        m_currentCoco.gameObject.SetActive(false);
        m_currentCoco = null;

        Rigidbody2D rbCoco = go.GetComponent<Rigidbody2D>();

        rbCoco.simulated = true;

        rbCoco.gravityScale = 0;

        rbCoco.AddRelativeForce(dirCoco * 100);

        m_score.AddScore();

    }

    private void ProjectForPlayer()
    {
        GameObject go = Instantiate(m_cocoLaunch);
        go.transform.position = m_currentCoco.position;

        m_currentCoco.gameObject.SetActive(false);
        m_currentCoco = null;

        go.GetComponent<Coco>().SetLayerThrowPlayer(gameObject.layer, transform);

        Rigidbody2D rbCoco = go.GetComponent<Rigidbody2D>();
        rbCoco.simulated = true;
        rbCoco.AddRelativeForce(m_projectionSpeed);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if((m_layerCoco.value & ( 1 << other.transform.gameObject.layer )) > 0 && m_currentCoco == null)
        {
            m_currentCoco = other.transform.GetComponent<GetCoco>().m_coco;
            m_currentCoco.parent = null;

            m_currentCoco.transform.GetComponent<CircleCollider2D>().enabled = false;

            m_currentCoco.transform.SetParent(transform);

            if (m_sprite.flipX)
            {
                m_currentCoco.transform.position = m_leftSlot.position;
            }

            m_currentCoco.transform.position = m_rightSlot.position;
            m_currentCoco.transform.localScale /= 2;
            Destroy(other.gameObject);
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

    public IEnumerator Stun()
    {
        m_rotateStun = true;
        m_stunPicture.gameObject.SetActive(true);
        m_speedMultiplier = 0.5f;
        m_jumpSpeed.y /= 2;
        yield return new WaitForSeconds(3f);
        m_rotateStun = false;
        m_stunPicture.gameObject.SetActive(false);
        m_speedMultiplier = 1;
        m_jumpSpeed.y *= 2;
    }

    private void MovePlayer(float p_dir)
    {
        m_speed.x = p_dir * m_SpeedMovement * m_speedMultiplier;

        
        if (p_dir == 0) return;

        m_projectionSpeed.x *= p_dir;

        if (p_dir > 0)
        {
            m_projectionSpeed.x = Mathf.Abs(m_projectionSpeed.x);

            m_sprite.flipX = true;
            SetPosCoco(m_rightSlot);
            return;
        }

        m_sprite.flipX = false;
        SetPosCoco(m_leftSlot);

        if (m_projectionSpeed.x < 0) return;
        m_projectionSpeed.x *= p_dir;
    }

    private void SetPosCoco(Transform p_trans)
    {
        if (m_currentCoco == null) return;
        m_currentCoco.position = p_trans.position;
    }

    public void GetDamage(int p_less)
    {
        m_HP -= p_less;

        if(m_HP <= 0)
        {
            Debug.Log("End Game");
            DisplayWinScreen();
        }
    }

    private void DisplayWinScreen()
    {
        m_pause = true;
        m_monster.canEat = false;

        m_gameManager.Display(1);
        //Display
    }

    private void JumpPlayer()
    {
        m_canJump = false;
        m_rb.velocity = m_jumpSpeed;
    }
}
