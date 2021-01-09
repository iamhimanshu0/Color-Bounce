using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Ball : MonoBehaviour {

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private float jumpForce;
    public float gravity = 1f;
    public float jumpHeight;
    public GameObject jumpEffect;
    public GameObject deadEffect;
    public GameObject stairJumpEffect;

    bool isDead = false;
    bool isStart = false;

    Vector2 touchPosition;
    Vector2 playerPosition;
    Vector2 dragPosition;

    public TextMeshProUGUI TapToPlay;

    stairManager stairMan;

    bool isDraging;

    private void Awake()
    {
        waitToTouch();
        Time.timeScale = 0.0f;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stairMan = GameObject.Find("Stair").GetComponent<stairManager>();
    }


    private void Update()
    {
        waitToTouch();
        //if (!isStart) return;
        if (isDead) return;
        if (!isStart) return;
        GetInput();
        MovePlayer();
        AddGravityToPlayer();
        DeadCheck();

    }

    private void waitToTouch()
    {
        if (!isStart)
        {
            if(Input.GetMouseButtonDown(0))
            {
                isStart = true;
                Time.timeScale = 1.0f;
                TapToPlay.enabled = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag=="Wall")
        {
            if (rb.velocity.y <= 0)
            {
                Jump();
                Addscore();
                Effect(collision);
                ChangeBackgroundColor(collision);
                DestroyAndMakeStair(collision);
            }
                
        }
    }

    void GetInput()
    {
        if(Input.GetMouseButtonDown(0))
        {
            isDraging = true;
            touchPosition = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            playerPosition = transform.position;
        }
       else if(Input.GetMouseButtonUp(0))
        {
            isDraging = false;
        }
    }

    void MovePlayer()
    {
        if(isDraging==true)
        {
            dragPosition = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            transform.position = new Vector2(playerPosition.x + (dragPosition.x - touchPosition.x), transform.position.y);
        }

        if(transform.position.x < -4.25f)
        {
            transform.position = new Vector2(-4.25f, transform.position.y);
        }
        if(transform.position.x > 4.25f)
        {
            transform.position = new Vector2(4.25f, transform.position.y);
        }
    }

    private void Jump()
    {
        jumpForce = gravity * jumpHeight;
        rb.velocity = new Vector2(0, jumpForce);
        gravity += 0.01f;
       
    }

    public void DestroyAndMakeStair(Collider2D stair)
    {
        Destroy(stair.gameObject);
        stairMan.MakeNewStair();
    }

    void Addscore()
    {
        GameObject.Find("GameManager").GetComponent<scoreManager>().addScore(1);
    }

    void Effect(Collider2D stair)
    {
        GameObject effect = Instantiate(jumpEffect, transform.position, Quaternion.identity) as GameObject;
        effect.transform.SetParent(transform);
        Destroy(effect, 0.4f);

        /*GameObject stairEffect = Instantiate(stairJumpEffect, transform.position, Quaternion.identity);
        stairEffect.transform.SetParent(transform);
        stairEffect.transform.localScale = new Vector2(stair.transform.position.x, stair.transform.position.y);
        Destroy(stairEffect, 1f);*/
    }

    private void AddGravityToPlayer()
    {
        rb.velocity = new Vector2(0, rb.velocity.y - (gravity * gravity));
    }

    private void DeadCheck()
    {
        if(!isDead && transform.position.y < Camera.main.transform.position.y - 10 )
        {
            isDead = true;
            Debug.Log("Dead");
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
            GameObject effect = Instantiate(deadEffect, new Vector2(transform.position.x,transform.position.y+3), Quaternion.identity) as GameObject;
            effect.transform.SetParent(transform);
            Destroy(effect, 1f);
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            GameObject.Find("GameManager").GetComponent<GameManager>().GameOver();
        }
    }

    void ChangeBackgroundColor(Collider2D stair)
    {
        if(Camera.main.backgroundColor == stair.GetComponent<SpriteRenderer>().color)
        {
            Camera.main.backgroundColor = Color.HSVToRGB(0.8f, 0.2f, 0.4f);
        }
        else
        {
            Camera.main.backgroundColor = stair.GetComponent<SpriteRenderer>().color;
        }
        
    }

   
}
