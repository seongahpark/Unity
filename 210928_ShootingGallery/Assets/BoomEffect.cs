using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomEffect : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, 0.31f);
    }
}
