using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameManager gm;
    private float Speed = 5.0f;
    private float rotSpeed = 90.0f;
    public Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        Vector3 pos = transform.position;
        Vector3 rot = transform.rotation.eulerAngles;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rot.y -= rotSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rot.y += rotSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * Speed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * Time.deltaTime * Speed);
        }

        body.MoveRotation(Quaternion.Euler(rot));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Finish")
        {
            gm.gameClear = true;
        }

        if(other.tag == "Item")
        {
            gm.GetItem();
        }
    }
}
