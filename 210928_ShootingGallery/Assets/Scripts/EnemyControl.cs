using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyControl : MonoBehaviour
{
    public PlayerControl pc;
    public GameObject explosionPrefab;
    public GameObject blue;
    public GameObject green;
    public GameObject purple;

    Blue b = new Blue();
    Green g = new Green();
    Purple p = new Purple();

    [SerializeField] private int enemySpeed = 3;

    // Start is called before the first frame update
    void Start()
    {
        b.enemyHP = 1;
        g.enemyHP = 3;
        p.enemyHP = 5;

        b.enemyScore = 5;
        g.enemyScore = 20;
        p.enemyScore = 50;

        pc = GameObject.FindWithTag("Player").GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.down * Time.deltaTime * enemySpeed;
        Destroy(this.gameObject, 5.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.gameObject == blue) b.hitEnemy();
        if (this.gameObject == green) g.hitEnemy();
        if (this.gameObject == purple) p.hitEnemy();

        if(collision.transform.tag != "Player")
        {
            if (b.hpChk() || g.hpChk() || p.hpChk())
            {
                if (b.hpChk()) pc.score += b.enemyScore;
                if (g.hpChk()) pc.score += g.enemyScore;
                if (p.hpChk()) pc.score += p.enemyScore + p.randomScore();
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }

        if (collision.transform.tag == "Player")
        {
            if (pc.isHittable == true)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
            pc.playerHit();
        }


    }
}
