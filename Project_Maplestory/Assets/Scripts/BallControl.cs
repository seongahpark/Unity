using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private float ballSpeed = 3.5f;
    private bool isLeft = true;
    // Start is called before the first frame update
    void Start()
    {
        Quaternion rot = transform.rotation;
        if (rot == Quaternion.Euler(0, 180, 0))
        {
            isLeft = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isLeft)
            transform.position += Vector3.left * Time.deltaTime * ballSpeed;
        else
            transform.position += Vector3.right * Time.deltaTime * ballSpeed;
        Destroy(gameObject, 5.0f);
    }
}
