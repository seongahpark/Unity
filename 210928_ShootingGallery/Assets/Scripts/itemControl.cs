using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemControl : MonoBehaviour
{
    public PlayerControl pc;
    [SerializeField] private int itemSpeed = 3;
    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.FindWithTag("Player").GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.down * Time.deltaTime * itemSpeed;
        Destroy(this.gameObject, 5.0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            pc.getHP();
            Destroy(this.gameObject);
        }
    }
}
