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

    [SerializeField] private bool isStun = false;
    public bool playerHit = false;
    private Rigidbody2D rb;

    [SerializeField] HandPersonalControl[] hpc = new HandPersonalControl[7];
    [SerializeField] DeathCountContrl dc;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        dc = GameObject.FindWithTag("DeathCount").GetComponent<DeathCountContrl>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isStun) PlayerMove();
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
        // hpc.isHit
        if (collision.gameObject.tag == "String" && playerHit)
        {
            dc.redCnt++;
            dc.DCWhiteToRed();
            StartCoroutine(StunState());
        }
    }

    IEnumerator StunState()
    {
        isStun = true;
        yield return new WaitForSeconds(2.0f);
        isStun = false;
    }
}
