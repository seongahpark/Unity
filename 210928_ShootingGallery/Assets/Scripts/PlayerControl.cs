using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab = null;
    public GameManager gm;
    public Text hpText;
    public int score = 0;
    public int HP = 3;
    private int maxHP = 5;
    public bool isHittable = true;
    [SerializeField] private float moveSpeed = 8.0f;
    
    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space)) Attack();
    }

    private void Move()
    {
        //플레이어가 맵 밖으로 튀어나가는 것을 막기 위함
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0.1f) pos.x = 0.1f;
        if (pos.x > 0.9f) pos.x = 0.9f;
        transform.position = Camera.main.ViewportToWorldPoint(pos);

        //플레이어 조작 (좌, 우)
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }

    private void Attack()
    {
        //총알과 플레이어가 같은 위치에있으면 충돌때문에 플레이어가 밀려남
        //총알 위치를 플레이어 현재 위치보다 좀 더 위에 생성되도록 함
        Vector3 pos = this.transform.position;
        pos.y += 0.5f;

        GameObject bullet = Instantiate(
            bulletPrefab, pos, Quaternion.identity);
    }

    IEnumerator blink()
    {
        SpriteRenderer sr = this.GetComponent<SpriteRenderer>();
        for (int i = 0; i < 10; i++)
        {
            sr.enabled = !sr.enabled;
            yield return new WaitForSeconds(0.1f);
        }

        isHittable = true;
    }
    public void playerHit()
    {
        if (isHittable == true)
        {
            isHittable = false;
            HP--;
            hpText.text = "X " + HP.ToString();
            if (HP <= 0)
                 gm.onGameOver();
            StartCoroutine("blink");
        }
    }

    public void getHP()
    {
        HP++;
        if (HP >= maxHP) HP = maxHP;
        hpText.text = "X " + HP.ToString();
    }
}
