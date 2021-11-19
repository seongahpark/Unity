using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    static PlayerControl pc = null;
    public GameManager gm;
    public Text hpText;
    //public GameObject explosionPrefab;
    public int HP = 3;
    public bool isHittable = true;
    public float moveSpeed = 10.0f;
    public bool isFever = false;
    public float feverTime = 20.0f;

    public int score = 0;
    private void Awake()
    {
        if(pc == null)
        {
            pc = this;
        }
        gm.Ready();
    }
    // Start is called before the first frame update
    void Start()
    {
        gm.gameStart();
        gm.onGameRestart();

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (isFever && !gm.isGameOver) Fever();
        //if (!isFever) Time.timeScale = 2;
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.DownArrow))
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
    }

    IEnumerator blink()
    {
        SpriteRenderer sr = this.GetComponent<SpriteRenderer>();
        for(int i=0; i<60; i++)
        {
            sr.enabled = !sr.enabled;
            yield return new WaitForSeconds(0.1f);
        }

        isHittable = true;
    }

    public void playerHit()
    {
        if(isHittable == true)
        {
            //Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            isHittable = false;
            HP--;
            hpText.text = "x " + HP.ToString();
            if (HP <= 0)
                gm.onGameOver();
            StartCoroutine("blink");
        }
    }

    public void hitRed()
    {
        StopCoroutine("blink");
        this.GetComponent<SpriteRenderer>().enabled = true;
        isHittable = false;
        StartCoroutine("blink");
    }

    public void Fever()
    {
        feverTime -= Time.deltaTime;
        if (gm.isGameOver) Time.timeScale = 0;
        if(feverTime <= 0)
        {
            isFever = false;
            Time.timeScale = 2;
            feverTime += 20.0f;
        }
        else Time.timeScale = 4;
    }

    static public PlayerControl getIns
    {
        get { return pc; }
    }
}
