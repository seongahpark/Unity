using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGold : MonoBehaviour
{
    public PlayerControl pc;
    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.left * Time.deltaTime * Time.timeScale;
        if (this.transform.position.x <= -10)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            pc.score += 50;
            //collision.GetComponent<PlayerControl>().hitGold();
            Destroy(this.gameObject);
        }
    }
}
