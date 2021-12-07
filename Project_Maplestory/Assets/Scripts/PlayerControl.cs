using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    private float speed = 3.0f;
    private float jumpForce = 300f;
    private float checkRadius = 0.35f;

    private bool isTouchRight = false;
    private bool isTouchLeft = false;
    private bool isGround = false;

    private Rigidbody2D rb;

    [SerializeField] HandPersonalControl hpc;
    [SerializeField] DeathCountContrl dc;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * Time.deltaTime * speed;
        }
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(0, jumpForce));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "String" && hpc.isHit)
        {
            dc.redCnt++;
        }
    }
}
