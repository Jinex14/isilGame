using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool inGame = true;
    public static PlayerMove instance;
    private float speed = 4;
    private Transform groundCheck;
    public LayerMask layer;
    private bool isGrounded;
    public float jumpForce = 4;
    private Animator anim;
    public GameObject bullet;
    public Transform bulletTransform;
    private List<GameObject> balas = new List<GameObject>();
    private bool shootTime = true;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        groundCheck = GameObject.Find("GroundCheck").GetComponent<Transform>();


    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.Linecast(transform.position, groundCheck.position, layer);
        anim.SetBool("jump", !isGrounded);

        if (Input.GetKey("f") && shootTime)
        {
            shootTime = false;
            anim.SetBool("shoot", true);
            GameObject obj = getBala();
            obj.transform.position = bulletTransform.position;
            obj.transform.rotation = bulletTransform.rotation;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        if (inGame)
        {
            //rb.velocity = new Vector2(dir * 4, (rb.velocity.y < -15) ? -15 : rb.velocity.y);

            rb.velocity = new Vector2(1 * speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }

    public void endShoot()
    {
        anim.SetBool("shoot", false);
        shootTime = true;
    }

    public GameObject getBala()
    {
        for (int i = 0; i < balas.Count; i++)
        {
            if (!balas[i].activeInHierarchy)
            {
                balas[i].SetActive(true);
                return balas[i];
            }
        }
        GameObject obj = Instantiate(bullet) as GameObject;
        balas.Add(obj);
        return obj;
    }
}
