using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameManager gm;
    private float playerSpeed = 7.0f;
    private bool canWarp = true;
    private float canWarpTime = 1.0f;
    Renderer playerRenderer;
    Color playerBasicColor;
    // Start is called before the first frame update
    void Start()
    {
        playerRenderer = gameObject.GetComponent<Renderer>();
        playerBasicColor = playerRenderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        if (gm.isFever) PlayerIsFever();
        if (!gm.isFever) PlayerIsNotFever();
    }

    private void PlayerMove()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * Time.deltaTime * playerSpeed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * Time.deltaTime * playerSpeed;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.forward * Time.deltaTime * playerSpeed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.back * Time.deltaTime * playerSpeed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Warp" && canWarp)
        {
            Vector3 pos = this.transform.position;
            pos.z *= -1;
            transform.position = pos;
            canWarp = false;
            StartCoroutine(WaitForWarp());
        }

        if(other.tag == "FeverItem")
        {
            gm.isFever = true;
            StopCoroutine(gm.IsFeverTime());
            StartCoroutine(gm.IsFeverTime());
        }
    }
    IEnumerator WaitForWarp()
    {
        yield return new WaitForSeconds(canWarpTime);
        canWarp = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy" && !gm.isFever)
        {
            gm.gameOver = true;
        }
    }

    private void PlayerIsFever()
    {
        playerRenderer.material.color = Color.cyan;
    }

    private void PlayerIsNotFever()
    {
        playerRenderer.material.color = playerBasicColor;
    }
}
