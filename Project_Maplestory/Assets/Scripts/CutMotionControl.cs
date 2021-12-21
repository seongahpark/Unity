using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutMotionControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3.6f);
    }

    // Update is called once per frame
    void Update()
    {
        GetPos();
    }

    private void GetPos()
    {
        Vector3 pos = Camera.main.transform.position;
        pos.z = 0;

        transform.position = pos;
    }
}
